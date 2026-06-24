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

            dgvRoles.DataSource = profile.Roles;
            dgvSysPrivs.DataSource = profile.SystemPrivileges;
            dgvObjPrivs.DataSource = profile.ObjectPrivileges;

            if (dgvRoles.Columns.Count > 0)
            {
                dgvRoles.Columns["RoleName"].HeaderText = "Tên Vai Trò (Role)";
                dgvRoles.Columns["IsDirect"].HeaderText = "Cấp Trực Tiếp?";
                dgvRoles.Columns["AdminOption"].HeaderText = "Quyền Gán Cho Người Khác (Admin Option)";
            }

            if (dgvSysPrivs.Columns.Count > 0)
            {
                dgvSysPrivs.Columns["PrivilegeName"].HeaderText = "Tên Quyền Hệ Thống";
                dgvSysPrivs.Columns["GrantedVia"].HeaderText = "Phương Thức Cấp Quyền";
                dgvSysPrivs.Columns["AdminOption"].HeaderText = "Quyền Gán Cho Người Khác";
            }

            if (dgvObjPrivs.Columns.Count > 0)
            {
                dgvObjPrivs.Columns["ObjectName"].HeaderText = "Tên Bảng Dữ Liệu (Table)";
                dgvObjPrivs.Columns["PrivilegeName"].HeaderText = "Thao Tác (Privilege)";
                dgvObjPrivs.Columns["GrantedBy"].HeaderText = "Người Cấp Quyền (Grantor)";
                dgvObjPrivs.Columns["Grantable"].HeaderText = "Quyền Cấp Tiếp (Grant Option)";
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

        private void btnQuanLyUser_Click(object sender, EventArgs e)
        {
            
        }

        private void btnQuanLyRole_Click(object sender, EventArgs e)
        {
            
        }

        private void btnQuanLyProfile_Click(object sender, EventArgs e)
        {
            
        }
    }
}
