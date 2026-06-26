namespace GUI.Views
{
    partial class frmPhanQuyen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
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
            this.tabObjPrivs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyenDoiTuong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTenDoiTuong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboLoaiDoiTuong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. CHỌN ĐỐI TƯỢNG CẤP QUYỀN (GRANTEE)";
            // 
            // cboTenDoiTuong
            // 
            this.cboTenDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenDoiTuong.FormattingEnabled = true;
            this.cboTenDoiTuong.Location = new System.Drawing.Point(495, 34);
            this.cboTenDoiTuong.Name = "cboTenDoiTuong";
            this.cboTenDoiTuong.Size = new System.Drawing.Size(262, 28);
            this.cboTenDoiTuong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên User/Role:";
            // 
            // cboLoaiDoiTuong
            // 
            this.cboLoaiDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiDoiTuong.FormattingEnabled = true;
            this.cboLoaiDoiTuong.Items.AddRange(new object[] {
            "USER",
            "ROLE"});
            this.cboLoaiDoiTuong.Location = new System.Drawing.Point(125, 34);
            this.cboLoaiDoiTuong.Name = "cboLoaiDoiTuong";
            this.cboLoaiDoiTuong.Size = new System.Drawing.Size(168, 28);
            this.cboLoaiDoiTuong.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cấp quyền cho:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSysPrivs);
            this.tabControl1.Controls.Add(this.tabObjPrivs);
            this.tabControl1.Location = new System.Drawing.Point(12, 114);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 420);
            this.tabControl1.TabIndex = 1;
            // 
            // tabSysPrivs
            // 
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
            this.tabSysPrivs.TabIndex = 0;
            this.tabSysPrivs.Text = "QUYỀN HỆ THỐNG (System Privileges)";
            this.tabSysPrivs.UseVisualStyleBackColor = true;
            // 
            // chkAdminOption
            // 
            this.chkAdminOption.AutoSize = true;
            this.chkAdminOption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkAdminOption.ForeColor = System.Drawing.Color.Red;
            this.chkAdminOption.Location = new System.Drawing.Point(336, 280);
            this.chkAdminOption.Name = "chkAdminOption";
            this.chkAdminOption.Size = new System.Drawing.Size(171, 24);
            this.chkAdminOption.TabIndex = 6;
            this.chkAdminOption.Text = "WITH ADMIN OPTION";
            this.chkAdminOption.UseVisualStyleBackColor = true;
            // 
            // btnThuHoiQuyenHT
            // 
            this.btnThuHoiQuyenHT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThuHoiQuyenHT.Location = new System.Drawing.Point(365, 203);
            this.btnThuHoiQuyenHT.Name = "btnThuHoiQuyenHT";
            this.btnThuHoiQuyenHT.Size = new System.Drawing.Size(110, 48);
            this.btnThuHoiQuyenHT.TabIndex = 5;
            this.btnThuHoiQuyenHT.Text = "<< REVOKE";
            this.btnThuHoiQuyenHT.UseVisualStyleBackColor = true;
            // 
            // btnCapQuyenHT
            // 
            this.btnCapQuyenHT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCapQuyenHT.Location = new System.Drawing.Point(365, 128);
            this.btnCapQuyenHT.Name = "btnCapQuyenHT";
            this.btnCapQuyenHT.Size = new System.Drawing.Size(110, 48);
            this.btnCapQuyenHT.TabIndex = 4;
            this.btnCapQuyenHT.Text = "GRANT >>";
            this.btnCapQuyenHT.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(495, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quyền đang sở hữu:";
            // 
            // lstQuyenDaCap
            // 
            this.lstQuyenDaCap.FormattingEnabled = true;
            this.lstQuyenDaCap.ItemHeight = 20;
            this.lstQuyenDaCap.Location = new System.Drawing.Point(499, 46);
            this.lstQuyenDaCap.Name = "lstQuyenDaCap";
            this.lstQuyenDaCap.Size = new System.Drawing.Size(320, 304);
            this.lstQuyenDaCap.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(17, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Danh sách quyền hệ thống:";
            // 
            // lstTatCaQuyen
            // 
            this.lstTatCaQuyen.FormattingEnabled = true;
            this.lstTatCaQuyen.ItemHeight = 20;
            this.lstTatCaQuyen.Location = new System.Drawing.Point(21, 46);
            this.lstTatCaQuyen.Name = "lstTatCaQuyen";
            this.lstTatCaQuyen.Size = new System.Drawing.Size(320, 304);
            this.lstTatCaQuyen.TabIndex = 0;
            // 
            // tabObjPrivs
            // 
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
            this.tabObjPrivs.Padding = new System.Windows.Forms.Padding(3);
            this.tabObjPrivs.Size = new System.Drawing.Size(842, 387);
            this.tabObjPrivs.TabIndex = 1;
            this.tabObjPrivs.Text = "QUYỀN ĐỐI TƯỢNG (Bảng/View)";
            this.tabObjPrivs.UseVisualStyleBackColor = true;
            // 
            // dgvQuyenDoiTuong
            // 
            this.dgvQuyenDoiTuong.AllowUserToAddRows = false;
            this.dgvQuyenDoiTuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuyenDoiTuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuyenDoiTuong.Location = new System.Drawing.Point(17, 131);
            this.dgvQuyenDoiTuong.Name = "dgvQuyenDoiTuong";
            this.dgvQuyenDoiTuong.ReadOnly = true;
            this.dgvQuyenDoiTuong.RowHeadersWidth = 51;
            this.dgvQuyenDoiTuong.Size = new System.Drawing.Size(806, 237);
            this.dgvQuyenDoiTuong.TabIndex = 9;
            // 
            // btnThuHoiQuyenDT
            // 
            this.btnThuHoiQuyenDT.Location = new System.Drawing.Point(707, 76);
            this.btnThuHoiQuyenDT.Name = "btnThuHoiQuyenDT";
            this.btnThuHoiQuyenDT.Size = new System.Drawing.Size(116, 29);
            this.btnThuHoiQuyenDT.TabIndex = 8;
            this.btnThuHoiQuyenDT.Text = "Thu Hồi (REVOKE)";
            this.btnThuHoiQuyenDT.UseVisualStyleBackColor = true;
            // 
            // btnCapQuyenDT
            // 
            this.btnCapQuyenDT.Location = new System.Drawing.Point(585, 76);
            this.btnCapQuyenDT.Name = "btnCapQuyenDT";
            this.btnCapQuyenDT.Size = new System.Drawing.Size(116, 29);
            this.btnCapQuyenDT.TabIndex = 7;
            this.btnCapQuyenDT.Text = "Cấp (GRANT)";
            this.btnCapQuyenDT.UseVisualStyleBackColor = true;
            // 
            // chkGrantOption
            // 
            this.chkGrantOption.AutoSize = true;
            this.chkGrantOption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkGrantOption.ForeColor = System.Drawing.Color.Red;
            this.chkGrantOption.Location = new System.Drawing.Point(585, 34);
            this.chkGrantOption.Name = "chkGrantOption";
            this.chkGrantOption.Size = new System.Drawing.Size(173, 24);
            this.chkGrantOption.TabIndex = 6;
            this.chkGrantOption.Text = "WITH GRANT OPTION";
            this.chkGrantOption.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(395, 81);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(82, 24);
            this.chkDelete.TabIndex = 5;
            this.chkDelete.Text = "DELETE";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(290, 81);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(88, 24);
            this.chkUpdate.TabIndex = 4;
            this.chkUpdate.Text = "UPDATE";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(191, 81);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(81, 24);
            this.chkInsert.TabIndex = 3;
            this.chkInsert.Text = "INSERT";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(92, 81);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(81, 24);
            this.chkSelect.TabIndex = 2;
            this.chkSelect.Text = "SELECT";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // cboTenBang
            // 
            this.cboTenBang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenBang.FormattingEnabled = true;
            this.cboTenBang.Location = new System.Drawing.Point(92, 32);
            this.cboTenBang.Name = "cboTenBang";
            this.cboTenBang.Size = new System.Drawing.Size(359, 28);
            this.cboTenBang.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên Bảng:";
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 546);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPhanQuyen";
            this.Text = "Quản Lý Cấp/Thu Hồi Quyền (GRANT / REVOKE)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabSysPrivs.ResumeLayout(false);
            this.tabSysPrivs.PerformLayout();
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
        private System.Windows.Forms.TabPage tabObjPrivs;
        private System.Windows.Forms.ListBox lstTatCaQuyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstQuyenDaCap;
        private System.Windows.Forms.Button btnThuHoiQuyenHT;
        private System.Windows.Forms.Button btnCapQuyenHT;
        private System.Windows.Forms.CheckBox chkAdminOption;
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