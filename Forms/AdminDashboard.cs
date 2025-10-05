using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Registration.Services;
using E_Registration.Data;
using Oracle.ManagedDataAccess.Client;
using E_Registration.Models;
using System.Runtime.InteropServices;

namespace E_Registration.Forms
{
    public partial class AdminDashboard : Form
    {
        private readonly ProgramService _service = new ProgramService();
        private readonly StudentService _studentService = new StudentService();
        private readonly EnrollmentService _enrollmentService = new EnrollmentService();
        private int selectedId = 0;
        private bool buttonsAdded = false; // Add this as a class-level field

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(guna2DataGridViewProgram.Rows[e.RowIndex].Cells["ID"].Value);

            if (guna2DataGridViewProgram.Columns[e.ColumnIndex].Name == "Edit")
            {
                var model = new ProgramModel
                {
                    Id = id,
                    Name = guna2DataGridViewProgram.Rows[e.RowIndex].Cells["Name"].Value.ToString(),
                    Description = guna2DataGridViewProgram.Rows[e.RowIndex].Cells["Description"].Value.ToString(),
                    Duration = guna2DataGridViewProgram.Rows[e.RowIndex].Cells["Duration"].Value.ToString(),
                };

                var modal = new FormProgramModal(model);
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    _service.UpdateProgram(modal.ProgramData);
                    LoadDataProgram();
                }
            }
            else if (guna2DataGridViewProgram.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Delete this program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _service.DeleteProgram(id);
                    LoadDataProgram();
                }
            }
        }

        private void program_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDataProgram();
            LoadDataStudents();
            LoadEnrollments();
        }

        private void LoadDataProgram()
        {
            try
            {
                DataTable dt = _service.GetAllPrograms();
                guna2DataGridViewProgram.DataSource = dt;
                guna2DataGridViewProgram.ColumnHeadersHeight = 20;
                guna2DataGridViewProgram.Columns["ID"].Visible = false;
                guna2DataGridViewProgram.AllowUserToAddRows = false;
                AddActionProgramButtons();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No programs found in the database.");
                }

                // Optional: auto resize columns
                guna2DataGridViewProgram.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading programs: " + ex.Message);
            }
        }
        private void LoadDataStudents()
        {
            try
            {
                DataTable dt = _studentService.GetAllStudents();
                guna2DataGridViewStudents.DataSource = dt;
                guna2DataGridViewStudents.ColumnHeadersHeight = 20;
                guna2DataGridViewStudents.Columns["ID"].Visible = false;
                guna2DataGridViewStudents.AllowUserToAddRows = false;

                // Add Edit/Delete buttons once only
                if (!buttonsAdded)
                {
                    ActionStudentButton();
                    buttonsAdded = true;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No student found in the database.");
                }

                // Optional: auto resize columns
                guna2DataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }

        }
        private void LoadEnrollments()
        {
            try
            {
                var dt = _enrollmentService.GetAllEnrolledStudents();
                guna2DataGridViewEnrollments.DataSource = dt;
                guna2DataGridViewEnrollments.ColumnHeadersHeight = 20;
                guna2DataGridViewEnrollments.Columns["enrollment_id"].Visible = false;
                guna2DataGridViewEnrollments.Columns["student_id"].Visible = false;
                guna2DataGridViewEnrollments.Columns["program_id"].Visible = false;

                if (guna2DataGridViewEnrollments.Columns["EditBtn"] == null)
                {
                    var editBtn = new DataGridViewButtonColumn
                    {
                        Name = "EditBtn",              // ✅ important
                        HeaderText = "Edit",
                        Text = "✏️",
                        UseColumnTextForButtonValue = true
                    };
                    guna2DataGridViewEnrollments.Columns.Add(editBtn);
                }

                if (guna2DataGridViewEnrollments.Columns["DeleteBtn"] == null)
                {
                    var deleteBtn = new DataGridViewButtonColumn
                    {
                        Name = "DeleteBtn",            // ✅ important
                        HeaderText = "Delete",
                        Text = "❌",
                        UseColumnTextForButtonValue = true
                    };
                    guna2DataGridViewEnrollments.Columns.Add(deleteBtn);
                }
                guna2DataGridViewEnrollments.Columns["EditBtn"].Width = 30;
                guna2DataGridViewEnrollments.Columns["DeleteBtn"].Width = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }
        
        private void AddActionProgramButtons()
        {
            // Prevent adding twice
            if (guna2DataGridViewProgram.Columns["Edit"] == null)
            {
                // Add Edit button
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 30;
                guna2DataGridViewProgram.Columns.Add(editBtn);

                // Add Delete button
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "Delete";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Width = 30;
                guna2DataGridViewProgram.Columns.Add(deleteBtn);
            }
            guna2DataGridViewProgram.Columns["Edit"].Width = 50;
            guna2DataGridViewProgram.Columns["Delete"].Width = 70;
        }
        private void ActionStudentButton()
        {
            // Add Edit button
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "Edit"
            };
            guna2DataGridViewStudents.Columns.Add(editBtn);

            // Add Delete button
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "Delete"
            };
            guna2DataGridViewStudents.Columns.Add(deleteBtn);

            guna2DataGridViewStudents.Columns["Edit"].Width = 50;
            guna2DataGridViewStudents.Columns["Delete"].Width = 70;
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            var modal = new FormProgramModal();
            if (modal.ShowDialog() == DialogResult.OK)
            {
                _service.AddProgram(modal.ProgramData);
                LoadDataProgram();
            }
        }

        private void btnLoadModelAddStudents_Click(object sender, EventArgs e)
        {
            var model = new FormStudentModal();
            if(model.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Adding student: " + model.StudentData.FullName); // 🧩 Debug line
                _studentService.AddStudent(model.StudentData);
                LoadDataStudents();
            }
        }

        private void guna2DataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = guna2DataGridViewStudents.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);

            if (guna2DataGridViewStudents.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                var s = new Student
                {
                    Id = id,
                    FullName = row.Cells["FULL_NAME"].Value.ToString(),
                    DOB = Convert.ToDateTime(row.Cells["DOB"].Value),
                    Gender = row.Cells["GENDER"].Value.ToString(),
                    Phone = row.Cells["PHONE"].Value.ToString(),
                    Address = row.Cells["ADDRESS"].Value.ToString(),
                };

                var form = new FormStudentModal(s);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _studentService.UpdateStudent(form.StudentData);
                    LoadDataStudents();
                }
            }
            else if (guna2DataGridViewStudents.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                if (MessageBox.Show("Delete this student?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _studentService.DeleteStudent(id);
                    LoadDataStudents();
                }
            }
        }

        private void guna2DataGridViewEnrollments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (guna2DataGridViewEnrollments.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                int id = Convert.ToInt32(guna2DataGridViewEnrollments.Rows[e.RowIndex].Cells["ENROLLMENT_ID"].Value);
                EditEnrollment(id);
            }
            else if (guna2DataGridViewEnrollments.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                int id = Convert.ToInt32(guna2DataGridViewEnrollments.Rows[e.RowIndex].Cells["ENROLLMENT_ID"].Value);
                if (MessageBox.Show("Delete this enrollment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _enrollmentService.DeleteEnrollment(id);
                    LoadEnrollments();
                }
            }
        }
        private void EditEnrollment(int id)
        {
            var row = guna2DataGridViewEnrollments.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => Convert.ToInt32(r.Cells["ENROLLMENT_ID"].Value) == id);

            if (row != null)
            {
                var enrollment = new Enrollment
                {
                    Id = id,
                    StudentId = Convert.ToInt32(row.Cells["STUDENT_ID"].Value),   // direct ID
                    ProgramId = Convert.ToInt32(row.Cells["PROGRAM_ID"].Value),   // direct ID
                    EnrollmentDate = Convert.ToDateTime(row.Cells["ENROLLMENT_DATE"].Value)
                };

                var frm = new FormStudentEnrollModal(enrollment);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _enrollmentService.SaveEnrollment(frm.EnrollmentData);
                    LoadEnrollments();
                }
            }
        }

        private void btnLoadAddEnroll_Click(object sender, EventArgs e)
        {
            var frm = new FormStudentEnrollModal();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _enrollmentService.SaveEnrollment(frm.EnrollmentData);
                LoadEnrollments();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.isRemmeberme = false;
            Properties.Settings.Default.Save();

            var login = new Login();
            login.FormClosed += (s, arags) => this.Close();
            login.Show();
            this.Hide();

        }

        private void guna2PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
