using System;
using System.Collections.Generic;
using DTO;

namespace GUI.Interfaces
{
    public interface IRoleManagerView
    {
        string RoleName { get; set; }
        bool HasPassword { get; set; }
        string Password { get; set; }
        bool IsCreating { get; set; }

        void LoadRoleList(List<AppRoleDTO> roles);
        void SetControlState(bool isEditing);
        void SetActionButtonsVisibility(bool canCreate, bool canEdit, bool canDrop);
        void ShowMessage(string message, bool isError);

        event EventHandler LoadData;
        event EventHandler SaveClicked;
        event EventHandler DeleteClicked;
    }
}