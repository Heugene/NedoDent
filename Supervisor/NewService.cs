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
    public partial class NewService : Form
    {
        public NewService()
        {
            InitializeComponent();
        }

        private void NewService_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable categories = new DataTable();
                SqlDataAdapter catAdapter = new SqlDataAdapter("SELECT ServiceCategories.ca_id, ServiceCategories.name FROM ServiceCategories", DBConnector.Connection);
                catAdapter.Fill(categories);
                comboBoxCategory.ValueMember = "ca_id";
                comboBoxCategory.DisplayMember = "name";
                comboBoxCategory.DataSource = categories;
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Services", DBConnector.Connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Fill(data);
                data.Rows.Add(1, textBoxName.Text, richTextBoxDescription.Text, comboBoxCategory.SelectedValue, numericUpDownPrice.Value, true);
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
