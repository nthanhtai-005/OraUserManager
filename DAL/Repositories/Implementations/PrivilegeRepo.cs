using System;
using System.Collections.Generic;
using System.Data;
using DAL.Providers;
using DAL.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Repositories.Implementations
{
    public class PrivilegeRepo : IPrivilegeRepo
    {
        private readonly DbConnectionManager _connManager = new DbConnectionManager();

        public List<string> GetSystemPrivileges(string currentUsername, string currentPassword)
        {
            var list = new List<string>();
            string sql = (currentUsername.ToUpper() == "ADMIN_BM" || currentUsername.ToUpper() == "SYS")
                ? "SELECT NAME FROM SYSTEM_PRIVILEGE_MAP ORDER BY NAME"
                : "SELECT PRIVILEGE AS NAME FROM USER_SYS_PRIVS WHERE ADMIN_OPTION = 'YES' ORDER BY NAME";

            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader()) while (reader.Read()) list.Add(reader["NAME"].ToString());
            }
            return list;
        }

        public List<string> GetRoles(string currentUsername, string currentPassword)
        {
            var list = new List<string>();
            string sql = (currentUsername.ToUpper() == "ADMIN_BM" || currentUsername.ToUpper() == "SYS")
                ? "SELECT ROLE AS NAME FROM DBA_ROLES WHERE ORACLE_MAINTAINED = 'N' ORDER BY NAME"
                : "SELECT GRANTED_ROLE AS NAME FROM USER_ROLE_PRIVS WHERE ADMIN_OPTION = 'YES' ORDER BY NAME";

            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader()) while (reader.Read()) list.Add(reader["NAME"].ToString());
            }
            return list;
        }

        public List<string> GetTablesAndViews(string owner, string currentUsername, string currentPassword)
        {
            var list = new List<string>();
            string sql = (currentUsername.ToUpper() == "ADMIN_BM" || currentUsername.ToUpper() == "SYS")
                ? $"SELECT TABLE_NAME AS OBJ_NAME FROM DBA_TABLES WHERE OWNER = '{owner}' UNION SELECT VIEW_NAME AS OBJ_NAME FROM DBA_VIEWS WHERE OWNER = '{owner}' ORDER BY OBJ_NAME"
                : $"SELECT DISTINCT TABLE_NAME AS OBJ_NAME FROM USER_TAB_PRIVS WHERE GRANTABLE = 'YES' AND OWNER = '{owner}' ORDER BY OBJ_NAME";

            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader()) while (reader.Read()) list.Add(reader["OBJ_NAME"].ToString());
            }
            return list;
        }

        public List<string> GetUsersOrRoles(bool isUser, string currentUsername)
        {
            var list = new List<string>();
            string sql;
            if (isUser)
            {
                // Chỉ lấy user trong APP_USERS, ẩn ADMIN_BM nếu không phải là Admin
                sql = "SELECT USERNAME AS NAME FROM ADMIN_BM.APP_USERS WHERE 1=1";
                if (currentUsername.ToUpper() != "ADMIN_BM") sql += " AND UPPER(USERNAME) != 'ADMIN_BM'";
                sql += " ORDER BY NAME";
            }
            else
            {
                sql = "SELECT ROLE AS NAME FROM DBA_ROLES WHERE ORACLE_MAINTAINED = 'N' ORDER BY NAME";
            }

            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader()) while (reader.Read()) list.Add(reader["NAME"].ToString());
            }
            return list;
        }

        public List<string> GetGrantedSystemPrivileges(string grantee)
        {
            var list = new List<string>();
            string sql = $"SELECT PRIVILEGE AS NAME FROM DBA_SYS_PRIVS WHERE GRANTEE = '{grantee}' ORDER BY NAME";
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader()) while (reader.Read()) list.Add(reader["NAME"].ToString());
            }
            return list;
        }

        public List<string> GetGrantedRoles(string grantee)
        {
            var list = new List<string>();
            string sql = $"SELECT GRANTED_ROLE AS NAME FROM DBA_ROLE_PRIVS WHERE GRANTEE = '{grantee}' ORDER BY NAME";
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader()) while (reader.Read()) list.Add(reader["NAME"].ToString());
            }
            return list;
        }

        public DataTable GetGrantedObjPrivs(string grantee)
        {
            var dt = new DataTable();
            string sql = $"SELECT TABLE_NAME AS \"Tên Bảng\", PRIVILEGE AS \"Quyền\", GRANTABLE AS \"Grant Option?\" FROM DBA_TAB_PRIVS WHERE GRANTEE = '{grantee}' ORDER BY TABLE_NAME";
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var da = new OracleDataAdapter(sql, conn)) da.Fill(dt);
            }
            return dt;
        }

        public bool ExecuteCommand(string sql, string currentUsername, string currentPassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn)) cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
}