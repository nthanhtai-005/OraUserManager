using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IPrivilegeRepo
    {
        List<string> GetSystemPrivileges();
        List<string> GetTablesAndViews(string owner);
        List<string> GetUsersOrRoles(bool isUser);
        bool ExecuteCommand(string sql, string currentUsername, string currentPassword);
    }
}