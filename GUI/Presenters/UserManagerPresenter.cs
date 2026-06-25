using System;
using System.Windows.Forms;
using DTO;
using GUI.Interfaces;
using BLL.Services.Interfaces; // ĐỔI TỪ DAL SANG BLL
using BLL.Security;

namespace GUI.Presenters
{
    public class UserManagerPresenter
    {
        private readonly IUserManagerView _view;
        private readonly IUserService _userService; 
        private readonly string _currentPassword;

        public UserManagerPresenter(IUserManagerView view, IUserService userService, string currentPassword)
        {
            _view = view;
            _userService = userService;
            _currentPassword = currentPassword;

            _view.LoadData += OnLoadData;
            _view.SaveClicked += OnSaveClicked;
            _view.DeleteClicked += OnDeleteClicked;
        }

        private void OnLoadData(object sender, EventArgs e)
        {
            try
            {
                var tsList = _userService.GetTablespaces();
                _view.LoadTablespaces(tsList);

                var profileList = _userService.GetProfiles();
                _view.LoadProfiles(profileList);

                var users = _userService.GetAllUsers(SessionContext.CurrentUsername, _currentPassword);
                _view.LoadUserList(users);

                bool canCreate = SessionContext.HasPrivilege("CREATE USER");
                bool canEdit = SessionContext.HasPrivilege("ALTER USER");
                bool canDrop = SessionContext.HasPrivilege("DROP USER");
                _view.SetActionButtonsVisibility(canCreate, canEdit, canDrop);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Lỗi tải danh sách User: " + ex.Message, true);
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                var user = new AppUserDTO
                {
                    Username = _view.Username,
                    FullName = _view.FullName,
                    Email = _view.Email,
                    RawPassword = _view.Password,
                    DefaultTablespace = _view.DefaultTablespace,
                    TempTablespace = _view.TempTablespace,
                    QuotaAmount = _view.QuotaAmount,
                    IsLocked = _view.IsLocked,
                    ProfileName = _view.ProfileName
                };

                string salt = HashHelper.GenerateSalt();
                string hash = string.IsNullOrEmpty(user.RawPassword) ? "" : HashHelper.HashPassword(user.RawPassword, salt);

                if (_view.IsCreating)
                {
                    if (string.IsNullOrWhiteSpace(user.RawPassword))
                    {
                        _view.ShowMessage("Vui lòng nhập mật khẩu cho User mới!", true); return;
                    }
                    _userService.CreateUser(user, SessionContext.CurrentUsername, _currentPassword, hash, salt);
                    _view.ShowMessage("Tạo mới User thành công!", false);
                }
                else
                {
                    bool updatePassword = !string.IsNullOrWhiteSpace(user.RawPassword);
                    _userService.UpdateUser(user, SessionContext.CurrentUsername, _currentPassword, hash, salt, updatePassword);
                    _view.ShowMessage("Cập nhật User thành công!", false);
                }

                _view.SetControlState(false);
                OnLoadData(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Thông báo nghiệp vụ: " + ex.Message, true);
            }
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.Username)) return;

            var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa User '{_view.Username}'?",
                                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _userService.DropUser(_view.Username, SessionContext.CurrentUsername, _currentPassword);
                    _view.ShowMessage("Xóa User thành công!", false);
                    OnLoadData(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    _view.ShowMessage("Lỗi hệ thống: " + ex.Message, true);
                }
            }
        }
    }
}