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
    public partial class ServiceCategories : Form
    {
        public ServiceCategories()
        {
            InitializeComponent();
        }

        private void ServiceCategories_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ServiceCategories", DBConnector.Connection);
                adapter.Fill(data);
                dataGridView.DataSource = data;
                dataGridView.Columns[0].HeaderText = "Код категорії послуг";
                dataGridView.Columns[1].HeaderText = "Назва категорії";
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null && dataGridView.SelectedRows.Count == 1)
            {
                toolStripButtonEdit.Enabled = true;
            }
            else
            {
                toolStripButtonEdit.Enabled = false;
            }
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            ServiceCategories_Load(sender, e);
        }

        private void toolStripButtonNewService_Click(object sender, EventArgs e)
        {
            NewEditServiceCategory form = new NewEditServiceCategory();
            form.ShowDialog();
            ServiceCategories_Load(sender, e);
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            NewEditServiceCategory form = new NewEditServiceCategory((int)dataGridView.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            ServiceCategories_Load(sender, e);
        }

        private void toolStripTextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (toolStripTextBoxSearch.Text != "")
                {
                    Searcher.Search(dataGridView, new int[] { 0, 1 }, toolStripTextBoxSearch.Text);
                }
                else
                {
                    ServiceCategories_Load(sender, e);
                }
            }
        }
    }
}
