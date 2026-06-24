using System;
namespace GUI.Interfaces
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }
        event EventHandler LoginAttempted;

        void ShowMessage(string message, bool isError);
        void SetLoginSuccess(); // Ra lệnh cho Form biết đã login thành công
    }
}