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
    public partial class Dentist : Form
    {
        DataSet data;
        SqlDataAdapter displayAdapter;
        SqlDataAdapter editAdapter;

        public Dentist()
        {
            data = new DataSet();
            data.Tables.Add("Edited");
            data.Tables.Add("Displayed"); 
            InitializeComponent();
        }

        private void Dentist_Load(object sender, EventArgs e)
        {
            // Якщо додаток вже був сконфігурований (наявний файл конфігурації)...
            if (Setup.IsConfigured)
            {
                // демонструємо заставку та переходимо одразу до форми авторизації.
                SplashScreen splashScreen = new SplashScreen(this, false);
                splashScreen.Splash();
            }
            // Якщо файл конфігурації відсутній...
            else
            {
                // демонструємо заставку та переходимо на форму конфігурації першого запуску.
                SplashScreen splashScreen = new SplashScreen(this, true);
                splashScreen.Splash();
            }
            toolStripButtonAddServices.Enabled = false;
            displayAdapter = new SqlDataAdapter();
        }

        private void AppDataGridReset()
        {
            try
            {
                data.Tables["Displayed"].Rows.Clear();
                displayAdapter.Fill(data.Tables["Displayed"]);
                dataGridView.DataSource = data.Tables["Displayed"];
                dataGridView.Columns[0].HeaderText = "Код прийому";
                dataGridView.Columns[1].HeaderText = "Дата і час";
                dataGridView.Columns[2].HeaderText = "Пацієнт";
                dataGridView.Columns[3].HeaderText = "Нотатка лікаря";
                dataGridView.Columns[4].HeaderText = "Був проведений?";
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        // Переходимо в налаштування.
        private void налаштуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        // Перегляд інформації про додаток.
        private void проДодатокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        // Вихід із програми.
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Перегляд довідникової таблиці пацієнтів.
        private void пацієнтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm("Patients", false);
            form.ShowDialog();
        }

        // Перегляд довідникової таблиці послуг.
        private void послугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm("Services", false);
            form.ShowDialog();
        }

        // Перегляд довідки.
        private void довідкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Help help = new Common.Help("Dentist");
            help.ShowDialog();
        }

        // Потрібно для правильної роботи заставки.
        private void Dentist_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Запит на підтвердження закриття форми.
        private void Dentist_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closeORnot = MessageBox.Show("Ви дійсно бажаєте вийти?", "Підтвердіть дію", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (closeORnot == DialogResult.No || closeORnot == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void toolStripTextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (toolStripTextBoxSearch.Text != "")
                {
                    Searcher.Search(dataGridView, new int[] { 1, 2, 3, 4 }, toolStripTextBoxSearch.Text);
                }
                else
                {
                    toolStripComboBox_SelectedIndexChanged(sender, e);
                }
            }
        }

        private void Dentist_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                displayAdapter = new SqlDataAdapter($"SELECT Appointments.ap_id, Appointments.datet, CONCAT(Patients.lname, ' ', Patients.fname, ' ', Patients.patro) AS PPIB, Appointments.note, Appointments.isfin FROM Appointments INNER JOIN Patients ON Appointments.pa_id = Patients.pa_id WHERE Appointments.do_id = {Tag};", DBConnector.Connection);
                editAdapter = new SqlDataAdapter("SELECT * FROM Appointments;", DBConnector.Connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(editAdapter);
                editAdapter.UpdateCommand = builder.GetUpdateCommand();
                AppDataGridReset();
                toolStripComboBox.SelectedIndex = 0;
            }
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            AppDataGridReset();
            toolStripComboBox_SelectedIndexChanged(sender, e);
        }

        private void toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppDataGridReset();
            DateTime date = DateTime.Now;
            switch (toolStripComboBox.SelectedItem.ToString())
            {
                case "День":
                    {
                        date = DateTime.Today;
                    }
                    break;
                case "Місяць":
                    {
                        date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    }
                    break;
                case "Рік":
                    {
                        date = new DateTime(DateTime.Today.Year, 1, 1);
                    }
                    break;
                case "Весь час":
                    {
                        date = DateTime.MinValue;
                    }
                    break;
            }
            dataGridView.ClearSelection();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if ((DateTime)row.Cells[1].Value >= date)
                {
                    row.Selected = true;
                }
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)dataGridView.BindingContext[dataGridView.DataSource];
                if (!row.Selected)
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();
                }
            }
            dataGridView.ClearSelection();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null && dataGridView.SelectedRows.Count == 1)
            {
                if (!(bool)dataGridView.CurrentRow.Cells[4].Value)
                {
                    toolStripButtonAddServices.Enabled = true;
                    toolStripButtonView.Enabled = false;
                }
                else
                {
                    toolStripButtonAddServices.Enabled = false;
                    toolStripButtonView.Enabled = true;
                }
            }
            else
            {
                toolStripButtonAddServices.Enabled = false;
                toolStripButtonView.Enabled = false;
            }
        }

        private void toolStripButtonAddServices_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand getDoctorById = new SqlCommand($"SELECT CONCAT(lname, ' ', fname, ' ', patro) AS DPIB FROM Doctors WHERE do_id = {int.Parse(this.Tag.ToString())}", DBConnector.Connection);
                DBConnector.OpenConnection();
                string dPIB = getDoctorById.ExecuteScalar().ToString();
                DBConnector.CloseConnection();
                ProvServices form = new ProvServices((int)dataGridView.CurrentRow.Cells[0].Value, (DateTime)dataGridView.CurrentRow.Cells[1].Value, dPIB, dataGridView.CurrentRow.Cells[2].Value.ToString());
                form.ShowDialog();
                if (form.IsFilled)
                {
                    data.Tables["Edited"].Rows.Clear();
                    editAdapter.Fill(data.Tables["Edited"]);
                    DataRow currentApp = data.Tables["Edited"].Select($"ap_id = {form.AppId}").First();
                    currentApp.ItemArray = new object[] { (int)currentApp[0], (int)currentApp[1], (int)currentApp[2], (DateTime)currentApp[3], form.Note, true };
                    editAdapter.Update(data.Tables["Edited"]);
                    AppDataGridReset();
                }
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand getDoctorById = new SqlCommand($"SELECT CONCAT(lname, ' ', fname, ' ', patro) AS DPIB FROM Doctors WHERE do_id = {int.Parse(this.Tag.ToString())}", DBConnector.Connection);
                DBConnector.OpenConnection();
                string dPIB = getDoctorById.ExecuteScalar().ToString();
                DBConnector.CloseConnection();
                Report report = new Report((int)dataGridView.CurrentRow.Cells[0].Value, (DateTime)dataGridView.CurrentRow.Cells[1].Value, dPIB, dataGridView.CurrentRow.Cells[2].Value.ToString(), dataGridView.CurrentRow.Cells[3].Value.ToString());
                report.ShowDialog();
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }
    }
}
