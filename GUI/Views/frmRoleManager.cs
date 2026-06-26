using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTO;
using GUI.Interfaces;

namespace GUI.Views
{
    public partial class frmRoleManager : Form, IRoleManagerView
    {
        public frmRoleManager()
        {
            InitializeComponent();

            SetControlState(false);

            chkHasPassword.CheckedChanged += (s, e) =>
            {
                txtPassword.Enabled = chkHasPassword.Checked && btnSave.Visible;

                if (!chkHasPassword.Checked) txtPassword.Clear();
            };

            this.Load += (s, e) => LoadData?.Invoke(this, EventArgs.Empty);

            dgvRoles.SelectionChanged += DgvRoles_SelectionChanged;
        }

        public string RoleName { get => txtRoleName.Text; set => txtRoleName.Text = value; }
        public bool HasPassword { get => chkHasPassword.Checked; set => chkHasPassword.Checked = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }
        public bool IsCreating { get; set; } = false;

        public event EventHandler LoadData;
        public event EventHandler SaveClicked;
        public event EventHandler DeleteClicked;

        public void LoadRoleList(List<AppRoleDTO> roles)
        {
            dgvRoles.DataSource = roles;

            if (dgvRoles.Columns["RoleName"] != null)
                dgvRoles.Columns["RoleName"].HeaderText = "Tên Role";

            if (dgvRoles.Columns["PasswordRequired"] != null)
                dgvRoles.Columns["PasswordRequired"].HeaderText = "Yêu cầu Mật khẩu?";

            if (dgvRoles.Columns["RawPassword"] != null)
                dgvRoles.Columns["RawPassword"].Visible = false; // Ẩn cột pass thô
        }

        public void SetControlState(bool isEditing)
        {
            txtRoleName.Enabled = IsCreating && isEditing; 
            chkHasPassword.Enabled = isEditing;

            txtPassword.Enabled = isEditing && chkHasPassword.Checked;

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

        private void DgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow != null && dgvRoles.CurrentRow.DataBoundItem is AppRoleDTO role)
            {
                txtRoleName.Text = role.RoleName;
                chkHasPassword.Checked = (role.PasswordRequired == "YES");
                txtPassword.Clear(); 
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            IsCreating = true;
            SetControlState(true);
            txtRoleName.Clear();
            chkHasPassword.Checked = false;
            txtPassword.Clear();
            SetActionButtonsVisibility(false, false, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsCreating = false;
            SetControlState(true);
            txtPassword.Clear();
            SetActionButtonsVisibility(false, false, false);
        }

        private void btnSave_Click(object sender, EventArgs e) => SaveClicked?.Invoke(this, EventArgs.Empty);
        private void btnDelete_Click(object sender, EventArgs e) => DeleteClicked?.Invoke(this, EventArgs.Empty);

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            LoadData?.Invoke(this, EventArgs.Empty);
        }
    }
}