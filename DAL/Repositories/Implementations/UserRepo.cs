using System;
using System.Collections.Generic;
using DAL.Providers;
using DAL.Repositories.Interfaces;
using DTO;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Repositories.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly DbConnectionManager _connManager;

        public UserRepo()
        {
            _connManager = new DbConnectionManager();
        }

        public List<AppUserDTO> GetAllUsers(string currentUsername, string currentPassword)
        {
            var list = new List<AppUserDTO>();

            // Câu SQL kết hợp bảng của ứng dụng và Từ điển dữ liệu của Oracle
            string sql = @"
                        SELECT a.USERNAME, a.FULLNAME, a.EMAIL, a.CREATED_DATE,
                               u.ACCOUNT_STATUS, u.DEFAULT_TABLESPACE, u.TEMPORARY_TABLESPACE, u.PROFILE,
                               q.MAX_BYTES
                        FROM ADMIN_BM.APP_USERS a
                        JOIN DBA_USERS u ON a.USERNAME = u.USERNAME
                        LEFT JOIN DBA_TS_QUOTAS q ON a.USERNAME = q.USERNAME AND u.DEFAULT_TABLESPACE = q.TABLESPACE_NAME";

            // Sử dụng kết nối ngầm định của ADMIN để luôn đọc được view DBA_USERS
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dto = new AppUserDTO
                        {
                            Username = reader["USERNAME"].ToString(),
                            FullName = reader["FULLNAME"].ToString(),
                            Email = reader["EMAIL"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CREATED_DATE"]),

                            // Lấy Tablespace hiện tại
                            DefaultTablespace = reader["DEFAULT_TABLESPACE"].ToString(),
                            TempTablespace = reader["TEMPORARY_TABLESPACE"].ToString(),
                            // Profile
                            ProfileName = reader["PROFILE"].ToString(),

                            IsLocked = reader["ACCOUNT_STATUS"].ToString().Contains("LOCKED")
                        };

                        string maxBytes = reader["MAX_BYTES"].ToString();
                        if (string.IsNullOrEmpty(maxBytes))
                            dto.QuotaAmount = "";
                        else if (maxBytes == "-1")
                            dto.QuotaAmount = "UNLIMITED";
                        else
                        {
                            long bytes = Convert.ToInt64(maxBytes);
                            long mb = bytes / (1024 * 1024); // Đổi từ byte sang MB
                            dto.QuotaAmount = mb.ToString() + "M";
                        }

                        list.Add(dto);
                    }
                }
            }
            return list;
        }

        public bool CreateUser(AppUserDTO user, string currentUsername, string currentPassword, string hash, string salt)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    bool isOracleUserCreated = false;

                    try
                    {
                        string accountStatus = user.IsLocked ? "ACCOUNT LOCK" : "ACCOUNT UNLOCK";

                        string sqlCreate = $"CREATE USER {user.Username} IDENTIFIED BY \"{user.RawPassword}\" " +
                                           $"DEFAULT TABLESPACE {user.DefaultTablespace} " +
                                           $"TEMPORARY TABLESPACE {user.TempTablespace} " +
                                           $"PROFILE {user.ProfileName} " +
                                           $"{accountStatus}";
                        using (var cmdCreate = new OracleCommand(sqlCreate, conn)) { cmdCreate.ExecuteNonQuery(); }

                        isOracleUserCreated = true;

                        if (!string.IsNullOrWhiteSpace(user.QuotaAmount) && !string.IsNullOrWhiteSpace(user.DefaultTablespace))
                        {
                            string sqlQuota = $"ALTER USER {user.Username} QUOTA {user.QuotaAmount} ON {user.DefaultTablespace}";
                            using (var cmdQuota = new OracleCommand(sqlQuota, conn)) { cmdQuota.ExecuteNonQuery(); }
                        }

                        string sqlInsert = "INSERT INTO ADMIN_BM.APP_USERS (USERNAME, FULLNAME, EMAIL, CREATED_DATE, PASSWORD_HASH, SALT) " +
                                           "VALUES (:usr, :fname, :email, SYSDATE, :hash, :salt)";
                        using (var cmdInsert = new OracleCommand(sqlInsert, conn))
                        {
                            cmdInsert.Parameters.Add(new OracleParameter("usr", user.Username.ToUpper()));
                            cmdInsert.Parameters.Add(new OracleParameter("fname", user.FullName));
                            cmdInsert.Parameters.Add(new OracleParameter("email", user.Email));
                            cmdInsert.Parameters.Add(new OracleParameter("hash", hash));
                            cmdInsert.Parameters.Add(new OracleParameter("salt", salt));

                            cmdInsert.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        if (isOracleUserCreated)
                        {
                            try
                            {
                                string sqlDrop = $"DROP USER {user.Username} CASCADE";
                                using (var cmdDrop = new OracleCommand(sqlDrop, conn)) { cmdDrop.ExecuteNonQuery(); }
                            }
                            catch
                            {
                            }
                        }

                        throw; 
                    }
                }
            }
        }

        public bool UpdateUser(AppUserDTO user, string currentUsername, string currentPassword, string hash, string salt, bool updatePassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string accountStatus = user.IsLocked ? "ACCOUNT LOCK" : "ACCOUNT UNLOCK";
                        string sqlAlter = $"ALTER USER {user.Username} {accountStatus} ";

                        // 2. Chỉ đổi mật khẩu nếu có nhập
                        if (updatePassword)
                        {
                            sqlAlter += $"IDENTIFIED BY \"{user.RawPassword}\" ";
                        }

                        // 3. Chỉ đổi Default Tablespace nếu không bị bỏ trống
                        if (!string.IsNullOrWhiteSpace(user.DefaultTablespace))
                        {
                            sqlAlter += $"DEFAULT TABLESPACE {user.DefaultTablespace} ";
                        }

                        // 4. Chỉ đổi Temp Tablespace nếu không bị bỏ trống
                        if (!string.IsNullOrWhiteSpace(user.TempTablespace))
                        {
                            sqlAlter += $"TEMPORARY TABLESPACE {user.TempTablespace} ";
                        }
                        if (!string.IsNullOrWhiteSpace(user.ProfileName))
                        {
                            sqlAlter += $"PROFILE {user.ProfileName} ";
                        }

                        // Chạy lệnh ALTER USER
                        using (var cmdAlter = new OracleCommand(sqlAlter, conn)) { cmdAlter.ExecuteNonQuery(); }

                        // 5. Lệnh Quota chỉ chạy khi người dùng CÓ nhập Quota VÀ CÓ chọn Default Tablespace
                        if (!string.IsNullOrWhiteSpace(user.QuotaAmount) && !string.IsNullOrWhiteSpace(user.DefaultTablespace))
                        {
                            string sqlQuota = $"ALTER USER {user.Username} QUOTA {user.QuotaAmount} ON {user.DefaultTablespace}";
                            using (var cmdQuota = new OracleCommand(sqlQuota, conn)) { cmdQuota.ExecuteNonQuery(); }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool DropUser(string targetUsername, string currentUsername, string currentPassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlDrop = $"DROP USER {targetUsername} CASCADE";
                        using (var cmdDrop = new OracleCommand(sqlDrop, conn)) { cmdDrop.ExecuteNonQuery(); }

                        string sqlDelete = "DELETE FROM ADMIN_BM.APP_USERS WHERE USERNAME = :usr";
                        using (var cmdDelete = new OracleCommand(sqlDelete, conn))
                        {
                            cmdDelete.Parameters.Add(new OracleParameter("usr", targetUsername.ToUpper()));
                            cmdDelete.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<string> GetTablespaces()
        {
            var list = new List<string>();
            string sql = "SELECT TABLESPACE_NAME FROM DBA_TABLESPACES";

            // Dùng kết nối của Admin hệ thống để đọc từ điển dữ liệu
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["TABLESPACE_NAME"].ToString());
                    }
                }
            }
            return list;
        }
        public List<string> GetProfiles()
        {
            var list = new List<string>();
            string sql = "SELECT DISTINCT PROFILE FROM DBA_PROFILES";

            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["PROFILE"].ToString());
                    }
                }
            }
            return list;
        }
    }
}