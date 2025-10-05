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

namespace E_Registration.Forms
{
    public partial class FormProgramModal : Form
    {
        public ProgramModel ProgramData { get; private set; }

        public FormProgramModal(ProgramModel model = null)
        {
            InitializeComponent();
            if (model != null)
            {
                ProgramData = model;
                txtName.Text = model.Name;
                txtDescription.Text = model.Description;
                txtDuration.Text = model.Duration;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProgramData = new ProgramModel
            {
                Id = ProgramData?.Id ?? 0,
                Name = txtName.Text,
                Description = txtDescription.Text,
                Duration = txtDuration.Text
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
