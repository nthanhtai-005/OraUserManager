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

        string SelectedTable { get; }
        List<string> SelectedObjectPrivs { get; }
        bool WithGrantOption { get; set; }

        void LoadGranteeNames(List<string> names);
        void LoadSystemPrivileges(List<string> privs);
        void LoadTables(List<string> tables);
        void ShowMessage(string message, bool isError);

        event EventHandler GranteeTypeChanged;
        event EventHandler GrantSysPrivClicked;
        event EventHandler RevokeSysPrivClicked;
        event EventHandler GrantObjPrivClicked;
        event EventHandler RevokeObjPrivClicked;
    }
}