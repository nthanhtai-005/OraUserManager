using System;
using System.Windows.Forms;
using DTO;
using GUI.Interfaces;
using DAL.Repositories.Interfaces;
using BLL.Security;

namespace GUI.Presenters
{
    public class UserManagerPresenter
    {
        private readonly IUserManagerView _view;
        private readonly IUserRepo _userRepo;
        private readonly string _currentPassword;

        public UserManagerPresenter(IUserManagerView view, IUserRepo userRepo, string currentPassword)
        {
            _view = view;
            _userRepo = userRepo;
            _currentPassword = currentPassword;

            // Lắng nghe các sự kiện thao tác từ Form
            _view.LoadData += OnLoadData;
            _view.SaveClicked += OnSaveClicked;
            _view.DeleteClicked += OnDeleteClicked;
        }

        private void OnLoadData(object sender, EventArgs e)
        {
            try
            {
                var tsList = _userRepo.GetTablespaces();
                _view.LoadTablespaces(tsList);
                var profileList = _userRepo.GetProfiles();
                _view.LoadProfiles(profileList);
                // 1. Lấy danh sách lên lưới (Grid)
                var users = _userRepo.GetAllUsers(SessionContext.CurrentUsername, _currentPassword);
                _view.LoadUserList(users);

                // 2. Kiểm tra quyền và Bật/Tắt các nút Tạo, Sửa, Xóa tương ứng
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
                // 1. Gom dữ liệu từ giao diện vào DTO
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

                // 2. Tạo Hash & Salt
                string salt = HashHelper.GenerateSalt();
                string hash = string.IsNullOrEmpty(user.RawPassword) ? "" : HashHelper.HashPassword(user.RawPassword, salt);

                // 3. Phân nhánh Tạo mới hoặc Sửa
                if (_view.IsCreating)
                {
                    if (string.IsNullOrWhiteSpace(user.RawPassword))
                    {
                        _view.ShowMessage("Vui lòng nhập mật khẩu cho User mới!", true); return;
                    }
                    _userRepo.CreateUser(user, SessionContext.CurrentUsername, _currentPassword, hash, salt);
                    _view.ShowMessage("Tạo mới User thành công!", false);
                }
                else
                {
                    bool updatePassword = !string.IsNullOrWhiteSpace(user.RawPassword);
                    _userRepo.UpdateUser(user, SessionContext.CurrentUsername, _currentPassword, hash, salt, updatePassword);
                    _view.ShowMessage("Cập nhật User thành công!", false);
                }

                _view.SetControlState(false);
                OnLoadData(this, EventArgs.Empty); 
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Lỗi: Bạn không có quyền thực hiện hoặc sai cú pháp!\n" + ex.Message, true);
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
                    _userRepo.DropUser(_view.Username, SessionContext.CurrentUsername, _currentPassword);
                    _view.ShowMessage("Xóa User thành công!", false);
                    OnLoadData(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    _view.ShowMessage("Lỗi xóa User: " + ex.Message, true);
                }
            }
        }
    }
}