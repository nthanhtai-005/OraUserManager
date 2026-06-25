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
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 67);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(393, 226);
            dgvUsers.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.CharacterCasing = CharacterCasing.Upper;
            txtUsername.Location = new Point(595, 67);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(195, 27);
            txtUsername.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(595, 119);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(195, 27);
            txtFullName.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(869, 119);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(195, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(595, 182);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(195, 27);
            txtPassword.TabIndex = 4;
            // 
            // cboDefaultTS
            // 
            cboDefaultTS.FormattingEnabled = true;
            cboDefaultTS.Location = new Point(595, 244);
            cboDefaultTS.Name = "cboDefaultTS";
            cboDefaultTS.Size = new Size(195, 28);
            cboDefaultTS.TabIndex = 5;
            // 
            // cboTempTS
            // 
            cboTempTS.FormattingEnabled = true;
            cboTempTS.Location = new Point(869, 244);
            cboTempTS.Name = "cboTempTS";
            cboTempTS.Size = new Size(195, 28);
            cboTempTS.TabIndex = 6;
            // 
            // txtQuota
            // 
            txtQuota.Location = new Point(595, 305);
            txtQuota.Name = "txtQuota";
            txtQuota.Size = new Size(195, 27);
            txtQuota.TabIndex = 7;
            // 
            // cboQuotaUnit
            // 
            cboQuotaUnit.FormattingEnabled = true;
            cboQuotaUnit.Items.AddRange(new object[] { "M", "G" });
            cboQuotaUnit.Location = new Point(869, 304);
            cboQuotaUnit.Name = "cboQuotaUnit";
            cboQuotaUnit.Size = new Size(151, 28);
            cboQuotaUnit.TabIndex = 8;
            // 
            // radUnlock
            // 
            radUnlock.AutoSize = true;
            radUnlock.Location = new Point(649, 372);
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
            radLock.Location = new Point(878, 372);
            radLock.Name = "radLock";
            radLock.Size = new Size(82, 24);
            radLock.TabIndex = 10;
            radLock.TabStop = true;
            radLock.Text = "radLock";
            radLock.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(77, 485);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "btnCreate";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(220, 485);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "btnEdit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(349, 485);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(793, 485);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 14;
            btnSave.Text = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(926, 485);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmUserManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 565);
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
    }
}