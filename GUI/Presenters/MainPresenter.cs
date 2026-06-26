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

            _view.LogoutClicked += OnLogoutClicked;
            _view.OpenUserManagerClicked += OnOpenUserManagerClicked;
            _view.OpenProfileManagerClicked += OnOpenProfileManagerClicked;
            _view.OpenRoleManagerClicked += OnOpenRoleManagerClicked;
            _view.OpenPhanQuyenClicked += OnOpenPhanQuyenClicked;
        }

        // --- CÁC HÀM XỬ LÝ MỞ FORM CON ---

        private void OnOpenUserManagerClicked(object sender, EventArgs e)
        {
            var userView = new frmUserManager();              
            var userRepo = new UserRepo();                    
            var userService = new UserService(userRepo);
            var userPresenter = new UserManagerPresenter(userView, userService, _rawPassword);
            ((Form)userView).ShowDialog();
        }

        private void OnOpenProfileManagerClicked(object sender, EventArgs e)
        {
            var view = new frmProfileManager();               
            var repo = new ProfileRepo();                     
            var service = new ProfileService(repo);           

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

            bool isSuperAdmin = SessionContext.CurrentUsername.ToUpper() == "ADMIN_BM" ||
                        SessionContext.CurrentUsername.ToUpper() == "SYS";
            bool hasSuperGrant = SessionContext.HasPrivilege("GRANT ANY PRIVILEGE") ||
                                 SessionContext.HasPrivilege("GRANT ANY ROLE");

            var privRepo = new DAL.Repositories.Implementations.PrivilegeRepo();
            var privService = new BLL.Services.Implementations.PrivilegeService(privRepo);

            bool hasGrantableSysPrivs = privService.GetSystemPrivileges(SessionContext.CurrentUsername, _rawPassword).Count > 0;
            bool hasGrantableObjPrivs = privService.GetTablesAndViews("ADMIN_BM", SessionContext.CurrentUsername, _rawPassword).Count > 0;

            bool canPhanQuyen = isSuperAdmin || hasSuperGrant || hasGrantableSysPrivs || hasGrantableObjPrivs;

            _view.SetPhanQuyenMenuVisibility(canPhanQuyen);
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
        private void OnOpenRoleManagerClicked(object sender, EventArgs e)
        {
            var view = new frmRoleManager();
            var repo = new RoleRepo();
            var service = new RoleService(repo);
            var presenter = new RoleManagerPresenter(view, service, _rawPassword);
            ((Form)view).ShowDialog();
        }
        private void OnOpenPhanQuyenClicked(object sender, EventArgs e)
        {
            var view = new frmPhanQuyen();
            var repo = new PrivilegeRepo();
            var service = new PrivilegeService(repo);
            var presenter = new PhanQuyenPresenter(view, service, _rawPassword);
            ((Form)view).ShowDialog();
        }
    }
}