using System;

namespace DTO
{
    public class AppUserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string RawPassword { get; set; } = string.Empty;

        public string DefaultTablespace { get; set; } = "USERS";
        public string TempTablespace { get; set; } = "TEMP";
        public string QuotaAmount { get; set; } = "UNLIMITED";
        public bool IsLocked { get; set; } = false;

        public DateTime CreatedDate { get; set; }
    }
}