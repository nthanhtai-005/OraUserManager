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

            // 3. Chạy Form Login dưới dạng Dialog chờ kết quả
            Application.Run(loginView);

            // 4. Kiểm tra: Nếu Form Login đóng và trả về OK, mới mở Main Form
            if (loginView.DialogResult == DialogResult.OK)
            {
                // Lắp ráp Form Main theo chuẩn MVP trước khi hiển thị
                var mainView = new frmMain();
                var mainPresenter = new MainPresenter(mainView); // MainPresenter không do frmMain tự new nữa!

                // Mở Form Main làm form chính của App
                Application.Run(mainView);
            }
        }
    }
}