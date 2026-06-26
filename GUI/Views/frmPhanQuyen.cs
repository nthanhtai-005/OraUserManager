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
            cboLoaiDoiTuong.SelectedIndex = 0; // Mặc định chọn USER

            // XỬ LÝ GIAO DIỆN KHÓA "WITH GRANT OPTION" NẾU CHỌN ROLE
            cboLoaiDoiTuong.SelectedIndexChanged += (s, e) =>
            {
                bool isRole = (cboLoaiDoiTuong.Text == "ROLE");
                chkGrantOption.Enabled = !isRole; // Khóa mờ checkbox đi
                if (isRole) chkGrantOption.Checked = false; // Tự động uncheck

                GranteeTypeChanged?.Invoke(this, EventArgs.Empty);
            };

            // Gắn sự kiện nút bấm
            btnCapQuyenHT.Click += (s, e) => GrantSysPrivClicked?.Invoke(this, EventArgs.Empty);
            btnThuHoiQuyenHT.Click += (s, e) => RevokeSysPrivClicked?.Invoke(this, EventArgs.Empty);
            btnCapQuyenDT.Click += (s, e) => GrantObjPrivClicked?.Invoke(this, EventArgs.Empty);
            btnThuHoiQuyenDT.Click += (s, e) => RevokeObjPrivClicked?.Invoke(this, EventArgs.Empty);
        }

        public string GranteeType => cboLoaiDoiTuong.Text;
        public string GranteeName => cboTenDoiTuong.Text;
        public string SelectedSysPriv => lstTatCaQuyen.SelectedItem?.ToString() ?? "";
        public bool WithAdminOption { get => chkAdminOption.Checked; set => chkAdminOption.Checked = value; }
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
        public event EventHandler GrantSysPrivClicked;
        public event EventHandler RevokeSysPrivClicked;
        public event EventHandler GrantObjPrivClicked;
        public event EventHandler RevokeObjPrivClicked;

        public void LoadGranteeNames(List<string> names) => cboTenDoiTuong.DataSource = names;
        public void LoadSystemPrivileges(List<string> privs) => lstTatCaQuyen.DataSource = privs;
        public void LoadTables(List<string> tables) => cboTenBang.DataSource = tables;
        public void ShowMessage(string message, bool isError) => MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
    }
}