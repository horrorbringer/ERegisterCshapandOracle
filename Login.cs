using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Registration.Forms;
using E_Registration.Services;

namespace E_Registration
{
    public partial class Login : Form
    {
        private readonly AdminService _service = new AdminService();
        public Login()
        {
            InitializeComponent();
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
                MessageBox.Show("Please enter both username and password.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open main admin form
                var adminDashbaord = new AdminDashboard();
                adminDashbaord.FormClosed += (s, arags) => this.Close();
                adminDashbaord.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkboxShowPassword_Click(object sender, EventArgs e)
        {
            if (checkboxShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }
    }
}
