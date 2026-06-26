using System;
using System.Collections.Generic;

namespace GUI.Interfaces
{
    public interface IPhanQuyenView
    {
        string GranteeType { get; }
        string GranteeName { get; }

        string SelectedSysPriv { get; }
        bool WithAdminOption { get; set; }

        string SelectedRole { get; }
        bool WithRoleAdminOption { get; set; }

        string SelectedTable { get; }
        List<string> SelectedObjectPrivs { get; }
        bool WithGrantOption { get; set; }

        void LoadGranteeNames(List<string> names);
        void LoadSystemPrivileges(List<string> privs);
        void LoadRoles(List<string> roles);
        void LoadTables(List<string> tables);

        void LoadGrantedSystemPrivileges(List<string> privs);
        void LoadGrantedRoles(List<string> roles);
        void LoadGrantedObjectPrivileges(object dataSource);

        void ShowMessage(string message, bool isError);
        string SelectedGrantedSysPriv { get; } // Đọc quyền đang chọn ở ListBox đã cấp
        string SelectedGrantedRole { get; }    // Đọc Role đang chọn ở ListBox đã cấp

        event EventHandler GranteeTypeChanged;
        event EventHandler GranteeNameChanged;
        event EventHandler GrantSysPrivClicked;
        event EventHandler RevokeSysPrivClicked;
        event EventHandler GrantRoleClicked;
        event EventHandler RevokeRoleClicked;
        event EventHandler GrantObjPrivClicked;
        event EventHandler RevokeObjPrivClicked;
    }
}