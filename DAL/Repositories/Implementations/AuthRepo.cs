using System;
using System.Data;
using DAL.Repositories.Interfaces;
using DTO;
using Oracle.ManagedDataAccess.Client;
using DAL.Providers;

namespace DAL.Repositories.Implementations
{
    public class AuthRepo : IAuthRepo
    {
        private readonly DbExecutor _dbExecutor;
        private readonly DbConnectionManager _connManager;

        public AuthRepo()
        {
            _dbExecutor = new DbExecutor();
            _connManager = new DbConnectionManager();
        }

        public AuthUserDTO GetAuthInfo(string username)
        {
            // SỬ DỤNG BIẾN BINDING :username
            string sql = "SELECT PASSWORD_HASH, SALT FROM ADMIN_BM.APP_USERS WHERE USERNAME = :username";

            // TRUYỀN PARAMETER
            OracleParameter[] parameters = {
                new OracleParameter("username", username.ToUpper())
            };

            DataTable dt = _dbExecutor.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                return new AuthUserDTO
                {
                    Username = username.ToUpper(),
                    PasswordHash = dt.Rows[0]["PASSWORD_HASH"].ToString(),
                    Salt = dt.Rows[0]["SALT"].ToString()
                };
            }
            return null; 
        }

        // KHẮC PHỤC LỖI 3-TIER LEAKAGE: Logic kết nối DB nằm hoàn toàn ở DAL
        public bool TestDatabaseLogin(string username, string password)
        {
            try
            {
                using (var conn = _connManager.GetConnectionWithCredentials(username, password))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<string> GetSessionPrivileges(string username, string password)
        {
            List<string> privileges = new List<string>();
            string sql = "SELECT privilege FROM session_privs";

            // Mở kết nối BẰNG CHÍNH TÀI KHOẢN CỦA USER ĐANG LOG IN
            using (var conn = _connManager.GetConnectionWithCredentials(username, password))
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            privileges.Add(reader["privilege"].ToString());
                        }
                    }
                }
            }
            return privileges;
        }
        public UserProfileDTO GetUserDashboardData(string username, string password)
        {
            var profile = new UserProfileDTO();

            // 1. Dùng tài khoản ADMIN_BM lấy Thông tin cá nhân + Profile + Status + Tablespace (Từ DBA_USERS)
            string sqlInfo = @"
                                SELECT a.USERNAME, a.FULLNAME, a.EMAIL, a.CREATED_DATE,
                                d.ACCOUNT_STATUS, d.LOCK_DATE, d.PROFILE, d.DEFAULT_TABLESPACE, d.TEMPORARY_TABLESPACE
                                FROM ADMIN_BM.APP_USERS a
                                JOIN DBA_USERS d ON a.USERNAME = d.USERNAME
                                WHERE a.USERNAME = :username";

            OracleParameter[] parameters = { new OracleParameter("username", username.ToUpper()) };
            DataTable dtInfo = _dbExecutor.ExecuteQuery(sqlInfo, parameters);

            if (dtInfo.Rows.Count > 0)
            {
                DataRow row = dtInfo.Rows[0];
                profile.Username = row["USERNAME"].ToString() ?? "";
                profile.FullName = row["FULLNAME"].ToString() ?? "";
                profile.Email = row["EMAIL"].ToString() ?? "";
                profile.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"]);

                // Gán các thông tin mới
                profile.AccountStatus = row["ACCOUNT_STATUS"].ToString() ?? "";
                profile.ProfileName = row["PROFILE"].ToString() ?? "";
                profile.DefaultTablespace = row["DEFAULT_TABLESPACE"].ToString() ?? "";
                profile.TemporaryTablespace = row["TEMPORARY_TABLESPACE"].ToString() ?? "";

                // Xử lý Lock_Date (vì nếu tài khoản không bị khóa, trường này sẽ là NULL)
                if (row["LOCK_DATE"] != DBNull.Value)
                    profile.LockDate = Convert.ToDateTime(row["LOCK_DATE"]).ToString("dd/MM/yyyy HH:mm");
                else
                    profile.LockDate = "Không bị khóa";
            }

            // 2. Dùng tài khoản CHÍNH USER ĐÓ lấy quyền và Quota (Cô lập dữ liệu hệ thống)
            using (var conn = _connManager.GetConnectionWithCredentials(username, password))
            {
                conn.Open();

                // a. Lấy Role
                string sqlRoles = "SELECT GRANTED_ROLE AS ROLE, 'Có' AS IS_DIRECT, ADMIN_OPTION FROM USER_ROLE_PRIVS";
                using (var cmd = new OracleCommand(sqlRoles, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        profile.Roles.Add(new RoleDTO
                        {
                            RoleName = reader["ROLE"].ToString() ?? "",
                            IsDirect = reader["IS_DIRECT"].ToString() ?? "Có",
                            AdminOption = reader["ADMIN_OPTION"].ToString() ?? "NO"
                        });
                    }
                }

                // b. Lấy Quyền Hệ thống
                string sqlSysPrivs = @"
                                        SELECT PRIVILEGE, 'Trực tiếp' AS GRANTED_VIA, ADMIN_OPTION FROM USER_SYS_PRIVS
                                        UNION ALL
                                        SELECT PRIVILEGE, 'Qua Role: ' || ROLE AS GRANTED_VIA, ADMIN_OPTION 
                                        FROM ROLE_SYS_PRIVS 
                                        WHERE ROLE IN (SELECT GRANTED_ROLE FROM USER_ROLE_PRIVS)";
                using (var cmd = new OracleCommand(sqlSysPrivs, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        profile.SystemPrivileges.Add(new SystemPrivilegeDTO
                        {
                            PrivilegeName = reader["PRIVILEGE"].ToString() ?? "",
                            GrantedVia = reader["GRANTED_VIA"].ToString() ?? "",
                            AdminOption = reader["ADMIN_OPTION"].ToString() ?? "NO"
                        });
                    }
                }

                // c. Lấy Quyền Đối tượng (Chỉ lấy Bảng và Khung nhìn)
                string sqlObjPrivs = "SELECT TABLE_NAME, PRIVILEGE, GRANTOR, GRANTABLE FROM USER_TAB_PRIVS WHERE TYPE IN ('TABLE', 'VIEW')";
                using (var cmd = new OracleCommand(sqlObjPrivs, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        profile.ObjectPrivileges.Add(new ObjectPrivilegeDTO
                        {
                            ObjectName = reader["TABLE_NAME"].ToString() ?? "",
                            PrivilegeName = reader["PRIVILEGE"].ToString() ?? "",
                            GrantedBy = reader["GRANTOR"].ToString() ?? "",
                            Grantable = reader["GRANTABLE"].ToString() ?? "NO"
                        });
                    }
                }

                // d. Lấy Quota
                string sqlQuota = "SELECT TABLESPACE_NAME, BYTES, MAX_BYTES FROM USER_TS_QUOTAS";
                using (var cmd = new OracleCommand(sqlQuota, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maxBytesStr = reader["MAX_BYTES"].ToString();
                        string displayMax = (maxBytesStr == "-1") ? "Unlimited" : maxBytesStr;

                        profile.Quotas.Add(new QuotaDTO
                        {
                            TablespaceName = reader["TABLESPACE_NAME"].ToString() ?? "",
                            Bytes = reader["BYTES"].ToString() ?? "0",
                            MaxBytes = displayMax
                        });
                    }
                }
            }

            return profile;
        }
    }
}