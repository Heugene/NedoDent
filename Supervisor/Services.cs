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
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable display = new DataTable();
                SqlDataAdapter displayAdapter = new SqlDataAdapter("SELECT Services.se_id, Services.name, Services.descr, ServiceCategories.name, Services.price, Services.is_active FROM Services INNER JOIN ServiceCategories ON Services.ca_id = ServiceCategories.ca_id", DBConnector.Connection);
                displayAdapter.Fill(display);
                dataGridView.DataSource = display;
                dataGridView.Columns[0].HeaderText = "Код послуги";
                dataGridView.Columns[1].HeaderText = "Назва";
                dataGridView.Columns[2].HeaderText = "Опис";
                dataGridView.Columns[3].HeaderText = "Натегорія";
                dataGridView.Columns[4].HeaderText = "Базова ціна";
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
            Services_Load(sender, e);
        }

        private void toolStripButtonNewService_Click(object sender, EventArgs e)
        {
            NewService form = new NewService();
            form.ShowDialog();
            Services_Load(sender, e);
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            EditService form = new EditService((int)dataGridView.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            Services_Load(sender, e);
        }

        private void toolStripTextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (toolStripTextBoxSearch.Text != "")
                {
                    Searcher.Search(dataGridView, new int[] { 1, 2, 3}, toolStripTextBoxSearch.Text);
                }
                else
                {
                    Services_Load(sender, e);
                }
            }
        }
    }
}
