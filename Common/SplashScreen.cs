using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Common
{
    public partial class SplashScreen : Form
    {
        Form caller;
        Timer timer;
        bool setup;

        public SplashScreen(Form caller, bool setup)
        {
            InitializeComponent();
            this.caller = caller;
            timer = new Timer();
            this.setup = setup;
        }
        public void Splash()
        {
            this.Show();
            timer.Interval = 5000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (setup)
            {
                Setup setupForm = new Setup(caller);
                setupForm.Show();
            }
            else
            {
                AuthForm auth = new AuthForm(caller);
                auth.Show();
            }
            this.timer.Stop();
            this.Close();
        }
    }
}
