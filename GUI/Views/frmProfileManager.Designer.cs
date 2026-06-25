namespace GUI.Views
{
    partial class frmProfileManager
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
            dgvProfiles = new DataGridView();
            txtProfileName = new TextBox();
            cboSessionsType = new ComboBox();
            numSessionsValue = new NumericUpDown();
            cboConnectTimeType = new ComboBox();
            numConnectTimeValue = new NumericUpDown();
            numIdleTimeValue = new NumericUpDown();
            cboIdleTimeType = new ComboBox();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProfiles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSessionsValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numConnectTimeValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIdleTimeValue).BeginInit();
            SuspendLayout();
            // 
            // dgvProfiles
            // 
            dgvProfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfiles.Location = new Point(24, 68);
            dgvProfiles.Name = "dgvProfiles";
            dgvProfiles.RowHeadersWidth = 51;
            dgvProfiles.Size = new Size(509, 220);
            dgvProfiles.TabIndex = 0;
            // 
            // txtProfileName
            // 
            txtProfileName.CharacterCasing = CharacterCasing.Upper;
            txtProfileName.Location = new Point(659, 68);
            txtProfileName.Name = "txtProfileName";
            txtProfileName.Size = new Size(207, 27);
            txtProfileName.TabIndex = 1;
            // 
            // cboSessionsType
            // 
            cboSessionsType.FormattingEnabled = true;
            cboSessionsType.Items.AddRange(new object[] { "UNLIMITED", "DEFAULT", "CUSTOM" });
            cboSessionsType.Location = new Point(659, 114);
            cboSessionsType.Name = "cboSessionsType";
            cboSessionsType.Size = new Size(151, 28);
            cboSessionsType.TabIndex = 2;
            // 
            // numSessionsValue
            // 
            numSessionsValue.Location = new Point(841, 115);
            numSessionsValue.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numSessionsValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSessionsValue.Name = "numSessionsValue";
            numSessionsValue.Size = new Size(150, 27);
            numSessionsValue.TabIndex = 3;
            numSessionsValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboConnectTimeType
            // 
            cboConnectTimeType.FormattingEnabled = true;
            cboConnectTimeType.Items.AddRange(new object[] { "UNLIMITED", "DEFAULT", "CUSTOM" });
            cboConnectTimeType.Location = new Point(659, 180);
            cboConnectTimeType.Name = "cboConnectTimeType";
            cboConnectTimeType.Size = new Size(151, 28);
            cboConnectTimeType.TabIndex = 4;
            // 
            // numConnectTimeValue
            // 
            numConnectTimeValue.Location = new Point(841, 180);
            numConnectTimeValue.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numConnectTimeValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numConnectTimeValue.Name = "numConnectTimeValue";
            numConnectTimeValue.Size = new Size(150, 27);
            numConnectTimeValue.TabIndex = 5;
            numConnectTimeValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numIdleTimeValue
            // 
            numIdleTimeValue.Location = new Point(841, 250);
            numIdleTimeValue.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numIdleTimeValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIdleTimeValue.Name = "numIdleTimeValue";
            numIdleTimeValue.Size = new Size(150, 27);
            numIdleTimeValue.TabIndex = 6;
            numIdleTimeValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboIdleTimeType
            // 
            cboIdleTimeType.FormattingEnabled = true;
            cboIdleTimeType.Items.AddRange(new object[] { "UNLIMITED", "DEFAULT", "CUSTOM" });
            cboIdleTimeType.Location = new Point(659, 250);
            cboIdleTimeType.Name = "cboIdleTimeType";
            cboIdleTimeType.Size = new Size(151, 28);
            cboIdleTimeType.TabIndex = 7;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(42, 317);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 8;
            btnCreate.Text = "btnCreate";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(201, 317);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "btnEdit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(346, 317);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(761, 317);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 11;
            btnSave.Text = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(883, 317);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmProfileManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 494);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnCreate);
            Controls.Add(cboIdleTimeType);
            Controls.Add(numIdleTimeValue);
            Controls.Add(numConnectTimeValue);
            Controls.Add(cboConnectTimeType);
            Controls.Add(numSessionsValue);
            Controls.Add(cboSessionsType);
            Controls.Add(txtProfileName);
            Controls.Add(dgvProfiles);
            Name = "frmProfileManager";
            Text = "frmProfileManager";
            ((System.ComponentModel.ISupportInitialize)dgvProfiles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSessionsValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)numConnectTimeValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIdleTimeValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProfiles;
        private TextBox txtProfileName;
        private ComboBox cboSessionsType;
        private NumericUpDown numSessionsValue;
        private ComboBox cboConnectTimeType;
        private NumericUpDown numConnectTimeValue;
        private NumericUpDown numIdleTimeValue;
        private ComboBox cboIdleTimeType;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSave;
        private Button btnCancel;
    }
}