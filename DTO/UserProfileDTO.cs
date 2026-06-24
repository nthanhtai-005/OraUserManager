using System;
using System.Collections.Generic;

namespace DTO
{
    // 1. DTO chứa thông tin Role
    public class RoleDTO
    {
        public string RoleName { get; set; } = string.Empty;
        public string IsDirect { get; set; } = "Có";
        public string AdminOption { get; set; } = "NO";
    }

    // 2. DTO chứa thông tin Quyền hệ thống
    public class SystemPrivilegeDTO
    {
        public string PrivilegeName { get; set; } = string.Empty;
        public string GrantedVia { get; set; } = "Trực tiếp";
        public string AdminOption { get; set; } = "NO";
    }

    // 3. DTO chứa thông tin Quyền đối tượng (Bảng/Cột)
    public class ObjectPrivilegeDTO
    {
        public string ObjectName { get; set; } = string.Empty;
        public string PrivilegeName { get; set; } = string.Empty;
        public string GrantedBy { get; set; } = string.Empty;
        public string Grantable { get; set; } = "NO";
    }
    public class QuotaDTO
    {
        public string TablespaceName { get; set; } = string.Empty;
        public string Bytes { get; set; } = string.Empty;
        public string MaxBytes { get; set; } = string.Empty;
    }

    // 4. DTO tổng hợp hiển thị lên Trang chủ Main
    public class UserProfileDTO
    {
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string AccountStatus { get; set; } = string.Empty;
        public string LockDate { get; set; } = string.Empty;
        public string ProfileName { get; set; } = string.Empty;
        public string DefaultTablespace { get; set; } = string.Empty;
        public string TemporaryTablespace { get; set; } = string.Empty;
        public List<QuotaDTO> Quotas { get; set; } = new List<QuotaDTO>();

        public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
        public List<SystemPrivilegeDTO> SystemPrivileges { get; set; } = new List<SystemPrivilegeDTO>();
        public List<ObjectPrivilegeDTO> ObjectPrivileges { get; set; } = new List<ObjectPrivilegeDTO>();
    }
}