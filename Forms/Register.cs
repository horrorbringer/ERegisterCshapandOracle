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

namespace E_Registration.Forms
{
    public partial class Register : Form
    {
        private readonly ProgramService _programService = new ProgramService();
        private readonly StudentService _studentService = new StudentService();

        public Student StudentData { get; private set; }
        public int SelectedProgramId { get; private set; }
        public Register()
        {
            InitializeComponent();
            LoadPrograms();

        }

        private void LoadPrograms()
        {
            var programs = _programService.GetAllPrograms();
            cmbProgram.DataSource = programs;
            cmbProgram.DisplayMember = "NAME";
            cmbProgram.ValueMember = "ID";
        }

        private void loginToAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter full name.");
                    return;
                }
                if (cmbProgram.SelectedValue == null)
                {
                    MessageBox.Show("Please select a program.");
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

                MessageBox.Show("✅ Student registered and enrolled successfully!");

                // Optionally clear form for next entry
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error saving student: " + ex.Message);
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
        }

        private void linkLabelAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var login = new Login();
            login.FormClosed += (s, arags) => this.Close();
            login.Show();
            this.Hide();
        }
    }
}
