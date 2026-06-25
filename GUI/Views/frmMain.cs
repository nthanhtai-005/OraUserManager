using DTO;
using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Views
{
    public partial class frmMain : Form, IMainView
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public void DisplayUserProfile(UserProfileDTO profile)
        {
            lblWelcome.Text = $"👋 XIN CHÀO: {profile.FullName}";
            lblUsername.Text = $"Username: {profile.Username}";
            lblEmail.Text = $"Email: {profile.Email}";
            lblCreatedDate.Text = $"Ngày tham gia: {profile.CreatedDate:dd/MM/yyyy}";

            lblAccountStatus.Text = $"Trạng thái: {profile.AccountStatus}";
            lblLockDate.Text = $"Ngày khóa: {profile.LockDate}";
            lblProfile.Text = $"Profile: {profile.ProfileName}";
            lblDefaultTS.Text = $"Default TS: {profile.DefaultTablespace}";
            lblTempTS.Text = $"Temp TS: {profile.TemporaryTablespace}";

            dgvRoles.DataSource = profile.Roles;
            dgvSysPrivs.DataSource = profile.SystemPrivileges;
            dgvObjPrivs.DataSource = profile.ObjectPrivileges;
            dgvQuotas.DataSource = profile.Quotas;

            if (dgvRoles.Columns.Count > 0)
            {
                dgvRoles.Columns["RoleName"].HeaderText = "Tên Vai Trò (Role)";
                dgvRoles.Columns["IsDirect"].HeaderText = "Cấp Trực Tiếp?";
                dgvRoles.Columns["AdminOption"].HeaderText = "Quyền Gán Cho Người Khác";
            }

            if (dgvSysPrivs.Columns.Count > 0)
            {
                dgvSysPrivs.Columns["PrivilegeName"].HeaderText = "Tên Quyền Hệ Thống";
                dgvSysPrivs.Columns["GrantedVia"].HeaderText = "Phương Thức Cấp Quyền";
                dgvSysPrivs.Columns["AdminOption"].HeaderText = "Quyền Gán Cho Người Khác";
            }

            if (dgvObjPrivs.Columns.Count > 0)
            {
                dgvObjPrivs.Columns["ObjectName"].HeaderText = "Tên Đối Tượng";
                dgvObjPrivs.Columns["PrivilegeName"].HeaderText = "Thao Tác (Privilege)";
                dgvObjPrivs.Columns["GrantedBy"].HeaderText = "Người Cấp Quyền";
                dgvObjPrivs.Columns["Grantable"].HeaderText = "Quyền Cấp Tiếp";
            }

            if (dgvQuotas.Columns.Count > 0)
            {
                dgvQuotas.Columns["TablespaceName"].HeaderText = "Tên Tablespace";
                dgvQuotas.Columns["Bytes"].HeaderText = "Đã Sử Dụng (Bytes)";
                dgvQuotas.Columns["MaxBytes"].HeaderText = "Giới Hạn (Max Bytes)";
            }
        }
        public void SetUserMenuVisibility(bool isVisible)
        {
            btnQuanLyUser.Visible = isVisible;
        }

        public void SetRoleMenuVisibility(bool isVisible)
        {
            btnQuanLyRole.Visible = isVisible;
        }

        public void SetProfileMenuVisibility(bool isVisible)
        {
            btnQuanLyProfile.Visible = isVisible;
        }

        public event EventHandler OpenUserManagerClicked;

        private void btnQuanLyUser_Click(object sender, EventArgs e)
        {
            OpenUserManagerClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnQuanLyRole_Click(object sender, EventArgs e)
        {

        }
        public event EventHandler OpenProfileManagerClicked;
        private void btnQuanLyProfile_Click(object sender, EventArgs e)
        {
            OpenProfileManagerClicked?.Invoke(this, EventArgs.Empty);
        }
        public bool IsLogout { get; set; } = false;
        public event EventHandler LogoutClicked;

        public void CloseView()
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogoutClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
