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
    public partial class AuthForm : Form
    {
        Form caller;
        bool aborted = true;

        public AuthForm(Form caller)
        {
            InitializeComponent();
            this.caller = caller;
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            if (Setup.CredentialsValid(textBoxLogin.Text, textBoxPassword.Text))
            {
                if (caller.GetType().Name == "Dentist")
                {
                    caller.Tag = textBoxLogin.Text.Split('_').Last();
                }
                aborted = false;
                caller.Opacity = 100;
                caller.Show();
                caller.Enabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Невірний пароль або логін", "Помилка входу!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (aborted)
            {
                Environment.Exit(0);
            }
        }
    }
}
