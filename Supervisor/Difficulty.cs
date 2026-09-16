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
    public partial class Difficulty : Form
    {
        private bool Add;
        private DataTable data;
        private SqlDataAdapter adapter;

        public Difficulty()
        {
            InitializeComponent();
        }

        private void Difficulty_Load(object sender, EventArgs e)
        {
            try
            {
                data = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM Difficulty;", DBConnector.Connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.Fill(data);
                if (data.Rows.Count == 0)
                {
                    Add = true;
                    MessageBox.Show("Увага! В БД не були знайдені потрібні дані. Зараз ця форма працює в режимі додавання. Після натискання кнопки підтвердження, введені дані будуть додані в БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Add = false;
                    numericUpDown1.Value = (decimal)data.Rows[0].ItemArray[1];
                    numericUpDown2.Value = (decimal)data.Rows[1].ItemArray[1];
                    numericUpDown3.Value = (decimal)data.Rows[2].ItemArray[1];
                    numericUpDown4.Value = (decimal)data.Rows[3].ItemArray[1];
                }
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Add)
                {
                    data.Rows.Add(1, numericUpDown1.Value);
                    data.Rows.Add(2, numericUpDown2.Value);
                    data.Rows.Add(3, numericUpDown3.Value);
                    data.Rows.Add(4, numericUpDown4.Value);
                    adapter.Update(data);
                    Difficulty_Load(sender, e);
                }
                else
                {
                    data.Rows[0].ItemArray = new object[] { 1, numericUpDown1.Value };
                    data.Rows[1].ItemArray = new object[] { 2, numericUpDown2.Value };
                    data.Rows[2].ItemArray = new object[] { 3, numericUpDown3.Value };
                    data.Rows[3].ItemArray = new object[] { 4, numericUpDown4.Value };
                    adapter.Update(data);
                    Difficulty_Load(sender, e);
                }
                MessageBox.Show("Зміни були успішно збережені!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                DBConnector.ConnectionFailed();
            }
        }
    }
}
