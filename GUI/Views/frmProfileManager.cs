using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTO;
using GUI.Interfaces;

namespace GUI.Views
{
    public partial class frmProfileManager : Form, IProfileManagerView
    {
        public frmProfileManager()
        {
            InitializeComponent();
            SetControlState(false);

            // Đăng ký sự kiện bật/tắt ô số dựa theo lựa chọn combobox
            cboSessionsType.SelectedIndexChanged += (s, e) => ToggleNumericInput(cboSessionsType, numSessionsValue);
            cboConnectTimeType.SelectedIndexChanged += (s, e) => ToggleNumericInput(cboConnectTimeType, numConnectTimeValue);
            cboIdleTimeType.SelectedIndexChanged += (s, e) => ToggleNumericInput(cboIdleTimeType, numIdleTimeValue);

            this.Load += (s, e) => LoadData?.Invoke(this, EventArgs.Empty);
            dgvProfiles.SelectionChanged += DgvProfiles_SelectionChanged;
        }

        public string ProfileName { get => txtProfileName.Text; set => txtProfileName.Text = value; }

        // Logic đóng gói: Nếu chọn CUSTOM thì lấy giá trị ô số, ngược lại lấy chữ UNLIMITED/DEFAULT
        public string SessionsPerUser { get => GetResourceValue(cboSessionsType, numSessionsValue); set => SetResourceValue(value, cboSessionsType, numSessionsValue); }
        public string ConnectTime { get => GetResourceValue(cboConnectTimeType, numConnectTimeValue); set => SetResourceValue(value, cboConnectTimeType, numConnectTimeValue); }
        public string IdleTime { get => GetResourceValue(cboIdleTimeType, numIdleTimeValue); set => SetResourceValue(value, cboIdleTimeType, numIdleTimeValue); }

        public bool IsCreating { get; set; } = false;

        public event EventHandler LoadData;
        public event EventHandler SaveClicked;
        public event EventHandler DeleteClicked;

        private string GetResourceValue(ComboBox cbo, NumericUpDown num)
        {
            if (cbo.Text == "CUSTOM") return num.Value.ToString();
            return cbo.Text;
        }

        private void SetResourceValue(string rawValue, ComboBox cbo, NumericUpDown num)
        {
            if (rawValue == "UNLIMITED" || rawValue == "DEFAULT" || string.IsNullOrEmpty(rawValue))
            {
                cbo.Text = string.IsNullOrEmpty(rawValue) ? "DEFAULT" : rawValue;
                num.Value = 1;
            }
            else
            {
                cbo.Text = "CUSTOM";
                if (decimal.TryParse(rawValue, out decimal res)) num.Value = res;
            }
        }

        private void ToggleNumericInput(ComboBox cbo, NumericUpDown num)
        {
            num.Enabled = (cbo.Text == "CUSTOM") && txtProfileName.Enabled;
            if (!num.Enabled) num.Value = 1;
        }

        public void LoadProfileList(List<ProfileDTO> profiles)
        {
            dgvProfiles.DataSource = profiles;
        }

        public void SetControlState(bool isEditing)
        {
            txtProfileName.Enabled = IsCreating && isEditing; // Không cho sửa tên Profile cũ
            cboSessionsType.Enabled = isEditing;
            cboConnectTimeType.Enabled = isEditing;
            cboIdleTimeType.Enabled = isEditing;

            ToggleNumericInput(cboSessionsType, numSessionsValue);
            ToggleNumericInput(cboConnectTimeType, numConnectTimeValue);
            ToggleNumericInput(cboIdleTimeType, numIdleTimeValue);

            btnSave.Visible = isEditing;
            btnCancel.Visible = isEditing;
        }

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

        private void DgvProfiles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfiles.CurrentRow != null && dgvProfiles.CurrentRow.DataBoundItem is ProfileDTO prof)
            {
                ProfileName = prof.ProfileName;
                SessionsPerUser = prof.SessionsPerUser;
                ConnectTime = prof.ConnectTime;
                IdleTime = prof.IdleTime;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            IsCreating = true;
            SetControlState(true);
            txtProfileName.Clear();
            cboSessionsType.Text = "DEFAULT";
            cboConnectTimeType.Text = "DEFAULT";
            cboIdleTimeType.Text = "DEFAULT";
            SetActionButtonsVisibility(false, false, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsCreating = false;
            SetControlState(true);
            SetActionButtonsVisibility(false, false, false);
        }

        private void btnSave_Click(object sender, EventArgs e) => SaveClicked?.Invoke(this, EventArgs.Empty);
        private void btnDelete_Click(object sender, EventArgs e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
        private void btnCancel_Click(object sender, EventArgs e) { SetControlState(false); LoadData?.Invoke(this, EventArgs.Empty); }
    }
}