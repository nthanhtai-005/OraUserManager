using BLL.Security;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using GUI.Interfaces;

namespace GUI.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IAuthService _authService;
        private readonly string _rawPassword;
        public MainPresenter(IMainView view, IAuthService authService, string rawPassword)
        {
            _view = view;
            _authService = authService;
            _rawPassword = rawPassword;

            ApplySecurityPolicies();
            LoadDashboardData();
        }
        private void ApplySecurityPolicies()
        {
            // Kiểm tra quyền Quản lý User (Cần 1 trong các quyền CREATE, ALTER, DROP USER)
            bool canManageUser = SessionContext.HasPrivilege("CREATE USER") ||
                                 SessionContext.HasPrivilege("ALTER USER") ||
                                 SessionContext.HasPrivilege("DROP USER");
            _view.SetUserMenuVisibility(canManageUser);

            // Kiểm tra quyền Quản lý Role
            bool canManageRole = SessionContext.HasPrivilege("CREATE ROLE") ||
                                 SessionContext.HasPrivilege("ALTER ANY ROLE") ||
                                 SessionContext.HasPrivilege("DROP ANY ROLE");
            _view.SetRoleMenuVisibility(canManageRole);

            // Kiểm tra quyền Quản lý Profile
            bool canManageProfile = SessionContext.HasPrivilege("CREATE PROFILE") ||
                                    SessionContext.HasPrivilege("ALTER PROFILE") ||
                                    SessionContext.HasPrivilege("DROP PROFILE");
            _view.SetProfileMenuVisibility(canManageProfile);
        }
        private void LoadDashboardData()
        {
            // Lấy dữ liệu nghiệp vụ tổng hợp từ BLL
            var profileData = _authService.GetLoggedInUserProfile(_rawPassword);

            // Ra lệnh đẩy ngược lên View hiển thị
            _view.DisplayUserProfile(profileData);
        }
    }
}