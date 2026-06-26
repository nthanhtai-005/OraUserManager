namespace DTO
{
    public class AppRoleDTO
    {
        public string RoleName { get; set; } = string.Empty;
        public string PasswordRequired { get; set; } = "NO"; 
        public string RawPassword { get; set; } = string.Empty; 
    }
}