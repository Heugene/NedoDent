using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void buttonChPass_Click(object sender, EventArgs e)
        {
            Setup.ChangePassword(textBoxNewPass.Text);
            MessageBox.Show("Пароль було успішно змінено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSaveChs_Click(object sender, EventArgs e)
        {
            Setup.ChangeSQLCredentials(textBoxServerName.Text, textBoxSQLLogin.Text, textBoxSQLPass.Text);
            MessageBox.Show("Параметри для SQL автентифікації були успішно змінені!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                textBoxNewPass.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxNewPass.UseSystemPasswordChar = true;
            }
        }
    }
}
