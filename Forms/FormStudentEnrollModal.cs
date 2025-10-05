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
    public partial class FormStudentEnrollModal : Form
    {
        private readonly EnrollmentService _service = new EnrollmentService();
        public Enrollment EnrollmentData { get; private set; }
        public FormStudentEnrollModal(Enrollment existing = null)
        {
            InitializeComponent();
            LoadDropdowns();

            if (existing != null)
            {
                EnrollmentData = existing;

                cmbStudent.SelectedValue = existing.StudentId;
                cmbProgram.SelectedValue = existing.ProgramId;
                dtpEnrollDate.Value = existing.EnrollmentDate;
            }
        }

        private void LoadDropdowns()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedValue == null || cmbProgram.SelectedValue == null)
            {
                MessageBox.Show("Please select both Student and Program.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
