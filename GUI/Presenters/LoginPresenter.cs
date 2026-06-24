using System;
using GUI.Interfaces;
using BLL.Services.Interfaces;

namespace GUI.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IAuthService _authService;

        public LoginPresenter(ILoginView view, IAuthService authService)
        {
            _view = view;
            _authService = authService;
            _view.LoginAttempted += OnLoginAttempted;
        }

        private void OnLoginAttempted(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.Username) || string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.ShowMessage("Vui lòng nhập đầy đủ!", true);
                return;
            }

            bool isSuccess = _authService.Login(_view.Username, _view.Password);
            if (isSuccess)
            {
                _view.ShowMessage("Đăng nhập thành công!", false);
                _view.SetLoginSuccess(); // Gửi tín hiệu về cho File Program.cs xử lý chuyển Form
            }
            else
            {
                _view.ShowMessage("Sai thông tin đăng nhập!", true);
            }
        }
    }
}