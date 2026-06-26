namespace GUI.Views
{
    partial class frmPhanQuyen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTenDoiTuong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLoaiDoiTuong = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSysPrivs = new System.Windows.Forms.TabPage();
            this.chkAdminOption = new System.Windows.Forms.CheckBox();
            this.btnThuHoiQuyenHT = new System.Windows.Forms.Button();
            this.btnCapQuyenHT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstQuyenDaCap = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstTatCaQuyen = new System.Windows.Forms.ListBox();
            this.tabRolePrivs = new System.Windows.Forms.TabPage();
            this.chkRoleAdminOption = new System.Windows.Forms.CheckBox();
            this.btnThuHoiRole = new System.Windows.Forms.Button();
            this.btnCapRole = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lstRoleDaCap = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstTatCaRole = new System.Windows.Forms.ListBox();
            this.tabObjPrivs = new System.Windows.Forms.TabPage();
            this.dgvQuyenDoiTuong = new System.Windows.Forms.DataGridView();
            this.btnThuHoiQuyenDT = new System.Windows.Forms.Button();
            this.btnCapQuyenDT = new System.Windows.Forms.Button();
            this.chkGrantOption = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.cboTenBang = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSysPrivs.SuspendLayout();
            this.tabRolePrivs.SuspendLayout();
            this.tabObjPrivs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyenDoiTuong)).BeginInit();
            this.SuspendLayout();
            // groupBox1
            this.groupBox1.Controls.Add(this.cboTenDoiTuong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboLoaiDoiTuong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 83);
            // cboTenDoiTuong
            this.cboTenDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenDoiTuong.Location = new System.Drawing.Point(495, 34);
            this.cboTenDoiTuong.Name = "cboTenDoiTuong";
            this.cboTenDoiTuong.Size = new System.Drawing.Size(262, 28);
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 37);
            this.label2.Name = "label2";
            this.label2.Text = "Tên User/Role:";
            // cboLoaiDoiTuong
            this.cboLoaiDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiDoiTuong.Items.AddRange(new object[] { "USER", "ROLE" });
            this.cboLoaiDoiTuong.Location = new System.Drawing.Point(125, 34);
            this.cboLoaiDoiTuong.Name = "cboLoaiDoiTuong";
            this.cboLoaiDoiTuong.Size = new System.Drawing.Size(168, 28);
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Text = "Cấp quyền cho:";
            // tabControl1
            this.tabControl1.Controls.Add(this.tabSysPrivs);
            this.tabControl1.Controls.Add(this.tabRolePrivs);
            this.tabControl1.Controls.Add(this.tabObjPrivs);
            this.tabControl1.Location = new System.Drawing.Point(12, 114);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 420);
            // tabSysPrivs
            this.tabSysPrivs.Controls.Add(this.chkAdminOption);
            this.tabSysPrivs.Controls.Add(this.btnThuHoiQuyenHT);
            this.tabSysPrivs.Controls.Add(this.btnCapQuyenHT);
            this.tabSysPrivs.Controls.Add(this.label4);
            this.tabSysPrivs.Controls.Add(this.lstQuyenDaCap);
            this.tabSysPrivs.Controls.Add(this.label3);
            this.tabSysPrivs.Controls.Add(this.lstTatCaQuyen);
            this.tabSysPrivs.Location = new System.Drawing.Point(4, 29);
            this.tabSysPrivs.Name = "tabSysPrivs";
            this.tabSysPrivs.Padding = new System.Windows.Forms.Padding(3);
            this.tabSysPrivs.Size = new System.Drawing.Size(842, 387);
            this.tabSysPrivs.Text = "1. QUYỀN HỆ THỐNG";
            this.tabSysPrivs.UseVisualStyleBackColor = true;
            // chkAdminOption
            this.chkAdminOption.AutoSize = true;
            this.chkAdminOption.ForeColor = System.Drawing.Color.Red;
            this.chkAdminOption.Location = new System.Drawing.Point(336, 280);
            this.chkAdminOption.Name = "chkAdminOption";
            this.chkAdminOption.Size = new System.Drawing.Size(171, 24);
            this.chkAdminOption.Text = "WITH ADMIN OPTION";
            // btnThuHoiQuyenHT
            this.btnThuHoiQuyenHT.Location = new System.Drawing.Point(365, 203);
            this.btnThuHoiQuyenHT.Name = "btnThuHoiQuyenHT";
            this.btnThuHoiQuyenHT.Size = new System.Drawing.Size(110, 48);
            this.btnThuHoiQuyenHT.Text = "<< REVOKE";
            // btnCapQuyenHT
            this.btnCapQuyenHT.Location = new System.Drawing.Point(365, 128);
            this.btnCapQuyenHT.Name = "btnCapQuyenHT";
            this.btnCapQuyenHT.Size = new System.Drawing.Size(110, 48);
            this.btnCapQuyenHT.Text = "GRANT >>";
            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 23);
            this.label4.Name = "label4";
            this.label4.Text = "Quyền HT đang sở hữu:";
            // lstQuyenDaCap
            this.lstQuyenDaCap.FormattingEnabled = true;
            this.lstQuyenDaCap.ItemHeight = 20;
            this.lstQuyenDaCap.Location = new System.Drawing.Point(499, 46);
            this.lstQuyenDaCap.Name = "lstQuyenDaCap";
            this.lstQuyenDaCap.Size = new System.Drawing.Size(320, 304);
            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 23);
            this.label3.Name = "label3";
            this.label3.Text = "Tất cả Quyền HT:";
            // lstTatCaQuyen
            this.lstTatCaQuyen.FormattingEnabled = true;
            this.lstTatCaQuyen.ItemHeight = 20;
            this.lstTatCaQuyen.Location = new System.Drawing.Point(21, 46);
            this.lstTatCaQuyen.Name = "lstTatCaQuyen";
            this.lstTatCaQuyen.Size = new System.Drawing.Size(320, 304);
            // tabRolePrivs
            this.tabRolePrivs.Controls.Add(this.chkRoleAdminOption);
            this.tabRolePrivs.Controls.Add(this.btnThuHoiRole);
            this.tabRolePrivs.Controls.Add(this.btnCapRole);
            this.tabRolePrivs.Controls.Add(this.label6);
            this.tabRolePrivs.Controls.Add(this.lstRoleDaCap);
            this.tabRolePrivs.Controls.Add(this.label7);
            this.tabRolePrivs.Controls.Add(this.lstTatCaRole);
            this.tabRolePrivs.Location = new System.Drawing.Point(4, 29);
            this.tabRolePrivs.Name = "tabRolePrivs";
            this.tabRolePrivs.Padding = new System.Windows.Forms.Padding(3);
            this.tabRolePrivs.Size = new System.Drawing.Size(842, 387);
            this.tabRolePrivs.Text = "2. CẤP VAI TRÒ (ROLE)";
            this.tabRolePrivs.UseVisualStyleBackColor = true;
            // chkRoleAdminOption
            this.chkRoleAdminOption.AutoSize = true;
            this.chkRoleAdminOption.ForeColor = System.Drawing.Color.Red;
            this.chkRoleAdminOption.Location = new System.Drawing.Point(336, 280);
            this.chkRoleAdminOption.Name = "chkRoleAdminOption";
            this.chkRoleAdminOption.Size = new System.Drawing.Size(171, 24);
            this.chkRoleAdminOption.Text = "WITH ADMIN OPTION";
            // btnThuHoiRole
            this.btnThuHoiRole.Location = new System.Drawing.Point(365, 203);
            this.btnThuHoiRole.Name = "btnThuHoiRole";
            this.btnThuHoiRole.Size = new System.Drawing.Size(110, 48);
            this.btnThuHoiRole.Text = "<< REVOKE";
            // btnCapRole
            this.btnCapRole.Location = new System.Drawing.Point(365, 128);
            this.btnCapRole.Name = "btnCapRole";
            this.btnCapRole.Size = new System.Drawing.Size(110, 48);
            this.btnCapRole.Text = "GRANT >>";
            // label6
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(495, 23);
            this.label6.Name = "label6";
            this.label6.Text = "Role đang sở hữu:";
            // lstRoleDaCap
            this.lstRoleDaCap.FormattingEnabled = true;
            this.lstRoleDaCap.ItemHeight = 20;
            this.lstRoleDaCap.Location = new System.Drawing.Point(499, 46);
            this.lstRoleDaCap.Name = "lstRoleDaCap";
            this.lstRoleDaCap.Size = new System.Drawing.Size(320, 304);
            // label7
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 23);
            this.label7.Name = "label7";
            this.label7.Text = "Tất cả Role:";
            // lstTatCaRole
            this.lstTatCaRole.FormattingEnabled = true;
            this.lstTatCaRole.ItemHeight = 20;
            this.lstTatCaRole.Location = new System.Drawing.Point(21, 46);
            this.lstTatCaRole.Name = "lstTatCaRole";
            this.lstTatCaRole.Size = new System.Drawing.Size(320, 304);
            // tabObjPrivs
            this.tabObjPrivs.Controls.Add(this.dgvQuyenDoiTuong);
            this.tabObjPrivs.Controls.Add(this.btnThuHoiQuyenDT);
            this.tabObjPrivs.Controls.Add(this.btnCapQuyenDT);
            this.tabObjPrivs.Controls.Add(this.chkGrantOption);
            this.tabObjPrivs.Controls.Add(this.chkDelete);
            this.tabObjPrivs.Controls.Add(this.chkUpdate);
            this.tabObjPrivs.Controls.Add(this.chkInsert);
            this.tabObjPrivs.Controls.Add(this.chkSelect);
            this.tabObjPrivs.Controls.Add(this.cboTenBang);
            this.tabObjPrivs.Controls.Add(this.label5);
            this.tabObjPrivs.Location = new System.Drawing.Point(4, 29);
            this.tabObjPrivs.Name = "tabObjPrivs";
            this.tabObjPrivs.Size = new System.Drawing.Size(842, 387);
            this.tabObjPrivs.Text = "3. QUYỀN ĐỐI TƯỢNG";
            // dgvQuyenDoiTuong
            this.dgvQuyenDoiTuong.AllowUserToAddRows = false;
            this.dgvQuyenDoiTuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuyenDoiTuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuyenDoiTuong.Location = new System.Drawing.Point(17, 131);
            this.dgvQuyenDoiTuong.Name = "dgvQuyenDoiTuong";
            this.dgvQuyenDoiTuong.ReadOnly = true;
            this.dgvQuyenDoiTuong.Size = new System.Drawing.Size(806, 237);
            // btnThuHoiQuyenDT
            this.btnThuHoiQuyenDT.Location = new System.Drawing.Point(707, 76);
            this.btnThuHoiQuyenDT.Name = "btnThuHoiQuyenDT";
            this.btnThuHoiQuyenDT.Size = new System.Drawing.Size(116, 29);
            this.btnThuHoiQuyenDT.Text = "REVOKE";
            // btnCapQuyenDT
            this.btnCapQuyenDT.Location = new System.Drawing.Point(585, 76);
            this.btnCapQuyenDT.Name = "btnCapQuyenDT";
            this.btnCapQuyenDT.Size = new System.Drawing.Size(116, 29);
            this.btnCapQuyenDT.Text = "GRANT";
            // chkGrantOption
            this.chkGrantOption.AutoSize = true;
            this.chkGrantOption.ForeColor = System.Drawing.Color.Red;
            this.chkGrantOption.Location = new System.Drawing.Point(585, 34);
            this.chkGrantOption.Name = "chkGrantOption";
            this.chkGrantOption.Size = new System.Drawing.Size(173, 24);
            this.chkGrantOption.Text = "WITH GRANT OPTION";
            // chkDelete
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(395, 81);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(82, 24);
            this.chkDelete.Text = "DELETE";
            // chkUpdate
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(290, 81);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(88, 24);
            this.chkUpdate.Text = "UPDATE";
            // chkInsert
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(191, 81);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(81, 24);
            this.chkInsert.Text = "INSERT";
            // chkSelect
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(92, 81);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(81, 24);
            this.chkSelect.Text = "SELECT";
            // cboTenBang
            this.cboTenBang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenBang.Location = new System.Drawing.Point(92, 32);
            this.cboTenBang.Name = "cboTenBang";
            this.cboTenBang.Size = new System.Drawing.Size(359, 28);
            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 35);
            this.label5.Name = "label5";
            this.label5.Text = "Tên Bảng:";
            // frmPhanQuyen
            this.ClientSize = new System.Drawing.Size(874, 546);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPhanQuyen";
            this.Text = "Quản Lý Phân Quyền Oracle (3 Tầng)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabSysPrivs.ResumeLayout(false);
            this.tabSysPrivs.PerformLayout();
            this.tabRolePrivs.ResumeLayout(false);
            this.tabRolePrivs.PerformLayout();
            this.tabObjPrivs.ResumeLayout(false);
            this.tabObjPrivs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyenDoiTuong)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboLoaiDoiTuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTenDoiTuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSysPrivs;
        private System.Windows.Forms.TabPage tabRolePrivs;
        private System.Windows.Forms.TabPage tabObjPrivs;
        private System.Windows.Forms.ListBox lstTatCaQuyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstQuyenDaCap;
        private System.Windows.Forms.Button btnThuHoiQuyenHT;
        private System.Windows.Forms.Button btnCapQuyenHT;
        private System.Windows.Forms.CheckBox chkAdminOption;

        private System.Windows.Forms.ListBox lstTatCaRole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstRoleDaCap;
        private System.Windows.Forms.Button btnThuHoiRole;
        private System.Windows.Forms.Button btnCapRole;
        private System.Windows.Forms.CheckBox chkRoleAdminOption;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTenBang;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkGrantOption;
        private System.Windows.Forms.Button btnThuHoiQuyenDT;
        private System.Windows.Forms.Button btnCapQuyenDT;
        private System.Windows.Forms.DataGridView dgvQuyenDoiTuong;
    }
}