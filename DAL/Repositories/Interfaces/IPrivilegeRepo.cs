using System.Collections.Generic;
using System.Data;

namespace DAL.Repositories.Interfaces
{
    public interface IPrivilegeRepo
    {
        List<string> GetSystemPrivileges(string currentUsername, string currentPassword);
        List<string> GetRoles(string currentUsername, string currentPassword);
        List<string> GetTablesAndViews(string owner, string currentUsername, string currentPassword);
        List<string> GetUsersOrRoles(bool isUser, string currentUsername);

        List<string> GetGrantedSystemPrivileges(string grantee);
        List<string> GetGrantedRoles(string grantee);
        DataTable GetGrantedObjPrivs(string grantee);

        bool ExecuteCommand(string sql, string currentUsername, string currentPassword);
    }
}