using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using E_Registration.Models;
using E_Registration.Services;
using System.Runtime.InteropServices;

namespace E_Registration.Forms
{
    public partial class Register : Form
    {
        private readonly ProgramService _programService = new ProgramService();
        private readonly StudentService _studentService = new StudentService();
        public Student StudentData { get; private set; }
        public int SelectedProgramId { get; private set; }

        // Modern Color Scheme
        private Color bgGradientStart = ColorTranslator.FromHtml("#667EEA");
        private Color bgGradientEnd = ColorTranslator.FromHtml("#764BA2");
        private Color cardBgColor = ColorTranslator.FromHtml("#FFFFFF");
        private Color accentColor = ColorTranslator.FromHtml("#667EEA");
        private Color successColor = ColorTranslator.FromHtml("#27AE60");
        private Color textColor = ColorTranslator.FromHtml("#2D3748");
        private Color placeholderColor = ColorTranslator.FromHtml("#A0AEC0");

        // Guna Controls
        private Guna2TextBox txtName;
        private Guna2TextBox txtPhone;
        private Guna2TextBox txtAddress;
        private Guna2ComboBox cmbGender;
        private Guna2ComboBox cmbProgram;
        private Guna2DateTimePicker dtpDob;
        private Guna2Button btnSaveRegister;
        private Guna2Button btnClear;
        private Guna2Button btnClose;
        private Guna2Panel mainContainer;
        private Guna2Panel headerPanel;
        private Guna2Panel formPanel;
        private Label linkLabelAdmin;

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public Register()
        {
            InitializeComponent();
            InitializeGunaComponents();
            CustomizeRegisterForm();
            LoadPrograms();
        }

        private void InitializeGunaComponents()
        {
            // Main container
            mainContainer = new Guna2Panel
            {
                Size = new Size(900, 650),
                Location = new Point(50, 25),
                BackColor = Color.Transparent,
                FillColor = Color.White,
                BorderRadius = 20
            };
            mainContainer.ShadowDecoration.Enabled = true;
            mainContainer.ShadowDecoration.Shadow = new Padding(10);

            // Header Panel
            headerPanel = new Guna2Panel
            {
                Size = new Size(900, 120),
                Location = new Point(0, 0),
                BackColor = Color.Transparent,
                FillColor = accentColor,
                BorderRadius = 20
            };
            headerPanel.MouseDown += headerPanel_MouseDown;

            // Form Panel
            formPanel = new Guna2Panel
            {
                Size = new Size(840, 440),
                Location = new Point(30, 140),
                BackColor = Color.Transparent,
                FillColor = ColorTranslator.FromHtml("#F7FAFC"),
                BorderRadius = 15
            };

            // Full Name TextBox
            txtName = new Guna2TextBox
            {
                Location = new Point(40, 70),
                Size = new Size(320, 40),
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Enter full name",
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0")
            };
            txtName.FocusedState.BorderColor = accentColor;

            // Phone TextBox
            txtPhone = new Guna2TextBox
            {
                Location = new Point(440, 40),
                Size = new Size(320, 40),
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Enter phone number",
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0")
            };
            txtPhone.FocusedState.BorderColor = accentColor;

            // Date of Birth Picker
            dtpDob = new Guna2DateTimePicker
            {
                Location = new Point(40, 140),
                Size = new Size(360, 40),
                Font = new Font("Segoe UI", 10),
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = Color.White,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };
            dtpDob.FocusedColor = accentColor;

            // Gender ComboBox
            cmbGender = new Guna2ComboBox
            {
                Location = new Point(440, 140),
                Size = new Size(360, 40),
                Font = new Font("Segoe UI", 10),
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = Color.White
            };
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbGender.FocusedColor = accentColor;

            // Program ComboBox
            cmbProgram = new Guna2ComboBox
            {
                Location = new Point(40, 230),
                Size = new Size(760, 40),
                Font = new Font("Segoe UI", 10),
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = Color.White
            };
            cmbProgram.FocusedColor = accentColor;

            // Address TextBox (Multiline)
            txtAddress = new Guna2TextBox
            {
                Location = new Point(100, 250),
                Size = new Size(678, 50),
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Enter full address",
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                Multiline = true
            };
            txtAddress.FocusedState.BorderColor = accentColor;

            // Save Button
            btnSaveRegister = new Guna2Button
            {
                Location = new Point(440, 600),
                Size = new Size(200, 40),
                Text = "REGISTER",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BorderRadius = 8,
                FillColor = successColor,
                Cursor = Cursors.Hand
            };
            btnSaveRegister.HoverState.FillColor = ColorTranslator.FromHtml("#229954");
            btnSaveRegister.Click += btnSaveRegister_Click;

            // Clear Button
            btnClear = new Guna2Button
            {
                Location = new Point(660, 600),
                Size = new Size(200, 40),
                Text = "CLEAR",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BorderRadius = 8,
                FillColor = ColorTranslator.FromHtml("#95A5A6"),
                Cursor = Cursors.Hand
            };
            btnClear.HoverState.FillColor = ColorTranslator.FromHtml("#7F8C8D");
            btnClear.Click += (s, e) => ClearForm();

            // Close Button
            btnClose = new Guna2Button
            {
                Text = "✕",
                Size = new Size(40, 40),
                Location = new Point(940, 10),
                BorderRadius = 20,
                FillColor = Color.Transparent,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.HoverState.FillColor = ColorTranslator.FromHtml("#EF4444");
            btnClose.Click += (s, e) => Application.Exit();

            // Admin Link Label
            linkLabelAdmin = new Label
            {
                Text = "← Admin Login",
                Location = new Point(40, 600),
                Size = new Size(150, 30),
                ForeColor = accentColor,
                Font = new Font("Segoe UI", 11, FontStyle.Bold | FontStyle.Underline),
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent,
                AutoSize = false
            };
            linkLabelAdmin.Click += linkLabelAdmin_LinkClicked;
            linkLabelAdmin.MouseEnter += (s, e) => linkLabelAdmin.ForeColor = ColorTranslator.FromHtml("#5568D3");
            linkLabelAdmin.MouseLeave += (s, e) => linkLabelAdmin.ForeColor = accentColor;
        }

        private void CustomizeRegisterForm()
        {
            // Form settings
            this.Size = new Size(1000, 700);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Paint += Register_Paint;

            // Add controls
            this.Controls.Add(btnClose);
            this.Controls.Add(mainContainer);

            mainContainer.Controls.Add(headerPanel);
            mainContainer.Controls.Add(formPanel);
            mainContainer.Controls.Add(btnSaveRegister);
            mainContainer.Controls.Add(btnClear);
            mainContainer.Controls.Add(linkLabelAdmin);

            CreateHeaderContent();
            CreateFormContent();
        }

        private void Register_Paint(object sender, PaintEventArgs e)
        {
            // Draw gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                bgGradientStart,
                bgGradientEnd,
                45f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void CreateHeaderContent()
        {
            // Title
            Label lblTitle = new Label
            {
                Text = "Student Registration",
                Location = new Point(40, 25),
                Size = new Size(820, 45),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                BackColor = Color.Transparent,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft
            };
            headerPanel.Controls.Add(lblTitle);
            lblTitle.MouseDown += lblTitle_MouseDown;

            // Subtitle
            Label lblSubtitle = new Label
            {
                Text = "Please fill in all required information",
                Location = new Point(40, 70),
                Size = new Size(820, 30),
                ForeColor = ColorTranslator.FromHtml("#E8E8FF"),
                Font = new Font("Segoe UI", 11),
                BackColor = Color.Transparent,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft
            };
            headerPanel.Controls.Add(lblSubtitle);
            lblSubtitle.MouseDown += LblSubtitle_MouseDown;
        }


        private void CreateFormContent()
        {
            int labelY1 = 30;
            int labelY2 = 140;
            int labelY3 = 230;
            int labelY4 = 310;

            // Full Name Label
            Label lblName = new Label
            {
                Text = "Full Name *",
                Location = new Point(40, labelY1),
                Size = new Size(150, 25),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            formPanel.Controls.Add(lblName);

            // Update txtName position to match label
            txtName.Location = new Point(40, 80);
            formPanel.Controls.Add(txtName);

            // Phone Label
            Label lblPhone = new Label
            {
                Text = "Phone Number *",
                Location = new Point(440, labelY1),
                Size = new Size(150, 25),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            formPanel.Controls.Add(lblPhone);

            // Update txtPhone position to match label
            txtPhone.Location = new Point(440, 80);
            formPanel.Controls.Add(txtPhone);

            // Date of Birth Label
            Label lblDob = new Label
            {
                Text = "Date of Birth *",
                Location = new Point(40, labelY2),
                Size = new Size(150, 25),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            formPanel.Controls.Add(lblDob);

            // Update dtpDob position
            dtpDob.Location = new Point(40, 170);
            formPanel.Controls.Add(dtpDob);

            // Gender Label
            Label lblGender = new Label
            {
                Text = "Gender *",
                Location = new Point(440, labelY2),
                Size = new Size(150, 25),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            formPanel.Controls.Add(lblGender);

            // Update cmbGender position
            cmbGender.Location = new Point(440, 170);
            formPanel.Controls.Add(cmbGender);

            // Program Label
            Label lblProgram = new Label
            {
                Text = "Program *",
                Location = new Point(40, labelY3),
                Size = new Size(150, 25),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            formPanel.Controls.Add(lblProgram);

            // Update cmbProgram position
            cmbProgram.Location = new Point(40, 260);
            formPanel.Controls.Add(cmbProgram);

            // Address Label
            Label lblAddress = new Label
            {
                Text = "Address",
                Location = new Point(40, labelY4),
                Size = new Size(150, 25),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            formPanel.Controls.Add(lblAddress);

            // Update txtAddress position
            txtAddress.Location = new Point(40, 350);
            formPanel.Controls.Add(txtAddress);
        }

        private void LoadPrograms()
        {
            var programs = _programService.GetAllPrograms();
            cmbProgram.DataSource = programs;
            cmbProgram.DisplayMember = "NAME";
            cmbProgram.ValueMember = "ID";
        }

        private void btnSaveRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter full name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Please enter phone number.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbGender.Text))
                {
                    MessageBox.Show("Please select gender.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbGender.Focus();
                    return;
                }

                if (cmbProgram.SelectedValue == null)
                {
                    MessageBox.Show("Please select a program.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProgram.Focus();
                    return;
                }

                // Create student object
                var student = new Student
                {
                    FullName = txtName.Text,
                    DOB = dtpDob.Value,
                    Gender = cmbGender.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text
                };

                int programId = Convert.ToInt32(cmbProgram.SelectedValue);

                // Call service to insert both student + enrollment
                _studentService.RegisterAndEnroll(student, programId);

                MessageBox.Show("✅ Student registered and enrolled successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form for next entry
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error saving student: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            cmbGender.SelectedIndex = -1;
            cmbProgram.SelectedIndex = -1;
            dtpDob.Value = DateTime.Today;
            txtName.Focus();
        }

        private void linkLabelAdmin_LinkClicked(object sender, EventArgs e)
        {
            var login = new Login();
            login.FormClosed += (s, arags) => this.Close();
            login.Show();
            this.Hide();
        }
        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void LblSubtitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Opacity = 0;
            Timer fadeIn = new Timer { Interval = 10 };
            fadeIn.Tick += (s, ev) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    fadeIn.Stop();
            };
            fadeIn.Start();
        }
    }
}