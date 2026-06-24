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
            lblWelcome = new Label();
            lblEmail = new Label();
            lblUsername = new Label();
            lblCreatedDate = new Label();
            tabControlPrivs = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            dgvObjPrivs = new DataGridView();
            dgvSysPrivs = new DataGridView();
            dgvRoles = new DataGridView();
            pnlDashboard.SuspendLayout();
            tabControlPrivs.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvObjPrivs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSysPrivs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
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
            pnlDashboard.Controls.Add(tabControlPrivs);
            pnlDashboard.Controls.Add(lblCreatedDate);
            pnlDashboard.Controls.Add(lblUsername);
            pnlDashboard.Controls.Add(lblEmail);
            pnlDashboard.Controls.Add(lblWelcome);
            pnlDashboard.Location = new Point(190, 45);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(677, 382);
            pnlDashboard.TabIndex = 3;
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
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 100);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "lblEmail";
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
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Location = new Point(383, 100);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(110, 20);
            lblCreatedDate.TabIndex = 3;
            lblCreatedDate.Text = "lblCreatedDate";
            // 
            // tabControlPrivs
            // 
            tabControlPrivs.AccessibleName = "";
            tabControlPrivs.Controls.Add(tabPage1);
            tabControlPrivs.Controls.Add(tabPage2);
            tabControlPrivs.Controls.Add(tabPage3);
            tabControlPrivs.Location = new Point(30, 147);
            tabControlPrivs.Name = "tabControlPrivs";
            tabControlPrivs.SelectedIndex = 0;
            tabControlPrivs.Size = new Size(620, 217);
            tabControlPrivs.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvRoles);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(612, 184);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Vai trò (Roles)";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvSysPrivs);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(612, 184);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quyền hệ thống";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvObjPrivs);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(612, 184);
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
            dgvObjPrivs.Size = new Size(603, 155);
            dgvObjPrivs.TabIndex = 0;
            // 
            // dgvSysPrivs
            // 
            dgvSysPrivs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSysPrivs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSysPrivs.Location = new Point(127, 18);
            dgvSysPrivs.Name = "dgvSysPrivs";
            dgvSysPrivs.ReadOnly = true;
            dgvSysPrivs.RowHeadersWidth = 51;
            dgvSysPrivs.Size = new Size(300, 114);
            dgvSysPrivs.TabIndex = 0;
            // 
            // dgvRoles
            // 
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Location = new Point(138, 7);
            dgvRoles.Name = "dgvRoles";
            dgvRoles.ReadOnly = true;
            dgvRoles.RowHeadersWidth = 51;
            dgvRoles.Size = new Size(300, 160);
            dgvRoles.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 464);
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
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvObjPrivs).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSysPrivs).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
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
    }
}