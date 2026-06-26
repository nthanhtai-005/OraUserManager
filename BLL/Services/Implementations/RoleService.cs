using System;
using System.Collections.Generic;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DTO;

namespace BLL.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;

        public RoleService(IRoleRepo roleRepo) { _roleRepo = roleRepo ?? throw new ArgumentNullException(nameof(roleRepo)); }

        public List<AppRoleDTO> GetAllRoles() => _roleRepo.GetAllRoles();

        public bool CreateRole(AppRoleDTO role, string currentUsername, string currentPassword)
        {
            ValidateRole(role);
            return _roleRepo.CreateRole(role, currentUsername, currentPassword);
        }

        public bool UpdateRole(AppRoleDTO role, string currentUsername, string currentPassword, bool isUpdatePassword)
        {
            ValidateRole(role);
            return _roleRepo.UpdateRole(role, currentUsername, currentPassword, isUpdatePassword);
        }

        public bool DropRole(string roleName, string currentUsername, string currentPassword)
        {
            if (string.IsNullOrWhiteSpace(roleName)) throw new ArgumentException("Tên Role không hợp lệ!");
            return _roleRepo.DropRole(roleName, currentUsername, currentPassword);
        }

        private void ValidateRole(AppRoleDTO role)
        {
            if (string.IsNullOrWhiteSpace(role.RoleName)) throw new ArgumentException("Tên Role không được để trống!");
            if (role.PasswordRequired == "YES" && string.IsNullOrWhiteSpace(role.RawPassword))
                throw new ArgumentException("Bạn đã chọn Role có mật khẩu, vui lòng nhập mật khẩu!");
        }
    }
}