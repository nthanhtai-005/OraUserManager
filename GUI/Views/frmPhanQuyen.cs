using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GUI.Interfaces;

namespace GUI.Views
{
    public partial class frmPhanQuyen : Form, IPhanQuyenView
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
            cboLoaiDoiTuong.SelectedIndex = 0;

            // Cập nhật giao diện khi đổi Loại Đối Tượng (Khóa sạch mọi Option nếu chọn ROLE)
            cboLoaiDoiTuong.SelectedIndexChanged += (s, e) =>
            {
                bool isRole = (cboLoaiDoiTuong.Text == "ROLE");
                chkAdminOption.Enabled = !isRole;
                chkGrantOption.Enabled = !isRole;
                chkRoleAdminOption.Enabled = !isRole;

                if (isRole)
                {
                    chkAdminOption.Checked = false;
                    chkGrantOption.Checked = false;
                    chkRoleAdminOption.Checked = false;
                }
                GranteeTypeChanged?.Invoke(this, EventArgs.Empty);
            };

            cboTenDoiTuong.SelectedIndexChanged += (s, e) => GranteeNameChanged?.Invoke(this, EventArgs.Empty);

            btnCapQuyenHT.Click += (s, e) => GrantSysPrivClicked?.Invoke(this, EventArgs.Empty);
            btnThuHoiQuyenHT.Click += (s, e) => RevokeSysPrivClicked?.Invoke(this, EventArgs.Empty);
            btnCapRole.Click += (s, e) => GrantRoleClicked?.Invoke(this, EventArgs.Empty);
            btnThuHoiRole.Click += (s, e) => RevokeRoleClicked?.Invoke(this, EventArgs.Empty);
            btnCapQuyenDT.Click += (s, e) => GrantObjPrivClicked?.Invoke(this, EventArgs.Empty);
            btnThuHoiQuyenDT.Click += (s, e) => RevokeObjPrivClicked?.Invoke(this, EventArgs.Empty);
        }

        public string GranteeType => cboLoaiDoiTuong.Text;
        public string GranteeName => cboTenDoiTuong.Text;

        public string SelectedSysPriv => lstTatCaQuyen.SelectedItem?.ToString() ?? "";
        public string SelectedGrantedSysPriv => lstQuyenDaCap.SelectedItem?.ToString() ?? "";
        public bool WithAdminOption { get => chkAdminOption.Checked; set => chkAdminOption.Checked = value; }

        public string SelectedRole => lstTatCaRole.SelectedItem?.ToString() ?? "";
        public string SelectedGrantedRole => lstRoleDaCap.SelectedItem?.ToString() ?? "";
        public bool WithRoleAdminOption { get => chkRoleAdminOption.Checked; set => chkRoleAdminOption.Checked = value; }

        public string SelectedTable => cboTenBang.Text;
        public bool WithGrantOption { get => chkGrantOption.Checked; set => chkGrantOption.Checked = value; }

        public List<string> SelectedObjectPrivs
        {
            get
            {
                var list = new List<string>();
                if (chkSelect.Checked) list.Add("SELECT");
                if (chkInsert.Checked) list.Add("INSERT");
                if (chkUpdate.Checked) list.Add("UPDATE");
                if (chkDelete.Checked) list.Add("DELETE");
                return list;
            }
        }

        public event EventHandler GranteeTypeChanged;
        public event EventHandler GranteeNameChanged;
        public event EventHandler GrantSysPrivClicked;
        public event EventHandler RevokeSysPrivClicked;
        public event EventHandler GrantRoleClicked;
        public event EventHandler RevokeRoleClicked;
        public event EventHandler GrantObjPrivClicked;
        public event EventHandler RevokeObjPrivClicked;

        public void LoadGranteeNames(List<string> names) => cboTenDoiTuong.DataSource = names;
        public void LoadSystemPrivileges(List<string> privs) => lstTatCaQuyen.DataSource = privs;
        public void LoadRoles(List<string> roles) => lstTatCaRole.DataSource = roles;
        public void LoadTables(List<string> tables) => cboTenBang.DataSource = tables;

        public void LoadGrantedSystemPrivileges(List<string> privs) => lstQuyenDaCap.DataSource = privs;
        public void LoadGrantedRoles(List<string> roles) => lstRoleDaCap.DataSource = roles;
        public void LoadGrantedObjectPrivileges(object dataSource) => dgvQuyenDoiTuong.DataSource = dataSource;

        public void ShowMessage(string message, bool isError) => MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
    }
}