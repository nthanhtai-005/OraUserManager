using DTO;
namespace BLL.Services.Interfaces
{
    public interface IAuthService
    {
        // Khai báo phương thức đăng nhập để Presenter gọi
        bool Login(string username, string rawPassword);
        UserProfileDTO GetLoggedInUserProfile(string rawPassword);
    }
}