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
    public partial class NewEditServiceCategory : Form
    {
        private int ca_id;

        public NewEditServiceCategory()
        {
            this.ca_id = -1;
            InitializeComponent();
        }

        public NewEditServiceCategory(int ca_id)
        {
            this.ca_id = ca_id;
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ServiceCategories", DBConnector.Connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Fill(data);
                if (ca_id != -1)
                {
                    data.Select("ca_id=" + ca_id)[0].ItemArray = new object[] { data.Select("ca_id=" + ca_id)[0].ItemArray[0], textBoxName.Text };
                    adapter.Update(data);
                }
                else
                {
                    data.Rows.Add(1, textBoxName.Text);
                    adapter.Update(data);
                }
                this.Close();
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }
    }
}
