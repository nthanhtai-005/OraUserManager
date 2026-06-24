using Oracle.ManagedDataAccess.Client;
using System.Configuration; // Thêm thư viện này

namespace DAL.Providers
{
    public class DbConnectionManager
    {
        // Đọc chuỗi kết nối từ file App.config thông qua thuộc tính Name là "OracleDbContext"
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;

        public OracleConnection GetConnection()
        {
            return new OracleConnection(_connectionString);
        }

        public OracleConnection GetConnectionWithCredentials(string username, string password)
        {
            // Trả về kết nối với tài khoản user cụ thể để test đăng nhập DB hoặc lấy quyền
            return new OracleConnection($"Data Source=localhost:1521/DB_BAOMAT; User Id={username}; Password={password};");
        }
    }
}