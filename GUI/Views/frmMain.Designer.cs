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
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuanLyProfile);
            Controls.Add(btnQuanLyRole);
            Controls.Add(btnQuanLyUser);
            Name = "frmMain";
            Text = "frmMain";
            ResumeLayout(false);
        }

        #endregion

        private Button btnQuanLyUser;
        private Button btnQuanLyRole;
        private Button btnQuanLyProfile;
    }
}