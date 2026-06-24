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

            // LƯU Ý BẢO MẬT 1: Lấy thông tin cá nhân bằng tài khoản ADMIN_BM hệ thống
            string sqlInfo = "SELECT USERNAME, FULLNAME, EMAIL, CREATED_DATE FROM ADMIN_BM.APP_USERS WHERE USERNAME = :username";
            OracleParameter[] parameters = { new OracleParameter("username", username.ToUpper()) };
            DataTable dtInfo = _dbExecutor.ExecuteQuery(sqlInfo, parameters);

            if (dtInfo.Rows.Count > 0)
            {
                profile.Username = dtInfo.Rows[0]["USERNAME"].ToString() ?? "";
                profile.FullName = dtInfo.Rows[0]["FULLNAME"].ToString() ?? "";
                profile.Email = dtInfo.Rows[0]["EMAIL"].ToString() ?? "";
                profile.CreatedDate = Convert.ToDateTime(dtInfo.Rows[0]["CREATED_DATE"]);
            }

            // LƯU Ý BẢO MẬT 2: Dùng chính tài khoản user đăng nhập kết nối để gọi view USER_ nhằm cô lập dữ liệu
            using (var conn = _connManager.GetConnectionWithCredentials(username, password))
            {
                conn.Open();

                // a. Lấy danh sách Vai trò (Roles) của chính user
                string sqlRoles = "SELECT ROLE, 'Có' AS IS_DIRECT, ADMIN_OPTION FROM USER_ROLE_PRIVS";
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

                // b. Lấy danh sách Quyền Hệ Thống (System Privileges) gồm cả trực tiếp và qua Role
                string sqlSysPrivs = @"
                    SELECT PRIVILEGE, 'Trực tiếp' AS GRANTED_VIA, ADMIN_OPTION FROM USER_SYS_PRIVS
                    UNION ALL
                    SELECT PRIVILEGE, 'Qua Role: ' || ROLE AS GRANTED_VIA, ADMIN_OPTION 
                    FROM ROLE_SYS_PRIVS 
                    WHERE ROLE IN (SELECT ROLE FROM USER_ROLE_PRIVS)";
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

                // c. Lấy danh sách Quyền Đối Tượng (Object Privileges) trên các bảng công ty
                string sqlObjPrivs = "SELECT TABLE_NAME, PRIVILEGE, GRANTOR, GRANTABLE FROM USER_TAB_PRIVS";
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
            }

            return profile;
        }
    }
}