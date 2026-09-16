using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class MonthYearParameter : Form
    {
        private bool isFilled = false;
        private int year;
        private int month;

        public bool IsFilled { get => isFilled; }
        public int Month { get => month; }
        public int Year { get => year; }

        public MonthYearParameter()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            month = (int)comboBoxMonth.SelectedValue;
            year = (int)numericUpDownYear.Value;

            isFilled = true;
            this.Close();
        }

        private void MonthYearParameter_Load(object sender, EventArgs e)
        {
            numericUpDownYear.Value = DateTime.Now.Year;
            var values = new List<Tuple<int, string>>();
            values.Add(new Tuple<int, string>(1, "Січень"));
            values.Add(new Tuple<int, string>(2, "Лютий"));
            values.Add(new Tuple<int, string>(3, "Березень"));
            values.Add(new Tuple<int, string>(4, "Квітень"));
            values.Add(new Tuple<int, string>(5, "Травень"));
            values.Add(new Tuple<int, string>(6, "Червень"));
            values.Add(new Tuple<int, string>(7, "Липень"));
            values.Add(new Tuple<int, string>(8, "Серпень"));
            values.Add(new Tuple<int, string>(9, "Вересень"));
            values.Add(new Tuple<int, string>(10, "Жовтень"));
            values.Add(new Tuple<int, string>(11, "Листопад"));
            values.Add(new Tuple<int, string>(12, "Грудень"));
            comboBoxMonth.DisplayMember = "Item2";
            comboBoxMonth.ValueMember = "Item1";
            comboBoxMonth.DataSource = values;
            comboBoxMonth.SelectedIndex = DateTime.Now.Month;
        }
    }
}
