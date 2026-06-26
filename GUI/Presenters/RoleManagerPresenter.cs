using System;
using System.Windows.Forms;
using DTO;
using GUI.Interfaces;
using BLL.Services.Interfaces;
using BLL.Security;

namespace GUI.Presenters
{
    public class RoleManagerPresenter
    {
        private readonly IRoleManagerView _view;
        private readonly IRoleService _roleService;
        private readonly string _currentPassword;

        public RoleManagerPresenter(IRoleManagerView view, IRoleService roleService, string currentPassword)
        {
            _view = view;
            _roleService = roleService;
            _currentPassword = currentPassword;

            _view.LoadData += OnLoadData;
            _view.SaveClicked += OnSaveClicked;
            _view.DeleteClicked += OnDeleteClicked;
        }

        private void OnLoadData(object sender, EventArgs e)
        {
            try
            {
                var roles = _roleService.GetAllRoles();
                _view.LoadRoleList(roles);

                // Phân quyền hiển thị nút bấm
                // (Role dùng quyền ALTER ANY ROLE / DROP ANY ROLE thay vì ALTER ROLE)
                bool canCreate = SessionContext.HasPrivilege("CREATE ROLE");
                bool canEdit = SessionContext.HasPrivilege("ALTER ANY ROLE");
                bool canDrop = SessionContext.HasPrivilege("DROP ANY ROLE");

                _view.SetActionButtonsVisibility(canCreate, canEdit, canDrop);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Lỗi tải danh sách Role: " + ex.Message, true);
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            // Đóng gói dữ liệu từ View sang DTO
            var dto = new AppRoleDTO
            {
                RoleName = _view.RoleName.Trim().ToUpper(),
                PasswordRequired = _view.HasPassword ? "YES" : "NO",
                RawPassword = _view.Password
            };

            try
            {
                if (_view.IsCreating)
                {
                    _roleService.CreateRole(dto, SessionContext.CurrentUsername, _currentPassword);
                    _view.ShowMessage("Tạo Role mới thành công!", false);
                }
                else
                {
                    // Sửa qua BLL. Nếu dto.RawPassword có giá trị tức là Admin muốn đổi pass mới
                    bool isUpdatePassword = !string.IsNullOrEmpty(dto.RawPassword);
                    _roleService.UpdateRole(dto, SessionContext.CurrentUsername, _currentPassword, isUpdatePassword);
                    _view.ShowMessage("Cập nhật Role thành công!", false);
                }

                _view.SetControlState(false);
                OnLoadData(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Bắt các lỗi do BLL hoặc Oracle ném ra
                _view.ShowMessage("Lỗi xử lý Role:\n" + ex.Message, true);
            }
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.RoleName)) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa Role '{_view.RoleName}' không?\nLưu ý: Mọi User đang được cấp Role này sẽ bị mất các quyền đi kèm!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _roleService.DropRole(_view.RoleName, SessionContext.CurrentUsername, _currentPassword);
                    _view.ShowMessage("Xóa Role thành công!", false);
                    OnLoadData(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    _view.ShowMessage("Lỗi xóa Role:\n" + ex.Message, true);
                }
            }
        }
    }
}