using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using E_Registration.Models;
using Guna.UI2.WinForms;

namespace E_Registration.Forms
{
    public partial class FormStudentModal : Form
    {
        public Student StudentData { get; private set; }

        // Modern Color Scheme
        private class ModalDesign
        {
            public static Color Primary = ColorTranslator.FromHtml("#6366F1");
            public static Color PrimaryHover = ColorTranslator.FromHtml("#4F46E5");
            public static Color BgMain = ColorTranslator.FromHtml("#F8FAFC");
            public static Color BgCard = Color.White;
            public static Color TextPrimary = ColorTranslator.FromHtml("#0F172A");
            public static Color TextSecondary = ColorTranslator.FromHtml("#64748B");
            public static Color Danger = ColorTranslator.FromHtml("#EF4444");
            public static Color Success = ColorTranslator.FromHtml("#10B981");
        }

        // UI Components
        private Guna2Panel mainPanel;
        private Guna2TextBox txtName;
        private Guna2DateTimePicker dtpDob;
        private Guna2ComboBox cmbGender;
        private Guna2TextBox txtPhone;
        private Guna2TextBox txtAddress;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Label lblTitle;

        public FormStudentModal(Student student = null)
        {
            InitializeComponent();
            InitializeModernUI();

            if (student != null)
            {
                txtName.Text = student.FullName;
                dtpDob.Value = student.DOB;
                cmbGender.Text = student.Gender;
                txtPhone.Text = student.Phone;
                txtAddress.Text = student.Address;
                StudentData = student;
                lblTitle.Text = "✏️ Edit Student";
            }
            else
            {
                lblTitle.Text = "➕ Add New Student";
            }
        }

        private void InitializeModernUI()
        {
            // Form Settings
            this.Size = new Size(600, 750);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ColorTranslator.FromHtml("#2D3748");
            this.Opacity = 0.95;
            this.ShowInTaskbar = false;

            // Main Panel (Card)
            mainPanel = new Guna2Panel
            {
                Location = new Point(75, 30),
                Size = new Size(450, 690),
                FillColor = ModalDesign.BgCard,
                BorderRadius = 20
            };

            // Title
            lblTitle = new Label
            {
                Text = "➕ Add New Student",
                Location = new Point(30, 30),
                Size = new Size(350, 35),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblTitle);

            // Close Button
            Guna2Button btnClose = new Guna2Button
            {
                Text = "✕",
                Size = new Size(40, 40),
                Location = new Point(385, 25),
                FillColor = Color.Transparent,
                ForeColor = ModalDesign.TextSecondary,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BorderRadius = 20,
                Cursor = Cursors.Hand
            };
            btnClose.HoverState.FillColor = ModalDesign.Danger;
            btnClose.HoverState.ForeColor = Color.White;
            btnClose.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            mainPanel.Controls.Add(btnClose);

            // Divider
            Panel divider = new Panel
            {
                Location = new Point(30, 85),
                Size = new Size(390, 1),
                BackColor = ColorTranslator.FromHtml("#E2E8F0")
            };
            mainPanel.Controls.Add(divider);

            // Full Name
            Label lblName = new Label
            {
                Text = "Full Name *",
                Location = new Point(30, 100),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblName);

            txtName = new Guna2TextBox
            {
                Location = new Point(20, 100),
                Size = new Size(290, 40),
                Font = new Font("Segoe UI", 12),
                PlaceholderText = "Enter student's full name",
                BorderRadius = 10,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                BackColor = Color.Transparent,
                FillColor = ModalDesign.BgMain,
                TextOffset = new Point(10, 0)
            };
            txtName.FocusedState.BorderColor = ModalDesign.Primary;
            mainPanel.Controls.Add(txtName);

            // Date of Birth
            Label lblDob = new Label
            {
                Text = "Date of Birth *",
                Location = new Point(30, 210),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblDob);

            dtpDob = new Guna2DateTimePicker
            {
                Location = new Point(30, 240),
                Size = new Size(390, 50),
                Font = new Font("Segoe UI", 12),
                BorderRadius = 10,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ModalDesign.BgMain,
                FocusedColor = ModalDesign.Primary,
                Format = DateTimePickerFormat.Long,
                BackColor = Color.Transparent,
                Value = DateTime.Now.AddYears(-18)
            };
            mainPanel.Controls.Add(dtpDob);

            // Gender
            Label lblGender = new Label
            {
                Text = "Gender *",
                Location = new Point(30, 310),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblGender);

            cmbGender = new Guna2ComboBox
            {
                Location = new Point(30, 340),
                Size = new Size(390, 50),
                Font = new Font("Segoe UI", 12),
                BorderRadius = 10,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ModalDesign.BgMain,
                FocusedColor = ModalDesign.Primary,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            mainPanel.Controls.Add(cmbGender);

            // Phone
            Label lblPhone = new Label
            {
                Text = "Phone Number *",
                Location = new Point(30, 400),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblPhone);

            txtPhone = new Guna2TextBox
            {
                Location = new Point(20, 310),
                Size = new Size(290, 40),
                Font = new Font("Segoe UI", 12),
                PlaceholderText = "Enter phone number (e.g., 0123456789)",
                BorderRadius = 10,
                BorderThickness = 2,
                BackColor = Color.Transparent,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ModalDesign.BgMain,
                TextOffset = new Point(10, 0)
            };
            txtPhone.FocusedState.BorderColor = ModalDesign.Primary;
            mainPanel.Controls.Add(txtPhone);

            // Address
            Label lblAddress = new Label
            {
                Text = "Address",
                Location = new Point(30, 510),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblAddress);

            txtAddress = new Guna2TextBox
            {
                Location = new Point(30, 430),
                Size = new Size(290, 40),
                Font = new Font("Segoe UI", 11),
                PlaceholderText = "Enter full address...",
                BackColor = Color.Transparent,
                BorderRadius = 10,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ModalDesign.BgMain,
                Multiline = true,
                TextOffset = new Point(10, 8)
            };
            txtAddress.FocusedState.BorderColor = ModalDesign.Primary;
            mainPanel.Controls.Add(txtAddress);

            // Cancel Button
            btnCancel = new Guna2Button
            {
                Text = "Cancel",
                Location = new Point(30, 615),
                Size = new Size(185, 50),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BorderRadius = 10,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                BackColor = Color.Transparent,
                FillColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnCancel.HoverState.FillColor = ModalDesign.BgMain;
            btnCancel.Click += btnCancel_Click;
            mainPanel.Controls.Add(btnCancel);

            // Save Button
            btnSave = new Guna2Button
            {
                Text = "Save Student",
                Location = new Point(235, 615),
                Size = new Size(185, 50),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                BorderRadius = 10,
                FillColor = ModalDesign.Primary,
                Cursor = Cursors.Hand
            };
            btnSave.HoverState.FillColor = ModalDesign.PrimaryHover;
            btnSave.Click += btnSave_Click;
            mainPanel.Controls.Add(btnSave);

            this.Controls.Add(mainPanel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Full name is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a gender!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone number is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            // Age validation (must be at least 10 years old)
            if (DateTime.Now.Year - dtpDob.Value.Year < 10)
            {
                MessageBox.Show("Student must be at least 10 years old!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDob.Focus();
                return;
            }

            StudentData = new Student
            {
                Id = StudentData?.Id ?? 0,
                FullName = txtName.Text.Trim(),
                DOB = dtpDob.Value,
                Gender = cmbGender.Text,
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Fade-in animation
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