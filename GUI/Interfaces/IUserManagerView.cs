using DTO;
using System;
using System.Collections.Generic;

namespace GUI.Interfaces
{
    public interface IUserManagerView
    {
        // 1. Dữ liệu trên Form (Properties)
        string Username { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string DefaultTablespace { get; set; }
        string TempTablespace { get; set; }
        string QuotaAmount { get; set; }
        bool IsLocked { get; set; }

        // Trạng thái Form
        bool IsCreating { get; set; }

        // 2. Phương thức hiển thị (Methods)
        void LoadUserList(List<AppUserDTO> users);
        void SetControlState(bool isEditing);
        void SetActionButtonsVisibility(bool canCreate, bool canEdit, bool canDrop);
        void ShowMessage(string message, bool isError);
        void ClearInputFields();
        void LoadTablespaces(List<string> tablespaces);

        // 3. Sự kiện người dùng thao tác (Events)
        event EventHandler LoadData;
        event EventHandler SaveClicked;
        event EventHandler DeleteClicked;
        event EventHandler SelectionChanged;
    }
}