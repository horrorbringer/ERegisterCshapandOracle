using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Registration.Models;
using E_Registration.Services;
using Guna.UI2.WinForms;

namespace E_Registration.Forms
{
    public partial class FormStudentEnrollModal : Form
    {
        private readonly EnrollmentService _service = new EnrollmentService();
        public Enrollment EnrollmentData { get; private set; }

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
        private Guna2ComboBox cmbStudent;
        private Guna2ComboBox cmbProgram;
        private Guna2DateTimePicker dtpEnrollDate;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Label lblTitle;

        public FormStudentEnrollModal(Enrollment existing = null)
        {
            InitializeComponent();
            InitializeModernUI();
            LoadDropdowns();

            if (existing != null)
            {
                EnrollmentData = existing;
                cmbStudent.SelectedValue = existing.StudentId;
                cmbProgram.SelectedValue = existing.ProgramId;
                dtpEnrollDate.Value = existing.EnrollmentDate;
                lblTitle.Text = "✏️ Edit Enrollment";
            }
            else
            {
                lblTitle.Text = "➕ Add New Enrollment";
                dtpEnrollDate.Value = DateTime.Now;
            }
        }

        private void InitializeModernUI()
        {
            // Form Settings
            this.Size = new Size(600, 600);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ColorTranslator.FromHtml("#2D3748");
            this.Opacity = 0.95;
            this.ShowInTaskbar = false;

            // Main Panel (Card) - Centered
            mainPanel = new Guna2Panel
            {
                Location = new Point(75, 50),
                Size = new Size(450, 500),
                FillColor = ModalDesign.BgCard,
                BorderRadius = 20
            };

            // Title
            lblTitle = new Label
            {
                Text = "➕ Add New Enrollment",
                Location = new Point(30, 30),
                Size = new Size(350, 35),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblTitle);

            // Close Button (X)
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

            // Divider Line
            Panel divider = new Panel
            {
                Location = new Point(30, 85),
                Size = new Size(390, 1),
                BackColor = ColorTranslator.FromHtml("#E2E8F0")
            };
            mainPanel.Controls.Add(divider);

            // Student Label
            Label lblStudent = new Label
            {
                Text = "Select Student *",
                Location = new Point(30, 100),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblStudent);

            // Student ComboBox
            cmbStudent = new Guna2ComboBox
            {
                Location = new Point(30, 130),
                Size = new Size(390, 50),
                Font = new Font("Segoe UI", 12),
                BorderRadius = 10,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ModalDesign.BgMain,
                FocusedColor = ModalDesign.Primary,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            mainPanel.Controls.Add(cmbStudent);

            // Program Label
            Label lblProgram = new Label
            {
                Text = "Select Program *",
                Location = new Point(30, 180),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblProgram);

            // Program ComboBox
            cmbProgram = new Guna2ComboBox
            {
                Location = new Point(30, 210),
                Size = new Size(390, 50),
                Font = new Font("Segoe UI", 12),
                BorderRadius = 10,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ModalDesign.BgMain,
                FocusedColor = ModalDesign.Primary,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            mainPanel.Controls.Add(cmbProgram);

            // Enrollment Date Label
            Label lblDate = new Label
            {
                Text = "Enrollment Date *",
                Location = new Point(30, 270),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblDate);

            // Date Picker
            dtpEnrollDate = new Guna2DateTimePicker
            {
                Location = new Point(30, 310),
                Size = new Size(390, 50),
                Font = new Font("Segoe UI", 12),
                BorderRadius = 10,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ModalDesign.BgMain,
                BackColor = Color.Transparent,
                FocusedColor = ModalDesign.Primary,
                Format = DateTimePickerFormat.Long,
                Value = DateTime.Now
            };
            mainPanel.Controls.Add(dtpEnrollDate);

            // Info box
            Guna2Panel infoBox = new Guna2Panel
            {
                Location = new Point(30, 370),
                Size = new Size(390, 50),
                FillColor = ColorTranslator.FromHtml("#EFF6FF"),
                BackColor = Color.Transparent,
                BorderRadius = 8
            };

            Label lblInfo = new Label
            {
                Text = "ℹ️ Enrolling a student will link them to the selected program.",
                Location = new Point(15, 15),
                Size = new Size(360, 20),
                Font = new Font("Segoe UI", 9),
                ForeColor = ModalDesign.Primary,
                BackColor = Color.Transparent
            };
            infoBox.Controls.Add(lblInfo);
            mainPanel.Controls.Add(infoBox);

            // Cancel Button
            btnCancel = new Guna2Button
            {
                Text = "Cancel",
                Location = new Point(30, 430),
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
                Text = "Save Enrollment",
                Location = new Point(235, 430),
                Size = new Size(185, 50),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BorderRadius = 10,
                FillColor = ModalDesign.Primary,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };
            btnSave.HoverState.FillColor = ModalDesign.PrimaryHover;
            btnSave.Click += btnSave_Click;
            mainPanel.Controls.Add(btnSave);

            this.Controls.Add(mainPanel);
        }

        private void LoadDropdowns()
        {
            try
            {
                // Load Students
                DataTable students = _service.GetStudents();
                cmbStudent.DataSource = students;
                cmbStudent.DisplayMember = "full_name";
                cmbStudent.ValueMember = "id";
                cmbStudent.SelectedIndex = -1;

                // Load Programs
                DataTable programs = _service.GetPrograms();
                cmbProgram.DataSource = programs;
                cmbProgram.DisplayMember = "name";
                cmbProgram.ValueMember = "id";
                cmbProgram.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbStudent.SelectedValue == null)
            {
                MessageBox.Show("Please select a student!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStudent.Focus();
                return;
            }

            if (cmbProgram.SelectedValue == null)
            {
                MessageBox.Show("Please select a program!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProgram.Focus();
                return;
            }

            EnrollmentData = new Enrollment
            {
                Id = EnrollmentData?.Id ?? 0,
                StudentId = Convert.ToInt32(cmbStudent.SelectedValue),
                ProgramId = Convert.ToInt32(cmbProgram.SelectedValue),
                EnrollmentDate = dtpEnrollDate.Value
            };

            try
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving enrollment: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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