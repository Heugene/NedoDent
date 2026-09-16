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
    public partial class Supervisor : Form
    {
        public Supervisor()
        {
            this.Opacity = 0; // Потрібно для правильної роботи заставки.
            InitializeComponent();
        }

        private void ChartYearDoctorsLoad()
        {
            try
            {
                chartYearDoctors.Series.Clear();
                int year = (int)numericUpDown1.Value;
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT CONCAT(Doctors.lname, ' ', Doctors.fname, ' ', Doctors.patro) AS DPIB, SUM(Services.price * ProvidedServices.quant * Difficulty.koef * PatientCategories.disc) AS YearIncome FROM Doctors INNER JOIN ProvidedServices ON Doctors.do_id = ProvidedServices.do_id INNER JOIN Services ON ProvidedServices.se_id = Services.se_id INNER JOIN Difficulty ON ProvidedServices.di_id = Difficulty.di_id INNER JOIN Appointments ON ProvidedServices.ap_id = Appointments.ap_id INNER JOIN Patients ON Appointments.pa_id = Patients.pa_id INNER JOIN PatientCategories ON Patients.ca_id = PatientCategories.ca_id WHERE YEAR(Appointments.datet) = {year} GROUP BY CONCAT(Doctors.lname, ' ', Doctors.fname, ' ', Doctors.patro)", DBConnector.Connection);
                adapter.Fill(data);

                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("За обраний рік послуги не надавалися.", "Дані не знайдені", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                chartYearDoctors.Series.Add("Main");
                chartYearDoctors.Series["Main"].Label = "#VALY (#PERCENT{P2})";
                chartYearDoctors.Series["Main"].LegendText = "#VALX";
                chartYearDoctors.Series["Main"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chartYearDoctors.Series["Main"].XValueMember = "DPIB";
                chartYearDoctors.Series["Main"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                chartYearDoctors.Series["Main"].YValueMembers = "YearIncome";
                chartYearDoctors.Series["Main"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Auto;
                chartYearDoctors.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChartYearIncomeDoctorLoad()
        {
            try
            {
                chartYearIncomeDoctor.Series.Clear();
                int doctor = (int)comboBoxDoctors.SelectedValue;
                int year = (int)numericUpDown2.Value;
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT DATENAME(mm, Appointments.datet) AS Month,  MONTH(Appointments.datet) , SUM(Services.price * ProvidedServices.quant * Difficulty.koef * PatientCategories.disc) AS Income FROM Doctors INNER JOIN ProvidedServices ON Doctors.do_id = ProvidedServices.do_id INNER JOIN Services ON ProvidedServices.se_id = Services.se_id INNER JOIN Difficulty ON ProvidedServices.di_id = Difficulty.di_id INNER JOIN Appointments ON ProvidedServices.ap_id = Appointments.ap_id INNER JOIN Patients ON Appointments.pa_id = Patients.pa_id INNER JOIN PatientCategories ON Patients.ca_id = PatientCategories.ca_id WHERE ProvidedServices.do_id = {doctor}  AND YEAR(Appointments.datet) = {year} GROUP BY DATENAME(mm, Appointments.datet),  MONTH(Appointments.datet) ORDER BY MONTH(Appointments.datet)", DBConnector.Connection);
                adapter.Fill(data);

                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("За обраний рік послуги не надавалися.", "Дані не знайдені", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                chartYearIncomeDoctor.Series.Add("Main");
                chartYearIncomeDoctor.Series["Main"].XValueMember = "Month";
                chartYearIncomeDoctor.Series["Main"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                chartYearIncomeDoctor.Series["Main"].YValueMembers = "Income";
                chartYearIncomeDoctor.Series["Main"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Auto;
                chartYearIncomeDoctor.Series["Main"].IsVisibleInLegend = false;
                chartYearIncomeDoctor.Series["Main"].Label = "#PERCENT{P2}";
                chartYearIncomeDoctor.Series["Main"].LabelBackColor = Color.White;
                chartYearIncomeDoctor.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboboxDoctorsFill()
        {
            try
            {
                DataTable doctors = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Doctors.do_id, CONCAT(Doctors.lname, ' ', Doctors.fname, ' ', Doctors.patro) AS DPIB FROM Doctors", DBConnector.Connection);
                adapter.Fill(doctors);
                comboBoxDoctors.ValueMember = "do_id";
                comboBoxDoctors.DisplayMember = "DPIB";
                comboBoxDoctors.DataSource = doctors;
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        private void Supervisor_Load(object sender, EventArgs e)
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

            numericUpDown1.Value = DateTime.Now.Year;
            numericUpDown2.Value = DateTime.Now.Year;

            ComboboxDoctorsFill();
            ChartYearDoctorsLoad();
            ChartYearIncomeDoctorLoad();
        }

        private void Supervisor_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void налаштуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void проДодатокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void лікаріToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doctors doctors = new Doctors();
            doctors.ShowDialog();
        }

        private void послугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.ShowDialog();
        }

        private void категоріїПослугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceCategories serviceCategories = new ServiceCategories();
            serviceCategories.ShowDialog();
        }

        private void категоріїПацієнтівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientCategories patientCategories = new PatientCategories();
            patientCategories.ShowDialog();
        }

        private void категоріїСкладностіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.ShowDialog();
        }

        private void довідкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Help help = new Common.Help("Supervisor");
            help.ShowDialog();
        }

        private void Supervisor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closeORnot = MessageBox.Show("Ви дійсно бажаєте вийти?", "Підтвердіть дію", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (closeORnot == DialogResult.No || closeORnot == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            ComboboxDoctorsFill();
            ChartYearDoctorsLoad();
            ChartYearIncomeDoctorLoad();
        }

        private void buttonShow2Chart_Click(object sender, EventArgs e)
        {
            ChartYearIncomeDoctorLoad();
        }

        private void buttonShow1Chart_Click(object sender, EventArgs e)
        {
            ChartYearDoctorsLoad();
        }

    }
}
