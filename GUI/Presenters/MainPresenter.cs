using BLL.Security;
using GUI.Interfaces;

namespace GUI.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;

            ApplySecurityPolicies();
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
    }
}