using System;
using System.Windows.Forms;
using DTO;
using GUI.Interfaces;
using BLL.Services.Interfaces; 
using BLL.Security;

namespace GUI.Presenters
{
    public class ProfileManagerPresenter
    {
        private readonly IProfileManagerView _view;
        private readonly IProfileService _profileService; 
        private readonly string _currentPassword;

        // Constructor nhận Service từ tầng BLL xuống
        public ProfileManagerPresenter(IProfileManagerView view, IProfileService profileService, string currentPassword)
        {
            _view = view;
            _profileService = profileService;
            _currentPassword = currentPassword;

            _view.LoadData += OnLoadData;
            _view.SaveClicked += OnSaveClicked;
            _view.DeleteClicked += OnDeleteClicked;
        }

        private void OnLoadData(object sender, EventArgs e)
        {
            try
            {
                // Gọi qua tầng BLL
                var list = _profileService.GetProfiles();
                _view.LoadProfileList(list);

                bool canCreate = SessionContext.HasPrivilege("CREATE PROFILE");
                bool canEdit = SessionContext.HasPrivilege("ALTER PROFILE");
                bool canDrop = SessionContext.HasPrivilege("DROP PROFILE");
                _view.SetActionButtonsVisibility(canCreate, canEdit, canDrop);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Lỗi tải danh sách Profile: " + ex.Message, true);
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            var dto = new ProfileDTO
            {
                ProfileName = _view.ProfileName.Trim().ToUpper(),
                SessionsPerUser = _view.SessionsPerUser,
                ConnectTime = _view.ConnectTime,
                IdleTime = _view.IdleTime
            };

            try
            {
                if (_view.IsCreating)
                {
                    // Gọi qua tầng BLL
                    _profileService.AddProfile(dto, SessionContext.CurrentUsername, _currentPassword);
                    _view.ShowMessage("Tạo mới Profile thành công!", false);
                }
                else
                {
                    // Gọi qua tầng BLL
                    _profileService.EditProfile(dto, SessionContext.CurrentUsername, _currentPassword);
                    _view.ShowMessage("Cập nhật Profile thành công!", false);
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
            if (string.IsNullOrWhiteSpace(_view.ProfileName)) return;

            var confirm = MessageBox.Show($"Xóa Profile '{_view.ProfileName}'? Tất cả User dùng profile này sẽ tự động chuyển về mặc định.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Gọi qua tầng BLL
                    _profileService.RemoveProfile(_view.ProfileName, SessionContext.CurrentUsername, _currentPassword);
                    _view.ShowMessage("Xóa Profile thành công!", false);
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