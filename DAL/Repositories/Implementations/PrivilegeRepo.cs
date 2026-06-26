using System;
using System.Collections.Generic;
using DAL.Providers;
using DAL.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Repositories.Implementations
{
    public class PrivilegeRepo : IPrivilegeRepo
    {
        private readonly DbConnectionManager _connManager = new DbConnectionManager();

        public List<string> GetSystemPrivileges()
        {
            var list = new List<string>();
            string sql = "SELECT NAME FROM SYSTEM_PRIVILEGE_MAP ORDER BY NAME";
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) list.Add(reader["NAME"].ToString());
                }
            }
            return list;
        }

        public List<string> GetTablesAndViews(string owner)
        {
            var list = new List<string>();
            // Lấy danh sách Bảng và View của tài khoản chủ schema (ADMIN_BM)
            string sql = $"SELECT TABLE_NAME AS OBJ_NAME FROM DBA_TABLES WHERE OWNER = '{owner}' " +
                         $"UNION SELECT VIEW_NAME AS OBJ_NAME FROM DBA_VIEWS WHERE OWNER = '{owner}' " +
                         $"ORDER BY OBJ_NAME";
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) list.Add(reader["OBJ_NAME"].ToString());
                }
            }
            return list;
        }

        public List<string> GetUsersOrRoles(bool isUser)
        {
            var list = new List<string>();
            string sql = isUser ? "SELECT USERNAME AS NAME FROM DBA_USERS ORDER BY NAME"
                                : "SELECT ROLE AS NAME FROM DBA_ROLES WHERE ORACLE_MAINTAINED = 'N' ORDER BY NAME";
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) list.Add(reader["NAME"].ToString());
                }
            }
            return list;
        }

        // Hàm dùng chung để chạy các lệnh GRANT / REVOKE
        public bool ExecuteCommand(string sql, string currentUsername, string currentPassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
                return true;
            }
        }
    }
}