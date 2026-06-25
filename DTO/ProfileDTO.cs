namespace DTO
{
    public class ProfileDTO
    {
        public string ProfileName { get; set; } = string.Empty;

        // Lưu trữ chuỗi thô từ Oracle (có thể là "UNLIMITED", "DEFAULT" hoặc một con số "5")
        public string SessionsPerUser { get; set; } = "DEFAULT";
        public string ConnectTime { get; set; } = "DEFAULT";
        public string IdleTime { get; set; } = "DEFAULT";
    }
}