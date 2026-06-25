using System;
using System.Collections.Generic;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DTO;

namespace BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        public List<AppUserDTO> GetAllUsers(string currentUsername, string currentPassword)
        {
            return _userRepo.GetAllUsers(currentUsername, currentPassword);
        }

        public List<string> GetTablespaces()
        {
            return _userRepo.GetTablespaces();
        }

        public List<string> GetProfiles()
        {
            return _userRepo.GetProfiles();
        }

        public bool CreateUser(AppUserDTO user, string currentUsername, string currentPassword, string hash, string salt)
        {
            ValidateUser(user);
            return _userRepo.CreateUser(user, currentUsername, currentPassword, hash, salt);
        }

        public bool UpdateUser(AppUserDTO user, string currentUsername, string currentPassword, string hash, string salt, bool updatePassword)
        {
            ValidateUser(user);
            return _userRepo.UpdateUser(user, currentUsername, currentPassword, hash, salt, updatePassword);
        }

        public bool DropUser(string targetUsername, string currentUsername, string currentPassword)
        {
            if (string.IsNullOrWhiteSpace(targetUsername))
                throw new ArgumentException("Tên User cần xóa không hợp lệ!");

            if (targetUsername.ToUpper() == "ADMIN_BM" || targetUsername.ToUpper() == "SYS")
                throw new InvalidOperationException("Nghiêm cấm xóa tài khoản Quản trị hệ thống!");

            return _userRepo.DropUser(targetUsername, currentUsername, currentPassword);
        }

        // Hàm kiểm tra logic đầu vào
        private void ValidateUser(AppUserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username không được để trống!");

            if (user.Username.Length > 30)
                throw new ArgumentException("Username không được vượt quá 30 ký tự theo chuẩn Oracle!");

            if (!string.IsNullOrWhiteSpace(user.Email) && !user.Email.Contains("@"))
                throw new ArgumentException("Email không đúng định dạng!");
        }
    }
}