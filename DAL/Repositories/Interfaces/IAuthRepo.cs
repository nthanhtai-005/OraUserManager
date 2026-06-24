using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL.Repositories.Interfaces
{
    public interface IAuthRepo
    {
        AuthUserDTO GetAuthInfo(string username);
        bool TestDatabaseLogin(string username, string password);
        List<string> GetSessionPrivileges(string username, string password);
        UserProfileDTO GetUserDashboardData(string username, string password);
    }
}
