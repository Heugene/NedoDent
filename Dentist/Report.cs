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
    public partial class Report : Form
    {
        private int ap_id;
        private DateTime apDateTime;
        private string doctor;
        private string patient;
        private string note;
        private decimal discount;
        DataTable provServices;

        public Report(int ap_id, DateTime dateTime, string doctor, string patient, string note)
        {
            this.ap_id = ap_id;
            apDateTime = dateTime;
            this.doctor = doctor;
            this.patient = patient;
            this.note = note;
            provServices = new DataTable();

            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            textBoxAppId.Text = ap_id.ToString();
            textBoxAppDateTime.Text = apDateTime.ToString();
            textBoxDpib.Text = doctor;
            textBoxPpib.Text = patient;
            richTextBoxNote.Text = note;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT ROW_NUMBER() OVER(ORDER BY Services.name ASC) AS Row#, Services.name, CONCAT(Doctors.lname,' ',Doctors.fname,' ',Doctors.patro) AS DPIB, Difficulty.koef, Services.price, ProvidedServices.quant, Difficulty.koef * Services.Price * ProvidedServices.quant AS total FROM ProvidedServices INNER JOIN Services ON ProvidedServices.se_id = Services.se_id INNER JOIN Doctors ON ProvidedServices.do_id = Doctors.do_id INNER JOIN Difficulty ON ProvidedServices.di_id = Difficulty.di_id INNER JOIN Appointments ON ProvidedServices.ap_id = Appointments.ap_id WHERE Appointments.ap_id = {ap_id};", DBConnector.Connection);
                adapter.Fill(provServices);
                dataGridView.DataSource = provServices;
                dataGridView.Columns[0].HeaderText = "Номер позиції";
                dataGridView.Columns[1].HeaderText = "Послуга";
                dataGridView.Columns[2].HeaderText = "Лікар";
                dataGridView.Columns[3].HeaderText = "Коефіцієнт складності";
                dataGridView.Columns[4].HeaderText = "Базова вартість";
                dataGridView.Columns[5].HeaderText = "Кількість";
                dataGridView.Columns[6].HeaderText = "Ціна";
                textBoxTotal.Text = provServices.AsEnumerable().Sum(r => r.Field<decimal>(6)).ToString("F2");
                SqlCommand getDiscount = new SqlCommand($"SELECT PatientCategories.disc FROM PatientCategories INNER JOIN Patients ON PatientCategories.ca_id = Patients.ca_id INNER JOIN Appointments ON Patients.pa_id = Appointments.pa_id WHERE Appointments.ap_id = {ap_id}", DBConnector.Connection);
                DBConnector.OpenConnection();
                discount = (decimal)getDiscount.ExecuteScalar();
                DBConnector.CloseConnection();
                textBoxDisc.Text = discount.ToString();
                textBoxTotalWithDisc.Text = (provServices.AsEnumerable().Sum(r => r.Field<decimal>(6)) * discount).ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DBConnector.ConnectionFailed();
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "HTML File|*.html";
                saveFileDialog1.Title = "Зберегти звіт";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog1.FileName);


                    writer.WriteLine("<html>");
                    writer.WriteLine("<head>");
                    writer.WriteLine($"<title>Кошторис {ap_id}</title>");
                    writer.WriteLine("<style>");
                    writer.WriteLine("table, th, td { border: 1px solid black; border-collapse: collapse; }");
                    writer.WriteLine("th, td { padding: 5px 5px 5px 5px; }");
                    writer.WriteLine("</style>");
                    writer.WriteLine("</head>");
                    writer.WriteLine("<body>");
                    writer.WriteLine("<div align = 'center'>");
                    writer.WriteLine($"<h2></h2>");
                    writer.WriteLine($"<h2>Кошторис наданих послуг за прийом №: {ap_id.ToString()}.</h2>");
                    writer.WriteLine($"<h3>Дата проведення: {apDateTime.ToString()}.</h3>");
                    writer.WriteLine($"<h3>Пацієнт: {patient}.</h3>");
                    writer.WriteLine($"<h3>Лікар: {doctor}.</h3>");
                    writer.WriteLine($"<h3>Коефіцієнт знижки по категорії пацієнта: {discount}.</h3>");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("<h3>Надані послуги:</h3>");
                    writer.WriteLine("<table>");
                    writer.WriteLine($"<tr><th>{"Номер позиції"}</th><th>{"Послуга"}</th><th>{"Лікар"}</th><th>{"Коефіцієнт складності"}</th><th>{"Базова вартість"}</th><th>{"Кількість"}</th><th>{"Ціна"}</th></tr>");
                    foreach (DataRow row in provServices.Rows)
                    {
                        writer.WriteLine($"<tr><td>{row[0]}</td><td>{row[1]}</td><td>{row[2]}</td><td>{row[3]}</td><td>{row[4]}</td><td>{row[5]}</td><td>{row[6]}</td></tr>");
                    }
                    writer.WriteLine("</table>");
                    writer.WriteLine($"<h3>Сумарна вартість послуг: {textBoxTotal.Text} грн.</h3>");
                    writer.WriteLine($"<h3>Сума до сплати зі знижкою: {textBoxTotalWithDisc.Text} грн.</h3>");
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                    writer.Close();
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
