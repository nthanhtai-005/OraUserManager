using BLL.Security;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL.Repositories.Implementations;
using GUI.Interfaces;
using GUI.Views;
using System;
using System.Windows.Forms; 

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

            // ĐĂNG KÝ LẮNG NGHE CÁC SỰ KIỆN TỪ VIEW
            _view.LogoutClicked += OnLogoutClicked;
            _view.OpenUserManagerClicked += OnOpenUserManagerClicked;

            // THÊM DÒNG NÀY ĐỂ LẮNG NGHE NÚT QUẢN LÝ PROFILE
            _view.OpenProfileManagerClicked += OnOpenProfileManagerClicked;
        }

        // --- CÁC HÀM XỬ LÝ MỞ FORM CON ---

        private void OnOpenUserManagerClicked(object sender, EventArgs e)
        {
            var userView = new frmUserManager();
            var userRepo = new UserRepo();
            var userPresenter = new UserManagerPresenter(userView, userRepo, _rawPassword);
            ((Form)userView).ShowDialog();
        }

        private void OnOpenProfileManagerClicked(object sender, EventArgs e)
        {
            var view = new frmProfileManager();               // 1. Khởi tạo Giao diện (GUI)
            var repo = new ProfileRepo();                     // 2. Khởi tạo Kho lưu trữ (DAL)
            var service = new ProfileService(repo);           // 3. Khởi tạo Nghiệp vụ (BLL) và tiêm DAL vào

            // 4. Khởi tạo Điều hướng (Presenter) và tiêm Service vào
            var presenter = new ProfileManagerPresenter(view, service, _rawPassword);

            ((Form)view).ShowDialog();
        }

        // --- CÁC HÀM LOGIC CỦA MAIN FORM ---

        private void ApplySecurityPolicies()
        {
            // Kiểm tra quyền Quản lý User
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
            var profileData = _authService.GetLoggedInUserProfile(_rawPassword);
            _view.DisplayUserProfile(profileData);
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            _authService.Logout();
            _view.IsLogout = true;
            _view.CloseView();
        }
    }
}