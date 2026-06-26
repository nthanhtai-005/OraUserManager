using System;
using System.Collections.Generic;
using DAL.Providers;
using DAL.Repositories.Interfaces;
using DTO;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Repositories.Implementations
{
    public class RoleRepo : IRoleRepo
    {
        private readonly DbConnectionManager _connManager = new DbConnectionManager();

        public List<AppRoleDTO> GetAllRoles()
        {
            var list = new List<AppRoleDTO>();
            // Lấy danh sách Role từ hệ thống (Bỏ qua các role mặc định của Oracle có ORACLE_MAINTAINED = 'N')
            string sql = "SELECT ROLE, PASSWORD_REQUIRED FROM DBA_ROLES WHERE ORACLE_MAINTAINED = 'N' ORDER BY ROLE";

            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new AppRoleDTO
                        {
                            RoleName = reader["ROLE"].ToString(),
                            PasswordRequired = reader["PASSWORD_REQUIRED"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool CreateRole(AppRoleDTO role, string currentUsername, string currentPassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                string sql = $"CREATE ROLE {role.RoleName} ";
                if (role.PasswordRequired == "YES" && !string.IsNullOrWhiteSpace(role.RawPassword))
                {
                    sql += $"IDENTIFIED BY \"{role.RawPassword}\"";
                }
                using (var cmd = new OracleCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
                return true;
            }
        }

        public bool UpdateRole(AppRoleDTO role, string currentUsername, string currentPassword, bool isUpdatePassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                string sql = $"ALTER ROLE {role.RoleName} ";

                if (role.PasswordRequired == "YES")
                {
                    if (isUpdatePassword) sql += $"IDENTIFIED BY \"{role.RawPassword}\"";
                    else return true; // Có pass nhưng không nhập pass mới -> Giữ nguyên, không cần ALTER
                }
                else
                {
                    sql += "NOT IDENTIFIED"; // Xóa bỏ mật khẩu của Role
                }

                using (var cmd = new OracleCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
                return true;
            }
        }

        public bool DropRole(string roleName, string currentUsername, string currentPassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                string sql = $"DROP ROLE {roleName}";
                using (var cmd = new OracleCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
                return true;
            }
        }
    }
}