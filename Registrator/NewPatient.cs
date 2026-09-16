using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registrator
{
    public partial class NewPatient : Form
    {
        private bool filled = false;

        public string Lname { get; set; }
        public string Fname { get; set; }
        public string Patro { get; set; }
        public DateTime Bdate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Category { get; set; }
        public bool Filled { get => filled; }

        private List<int> categories;

        public NewPatient(List<int> categories)
        {
            InitializeComponent();
            this.categories = categories;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.filled = true;

            Lname = textBoxLname.Text;
            Fname = textBoxFname.Text;
            Patro = textBoxPatro.Text;
            Bdate = dateTimePicker.Value;
            Gender = comboBoxGender.SelectedItem.ToString();
            Phone = maskedTextBoxPhone.Text;
            Address = textBoxAddress.Text;
            Category = (int)comboBoxCategory.SelectedItem;

            this.Close();
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
            comboBoxCategory.DataSource = categories;
            comboBoxGender.DataSource = new char[] { 'Ч', 'Ж' };
        }
    }
}
