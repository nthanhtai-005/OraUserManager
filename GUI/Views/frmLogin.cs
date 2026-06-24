using System;
using System.Windows.Forms;
using GUI.Interfaces;

namespace GUI.Views
{
    public partial class frmLogin : Form, ILoginView
    {
        public frmLogin() { InitializeComponent(); }

        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;

        public event EventHandler LoginAttempted;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginAttempted?.Invoke(this, EventArgs.Empty);
        }

        public void ShowMessage(string message, bool isError)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public void SetLoginSuccess()
        {
            this.DialogResult = DialogResult.OK; // Đánh dấu thành công và đóng form
            this.Close();
        }
    }
}