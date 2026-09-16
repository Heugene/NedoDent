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
    public partial class TableForm : Form
    {
        private string tableName;
        private bool selection;
        private DataGridViewRow selectedRow;

        public DataGridViewRow SelectedRow { get => selectedRow; }

        public TableForm(string tableName, bool Selection)
        {
            this.tableName = tableName;
            this.selection = Selection;
            InitializeComponent();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                switch (tableName)
                {
                    case "Patients":
                        {
                            labelHeader.Text = "Пацієнти";
                            adapter.SelectCommand = new SqlCommand("SELECT pa_id, CONCAT(lname, ' ', fname, ' ', patro) AS PPIB, bdate, gender, phone, address, ca_id FROM Patients", DBConnector.Connection);
                            adapter.Fill(data);
                            dataGridView.DataSource = data;
                            dataGridView.Columns[0].HeaderText = "Код пацієнта";
                            dataGridView.Columns[1].HeaderText = "ПІБ";
                            dataGridView.Columns[2].HeaderText = "Дата народження";
                            dataGridView.Columns[3].HeaderText = "Стать";
                            dataGridView.Columns[4].HeaderText = "Телефон";
                            dataGridView.Columns[5].HeaderText = "Адреса";
                            dataGridView.Columns[6].HeaderText = "Категорія пацієнта";
                        }
                        break;
                    case "Services":
                        {
                            labelHeader.Text = "Послуги";
                            adapter.SelectCommand = new SqlCommand("SELECT Services.se_id, Services.name, Services.descr, ServiceCategories.name, Services.price FROM Services INNER JOIN ServiceCategories ON Services.ca_id = ServiceCategories.ca_id WHERE Services.is_active = 1;", DBConnector.Connection);
                            adapter.Fill(data);
                            dataGridView.DataSource = data;
                            dataGridView.Columns[0].HeaderText = "Код послуги";
                            dataGridView.Columns[1].HeaderText = "Назва";
                            dataGridView.Columns[2].HeaderText = "Опис";
                            dataGridView.Columns[3].HeaderText = "Натегорія";
                            dataGridView.Columns[4].HeaderText = "Базова ціна";
                        }
                        break;
                }
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }

        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                switch (labelHeader.Text)
                {
                    case "Пацієнти":
                        {
                            if (textBoxSearch.Text != "")
                            {
                                Searcher.Search(dataGridView, new int[] { 1, 2, 4, 5 }, textBoxSearch.Text);
                            }
                            else
                            {
                                TableForm_Load(sender, e);
                            }
                        }
                        break;
                    case "Послуги":
                        {
                            if (textBoxSearch.Text != "")
                            {
                                Searcher.Search(dataGridView, new int[] { 1, 2, 3 }, textBoxSearch.Text);
                            }
                            else
                            {
                                TableForm_Load(sender, e);
                            }

                        }
                        break;
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentRow != null && selection)
            {
                selectedRow = dataGridView.CurrentRow;
                this.Close();
            }
        }
    }
}
