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

namespace Supervisor
{
    public partial class NewDoctor : Form
    {
        public NewDoctor()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Doctors;", DBConnector.Connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Fill(data);
                data.Rows.Add(1, textBoxLname.Text, textBoxFname.Text, textBoxPatro.Text, dateTimePicker.Value.ToShortDateString(), comboBoxGender.SelectedItem.ToString(), comboBoxCategory.SelectedItem.ToString(), maskedTextBoxPhone.Text, textBoxAddress.Text, true);
                adapter.Update(data);
                this.Close();
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }

        }

        private void NewDoctor_Load(object sender, EventArgs e)
        {
            comboBoxGender.DataSource = new char[] { 'Ч', 'Ж' };
            comboBoxCategory.DataSource = new int[] { 2, 1, 0 };
        }
    }
}
