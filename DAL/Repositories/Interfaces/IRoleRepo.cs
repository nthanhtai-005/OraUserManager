using System.Collections.Generic;
using DTO;

namespace DAL.Repositories.Interfaces
{
    public interface IRoleRepo
    {
        List<AppRoleDTO> GetAllRoles();
        bool CreateRole(AppRoleDTO role, string currentUsername, string currentPassword);
        bool UpdateRole(AppRoleDTO role, string currentUsername, string currentPassword, bool isUpdatePassword);
        bool DropRole(string roleName, string currentUsername, string currentPassword);
    }
}