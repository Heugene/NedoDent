using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Common;

namespace Dentist
{
    public partial class ProvServices : Form
    {
        private bool isFilled = false;
        private int appId;
        private DateTime appDateTime;
        private string dPIB;
        private string pBIB;
        private string note;

        public bool IsFilled { get => isFilled; }
        public string Note { get => note; }
        public int AppId { get => appId; }

        private DataTable provServices;
        private SqlDataAdapter provServicesAdapter;

        public ProvServices(int appId, DateTime appDateTime, string dPIB, string pBIB)
        {
            InitializeComponent();
            this.appId = appId;
            this.appDateTime = appDateTime;
            this.dPIB = dPIB;
            this.pBIB = pBIB;
        }

        private void ProvServices_Load(object sender, EventArgs e)
        {
            textBoxAppId.Text = appId.ToString();
            textBoxAppDateTime.Text = appDateTime.ToString();
            textBoxPpib.Text = pBIB;
            textBoxDpib.Text = dPIB;

            try
            {
                provServices = new DataTable();
                provServicesAdapter = new SqlDataAdapter("SELECT * FROM ProvidedServices", DBConnector.Connection);
                provServicesAdapter.Fill(provServices);
                SqlCommandBuilder builder = new SqlCommandBuilder(provServicesAdapter);
                provServicesAdapter.InsertCommand = builder.GetInsertCommand();
                provServicesAdapter.UpdateCommand = builder.GetUpdateCommand();

                dataGridView.Columns.Add("Service", "Послуга");
                dataGridView.Columns.Add("Difficulty", "Складність");
                dataGridView.Columns.Add("Doctor", "Лікар");
                dataGridView.Columns.Add("Quantity", "Кількість");
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            ProvServicesAdd form = new ProvServicesAdd(appId);
            form.ShowDialog();
            if (form.IsFilled)
            {
                provServices.Rows.Add(1, form.Se_id, form.Di_id, form.Ap_id, form.Do_id, form.Quantity);
                dataGridView.Rows.Add(form.Service, form.Difficulty, form.Doctor, form.Quantity);
                buttonConfirm.Enabled = true;
            }
        }

        private void buttonRemoveService_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Remove(dataGridView.CurrentRow);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.note = richTextBoxNote.Text;
            provServicesAdapter.Update(provServices);

            isFilled = true;
            this.Close();
        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            provServices.Rows.RemoveAt(provServices.Rows.Count - e.RowIndex - 1);
            if (dataGridView.Rows.Count == 0)
            {
                buttonConfirm.Enabled = false;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                buttonRemoveService.Enabled = true;
            }
            else
            {
                buttonRemoveService.Enabled = false;
            }
        }
    }
}
