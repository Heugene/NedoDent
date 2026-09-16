using Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Registrator
{
    public partial class Registrator : Form
    {
        // Для відображення табличних даних в читабельному вигляді
        private DataSet displayedData;
        private SqlDataAdapter appAdapter;
        private SqlDataAdapter patAdapter;
        private SqlDataAdapter docAdapter;

        // Для редагування табличних даних. (Автозгенеровані команди за допомогою SqlCommandBuilder не можуть бути застосовані
        // до таблиць, які були заповнені складними запитами на вибірку, тому було вирішено створити другий DataSet з незмінним
        // поданням даних із БД виключно для редагування тих самих даних).
        private DataSet editedData;
        private SqlDataAdapter appEditAdapter;
        private SqlDataAdapter patEditAdapter;

        public Registrator()
        {
            InitializeComponent();
            this.Opacity = 0; // Потрібно для правильної роботи заставки.

            //Ініціалізація датасету відображення даних та відповідних адаптерів.
            this.displayedData = new DataSet();
            this.displayedData.Tables.Add("Appointments");
            this.displayedData.Tables.Add("Patients");
            this.displayedData.Tables.Add("Doctors");

            //Ініціалізація датасету редагування даних.
            this.editedData = new DataSet();
            this.editedData.Tables.Add("Appointments");
            this.editedData.Tables.Add("Patients");

        }

        private void Registrator_Load(object sender, EventArgs e)
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
            // Ініціалізація побудовників команд.
            try
            {
                this.appAdapter = new SqlDataAdapter("SELECT Appointments.ap_id, Appointments.datet, CONCAT(Doctors.lname, ' ', Doctors.fname, ' ', Doctors.patro) AS DPIB, CONCAT(Patients.lname, ' ', Patients.fname, ' ', Patients.patro) AS PPIB, Appointments.isfin FROM Appointments INNER JOIN Doctors ON Appointments.do_id = Doctors.do_id INNER JOIN Patients ON Appointments.pa_id = Patients.pa_id;", DBConnector.Connection);
                this.patAdapter = new SqlDataAdapter("SELECT pa_id, CONCAT(lname, ' ', fname, ' ', patro) AS PPIB, bdate, gender, phone, address, ca_id FROM Patients", DBConnector.Connection);
                this.docAdapter = new SqlDataAdapter("SELECT do_id, CONCAT(lname, ' ', fname, ' ', patro) AS DPIB, bdate, gender, docat, phone, address FROM Doctors WHERE is_active = 1", DBConnector.Connection);

                this.appEditAdapter = new SqlDataAdapter("SELECT * FROM Appointments", DBConnector.Connection);
                this.patEditAdapter = new SqlDataAdapter("SELECT * FROM Patients", DBConnector.Connection);
                SqlCommandBuilder appCBuilder = new SqlCommandBuilder(appEditAdapter);
                SqlCommandBuilder patCBuilder = new SqlCommandBuilder(patEditAdapter);
                appEditAdapter.InsertCommand = appCBuilder.GetInsertCommand();
                appEditAdapter.DeleteCommand = appCBuilder.GetDeleteCommand();
                appEditAdapter.UpdateCommand = appCBuilder.GetUpdateCommand();
                patEditAdapter.InsertCommand = patCBuilder.GetInsertCommand();
                patEditAdapter.DeleteCommand = patCBuilder.GetDeleteCommand();
                patEditAdapter.UpdateCommand = patCBuilder.GetUpdateCommand();
            }
            catch
            {
                MessageBox.Show("Не вдалося зв'язатися з БД! Повідомте технічного спеціаліста. \nМожливі причини:\nНеправильна конфігурація модуля (див. Налаштування)\nСервер не відповідає\nСервер не має живлення\nМережеві проблеми на шляху до сервера.", "Помилка з'єднання!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Після вирішення проблем перезапустіть додаток!", "Помилка запуску!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Потрібно для нормальної роботи заставки.
        private void Registrator_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Переходимо в налаштування.
        private void налаштуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        // Переходимо на форму перегляду інформації про додаток.
        private void проДодатокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        // Завершення роботи додатка.
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Перегляд табличних даних прийомів.
        private void AppDataGridReset()
        {
            dataGridView.DataSource = null;
            displayedData.Tables["Appointments"].Rows.Clear();
            displayedData.Tables["Appointments"].Columns.Clear();
            try
            {
                appAdapter.Fill(displayedData.Tables["Appointments"]);

                dataGridView.DataSource = displayedData.Tables["Appointments"];

                dataGridView.Columns[0].HeaderText = "Код прийому";
                dataGridView.Columns[1].HeaderText = "Дата і час";
                dataGridView.Columns[2].HeaderText = "Лікар";
                dataGridView.Columns[3].HeaderText = "Пацієнт";
                dataGridView.Columns[4].HeaderText = "Був проведений?";

                labelHeader.Text = "Прийоми";
                panelToolPatients.Hide();

                labelHeader.Show();
                panelToolAppointments.Show();
                panelSearch.Show();
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
            buttonEditPat.Enabled = false;
            buttonCancelApp.Enabled = false;
        }

        // Перегляд табличних даних пацієнтів.
        private void PatDataGridReset()
        {
            dataGridView.DataSource = null;
            displayedData.Tables["Patients"].Rows.Clear();
            displayedData.Tables["Patients"].Columns.Clear();
            try
            {
                patAdapter.Fill(displayedData.Tables["Patients"]);

                dataGridView.DataSource = displayedData.Tables["Patients"];

                dataGridView.Columns[0].HeaderText = "Код пацієнта";
                dataGridView.Columns[1].HeaderText = "ПІБ";
                dataGridView.Columns[2].HeaderText = "Дата народження";
                dataGridView.Columns[3].HeaderText = "Стать";
                dataGridView.Columns[4].HeaderText = "Телефон";
                dataGridView.Columns[5].HeaderText = "Адреса";
                dataGridView.Columns[6].HeaderText = "Категорія пацієнта";

                labelHeader.Text = "Пацієнти";
                panelToolAppointments.Hide();

                labelHeader.Show();
                panelToolPatients.Show();
                panelSearch.Show();
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
            buttonEditPat.Enabled = false;
            buttonCancelApp.Enabled = false;
        }

        // Перегляд табличних даних лікарів.
        private void DocDataGridReset()
        {
            dataGridView.DataSource = null;
            displayedData.Tables["Doctors"].Rows.Clear();
            displayedData.Tables["Doctors"].Columns.Clear();
            try
            {
                docAdapter.Fill(displayedData.Tables["Doctors"]);

                dataGridView.DataSource = displayedData.Tables["Doctors"];

                dataGridView.Columns[0].HeaderText = "Код лікаря";
                dataGridView.Columns[1].HeaderText = "ПІБ";
                dataGridView.Columns[2].HeaderText = "Дата народження";
                dataGridView.Columns[3].HeaderText = "Стать";
                dataGridView.Columns[4].HeaderText = "Категорія лікаря";
                dataGridView.Columns[5].HeaderText = "Телефон";
                dataGridView.Columns[6].HeaderText = "Адреса";

                labelHeader.Text = "Лікарі";
                panelToolAppointments.Hide();
                panelToolPatients.Hide();

                labelHeader.Show();
                panelSearch.Show();
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
            buttonEditPat.Enabled = false;
            buttonCancelApp.Enabled = false;
        }

        private void прийомиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppDataGridReset();
        }

        
        private void пацієнтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatDataGridReset();
        }

        
        private void лікаріToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocDataGridReset();
        }

        // Перегляд довідки.
        private void довідкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Help help = new Common.Help("Registrator");
            help.ShowDialog();
        }

        private void toolStripButtonAppointments_Click(object sender, EventArgs e)
        {
            прийомиToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonPatients_Click(object sender, EventArgs e)
        {
            пацієнтиToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonDoctors_Click(object sender, EventArgs e)
        {
            лікаріToolStripMenuItem_Click(sender, e);
        }

        // Запит на підтвердження виходу з програми.
        private void Registrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closeORnot = MessageBox.Show("Ви дійсно бажаєте вийти?", "Підтвердіть дію", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (closeORnot == DialogResult.No || closeORnot == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        // Реєстрація нового пацієнта.
        private void buttonNewPat_Click(object sender, EventArgs e)
        {
            try
            {
                // Вибірка з БД переліку категорій пацієнтів для заповнення відповідного компоненту введення на формі реєстрації пацієнтів.
                SqlDataAdapter patCatAdapter = new SqlDataAdapter("SELECT ca_id FROM PatientCategories", DBConnector.Connection);
                DataTable patCatTable = new DataTable();
                patCatAdapter.Fill(patCatTable);

                // Ініціалізація та демонстрація форми реєстрації 
                NewPatient form = new NewPatient(patCatTable.AsEnumerable().Select(X => (int)X[0]).ToList());
                form.ShowDialog();

                // Якщо форма була заповнена даними з підтвердженням реєстрації...
                if (form.Filled)
                {
                    // Додаємо новий запис в БД та оновлюємо подання табличних даних на формі.
                    editedData.Tables["Patients"].Rows.Clear();
                    patEditAdapter.Fill(editedData.Tables["Patients"]);
                    editedData.Tables["Patients"].Rows.Add(1, form.Lname, form.Fname, form.Patro, form.Bdate.ToShortDateString(), form.Gender, form.Phone, form.Address, form.Category);
                    patEditAdapter.Update(editedData.Tables["Patients"]);
                    пацієнтиToolStripMenuItem_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEditPat_Click(object sender, EventArgs e)
        {
            try
            {
                // Вибірка з БД переліку категорій пацієнтів для заповнення відповідного компоненту введення на формі реєстрації пацієнтів.
                SqlDataAdapter patCatAdapter = new SqlDataAdapter("SELECT ca_id FROM PatientCategories", DBConnector.Connection);
                DataTable patCatTable = new DataTable();
                patCatAdapter.Fill(patCatTable);

                //Дістаємо таблицю в поданні БД та вибираємо звідти рядок, який зараз редагується для його зміни.
                editedData.Tables["Patients"].Rows.Clear();
                patEditAdapter.Fill(editedData.Tables["Patients"]);
                DataRow currentDataRow = editedData.Tables["Patients"].Select("pa_id=" + dataGridView.CurrentRow.Cells[0].Value.ToString())[0];

                //Перевіряємо, чи можна видаляти пацієнта (кількість проведених прийомів має бути 0).
                DataTable temp = new DataTable();
                appEditAdapter.Fill(temp);
                int AppCount = temp.Select($"pa_id={dataGridView.CurrentRow.Cells[0].Value} AND isfin=1").Length;

                // Ініціалізація та демонстрація форми редагування.
                DataTable doctors = new DataTable();
                docAdapter.Fill(doctors);
                EditPatient form = new EditPatient((int)currentDataRow[0], currentDataRow[1].ToString(), currentDataRow[2].ToString(), currentDataRow[3].ToString(), (DateTime)currentDataRow[4], currentDataRow[5].ToString(), currentDataRow[6].ToString(), currentDataRow[7].ToString(), (int)currentDataRow[8], patCatTable.AsEnumerable().Select(X => (int)X[0]).ToList(), (AppCount == 0), doctors);
                form.ShowDialog();

                // Якщо форма була заповнена даними з підтвердженням змін...
                if (form.Filled)
                {
                    // Оновлюємо поточний запис в БД та подання табличних даних на формі.
                    currentDataRow.ItemArray = new object[] { currentDataRow.ItemArray[0], form.Lname, form.Fname, form.Patro, form.Bdate.ToShortDateString(), form.Gender, form.Phone, form.Address, form.Category };
                    patEditAdapter.Update(editedData.Tables["Patients"]);
                    пацієнтиToolStripMenuItem_Click(sender, e);
                }
                // Якщо обрали видалення пацієнта, видаляємо.
                else if (form.Deleted)
                {
                    currentDataRow.Delete();
                    patEditAdapter.Update(editedData.Tables["Patients"]);
                    пацієнтиToolStripMenuItem_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonNewApp_Click(object sender, EventArgs e)
        {
            try
            {
                displayedData.Tables["Doctors"].Rows.Clear();
                displayedData.Tables["Patients"].Rows.Clear();
                docAdapter.Fill(displayedData.Tables["Doctors"]);
                patAdapter.Fill(displayedData.Tables["Patients"]);
                NewAppointment form = new NewAppointment(displayedData.Tables["Doctors"], displayedData.Tables["Patients"]);
                form.ShowDialog();

                if(form.Filled)
                {
                    AddNewApp(form.Do_id, form.Pa_id, form.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void AddNewApp(int Do_id, int Pa_id, DateTime Date)
        {
            editedData.Tables["Appointments"].Rows.Clear();
            appEditAdapter.Fill(editedData.Tables["Appointments"]);
            editedData.Tables["Appointments"].Rows.Add(1, Do_id, Pa_id, Date, null, false);
            appEditAdapter.Update(editedData.Tables["Appointments"]);
            AppDataGridReset();
        }

        private void buttonCancelApp_Click(object sender, EventArgs e)
        {
            // Дістаємо таблицю в поданні БД та вибираємо звідти рядок, який зараз редагується для його зміни.
            editedData.Tables["Appointments"].Rows.Clear();
            appEditAdapter.Fill(editedData.Tables["Appointments"]);
            DataRow currentDataRow = editedData.Tables["Appointments"].Select("ap_id=" + dataGridView.CurrentRow.Cells[0].Value.ToString())[0];

            // Перевіряємо, чи можна скасувати цей прийом (Можна скасувати лише ті, які ще не були проведені).
            if (!(bool)currentDataRow.ItemArray[5])
            {
                // Можна видалити.
                // Якщо є підтвердження, видаляємо прийом.
                if (MessageBox.Show("Ви дійсно хочете скасувати прийом?", "Підтвердіть дію", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    currentDataRow.Delete();
                    appEditAdapter.Update(editedData.Tables["Appointments"]);
                    прийомиToolStripMenuItem_Click(sender, e);
                }
            }
            else
            {
                // Не можна видалити, повідомляємо.
                MessageBox.Show("Не можна скасувати вже проведений прийом!", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null && dataGridView.SelectedRows.Count == 1)
            {
                buttonEditPat.Enabled = true;
                buttonCancelApp.Enabled = true;
            }
            else
            {
                buttonEditPat.Enabled = false;
                buttonCancelApp.Enabled = false;
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                switch (labelHeader.Text)
                {
                    case "Пацієнти":
                        {
                            buttonEditPat_Click(sender, e);
                        }
                        break;
                }
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
                                пацієнтиToolStripMenuItem_Click(sender, e);
                            }
                        }
                        break;
                    case "Прийоми":
                        {
                            if (textBoxSearch.Text != "")
                            {
                                Searcher.Search(dataGridView, new int[] { 1, 2, 3 }, textBoxSearch.Text);
                            }
                            else
                            {
                                прийомиToolStripMenuItem_Click(sender, e);
                            }

                        }
                        break;
                    case "Лікарі":
                        {
                            if (textBoxSearch.Text != "")
                            {
                                Searcher.Search(dataGridView, new int[] { 1, 2, 5, 6 }, textBoxSearch.Text);
                            }
                            else
                            {
                                лікаріToolStripMenuItem_Click(sender, e);
                            }
                        }
                        break;
                }
            }
        }
    }
}
