using System;
using System.Collections.Generic;
using DAL.Providers;
using DAL.Repositories.Interfaces;
using DTO;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Repositories.Implementations
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly DbConnectionManager _connManager = new DbConnectionManager();

        public List<ProfileDTO> GetAllProfiles()
        {
            var list = new List<ProfileDTO>();
            // Sử dụng PIVOT bằng mệnh đề CASE WHEN để gom nhóm dữ liệu dòng từ DBA_PROFILES thành cột
            string sql = @"
                SELECT PROFILE,
                       MAX(CASE WHEN RESOURCE_NAME = 'SESSIONS_PER_USER' THEN LIMIT END) AS SESSIONS_PER_USER,
                       MAX(CASE WHEN RESOURCE_NAME = 'CONNECT_TIME' THEN LIMIT END) AS CONNECT_TIME,
                       MAX(CASE WHEN RESOURCE_NAME = 'IDLE_TIME' THEN LIMIT END) AS IDLE_TIME
                FROM DBA_PROFILES
                WHERE RESOURCE_NAME IN ('SESSIONS_PER_USER', 'CONNECT_TIME', 'IDLE_TIME')
                GROUP BY PROFILE";

            using (var conn = _connManager.GetConnection()) // Kết nối bằng ADMIN_BM để đọc DBA view
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProfileDTO
                        {
                            ProfileName = reader["PROFILE"].ToString(),
                            SessionsPerUser = reader["SESSIONS_PER_USER"].ToString(),
                            ConnectTime = reader["CONNECT_TIME"].ToString(),
                            IdleTime = reader["IDLE_TIME"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool CreateProfile(ProfileDTO profile, string currentUsername, string currentPassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                string sql = $"CREATE PROFILE {profile.ProfileName} LIMIT " +
                             $"SESSIONS_PER_USER {profile.SessionsPerUser} " +
                             $"CONNECT_TIME {profile.ConnectTime} " +
                             $"IDLE_TIME {profile.IdleTime}";
                using (var cmd = new OracleCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
                return true;
            }
        }

        public bool UpdateProfile(ProfileDTO profile, string currentUsername, string currentPassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                string sql = $"ALTER PROFILE {profile.ProfileName} LIMIT " +
                             $"SESSIONS_PER_USER {profile.SessionsPerUser} " +
                             $"CONNECT_TIME {profile.ConnectTime} " +
                             $"IDLE_TIME {profile.IdleTime}";
                using (var cmd = new OracleCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
                return true;
            }
        }

        public bool DropProfile(string profileName, string currentUsername, string currentPassword)
        {
            using (var conn = _connManager.GetConnectionWithCredentials(currentUsername, currentPassword))
            {
                conn.Open();
                // CASCADE giúp tự động gỡ profile này ra khỏi những user đang bị gán nó và chuyển họ về DEFAULT
                string sql = $"DROP PROFILE {profileName} CASCADE";
                using (var cmd = new OracleCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
                return true;
            }
        }
    }
}