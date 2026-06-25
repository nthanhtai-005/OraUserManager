using System;
using System.Collections.Generic;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DTO;

namespace BLL.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepo _profileRepo;

        public ProfileService(IProfileRepo profileRepo)
        {
            _profileRepo = profileRepo ?? throw new ArgumentNullException(nameof(profileRepo));
        }

        public List<ProfileDTO> GetProfiles()
        {
            // Thao tác đọc danh sách thường không có logic phức tạp, gọi thẳng DAL
            return _profileRepo.GetAllProfiles();
        }

        public bool AddProfile(ProfileDTO profile, string currentUsername, string currentPassword)
        {
            // CHẶN LOGIC NGHIỆP VỤ: Tên profile không được trống
            if (string.IsNullOrWhiteSpace(profile.ProfileName))
                throw new ArgumentException("Tên Profile nghiệp vụ không được để trống!");

            // CHẶN LOGIC ORACLE: Tên đối tượng trong Oracle không được quá 30 ký tự
            if (profile.ProfileName.Length > 30)
                throw new ArgumentException("Tên Profile không được vượt quá 30 ký tự theo chuẩn Oracle!");

            return _profileRepo.CreateProfile(profile, currentUsername, currentPassword);
        }

        public bool EditProfile(ProfileDTO profile, string currentUsername, string currentPassword)
        {
            if (string.IsNullOrWhiteSpace(profile.ProfileName))
                throw new ArgumentException("Tên Profile cần chỉnh sửa không hợp lệ!");

            return _profileRepo.UpdateProfile(profile, currentUsername, currentPassword);
        }

        public bool RemoveProfile(string profileName, string currentUsername, string currentPassword)
        {
            if (string.IsNullOrWhiteSpace(profileName))
                throw new ArgumentException("Tên Profile cần xóa không hợp lệ!");

            // CHẶN LOGIC AN TOÀN: Tuyệt đối không cho phép gửi lệnh xóa profile DEFAULT lên Oracle
            if (profileName.ToUpper() == "DEFAULT")
                throw new InvalidOperationException("Đây là Profile mặc định của hệ thống Oracle, không được phép xóa!");

            return _profileRepo.DropProfile(profileName, currentUsername, currentPassword);
        }
    }
}