using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Common
{
    public partial class Setup : Form
    {
        Form caller;
        bool aborted = true;
        static string configPath = Application.StartupPath + "\\config.bin";

        public Setup(Form caller)
        {
            InitializeComponent();
            this.caller = caller;
        }

        public static bool IsConfigured
        {
            get
            {
                if (File.Exists(configPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void SaveConfig(string appLogin, string appPassword, string serverName, string SQLLogin, string SQLPassword)
        {
            using (var stream = File.Open(Application.StartupPath + "\\config.bin", FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(appLogin);
                    writer.Write(appPassword);
                    writer.Write($"Data Source = {serverName}; Initial Catalog = NedoDent; User ID = {SQLLogin}; Password = {SQLPassword}");
                    stream.Close();
                }
            }
        }

        public static void SaveConfig(string appLogin, string appPassword, string connectionString)
        {
            using (var stream = File.Open(Application.StartupPath + "\\config.bin", FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(appLogin);
                    writer.Write(appPassword);
                    writer.Write(connectionString);
                    stream.Close();
                }
            }
        }

        internal static void ChangePassword(string newPassword)
        {
            using (var stream = File.Open(configPath, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    string Login = reader.ReadString();
                    reader.ReadString();
                    string ConnectionString = reader.ReadString();
                    stream.Close();
                    SaveConfig(Login, newPassword, ConnectionString);
                }
            }
        }

        internal static void ChangeSQLCredentials(string newServerName, string newSQLLogin, string newSQLPassword)
        {
            using (var stream = File.Open(configPath, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    string Login = reader.ReadString();
                    string Password = reader.ReadString();
                    stream.Close();
                    SaveConfig(Login, Password, newServerName, newSQLLogin, newSQLPassword);
                }
            }
        }

        public static bool CredentialsValid(string inputLogin, string inputPassword)
        {
            using (var stream = File.Open(configPath, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    string Login = reader.ReadString();
                    string Password = reader.ReadString();
                    stream.Close();
                    if (inputLogin == Login && inputPassword == Password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static string GetConnectionString()
        {
            using (var stream = File.Open(configPath, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    reader.ReadString();
                    reader.ReadString();
                    string connString = reader.ReadString();
                    stream.Close();
                    return connString;
                    
                }
            }
        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            if (caller.GetType().Name == "Dentist")
            {
                int ID = 0;
                if (int.TryParse(textBoxAppLogin.Text.Split('_').Last(), out ID))
                {
                    try
                    {
                        DataTable doctor = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Doctors WHERE do_id = {ID};", new SqlConnection($"Data Source = {textBoxServerName.Text}; Initial Catalog = NedoDent; User ID = {textBoxSQLLogin.Text}; Password = {textBoxSQLPassword.Text}"));
                        adapter.Fill(doctor);
                        if (doctor.Rows.Count != 1)
                        {
                            MessageBox.Show("Діючий лікар з таким кодом в системі не знайдений!", "Помилка введення!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (MessageBox.Show($"Обраний лікар: {doctor.Rows[0][1]+" "+doctor.Rows[0][2]+" "+ doctor.Rows[0][3]}. Якщо вибір правильний, натисніть Так. Якщо неправильний - Ні.", "Підтвердіть дію", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                aborted = false;
                                MessageBox.Show("Рекомендуємо записати дані для входу і передати працівнику.\n" +
                                    "У випадку втрати даних для входу доведеться перевстановлювати та повторно налаштувати модуль!\n \n" +
                                    $"Дані для входу:\nЛогін: {textBoxAppLogin.Text} ;\nПароль: 1111 .", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                AuthForm auth = new AuthForm(caller);

                                SaveConfig(textBoxAppLogin.Text, "1111", textBoxServerName.Text, textBoxSQLLogin.Text, textBoxSQLPassword.Text);

                                auth.Show();
                                this.Close();
                            }

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не вдалося зв'язатися з БД! Повідомте технічного спеціаліста. \nМожливі причини:\nНеправильна конфігурація модуля (див. Налаштування)\nСервер не відповідає\nСервер не має живлення\nМережеві проблеми на шляху до сервера.", "Помилка з'єднання!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Невірний формат логіну для лікаря! Правильний формат: 'логін_код', де код - код лікаря, який користуватиметься цією копією модуля. Наприклад, 'лікар_32'. Код можна спитати у керівника чи подивитися напряму в БД.", "Помилка введення!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                aborted = false;
                MessageBox.Show("Рекомендуємо записати дані для входу і передати працівнику.\n" +
                    "У випадку втрати даних для входу доведеться перевстановлювати та повторно налаштувати модуль!\n \n" +
                    $"Дані для входу:\nЛогін: {textBoxAppLogin.Text} ;\nПароль: 1111 .", "Попередження!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AuthForm auth = new AuthForm(caller);

                SaveConfig(textBoxAppLogin.Text, "1111", textBoxServerName.Text, textBoxSQLLogin.Text, textBoxSQLPassword.Text);

                auth.Show();
                this.Close();
            }
        }

        private void Setup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (aborted)
            {
                Environment.Exit(0);
            }
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            if (caller.GetType().Name == "Dentist")
            {
                labelDocWarn.Show();
            }
            else
            {
                labelDocWarn.Hide();
            }
        }
    }
}

