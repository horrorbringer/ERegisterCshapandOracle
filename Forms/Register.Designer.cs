namespace E_Registration.Forms
{
    partial class Register
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpDob = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbProgram = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbRegistration = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSaveRegister = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.linkLabelAdmin = new System.Windows.Forms.LinkLabel();
            this.gbRegistration.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(179, 61);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(448, 48);
            this.txtName.TabIndex = 0;
            // 
            // dtpDob
            // 
            this.dtpDob.Checked = true;
            this.dtpDob.FillColor = System.Drawing.Color.White;
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDob.Location = new System.Drawing.Point(179, 133);
            this.dtpDob.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDob.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(448, 52);
            this.dtpDob.TabIndex = 2;
            this.dtpDob.Value = new System.DateTime(2025, 10, 3, 21, 54, 55, 965);
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.Color.Transparent;
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbGender.ItemHeight = 30;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(179, 213);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(448, 36);
            this.cmbGender.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(179, 282);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(448, 48);
            this.txtPhone.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 466);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Program";
            // 
            // txtAddress
            // 
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(179, 371);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(448, 48);
            this.txtAddress.TabIndex = 4;
            // 
            // cmbProgram
            // 
            this.cmbProgram.BackColor = System.Drawing.Color.Transparent;
            this.cmbProgram.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProgram.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProgram.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProgram.ItemHeight = 30;
            this.cmbProgram.Location = new System.Drawing.Point(179, 452);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(448, 36);
            this.cmbProgram.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(44, 397);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 22);
            this.label11.TabIndex = 1;
            this.label11.Text = "Address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(44, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 22);
            this.label10.TabIndex = 1;
            this.label10.Text = "Phone";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(37, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 22);
            this.label9.TabIndex = 1;
            this.label9.Text = "Gender";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "Date of birth";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 22);
            this.label7.TabIndex = 1;
            this.label7.Text = "Full Name";
            // 
            // gbRegistration
            // 
            this.gbRegistration.Controls.Add(this.txtName);
            this.gbRegistration.Controls.Add(this.label6);
            this.gbRegistration.Controls.Add(this.cmbProgram);
            this.gbRegistration.Controls.Add(this.label11);
            this.gbRegistration.Controls.Add(this.txtAddress);
            this.gbRegistration.Controls.Add(this.label10);
            this.gbRegistration.Controls.Add(this.dtpDob);
            this.gbRegistration.Controls.Add(this.label9);
            this.gbRegistration.Controls.Add(this.txtPhone);
            this.gbRegistration.Controls.Add(this.label8);
            this.gbRegistration.Controls.Add(this.cmbGender);
            this.gbRegistration.Controls.Add(this.label7);
            this.gbRegistration.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbRegistration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbRegistration.Location = new System.Drawing.Point(122, 83);
            this.gbRegistration.Name = "gbRegistration";
            this.gbRegistration.Size = new System.Drawing.Size(670, 503);
            this.gbRegistration.TabIndex = 5;
            this.gbRegistration.Text = "Registration and Enrollment";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel1.Controls.Add(this.guna2ControlBox3);
            this.guna2GradientPanel1.Controls.Add(this.guna2ControlBox1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(910, 55);
            this.guna2GradientPanel1.TabIndex = 6;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.linkLabelAdmin);
            this.guna2Panel1.Controls.Add(this.btnSaveRegister);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 621);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(910, 64);
            this.guna2Panel1.TabIndex = 7;
            // 
            // btnSaveRegister
            // 
            this.btnSaveRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRegister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveRegister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveRegister.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveRegister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveRegister.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRegister.ForeColor = System.Drawing.Color.White;
            this.btnSaveRegister.Location = new System.Drawing.Point(710, 13);
            this.btnSaveRegister.Name = "btnSaveRegister";
            this.btnSaveRegister.Size = new System.Drawing.Size(179, 39);
            this.btnSaveRegister.TabIndex = 0;
            this.btnSaveRegister.Text = "Save";
            this.btnSaveRegister.Click += new System.EventHandler(this.btnSaveRegister_Click);
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.CustomIconSize = 13F;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.Font = new System.Drawing.Font("Nokora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2ControlBox3.Location = new System.Drawing.Point(798, 0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(57, 34);
            this.guna2ControlBox3.TabIndex = 3;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.CustomIconSize = 13F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.Font = new System.Drawing.Font("Nokora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(851, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(57, 34);
            this.guna2ControlBox1.TabIndex = 5;
            // 
            // linkLabelAdmin
            // 
            this.linkLabelAdmin.AutoSize = true;
            this.linkLabelAdmin.Font = new System.Drawing.Font("Nokora", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelAdmin.Location = new System.Drawing.Point(21, 22);
            this.linkLabelAdmin.Name = "linkLabelAdmin";
            this.linkLabelAdmin.Size = new System.Drawing.Size(62, 23);
            this.linkLabelAdmin.TabIndex = 1;
            this.linkLabelAdmin.TabStop = true;
            this.linkLabelAdmin.Text = "Admin";
            this.linkLabelAdmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAdmin_LinkClicked);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 685);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.gbRegistration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.gbRegistration.ResumeLayout(false);
            this.gbRegistration.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProgram;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGender;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2GroupBox gbRegistration;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnSaveRegister;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.LinkLabel linkLabelAdmin;
    }
}