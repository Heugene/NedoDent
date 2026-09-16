using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Common;

namespace Dentist
{
    public partial class ProvServicesAdd : Form
    {
        private bool isFilled = false;

        private int se_id;
        private int di_id;
        private int ap_id;
        private int do_id;
        private short quantity;

        private string service;
        private string difficulty;
        private string doctor;

        public bool IsFilled { get => isFilled; } 

        public int Se_id { get => se_id; }
        public int Di_id { get => di_id; }
        public int Ap_id { get => ap_id; }
        public int Do_id { get => do_id; }
        public int Quantity { get => quantity; }

        public string Service { get => service; }
        public string Difficulty { get => difficulty; }
        public string Doctor { get => doctor; }

        public ProvServicesAdd(int ap_id)
        {
            this.ap_id = ap_id;
            InitializeComponent();
        }

        private void ProvServicesAdd_Load(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = false;
            try
            {
                textBoxAppId.Text = ap_id.ToString();

                DataTable doctors = new DataTable();
                SqlDataAdapter doctorsAdapter = new SqlDataAdapter("SELECT do_id, CONCAT(lname, ' ', fname, ' ', patro) AS DPIB FROM Doctors", DBConnector.Connection);
                doctorsAdapter.Fill(doctors);
                comboBoxDoctor.DisplayMember = "DPIB";
                comboBoxDoctor.ValueMember = "do_id";
                comboBoxDoctor.DataSource = doctors;
                var values = new List<Tuple<int, string>>();
                values.Add(new Tuple<int, string>(1, "Початкова"));
                values.Add(new Tuple<int, string>(2, "Середня"));
                values.Add(new Tuple<int, string>(3, "Висока"));
                values.Add(new Tuple<int, string>(4, "Критична"));
                comboBoxDifficulty.DisplayMember = "Item2";
                comboBoxDifficulty.ValueMember = "Item1";
                comboBoxDifficulty.DataSource = values;
                comboBoxDifficulty.SelectedIndex = 0;
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm("Services", true);
            form.ShowDialog();
            if (form.SelectedRow != null)
            {
                se_id = (int)form.SelectedRow.Cells[0].Value;
                textBoxService.Text = form.SelectedRow.Cells[1].Value.ToString();
                service = textBoxService.Text;
            }
            buttonConfirm.Enabled = true;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            isFilled = true;
            di_id = (int)comboBoxDifficulty.SelectedValue;
            do_id = (int)comboBoxDoctor.SelectedValue;
            quantity = (short)numericUpDownQuantity.Value;
            doctor = ((DataRowView)comboBoxDoctor.SelectedItem).Row.ItemArray[1].ToString();
            difficulty = ((Tuple<int, string>)comboBoxDifficulty.SelectedItem).Item2;
            this.Close();
        }
    }
}
