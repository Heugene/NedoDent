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
    public partial class EditDoctor : Form
    {
        private int do_id;
        DataTable data;
        SqlDataAdapter adapter;
        DataRow currentDataRow;

        public EditDoctor(int do_id)
        {
            InitializeComponent();
            this.do_id = do_id;
        }

        private void EditDoctor_Load(object sender, EventArgs e)
        {
            comboBoxGender.DataSource = new char[] { 'Ч', 'Ж' };
            comboBoxCategory.DataSource = new int[] { 2, 1, 0 };

            try
            {
                data = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM Doctors;", DBConnector.Connection);
                adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
                adapter.Fill(data);
                currentDataRow = data.Select("do_id=" + do_id)[0];

                textBoxLname.Text = currentDataRow.ItemArray[1].ToString();
                textBoxFname.Text = currentDataRow.ItemArray[2].ToString();
                textBoxPatro.Text = currentDataRow.ItemArray[3].ToString();
                dateTimePicker.Value = (DateTime)currentDataRow.ItemArray[4];
                comboBoxGender.SelectedIndex = comboBoxGender.FindStringExact(currentDataRow.ItemArray[5].ToString());
                maskedTextBoxPhone.Text = currentDataRow.ItemArray[7].ToString();
                textBoxAddress.Text = currentDataRow.ItemArray[8].ToString();
                comboBoxCategory.SelectedIndex = comboBoxCategory.FindStringExact(currentDataRow.ItemArray[6].ToString());
                checkBoxActive.Checked = (bool)currentDataRow.ItemArray[9];
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                currentDataRow.ItemArray = new object[] { (int)currentDataRow.ItemArray[0], textBoxLname.Text, textBoxFname.Text, textBoxPatro.Text, dateTimePicker.Value.ToShortDateString(), comboBoxGender.SelectedItem.ToString(), comboBoxCategory.SelectedItem.ToString(), maskedTextBoxPhone.Text, textBoxAddress.Text, checkBoxActive.Checked};
                adapter.Update(data);
                this.Close();
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }
    }
}
