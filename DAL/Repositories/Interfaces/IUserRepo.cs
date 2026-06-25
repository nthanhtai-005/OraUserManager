using System.Collections.Generic;
using DTO;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepo
    {
        List<AppUserDTO> GetAllUsers(string currentUsername, string currentPassword);
        List<string> GetTablespaces();
        bool CreateUser(AppUserDTO user, string currentUsername, string currentPassword, string hash, string salt);
        bool UpdateUser(AppUserDTO user, string currentUsername, string currentPassword, string hash, string salt, bool updatePassword);
        bool DropUser(string targetUsername, string currentUsername, string currentPassword);
    }
}