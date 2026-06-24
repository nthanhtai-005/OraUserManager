using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Providers
{
    public class DbConnectionManager
    {
        // Chuỗi kết nối mặc định (Quản trị viên)
        private string _connectionString = "Data Source=localhost:1521/DB_BAOMAT; User Id=ADMIN_BM; Password=Oracle_1234;";

        public OracleConnection GetConnection()
        {
            return new OracleConnection(_connectionString);
        }

        public OracleConnection GetConnectionWithCredentials(string username, string password)
        {
            // Trả về kết nối với tài khoản user cụ thể để test đăng nhập DB
            return new OracleConnection($"Data Source=localhost:1521/DB_BAOMAT; User Id={username}; Password={password};");
        }
    }
}
