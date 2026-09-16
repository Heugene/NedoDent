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
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
        }

        internal void DoctorsReset()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT do_id, CONCAT(lname, ' ', fname, ' ', patro) AS DPIB, bdate, gender, docat, phone, address, is_active FROM Doctors", DBConnector.Connection);
            adapter.Fill(data);
            dataGridView.DataSource = data;
            dataGridView.Columns[0].HeaderText = "Код лікаря";
            dataGridView.Columns[1].HeaderText = "ПІБ";
            dataGridView.Columns[2].HeaderText = "Дата народження";
            dataGridView.Columns[3].HeaderText = "Стать";
            dataGridView.Columns[4].HeaderText = "Категорія лікаря";
            dataGridView.Columns[5].HeaderText = "Телефон";
            dataGridView.Columns[6].HeaderText = "Адреса";
            dataGridView.Columns[7].HeaderText = "Активований?";
        }

        private void Doctors_Load(object sender, EventArgs e)
        {
            DoctorsReset();
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            DoctorsReset();
        }

        private void toolStripButtonNewDoctor_Click(object sender, EventArgs e)
        {
            NewDoctor form = new NewDoctor();
            form.ShowDialog();
            DoctorsReset();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            EditDoctor form = new EditDoctor((int)dataGridView.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            DoctorsReset();
        }

        private void toolStripButtonInactive_Click(object sender, EventArgs e)
        {
            MonthYearParameter form = new MonthYearParameter();
            form.ShowDialog();
            if (form.IsFilled)
            {
                try
                {
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter($" SELECT CONCAT(lname, ' ', fname, ' ', patro) AS DPIB FROM Doctors WHERE NOT EXISTS( SELECT CONCAT(lname, ' ', fname, ' ', patro) AS DPIB, COUNT(ProvidedServices.prse_id) FROM Doctors INNER JOIN ProvidedServices ON Doctors.do_id = ProvidedServices.do_id INNER JOIN Appointments ON ProvidedServices.ap_id = Appointments.ap_id WHERE YEAR(Appointments.datet) = {form.Year} AND MONTH(Appointments.datet) = {form.Month} GROUP BY CONCAT(lname, ' ', fname, ' ', patro))", DBConnector.Connection);
                    adapter.Fill(data);
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = data;
                    if (data.Rows.Count == 0)
                    {
                        MessageBox.Show("Лікарів без практики протягом вибраного періоду знайдено не було.", "Пошук не дав результатів", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    DBConnector.ConnectionFailed();
                }
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

        private void toolStripTextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (toolStripTextBoxSearch.Text != "")
                {
                    Searcher.Search(dataGridView, new int[] { 1, 2, 5, 6 }, toolStripTextBoxSearch.Text);
                }
                else
                {
                    DoctorsReset();
                }
            }
        }
    }
}
