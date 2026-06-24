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

            // 1. Khởi tạo các Dependencies
            var authRepo = new AuthRepo();
            var authService = new AuthService(authRepo);

            // 2. Lắp ráp Form Login
            var loginView = new frmLogin();
            var loginPresenter = new LoginPresenter(loginView, authService);

            if (loginView.ShowDialog() == DialogResult.OK)
            {
                // Lắp ráp Form Main theo chuẩn MVP trước khi hiển thị
                var mainView = new frmMain();
                var mainPresenter = new MainPresenter(mainView, authService, loginView.Password);

                // Mở Form Main làm form chính của App
                Application.Run(mainView);
            }
        }
    }
}