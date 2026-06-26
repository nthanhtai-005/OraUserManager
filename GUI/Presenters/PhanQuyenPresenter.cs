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
            _view = view;
            _service = service;
            _currentPassword = currentPassword;

            _view.GranteeTypeChanged += OnGranteeTypeChanged;
            _view.GrantSysPrivClicked += OnGrantSysPrivClicked;
            _view.RevokeSysPrivClicked += OnRevokeSysPrivClicked;
            _view.GrantObjPrivClicked += OnGrantObjPrivClicked;
            _view.RevokeObjPrivClicked += OnRevokeObjPrivClicked;

            // Load data ban đầu
            LoadInitialData();
            OnGranteeTypeChanged(this, EventArgs.Empty);
        }

        private void LoadInitialData()
        {
            _view.LoadSystemPrivileges(_service.GetSystemPrivileges());
            _view.LoadTables(_service.GetTablesAndViews("ADMIN_BM"));
        }

        private void OnGranteeTypeChanged(object sender, EventArgs e)
        {
            bool isUser = _view.GranteeType == "USER";
            _view.LoadGranteeNames(_service.GetUsersOrRoles(isUser));
        }

        private void OnGrantSysPrivClicked(object sender, EventArgs e)
        {
            try
            {
                _service.GrantSystemPrivilege(_view.SelectedSysPriv, _view.GranteeName, _view.WithAdminOption, SessionContext.CurrentUsername, _currentPassword);
                _view.ShowMessage($"Đã cấp quyền {_view.SelectedSysPriv} thành công!", false);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnRevokeSysPrivClicked(object sender, EventArgs e)
        {
            try
            {
                _service.RevokeSystemPrivilege(_view.SelectedSysPriv, _view.GranteeName, SessionContext.CurrentUsername, _currentPassword);
                _view.ShowMessage($"Đã thu hồi quyền {_view.SelectedSysPriv} thành công!", false);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnGrantObjPrivClicked(object sender, EventArgs e)
        {
            try
            {
                _service.GrantObjectPrivilege(_view.GranteeType, _view.GranteeName, _view.SelectedTable, _view.SelectedObjectPrivs, _view.WithGrantOption, SessionContext.CurrentUsername, _currentPassword);
                _view.ShowMessage($"Cấp quyền trên bảng {_view.SelectedTable} thành công!", false);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }

        private void OnRevokeObjPrivClicked(object sender, EventArgs e)
        {
            try
            {
                _service.RevokeObjectPrivilege(_view.GranteeName, _view.SelectedTable, _view.SelectedObjectPrivs, SessionContext.CurrentUsername, _currentPassword);
                _view.ShowMessage($"Thu hồi quyền trên bảng {_view.SelectedTable} thành công!", false);
            }
            catch (Exception ex) { _view.ShowMessage(ex.Message, true); }
        }
    }
}