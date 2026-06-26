using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface IPrivilegeService
    {
        List<string> GetSystemPrivileges();
        List<string> GetTablesAndViews(string owner);
        List<string> GetUsersOrRoles(bool isUser);

        bool GrantSystemPrivilege(string privilege, string grantee, bool withAdminOption, string currentUsername, string currentPassword);
        bool RevokeSystemPrivilege(string privilege, string grantee, string currentUsername, string currentPassword);

        bool GrantObjectPrivilege(string granteeType, string grantee, string tableName, List<string> privs, bool withGrantOption, string currentUsername, string currentPassword);
        bool RevokeObjectPrivilege(string grantee, string tableName, List<string> privs, string currentUsername, string currentPassword);
    }
}