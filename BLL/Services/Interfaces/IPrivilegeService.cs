using System.Collections.Generic;
using System.Data;

namespace BLL.Services.Interfaces
{
    public interface IPrivilegeService
    {
        List<string> GetSystemPrivileges(string currentUsername, string currentPassword);
        List<string> GetRoles(string currentUsername, string currentPassword);
        List<string> GetTablesAndViews(string owner, string currentUsername, string currentPassword);
        List<string> GetUsersOrRoles(bool isUser, string currentUsername);

        List<string> GetGrantedSystemPrivileges(string grantee);
        List<string> GetGrantedRoles(string grantee);
        DataTable GetGrantedObjPrivs(string grantee);

        bool GrantSystemPrivilege(string granteeType, string privilegeOrRole, string grantee, bool withAdminOption, string currentUsername, string currentPassword);
        bool RevokeSystemPrivilege(string privilegeOrRole, string grantee, string currentUsername, string currentPassword);

        bool GrantObjectPrivilege(string granteeType, string grantee, string tableName, List<string> privs, bool withGrantOption, string currentUsername, string currentPassword);
        bool RevokeObjectPrivilege(string grantee, string tableName, List<string> privs, string currentUsername, string currentPassword);
    }
}