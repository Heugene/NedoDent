using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registrator
{
    public partial class NewAppointment : Form
    {
        private bool filled = false;

        public DateTime Date { get; set; }
        public int Do_id { get; set; }
        public int Pa_id { get; set; }
        public bool Filled { get => filled; }

        private DataTable doctors;
        private DataTable patients;

        public NewAppointment(DataTable doctors, DataTable patients)
        {
            this.doctors = doctors;
            this.patients = patients;
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.filled = true;

            Date = dateTimePicker.Value;
            Do_id = (int)comboBoxDoctor.SelectedValue;
            Pa_id = (int)comboBoxPatient.SelectedValue;

            this.Close();
        }

        private void NewAppointment_Load(object sender, EventArgs e)
        {
            comboBoxDoctor.DisplayMember = "DPIB";
            comboBoxDoctor.ValueMember = "do_id";
            comboBoxDoctor.DataSource = doctors;

            comboBoxPatient.DisplayMember = "PPIB";
            comboBoxPatient.ValueMember = "pa_id";
            comboBoxPatient.DataSource = patients;

            dateTimePicker.Value = DateTime.Now;
        }
    }
}
