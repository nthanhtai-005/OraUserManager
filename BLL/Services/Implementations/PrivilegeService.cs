using System;
using System.Collections.Generic;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services.Implementations
{
    public class PrivilegeService : IPrivilegeService
    {
        private readonly IPrivilegeRepo _repo;

        public PrivilegeService(IPrivilegeRepo repo) { _repo = repo; }

        public List<string> GetSystemPrivileges() => _repo.GetSystemPrivileges();
        public List<string> GetTablesAndViews(string owner) => _repo.GetTablesAndViews(owner);
        public List<string> GetUsersOrRoles(bool isUser) => _repo.GetUsersOrRoles(isUser);

        // --- CẤP / THU HỒI QUYỀN HỆ THỐNG ---
        public bool GrantSystemPrivilege(string privilege, string grantee, bool withAdminOption, string currentUsername, string currentPassword)
        {
            if (string.IsNullOrEmpty(privilege) || string.IsNullOrEmpty(grantee)) throw new ArgumentException("Thiếu thông tin quyền hoặc đối tượng!");

            string sql = $"GRANT {privilege} TO {grantee}";
            if (withAdminOption) sql += " WITH ADMIN OPTION"; // Admin option dùng được cho cả Role và User

            return _repo.ExecuteCommand(sql, currentUsername, currentPassword);
        }

        public bool RevokeSystemPrivilege(string privilege, string grantee, string currentUsername, string currentPassword)
        {
            if (string.IsNullOrEmpty(privilege) || string.IsNullOrEmpty(grantee)) throw new ArgumentException("Thiếu thông tin quyền hoặc đối tượng!");
            string sql = $"REVOKE {privilege} FROM {grantee}"; // Revoke không có option
            return _repo.ExecuteCommand(sql, currentUsername, currentPassword);
        }

        // --- CẤP / THU HỒI QUYỀN ĐỐI TƯỢNG ---
        public bool GrantObjectPrivilege(string granteeType, string grantee, string tableName, List<string> privs, bool withGrantOption, string currentUsername, string currentPassword)
        {
            if (privs.Count == 0) throw new ArgumentException("Vui lòng chọn ít nhất 1 quyền (SELECT, INSERT...)!");
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(grantee)) throw new ArgumentException("Thiếu thông tin bảng hoặc đối tượng!");

            // XỬ LÝ NGOẠI LỆ ORACLE: ROLE KHÔNG ĐƯỢC CÓ WITH GRANT OPTION
            if (granteeType.ToUpper() == "ROLE" && withGrantOption)
            {
                throw new InvalidOperationException("Ngoại lệ Oracle: KHÔNG cho phép cấp quyền đối tượng cho ROLE kèm theo WITH GRANT OPTION!");
            }

            string privList = string.Join(", ", privs);
            // Quy ước: Các bảng/view này thuộc sở hữu của ADMIN_BM
            string sql = $"GRANT {privList} ON ADMIN_BM.{tableName} TO {grantee}";

            if (withGrantOption) sql += " WITH GRANT OPTION";

            return _repo.ExecuteCommand(sql, currentUsername, currentPassword);
        }

        public bool RevokeObjectPrivilege(string grantee, string tableName, List<string> privs, string currentUsername, string currentPassword)
        {
            if (privs.Count == 0) throw new ArgumentException("Vui lòng chọn ít nhất 1 quyền (SELECT, INSERT...)!");
            string privList = string.Join(", ", privs);
            string sql = $"REVOKE {privList} ON ADMIN_BM.{tableName} FROM {grantee}";
            return _repo.ExecuteCommand(sql, currentUsername, currentPassword);
        }
    }
}