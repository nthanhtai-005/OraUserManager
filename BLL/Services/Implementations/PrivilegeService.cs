using System;
using System.Collections.Generic;
using System.Data;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services.Implementations
{
    public class PrivilegeService : IPrivilegeService
    {
        private readonly IPrivilegeRepo _repo;
        public PrivilegeService(IPrivilegeRepo repo) { _repo = repo; }

        public List<string> GetSystemPrivileges(string currentUsername, string currentPassword) => _repo.GetSystemPrivileges(currentUsername, currentPassword);
        public List<string> GetRoles(string currentUsername, string currentPassword) => _repo.GetRoles(currentUsername, currentPassword);
        public List<string> GetTablesAndViews(string owner, string currentUsername, string currentPassword) => _repo.GetTablesAndViews(owner, currentUsername, currentPassword);
        public List<string> GetUsersOrRoles(bool isUser, string currentUsername) => _repo.GetUsersOrRoles(isUser, currentUsername);

        public List<string> GetGrantedSystemPrivileges(string grantee) => _repo.GetGrantedSystemPrivileges(grantee);
        public List<string> GetGrantedRoles(string grantee) => _repo.GetGrantedRoles(grantee);
        public DataTable GetGrantedObjPrivs(string grantee) => _repo.GetGrantedObjPrivs(grantee);

        public bool GrantSystemPrivilege(string granteeType, string privilegeOrRole, string grantee, bool withAdminOption, string currentUsername, string currentPassword)
        {
            if (string.IsNullOrEmpty(privilegeOrRole) || string.IsNullOrEmpty(grantee)) throw new ArgumentException("Thiếu thông tin quyền hoặc đối tượng!");

            // CHẶN ROLE KHÔNG ĐƯỢC ADMIN OPTION
            if (granteeType.ToUpper() == "ROLE" && withAdminOption)
                throw new InvalidOperationException("Không thể dùng WITH ADMIN OPTION khi cấp cho ROLE!");

            string sql = $"GRANT {privilegeOrRole} TO {grantee}";
            if (withAdminOption) sql += " WITH ADMIN OPTION";

            return _repo.ExecuteCommand(sql, currentUsername, currentPassword);
        }

        public bool RevokeSystemPrivilege(string privilegeOrRole, string grantee, string currentUsername, string currentPassword)
        {
            if (string.IsNullOrEmpty(privilegeOrRole) || string.IsNullOrEmpty(grantee)) throw new ArgumentException("Thiếu thông tin!");
            string sql = $"REVOKE {privilegeOrRole} FROM {grantee}";
            return _repo.ExecuteCommand(sql, currentUsername, currentPassword);
        }

        public bool GrantObjectPrivilege(string granteeType, string grantee, string tableName, List<string> privs, bool withGrantOption, string currentUsername, string currentPassword)
        {
            if (privs.Count == 0) throw new ArgumentException("Chọn ít nhất 1 quyền thao tác!");

            // CHẶN ROLE KHÔNG ĐƯỢC GRANT OPTION
            if (granteeType.ToUpper() == "ROLE" && withGrantOption)
                throw new InvalidOperationException("Không thể dùng WITH GRANT OPTION khi cấp cho ROLE!");

            string sql = $"GRANT {string.Join(", ", privs)} ON ADMIN_BM.{tableName} TO {grantee}";
            if (withGrantOption) sql += " WITH GRANT OPTION";

            return _repo.ExecuteCommand(sql, currentUsername, currentPassword);
        }

        public bool RevokeObjectPrivilege(string grantee, string tableName, List<string> privs, string currentUsername, string currentPassword)
        {
            if (privs.Count == 0) throw new ArgumentException("Chọn ít nhất 1 quyền thao tác!");
            string sql = $"REVOKE {string.Join(", ", privs)} ON ADMIN_BM.{tableName} FROM {grantee}";
            return _repo.ExecuteCommand(sql, currentUsername, currentPassword);
        }
    }
}