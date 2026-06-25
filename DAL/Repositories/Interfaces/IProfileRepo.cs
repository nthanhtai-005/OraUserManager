using System.Collections.Generic;
using DTO;

namespace DAL.Repositories.Interfaces
{
    public interface IProfileRepo
    {
        List<ProfileDTO> GetAllProfiles();
        bool CreateProfile(ProfileDTO profile, string currentUsername, string currentPassword);
        bool UpdateProfile(ProfileDTO profile, string currentUsername, string currentPassword);
        bool DropProfile(string profileName, string currentUsername, string currentPassword);
    }
}