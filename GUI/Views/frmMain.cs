using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Interfaces;

namespace GUI.Views
{
    public partial class frmMain : Form, IMainView
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public void SetUserMenuVisibility(bool isVisible)
        {
            btnQuanLyUser.Visible = isVisible; // Hoặc .Enabled = isVisible
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
