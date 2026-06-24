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
    }
}