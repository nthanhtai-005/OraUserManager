namespace GUI.Views
{
    partial class frmUserManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvUsers = new DataGridView();
            txtUsername = new TextBox();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            cboDefaultTS = new ComboBox();
            cboTempTS = new ComboBox();
            txtQuota = new TextBox();
            cboQuotaUnit = new ComboBox();
            radUnlock = new RadioButton();
            radLock = new RadioButton();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            cboProfile = new ComboBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 46);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(476, 226);
            dgvUsers.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.CharacterCasing = CharacterCasing.Upper;
            txtUsername.Location = new Point(595, 68);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(195, 27);
            txtUsername.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(595, 136);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(195, 27);
            txtFullName.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(869, 136);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(195, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(595, 203);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(195, 27);
            txtPassword.TabIndex = 4;
            // 
            // cboDefaultTS
            // 
            cboDefaultTS.FormattingEnabled = true;
            cboDefaultTS.Location = new Point(595, 266);
            cboDefaultTS.Name = "cboDefaultTS";
            cboDefaultTS.Size = new Size(195, 28);
            cboDefaultTS.TabIndex = 5;
            // 
            // cboTempTS
            // 
            cboTempTS.FormattingEnabled = true;
            cboTempTS.Location = new Point(869, 266);
            cboTempTS.Name = "cboTempTS";
            cboTempTS.Size = new Size(195, 28);
            cboTempTS.TabIndex = 6;
            // 
            // txtQuota
            // 
            txtQuota.Location = new Point(595, 327);
            txtQuota.Name = "txtQuota";
            txtQuota.Size = new Size(151, 27);
            txtQuota.TabIndex = 7;
            // 
            // cboQuotaUnit
            // 
            cboQuotaUnit.FormattingEnabled = true;
            cboQuotaUnit.Items.AddRange(new object[] { "M", "G" });
            cboQuotaUnit.Location = new Point(869, 326);
            cboQuotaUnit.Name = "cboQuotaUnit";
            cboQuotaUnit.Size = new Size(91, 28);
            cboQuotaUnit.TabIndex = 8;
            // 
            // radUnlock
            // 
            radUnlock.AutoSize = true;
            radUnlock.Location = new Point(595, 383);
            radUnlock.Name = "radUnlock";
            radUnlock.Size = new Size(97, 24);
            radUnlock.TabIndex = 9;
            radUnlock.TabStop = true;
            radUnlock.Text = "radUnlock";
            radUnlock.UseVisualStyleBackColor = true;
            // 
            // radLock
            // 
            radLock.AutoSize = true;
            radLock.Location = new Point(725, 383);
            radLock.Name = "radLock";
            radLock.Size = new Size(82, 24);
            radLock.TabIndex = 10;
            radLock.TabStop = true;
            radLock.Text = "radLock";
            radLock.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(36, 327);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "btnCreate";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(183, 327);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "btnEdit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(318, 327);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(595, 436);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 14;
            btnSave.Text = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(725, 436);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(595, 45);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 16;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(595, 113);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 17;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(869, 113);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 18;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(595, 180);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 19;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(595, 243);
            label5.Name = "label5";
            label5.Size = new Size(135, 20);
            label5.TabIndex = 20;
            label5.Text = "Default Tablespace";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(869, 243);
            label6.Name = "label6";
            label6.Size = new Size(123, 20);
            label6.TabIndex = 21;
            label6.Text = "Temp Tablespace";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(595, 304);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 22;
            label7.Text = "Quota";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(869, 304);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 23;
            label8.Text = "Don vi";
            // 
            // cboProfile
            // 
            cboProfile.FormattingEnabled = true;
            cboProfile.Location = new Point(869, 202);
            cboProfile.Name = "cboProfile";
            cboProfile.Size = new Size(195, 28);
            cboProfile.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(869, 179);
            label9.Name = "label9";
            label9.Size = new Size(52, 20);
            label9.TabIndex = 25;
            label9.Text = "Profile";
            // 
            // frmUserManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 489);
            Controls.Add(label9);
            Controls.Add(cboProfile);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnCreate);
            Controls.Add(radLock);
            Controls.Add(radUnlock);
            Controls.Add(cboQuotaUnit);
            Controls.Add(txtQuota);
            Controls.Add(cboTempTS);
            Controls.Add(cboDefaultTS);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(txtUsername);
            Controls.Add(dgvUsers);
            Name = "frmUserManager";
            Text = "frmUserManager";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsers;
        private TextBox txtUsername;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private ComboBox cboDefaultTS;
        private ComboBox cboTempTS;
        private TextBox txtQuota;
        private ComboBox cboQuotaUnit;
        private RadioButton radUnlock;
        private RadioButton radLock;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox cboProfile;
        private Label label9;
    }
}