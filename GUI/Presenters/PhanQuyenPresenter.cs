using System;
using GUI.Interfaces;
using BLL.Services.Interfaces;
using BLL.Security;

namespace GUI.Presenters
{
    public class PhanQuyenPresenter
    {
        private readonly IPhanQuyenView _view;
        private readonly IPrivilegeService _service;
        private readonly string _currentPassword;

        public PhanQuyenPresenter(IPhanQuyenView view, IPrivilegeService service, string currentPassword)
        {
            _view = view; _service = service; _currentPassword = currentPassword;

            _view.GranteeTypeChanged += OnGranteeTypeChanged;
            _view.GranteeNameChanged += OnGranteeNameChanged;
            _view.GrantSysPrivClicked += OnGrantSysPrivClicked;
            _view.RevokeSysPrivClicked += OnRevokeSysPrivClicked;
            _view.GrantRoleClicked += OnGrantRoleClicked;
            _view.RevokeRoleClicked += OnRevokeRoleClicked;
            _view.GrantObjPrivClicked += OnGrantObjPrivClicked;
            _view.RevokeObjPrivClicked += OnRevokeObjPrivClicked;

            LoadInitialData();
            OnGranteeTypeChanged(this, EventArgs.Empty);
        }

        private void LoadInitialData()
        {
            _view.LoadSystemPrivileges(_service.GetSystemPrivileges(SessionContext.CurrentUsername, _currentPassword));
            _view.LoadRoles(_service.GetRoles(SessionContext.CurrentUsername, _currentPassword));
            _view.LoadTables(_service.GetTablesAndViews("ADMIN_BM", SessionContext.CurrentUsername, _currentPassword));
        }

        private void OnGranteeTypeChanged(object sender, EventArgs e)
        {
            bool isUser = _view.GranteeType == "USER";
            _view.LoadGranteeNames(_service.GetUsersOrRoles(isUser, SessionContext.CurrentUsername));
            OnGranteeNameChanged(this, EventArgs.Empty);
        }

        private void OnGranteeNameChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.GranteeName)) return;
            _view.LoadGrantedSystemPrivileges(_service.GetGrantedSystemPrivileges(_view.GranteeName));
            _view.LoadGrantedRoles(_service.GetGrantedRoles(_view.GranteeName));
            _view.LoadGrantedObjectPrivileges(_service.GetGrantedObjPrivs(_view.GranteeName));
        }

        private void OnGrantSysPrivClicked(object sender, EventArgs e)
        {
            try
            {
                _service.GrantSystemPrivilege(_view.GranteeType, _view.SelectedSysPriv, _view.GranteeName, _view.WithAdminOption, SessionContext.CurrentUsername, _currentPassword);
                _view.ShowMessage("Cấp Quyền HT thành công!", false);
                OnGranteeNameChanged(this, EventArgs.Empty);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnRevokeSysPrivClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.SelectedGrantedSysPriv))
                {
                    _view.ShowMessage("Vui lòng chọn một quyền từ danh sách Quyền đã cấp (bên phải) để thu hồi!", true);
                    return;
                }

                // 2. Gọi lệnh Revoke với biến SelectedGrantedSysPriv
                _service.RevokeSystemPrivilege(_view.SelectedGrantedSysPriv, _view.GranteeName, SessionContext.CurrentUsername, _currentPassword);

                _view.ShowMessage("Thu hồi Quyền HT thành công!", false);
                OnGranteeNameChanged(this, EventArgs.Empty);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnGrantRoleClicked(object sender, EventArgs e)
        {
            try
            {
                _service.GrantSystemPrivilege(_view.GranteeType, _view.SelectedRole, _view.GranteeName, _view.WithRoleAdminOption, SessionContext.CurrentUsername, _currentPassword);
                _view.ShowMessage("Cấp Role thành công!", false);
                OnGranteeNameChanged(this, EventArgs.Empty);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnRevokeRoleClicked(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra xem người dùng đã chọn Role ở list bên phải chưa
                if (string.IsNullOrEmpty(_view.SelectedGrantedRole))
                {
                    _view.ShowMessage("Vui lòng chọn một Role từ danh sách Role đã cấp (bên phải) để thu hồi!", true);
                    return;
                }

                // 2. Gọi lệnh Revoke với biến SelectedGrantedRole
                _service.RevokeSystemPrivilege(_view.SelectedGrantedRole, _view.GranteeName, SessionContext.CurrentUsername, _currentPassword);

                _view.ShowMessage("Thu hồi Role thành công!", false);
                OnGranteeNameChanged(this, EventArgs.Empty);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnGrantObjPrivClicked(object sender, EventArgs e)
        {
            try
            {
                _service.GrantObjectPrivilege(_view.GranteeType, _view.GranteeName, _view.SelectedTable, _view.SelectedObjectPrivs, _view.WithGrantOption, SessionContext.CurrentUsername, _currentPassword);
                _view.ShowMessage("Cấp Quyền Bảng thành công!", false);
                OnGranteeNameChanged(this, EventArgs.Empty);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnRevokeObjPrivClicked(object sender, EventArgs e)
        {
            try
            {
                _service.RevokeObjectPrivilege(_view.GranteeName, _view.SelectedTable, _view.SelectedObjectPrivs, SessionContext.CurrentUsername, _currentPassword);
                _view.ShowMessage("Thu hồi Quyền Bảng thành công!", false);
                OnGranteeNameChanged(this, EventArgs.Empty);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }
    }
}