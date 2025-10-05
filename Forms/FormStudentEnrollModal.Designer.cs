namespace E_Registration.Forms
{
    partial class FormStudentEnrollModal
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
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStudent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbProgram = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpEnrollDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(515, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(226, 45);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(220, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(247, 45);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nokora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nokora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Program";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Nokora Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(321, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 38);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enrollments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nokora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Student";
            // 
            // cmbStudent
            // 
            this.cmbStudent.BackColor = System.Drawing.Color.Transparent;
            this.cmbStudent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStudent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStudent.ItemHeight = 30;
            this.cmbStudent.Location = new System.Drawing.Point(216, 128);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(525, 36);
            this.cmbStudent.TabIndex = 12;
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
            this.cmbProgram.Location = new System.Drawing.Point(216, 209);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(525, 36);
            this.cmbProgram.TabIndex = 12;
            // 
            // dtpEnrollDate
            // 
            this.dtpEnrollDate.Checked = true;
            this.dtpEnrollDate.FillColor = System.Drawing.Color.LightGray;
            this.dtpEnrollDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEnrollDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEnrollDate.Location = new System.Drawing.Point(216, 291);
            this.dtpEnrollDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEnrollDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEnrollDate.Name = "dtpEnrollDate";
            this.dtpEnrollDate.Size = new System.Drawing.Size(525, 36);
            this.dtpEnrollDate.TabIndex = 13;
            this.dtpEnrollDate.Value = new System.DateTime(2025, 10, 5, 20, 2, 52, 371);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(800, 64);
            this.guna2Panel1.TabIndex = 14;
            // 
            // FormStudentEnrollModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dtpEnrollDate);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStudentEnrollModal";
            this.Text = "FormStudentEnrollModal";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStudent;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProgram;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEnrollDate;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}