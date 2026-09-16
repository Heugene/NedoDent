using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class DBConnector
    {
        private readonly static string ConnectionString = Setup.GetConnectionString();
        public readonly static SqlConnection Connection = new SqlConnection(ConnectionString);

        public static void OpenConnection()
        {
            Connection.Open();
        }

        public static void CloseConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
            { Connection.Close(); }
        }

        public static void ConnectionFailed()
        {
            MessageBox.Show("Не вдалося зв'язатися з БД! Повідомте технічного спеціаліста. \nМожливі причини:\nНеправильна конфігурація модуля (див. Налаштування)\nСервер не відповідає\nСервер не має живлення\nМережеві проблеми на шляху до сервера.", "Помилка з'єднання!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
