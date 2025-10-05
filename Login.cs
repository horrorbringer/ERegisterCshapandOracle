using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using E_Registration.Forms;
using E_Registration.Services;

namespace E_Registration
{
    public partial class Login : Form
    {
        private readonly AdminService _service = new AdminService();

        // Modern Color Scheme
        private Color bgGradientStart = ColorTranslator.FromHtml("#667EEA");
        private Color bgGradientEnd = ColorTranslator.FromHtml("#764BA2");
        private Color cardBgColor = ColorTranslator.FromHtml("#FFFFFF");
        private Color accentColor = ColorTranslator.FromHtml("#667EEA");
        private Color textColor = ColorTranslator.FromHtml("#2D3748");
        private Color placeholderColor = ColorTranslator.FromHtml("#A0AEC0");

        // Guna Controls
        private Guna2TextBox txtUsername;
        private Guna2TextBox txtPassword;
        private Guna2Button btnLogin;
        private Guna2Button btnClose;
        private Guna2CheckBox cbRemmeberme;
        private Guna2CheckBox checkboxShowPassword;
        private Guna2Panel mainContainer;
        private Guna2Panel leftPanel;
        private Guna2Panel rightPanel;

        public Login()
        {
            InitializeComponent();
            InitializeGunaComponents();
            CustomizeLoginForm();
        }

        private void InitializeGunaComponents()
        {

            // Main container
            mainContainer = new Guna2Panel
            {
                Size = new Size(900, 500),
                Location = new Point(50, 50),
                BackColor = Color.Transparent,
                BorderRadius = 20
            };

            // Left Panel
            leftPanel = new Guna2Panel
            {
                Size = new Size(400, 500),
                Location = new Point(0, 0),
                BackColor = Color.Transparent,
                FillColor = Color.Transparent
            };

            // Right Panel
            rightPanel = new Guna2Panel
            {
                Size = new Size(480, 500),
                Location = new Point(420, 0),
                BackColor = Color.White,
                FillColor = Color.White,
                BorderRadius = 20
            };
            rightPanel.ShadowDecoration.Enabled = true;
            rightPanel.ShadowDecoration.Shadow = new Padding(10);

            // Username TextBox
            txtUsername = new Guna2TextBox
            {
                Location = new Point(60, 170),
                Size = new Size(280, 40),
                Font = new Font("Segoe UI", 11),
                PlaceholderText = "Enter your username",
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ColorTranslator.FromHtml("#F7FAFC")
            };
            txtUsername.FocusedState.BorderColor = accentColor;

            // Password TextBox
            txtPassword = new Guna2TextBox
            {
                Location = new Point(60, 255),
                Size = new Size(280, 40),
                Font = new Font("Segoe UI", 11),
                PlaceholderText = "Enter your password",
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = ColorTranslator.FromHtml("#E2E8F0"),
                FillColor = ColorTranslator.FromHtml("#F7FAFC"),
                PasswordChar = '●'
            };
            txtPassword.FocusedState.BorderColor = accentColor;

            // Show Password Checkbox
            checkboxShowPassword = new Guna2CheckBox
            {
                Location = new Point(320, 320),
                Size = new Size(140, 20),
                Text = "Show Password",
                Font = new Font("Segoe UI", 9),
                ForeColor = placeholderColor
            };
            checkboxShowPassword.CheckedState.BorderColor = accentColor;
            checkboxShowPassword.CheckedState.FillColor = accentColor;
            checkboxShowPassword.CheckedState.BorderThickness = 1;
            checkboxShowPassword.CheckedChanged += checkboxShowPassword_CheckedChanged;

            // Remember Me Checkbox
            cbRemmeberme = new Guna2CheckBox
            {
                Location = new Point(60, 320),
                Size = new Size(120, 20),
                Text = "Remember me",
                Font = new Font("Segoe UI", 9),
                ForeColor = placeholderColor
            };
            cbRemmeberme.CheckedState.BorderColor = accentColor;
            cbRemmeberme.CheckedState.FillColor = accentColor;
            cbRemmeberme.CheckedState.BorderThickness = 1;

            // Login Button
            btnLogin = new Guna2Button
            {
                Location = new Point(60, 370),
                Size = new Size(360, 50),
                Text = "LOGIN",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BorderRadius = 8,
                FillColor = accentColor,
                Cursor = Cursors.Hand
            };
            btnLogin.HoverState.FillColor = ColorTranslator.FromHtml("#5568D3");
            btnLogin.Click += btnLogin_Click;

            // Close Button
            btnClose = new Guna2Button
            {
                Text = "✕",
                Size = new Size(40, 40),
                Location = new Point(940, 10),
                BorderRadius = 20,
                FillColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.HoverState.FillColor = ColorTranslator.FromHtml("#FFFFFF30");
            btnClose.Click += guna2Button2_Click;
        }

        private void CustomizeLoginForm()
        {
            // Form settings
            this.Size = new Size(1000, 600);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Paint += Login_Paint;

            // Add controls in correct order
            this.Controls.Add(btnClose);
            this.Controls.Add(mainContainer);

            mainContainer.Controls.Add(leftPanel);
            mainContainer.Controls.Add(rightPanel);

            // Bring panels to front
            mainContainer.BringToFront();
            leftPanel.BringToFront();
            rightPanel.BringToFront();

            CreateLeftPanelContent();
            CreateRightPanelContent();
        }

        private void Login_Paint(object sender, PaintEventArgs e)
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

        private void CreateLeftPanelContent()
        {
            // Logo/Brand
            Label lblBrand = new Label
            {
                Text = "E-Registration",
                Location = new Point(50, 120),
                Size = new Size(300, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            leftPanel.Controls.Add(lblBrand);

            // Tagline
            Label lblTagline = new Label
            {
                Text = "Manage your registrations\nwith ease and efficiency",
                Location = new Point(50, 185),
                Size = new Size(300, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            leftPanel.Controls.Add(lblTagline);

            // Decorative panel with icon
            Guna2Panel iconPanel = new Guna2Panel
            {
                Size = new Size(150, 150),
                Location = new Point(125, 280),
                BackColor = Color.Transparent,
                FillColor = ColorTranslator.FromHtml("#FFFFFF30"),
                BorderRadius = 75
            };
            iconPanel.Paint += (s, e) =>
            {
                // Draw a simple user icon
                using (Pen pen = new Pen(Color.White, 3))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawEllipse(pen, 50, 30, 50, 50);
                    e.Graphics.DrawLine(pen, 75, 70, 75, 90);
                    e.Graphics.DrawArc(pen, 45, 85, 60, 40, 0, 180);
                }
            };
            leftPanel.Controls.Add(iconPanel);
        }

        private void CreateRightPanelContent()
        {
            // Welcome text
            Label lblWelcome = new Label
            {
                Text = "Welcome Back!",
                Location = new Point(60, 30),
                Size = new Size(360, 40),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            rightPanel.Controls.Add(lblWelcome);

            Label lblSubtext = new Label
            {
                Text = "Please login to your account",
                Location = new Point(60, 95),
                Size = new Size(360, 25),
                ForeColor = placeholderColor,
                Font = new Font("Segoe UI", 11),
                BackColor = Color.Transparent
            };
            rightPanel.Controls.Add(lblSubtext);

            // Username Label
            Label lblUsername = new Label
            {
                Text = "Username",
                Location = new Point(60, 145),
                Size = new Size(100, 20),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            rightPanel.Controls.Add(lblUsername);

            // Update username textbox position
            txtUsername.Location = new Point(60, 170);
            rightPanel.Controls.Add(txtUsername);

            // Password Label
            Label lblPassword = new Label
            {
                Text = "Password",
                Location = new Point(60, 230),
                Size = new Size(100, 20),
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            rightPanel.Controls.Add(lblPassword);

            // Update password textbox position
            txtPassword.Location = new Point(60, 255);
            rightPanel.Controls.Add(txtPassword);

            // Update checkboxes positions
            cbRemmeberme.Location = new Point(60, 315);
            checkboxShowPassword.Location = new Point(260, 315);

            rightPanel.Controls.Add(cbRemmeberme);
            rightPanel.Controls.Add(checkboxShowPassword);

            // Update login button position
            btnLogin.Location = new Point(60, 365);
            rightPanel.Controls.Add(btnLogin);

            // Forgot password link
            Label lblForgot = new Label
            {
                Text = "Forgot Password?",
                Location = new Point(60, 430),
                Size = new Size(360, 20),
                ForeColor = accentColor,
                Font = new Font("Segoe UI", 9, FontStyle.Underline),
                TextAlign = ContentAlignment.TopCenter,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent
            };
            lblForgot.Click += (s, e) => MessageBox.Show("Password recovery feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            rightPanel.Controls.Add(lblForgot);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = _service.Login(username, password);
            if (success)
            {
                if (cbRemmeberme.Checked)
                    Properties.Settings.Default.isRemmeberme = true;
                else
                    Properties.Settings.Default.isRemmeberme = false;
                Properties.Settings.Default.Save();

                MessageBox.Show("Login successful!", "Welcome",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var adminDashbaord = new AdminDashboard();
                adminDashbaord.FormClosed += (s, arags) => this.Close();
                adminDashbaord.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkboxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShowPassword.Checked)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '●';
        }
    }
}