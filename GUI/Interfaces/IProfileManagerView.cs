using System;
using System.Collections.Generic;
using DTO;

namespace GUI.Interfaces
{
    public interface IProfileManagerView
    {
        string ProfileName { get; set; }

        string SessionsPerUser { get; set; }
        string ConnectTime { get; set; }
        string IdleTime { get; set; }

        bool IsCreating { get; set; }

        void LoadProfileList(List<ProfileDTO> profiles);
        void SetControlState(bool isEditing);
        void SetActionButtonsVisibility(bool canCreate, bool canEdit, bool canDrop);
        void ShowMessage(string message, bool isError);

        event EventHandler LoadData;
        event EventHandler SaveClicked;
        event EventHandler DeleteClicked;
    }
}