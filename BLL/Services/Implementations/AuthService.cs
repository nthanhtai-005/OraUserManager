using BLL.Security;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DTO;

namespace BLL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo _authRepo;

        public AuthService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        public bool Login(string username, string rawPassword)
        {
            // 1. Lấy thông tin user từ DB (trả về DTO)
            var authUser = _authRepo.GetAuthInfo(username);
            if (authUser == null) return false;

            // 2. Kiểm tra mật khẩu băm
            string calculatedHash = HashHelper.HashPassword(rawPassword, authUser.Salt);
            if (calculatedHash != authUser.PasswordHash) return false;

            // 3. Test kết nối DB bằng tài khoản thực (Gọi DAL, BLL không import thư viện Oracle)
            bool isDbLoginSuccess = _authRepo.TestDatabaseLogin(username, rawPassword);
            if (!isDbLoginSuccess) return false;

            // 3. Nạp Session
            SessionContext.ClearSession();
            SessionContext.CurrentUsername = username;

            // Lấy quyền từ DAL và lưu vào Session
            var privs = _authRepo.GetSessionPrivileges(username, rawPassword);
            foreach (var priv in privs)
            {
                SessionContext.SystemPrivileges.Add(priv);
            }
            return true;
        }
        public UserProfileDTO GetLoggedInUserProfile(string rawPassword)
        {
            string currentUsername = SessionContext.CurrentUsername;
            return _authRepo.GetUserDashboardData(currentUsername, rawPassword);
        }
    }
}