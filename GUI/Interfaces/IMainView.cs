using System;
using DTO;

namespace GUI.Interfaces
{
    public interface IMainView
    {
        // Các hàm để Presenter ra lệnh
        void SetUserMenuVisibility(bool isVisible);
        void SetRoleMenuVisibility(bool isVisible);
        void SetProfileMenuVisibility(bool isVisible);
        void DisplayUserProfile(UserProfileDTO profile);
        event EventHandler LogoutClicked; // Sự kiện khi bấm nút
        bool IsLogout { get; set; }     
        void CloseView();
        event EventHandler OpenUserManagerClicked;
        event EventHandler OpenProfileManagerClicked;
    }
}