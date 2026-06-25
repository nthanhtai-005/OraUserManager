using System.Collections.Generic;
using DTO;

namespace BLL.Services.Interfaces
{
    public interface IProfileService
    {
        List<ProfileDTO> GetProfiles();
        bool AddProfile(ProfileDTO profile, string currentUsername, string currentPassword);
        bool EditProfile(ProfileDTO profile, string currentUsername, string currentPassword);
        bool RemoveProfile(string profileName, string currentUsername, string currentPassword);
    }
}