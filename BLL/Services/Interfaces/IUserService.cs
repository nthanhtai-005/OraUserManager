using System.Collections.Generic;
using DTO;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        List<AppUserDTO> GetAllUsers(string currentUsername, string currentPassword);
        List<string> GetTablespaces();
        List<string> GetProfiles();
        bool CreateUser(AppUserDTO user, string currentUsername, string currentPassword, string hash, string salt);
        bool UpdateUser(AppUserDTO user, string currentUsername, string currentPassword, string hash, string salt, bool updatePassword);
        bool DropUser(string targetUsername, string currentUsername, string currentPassword);
    }
}