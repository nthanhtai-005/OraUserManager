using System;
using System.Windows.Forms;
using GUI.Views;
using GUI.Presenters;
using BLL.Services.Implementations;
using DAL.Repositories.Implementations;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var authRepo = new AuthRepo();
            var authService = new AuthService(authRepo);

            bool keepRunning = true;
            while (keepRunning)
            {
                var loginView = new frmLogin();
                var loginPresenter = new LoginPresenter(loginView, authService);

                if (loginView.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var mainView = new frmMain();
                        var mainPresenter = new MainPresenter(mainView, authService, loginView.Password);

                        Application.Run(mainView);
                        keepRunning = mainView.IsLogout;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        keepRunning = false;
                    }
                }
                else
                {
                    keepRunning = false;
                }
            }
        }
    }
}