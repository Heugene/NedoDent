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
    public partial class EditService : Form
    {
        private int se_id;

        private DataTable data;
        private SqlDataAdapter adapter;
        private DataRow currentDataRow;

        public EditService(int se_id)
        {
            InitializeComponent();
            this.se_id = se_id;
        }

        private void EditService_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable categories = new DataTable();
                SqlDataAdapter catAdapter = new SqlDataAdapter("SELECT ServiceCategories.ca_id, ServiceCategories.name FROM ServiceCategories", DBConnector.Connection);
                catAdapter.Fill(categories);
                comboBoxCategory.ValueMember = "ca_id";
                comboBoxCategory.DisplayMember = "name";
                comboBoxCategory.DataSource = categories;

                data = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM Services;", DBConnector.Connection);
                adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
                adapter.Fill(data);
                currentDataRow = data.Select("se_id=" + se_id)[0];

                textBoxName.Text = currentDataRow.ItemArray[1].ToString();
                richTextBoxDescription.Text = currentDataRow.ItemArray[2].ToString();
                comboBoxCategory.SelectedValue = (int)currentDataRow.ItemArray[3];
                numericUpDownPrice.Value = (decimal)currentDataRow.ItemArray[4];
                checkBoxActive.Checked = (bool)currentDataRow.ItemArray[5];
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        private void numericUpDownChPrice_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownPrice.Value = (decimal)currentDataRow.ItemArray[4] + (decimal)currentDataRow.ItemArray[4] * (numericUpDownChPrice.Value / 100);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                currentDataRow.ItemArray = new object[] { currentDataRow.ItemArray[0], textBoxName.Text, richTextBoxDescription.Text, comboBoxCategory.SelectedValue, numericUpDownPrice.Value, checkBoxActive.Checked };
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
