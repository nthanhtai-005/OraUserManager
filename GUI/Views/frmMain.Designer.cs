namespace GUI.Views
{
    partial class frmMain
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
            btnQuanLyUser = new Button();
            btnQuanLyRole = new Button();
            btnQuanLyProfile = new Button();
            pnlDashboard = new Panel();
            lblTempTS = new Label();
            lblLockDate = new Label();
            lblAccountStatus = new Label();
            lblDefaultTS = new Label();
            lblProfile = new Label();
            tabControlPrivs = new TabControl();
            tabPage1 = new TabPage();
            dgvRoles = new DataGridView();
            tabPage2 = new TabPage();
            dgvSysPrivs = new DataGridView();
            tabPage3 = new TabPage();
            dgvObjPrivs = new DataGridView();
            tabPage4 = new TabPage();
            dgvQuotas = new DataGridView();
            lblCreatedDate = new Label();
            lblUsername = new Label();
            lblEmail = new Label();
            lblWelcome = new Label();
            btnLogout = new Button();
            pnlDashboard.SuspendLayout();
            tabControlPrivs.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSysPrivs).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvObjPrivs).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuotas).BeginInit();
            SuspendLayout();
            // 
            // btnQuanLyUser
            // 
            btnQuanLyUser.Location = new Point(33, 45);
            btnQuanLyUser.Name = "btnQuanLyUser";
            btnQuanLyUser.Size = new Size(138, 29);
            btnQuanLyUser.TabIndex = 0;
            btnQuanLyUser.Text = "btnQuanLyUser";
            btnQuanLyUser.UseVisualStyleBackColor = true;
            btnQuanLyUser.Click += btnQuanLyUser_Click;
            // 
            // btnQuanLyRole
            // 
            btnQuanLyRole.Location = new Point(33, 122);
            btnQuanLyRole.Name = "btnQuanLyRole";
            btnQuanLyRole.Size = new Size(138, 29);
            btnQuanLyRole.TabIndex = 1;
            btnQuanLyRole.Text = "btnQuanLyRole";
            btnQuanLyRole.UseVisualStyleBackColor = true;
            btnQuanLyRole.Click += btnQuanLyRole_Click;
            // 
            // btnQuanLyProfile
            // 
            btnQuanLyProfile.Location = new Point(33, 211);
            btnQuanLyProfile.Name = "btnQuanLyProfile";
            btnQuanLyProfile.Size = new Size(138, 29);
            btnQuanLyProfile.TabIndex = 2;
            btnQuanLyProfile.Text = "btnQuanLyProfile";
            btnQuanLyProfile.UseVisualStyleBackColor = true;
            btnQuanLyProfile.Click += btnQuanLyProfile_Click;
            // 
            // pnlDashboard
            // 
            pnlDashboard.Controls.Add(lblTempTS);
            pnlDashboard.Controls.Add(lblLockDate);
            pnlDashboard.Controls.Add(lblAccountStatus);
            pnlDashboard.Controls.Add(lblDefaultTS);
            pnlDashboard.Controls.Add(lblProfile);
            pnlDashboard.Controls.Add(tabControlPrivs);
            pnlDashboard.Controls.Add(lblCreatedDate);
            pnlDashboard.Controls.Add(lblUsername);
            pnlDashboard.Controls.Add(lblEmail);
            pnlDashboard.Controls.Add(lblWelcome);
            pnlDashboard.Location = new Point(190, 45);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(969, 526);
            pnlDashboard.TabIndex = 3;
            // 
            // lblTempTS
            // 
            lblTempTS.AutoSize = true;
            lblTempTS.Location = new Point(715, 100);
            lblTempTS.Name = "lblTempTS";
            lblTempTS.Size = new Size(79, 20);
            lblTempTS.TabIndex = 9;
            lblTempTS.Text = "lblTempTS";
            // 
            // lblLockDate
            // 
            lblLockDate.AutoSize = true;
            lblLockDate.Location = new Point(416, 100);
            lblLockDate.Name = "lblLockDate";
            lblLockDate.Size = new Size(88, 20);
            lblLockDate.TabIndex = 8;
            lblLockDate.Text = "lblLockDate";
            // 
            // lblAccountStatus
            // 
            lblAccountStatus.AutoSize = true;
            lblAccountStatus.Location = new Point(416, 58);
            lblAccountStatus.Name = "lblAccountStatus";
            lblAccountStatus.Size = new Size(120, 20);
            lblAccountStatus.TabIndex = 7;
            lblAccountStatus.Text = "lblAccountStatus";
            // 
            // lblDefaultTS
            // 
            lblDefaultTS.AutoSize = true;
            lblDefaultTS.Location = new Point(715, 58);
            lblDefaultTS.Name = "lblDefaultTS";
            lblDefaultTS.Size = new Size(91, 20);
            lblDefaultTS.TabIndex = 6;
            lblDefaultTS.Text = "lblDefaultTS";
            // 
            // lblProfile
            // 
            lblProfile.AutoSize = true;
            lblProfile.Location = new Point(416, 145);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(69, 20);
            lblProfile.TabIndex = 5;
            lblProfile.Text = "lblProfile";
            // 
            // tabControlPrivs
            // 
            tabControlPrivs.AccessibleName = "";
            tabControlPrivs.Controls.Add(tabPage1);
            tabControlPrivs.Controls.Add(tabPage2);
            tabControlPrivs.Controls.Add(tabPage3);
            tabControlPrivs.Controls.Add(tabPage4);
            tabControlPrivs.Location = new Point(30, 202);
            tabControlPrivs.Name = "tabControlPrivs";
            tabControlPrivs.SelectedIndex = 0;
            tabControlPrivs.Size = new Size(909, 307);
            tabControlPrivs.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvRoles);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(901, 274);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Vai trò (Roles)";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvRoles
            // 
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Location = new Point(6, 7);
            dgvRoles.Name = "dgvRoles";
            dgvRoles.ReadOnly = true;
            dgvRoles.RowHeadersWidth = 51;
            dgvRoles.Size = new Size(889, 261);
            dgvRoles.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvSysPrivs);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(901, 274);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quyền hệ thống";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvSysPrivs
            // 
            dgvSysPrivs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSysPrivs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSysPrivs.Location = new Point(6, 6);
            dgvSysPrivs.Name = "dgvSysPrivs";
            dgvSysPrivs.ReadOnly = true;
            dgvSysPrivs.RowHeadersWidth = 51;
            dgvSysPrivs.Size = new Size(892, 262);
            dgvSysPrivs.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvObjPrivs);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(901, 274);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Quyền đối tượng";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvObjPrivs
            // 
            dgvObjPrivs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvObjPrivs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvObjPrivs.Location = new Point(3, 6);
            dgvObjPrivs.Name = "dgvObjPrivs";
            dgvObjPrivs.ReadOnly = true;
            dgvObjPrivs.RowHeadersWidth = 51;
            dgvObjPrivs.Size = new Size(892, 262);
            dgvObjPrivs.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dgvQuotas);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(901, 274);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Quota";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvQuotas
            // 
            dgvQuotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuotas.Location = new Point(6, 6);
            dgvQuotas.Name = "dgvQuotas";
            dgvQuotas.ReadOnly = true;
            dgvQuotas.RowHeadersWidth = 51;
            dgvQuotas.Size = new Size(889, 262);
            dgvQuotas.TabIndex = 0;
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Location = new Point(30, 145);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(110, 20);
            lblCreatedDate.TabIndex = 3;
            lblCreatedDate.Text = "lblCreatedDate";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(30, 58);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(92, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "lblUsername";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 100);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "lblEmail";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(30, 21);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(88, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "lblWelcome";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(33, 521);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(138, 29);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "btnLogout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 583);
            Controls.Add(btnLogout);
            Controls.Add(pnlDashboard);
            Controls.Add(btnQuanLyProfile);
            Controls.Add(btnQuanLyRole);
            Controls.Add(btnQuanLyUser);
            Name = "frmMain";
            Text = "frmMain";
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            tabControlPrivs.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSysPrivs).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvObjPrivs).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQuotas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnQuanLyUser;
        private Button btnQuanLyRole;
        private Button btnQuanLyProfile;
        private Panel pnlDashboard;
        private Label lblEmail;
        private Label lblWelcome;
        private Label lblCreatedDate;
        private Label lblUsername;
        private TabControl tabControlPrivs;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dgvObjPrivs;
        private DataGridView dgvRoles;
        private DataGridView dgvSysPrivs;
        private Label lblTempTS;
        private Label lblLockDate;
        private Label lblAccountStatus;
        private Label lblDefaultTS;
        private Label lblProfile;
        private TabPage tabPage4;
        private DataGridView dgvQuotas;
        private Button btnLogout;
    }
}