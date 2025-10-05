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

namespace E_Registration.Forms
{
    public partial class FormStudentModal : Form
    {
        public Student StudentData { get; private set; }
        public FormStudentModal(Student student = null)
        {
            InitializeComponent();
            if (student != null)
            {
                txtName.Text = student.FullName;
                dtpDob.Value = student.DOB;
                cmbGender.Text = student.Gender;
                txtPhone.Text = student.Phone;
                txtAddress.Text = student.Address;
                StudentData = student;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            StudentData = new Student
            {
                Id = StudentData?.Id ?? 0,
                FullName = txtName.Text,
                DOB = dtpDob.Value,
                Gender = cmbGender.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

           }
}
