using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Registration.Models;
using Guna.UI2.WinForms;

namespace E_Registration.Forms
{
    public partial class FormProgramModal : Form
    {
        public ProgramModel ProgramData { get; private set; }

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
        private Guna2TextBox txtDescription;
        private Guna2TextBox txtDuration;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Label lblTitle;

        public FormProgramModal(ProgramModel model = null)
        {
            InitializeComponent();
            InitializeModernUI();

            if (model != null)
            {
                ProgramData = model;
                txtName.Text = model.Name;
                txtDescription.Text = model.Description;
                txtDuration.Text = model.Duration;
                lblTitle.Text = "✏️ Edit Program";
            }
            else
            {
                lblTitle.Text = "➕ Add New Program";
            }
        }

        private void InitializeModernUI()
        {
            // Form Settings
            this.Size = new Size(550, 520);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ColorTranslator.FromHtml("#2D3748"); // Dark solid background instead of transparent
            this.Opacity = 0.95; // Slight transparency for the whole form
            this.ShowInTaskbar = false;

            // Main Panel (Card)
            mainPanel = new Guna2Panel
            {
                Location = new Point(50, 30),
                Size = new Size(450, 460),
                FillColor = ModalDesign.BgCard,
                BorderRadius = 15
            };

            // Title
            lblTitle = new Label
            {
                Text = "➕ Add New Program",
                Location = new Point(30, 25),
                Size = new Size(390, 35),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblTitle);

            // Close Button (X)
            Guna2Button btnClose = new Guna2Button
            {
                Text = "✕",
                Size = new Size(35, 35),
                Location = new Point(390, 20),
                FillColor = Color.Transparent,
                ForeColor = ModalDesign.TextSecondary,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BorderRadius = 17,
                Cursor = Cursors.Hand
            };
            btnClose.HoverState.FillColor = ModalDesign.Danger;
            btnClose.HoverState.ForeColor = Color.White;
            btnClose.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            mainPanel.Controls.Add(btnClose);

            // Divider Line
            Panel divider = new Panel
            {
                Location = new Point(30, 70),
                Size = new Size(390, 2),
                BackColor = ColorTranslator.FromHtml("#E2E8F0")
            };
            mainPanel.Controls.Add(divider);

            // Program Name Label
            Label lblName = new Label
            {
                Text = "Program Name *",
                Location = new Point(30, 80),
                Size = new Size(150, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblName);

            // Program Name TextBox
            txtName = new Guna2TextBox
            {
                Location = new Point(30, 90),
                Size = new Size(300, 45),
                Font = new Font("Segoe UI", 11),
                PlaceholderText = "Enter program name (e.g., Computer Science)",
                BorderRadius = 8,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                BackColor = Color.Transparent,
                FillColor = ModalDesign.BgMain
            };
            txtName.FocusedState.BorderColor = ModalDesign.Primary;
            mainPanel.Controls.Add(txtName);

            // Description Label
            Label lblDescription = new Label
            {
                Text = "Description",
                Location = new Point(30, 180),
                Size = new Size(150, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblDescription);

            // Description TextBox (Multiline)
            txtDescription = new Guna2TextBox
            {
                Location = new Point(30, 170),
                Size = new Size(300, 50),
                Font = new Font("Segoe UI", 11),
                PlaceholderText = "Enter program description...",
                BorderRadius = 8,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                BackColor = Color.Transparent,
                FillColor = ModalDesign.BgMain,
                Multiline = true
            };
            txtDescription.FocusedState.BorderColor = ModalDesign.Primary;
            mainPanel.Controls.Add(txtDescription);

            // Duration Label
            Label lblDuration = new Label
            {
                Text = "Duration *",
                Location = new Point(30, 290),
                Size = new Size(150, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(lblDuration);

            // Duration TextBox
            txtDuration = new Guna2TextBox
            {
                Location = new Point(30, 260),
                Size = new Size(300, 45),
                Font = new Font("Segoe UI", 11),
                PlaceholderText = "Enter duration (e.g., 4 years, 6 months)",
                BorderRadius = 8,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                BackColor = Color.Transparent,
                FillColor = ModalDesign.BgMain
            };
            txtDuration.FocusedState.BorderColor = ModalDesign.Primary;
            mainPanel.Controls.Add(txtDuration);

            // Cancel Button
            btnCancel = new Guna2Button
            {
                Text = "Cancel",
                Location = new Point(30, 400),
                Size = new Size(185, 45),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = ModalDesign.TextPrimary,
                BorderRadius = 8,
                BorderThickness = 2,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = Color.White,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };
            btnCancel.HoverState.FillColor = ModalDesign.BgMain;
            btnCancel.Click += btnCancel_Click;
            mainPanel.Controls.Add(btnCancel);

            // Save Button
            btnSave = new Guna2Button
            {
                Text = "Save Program",
                Location = new Point(235, 400),
                Size = new Size(185, 45),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BorderRadius = 8,
                FillColor = ModalDesign.Primary,
                BackColor = Color.Transparent,
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
                MessageBox.Show("Program name is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                MessageBox.Show("Duration is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuration.Focus();
                return;
            }

            ProgramData = new ProgramModel
            {
                Id = ProgramData?.Id ?? 0,
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Duration = txtDuration.Text.Trim()
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Optional: Add shadow effect when form loads
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Fade-in animation (optional)
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