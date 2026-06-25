using DTO;
using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.Views
{
    public partial class frmUserManager : Form, IUserManagerView
    {
        public frmUserManager()
        {
            InitializeComponent();
            SetControlState(false);
            // Gắn sự kiện khi form vừa mở
            this.Load += (s, e) => LoadData?.Invoke(this, EventArgs.Empty);

            // Gắn sự kiện click trên Grid
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
        }

        // --- 1. THUỘC TÍNH (Lấy/Gán dữ liệu từ Control) ---
        public string Username { get => txtUsername.Text; set => txtUsername.Text = value; }
        public string FullName { get => txtFullName.Text; set => txtFullName.Text = value; }
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }
        public string DefaultTablespace { get => cboDefaultTS.Text; set => cboDefaultTS.Text = value; }
        public string TempTablespace { get => cboTempTS.Text; set => cboTempTS.Text = value; }
        public string QuotaAmount
        {
            get
            {
                string val = txtQuota.Text.Trim().ToUpper();

                if (string.IsNullOrEmpty(val)) return "";

                if (val == "-1" || val == "UNLIMITED") return "UNLIMITED";

                string unit = string.IsNullOrEmpty(cboQuotaUnit.Text) ? "M" : cboQuotaUnit.Text.Trim();
                return val + unit;
            }
            set { txtQuota.Text = value; }
        }
        public bool IsLocked { get => radLock.Checked; set { radLock.Checked = value; radUnlock.Checked = !value; } }
        public bool IsCreating { get; set; } = false;

        // --- 2. SỰ KIỆN (Events) ---
        public event EventHandler LoadData;
        public event EventHandler SaveClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SelectionChanged;

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null && dgvUsers.CurrentRow.DataBoundItem is AppUserDTO user)
            {
                // 1. Điền thông tin cơ bản
                txtUsername.Text = user.Username;
                txtFullName.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtPassword.Clear();

                // 2. Điền Tablespace và trạng thái Lock chính xác từ Oracle
                cboDefaultTS.Text = user.DefaultTablespace;
                cboTempTS.Text = user.TempTablespace;
                radLock.Checked = user.IsLocked;
                radUnlock.Checked = !user.IsLocked;

                // 3. Tách chuỗi Quota thành Số và Đơn vị (M/G)
                if (user.QuotaAmount == "UNLIMITED" || string.IsNullOrEmpty(user.QuotaAmount))
                {
                    txtQuota.Text = user.QuotaAmount == "UNLIMITED" ? "UNLIMITED" : "";
                    cboQuotaUnit.SelectedIndex = -1; 
                }
                else
                {
                    // Ví dụ chuỗi là "50M"
                    string unit = user.QuotaAmount.Substring(user.QuotaAmount.Length - 1); // Lấy chữ 'M'
                    string number = user.QuotaAmount.Substring(0, user.QuotaAmount.Length - 1); // Lấy số '50'

                    txtQuota.Text = number;
                    cboQuotaUnit.Text = unit;
                }
            }
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        // --- 3. PHƯƠNG THỨC HIỂN THỊ (Methods) ---
        public void LoadUserList(List<AppUserDTO> users)
        {
            dgvUsers.DataSource = users;

            // Ẩn tất cả các cột DTO đang có
            foreach (DataGridViewColumn col in dgvUsers.Columns)
            {
                col.Visible = false;
            }

            // Chỉ bật lại đúng 3 cột bạn yêu cầu và đổi tên cho đẹp
            if (dgvUsers.Columns["Username"] != null)
            {
                dgvUsers.Columns["Username"].Visible = true;
                dgvUsers.Columns["Username"].HeaderText = "Username";
            }
            if (dgvUsers.Columns["IsLocked"] != null)
            {
                dgvUsers.Columns["IsLocked"].Visible = true;
                dgvUsers.Columns["IsLocked"].HeaderText = "Đã khóa?";
            }
            if (dgvUsers.Columns["CreatedDate"] != null)
            {
                dgvUsers.Columns["CreatedDate"].Visible = true;
                dgvUsers.Columns["CreatedDate"].HeaderText = "Ngày tạo";
            }
        }

        public void ClearInputFields()
        {
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtQuota.Text = "UNLIMITED";
            radUnlock.Checked = true;
        }

        public void SetControlState(bool isEditing)
        {
            // Bật/tắt các ô nhập liệu
            txtFullName.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtPassword.Enabled = isEditing;
            cboDefaultTS.Enabled = isEditing;
            cboTempTS.Enabled = isEditing;
            txtQuota.Enabled = isEditing;
            cboQuotaUnit.Enabled = isEditing;
            radLock.Enabled = isEditing;
            radUnlock.Enabled = isEditing;

            // Ẩn/Hiện nút Lưu, Hủy
            btnSave.Visible = isEditing;
            btnCancel.Visible = isEditing;

            // Username chỉ cho phép nhập khi Đang Tạo Mới (Không cho sửa Tên Oracle)
            txtUsername.Enabled = IsCreating && isEditing;
        }

        // Hàm này đáp ứng đúng yêu cầu: User không có quyền nào sẽ ẩn nút của quyền đó
        public void SetActionButtonsVisibility(bool canCreate, bool canEdit, bool canDrop)
        {
            btnCreate.Visible = canCreate;
            btnEdit.Visible = canEdit;
            btnDelete.Visible = canDrop;
        }

        public void ShowMessage(string message, bool isError)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        // --- 4. XỬ LÝ NÚT BẤM (Gắn Logic UI cơ bản) ---
        private void btnCreate_Click(object sender, EventArgs e)
        {
            IsCreating = true;
            SetControlState(true);
            ClearInputFields();
            SetActionButtonsVisibility(false, false, false); // Tạm ẩn nút Thêm, Sửa, Xóa
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsCreating = false;
            SetControlState(true);
            txtPassword.Clear(); // Xóa trắng để mồi người dùng nhập pass mới nếu muốn
            SetActionButtonsVisibility(false, false, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            // Gửi tín hiệu để Load lại dữ liệu từ Grid sang các TextBox
            SelectionChanged?.Invoke(this, EventArgs.Empty);
            // Presenter sẽ tính toán lại việc bật các nút Thêm, Sửa, Xóa
            LoadData?.Invoke(this, EventArgs.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
        public void LoadTablespaces(List<string> tablespaces)
        {
            // Tạo một list mới và thêm giá trị rỗng lên đầu
            var listWithEmpty = new List<string> { "" };
            listWithEmpty.AddRange(tablespaces);

            // Gán vào ComboBox
            cboDefaultTS.DataSource = new List<string>(listWithEmpty);
            cboTempTS.DataSource = new List<string>(listWithEmpty);
        }
    }
}