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
    public partial class EditPatient : Form
    {
        private List<int> categories;

        private bool filled = false;
        private bool deleted = false;
        private bool isRemovable;
        private DataTable Doctors;
        private int id;

        public string Lname { get; set; }
        public string Fname { get; set; }
        public string Patro { get; set; }
        public DateTime Bdate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Category { get; set; }
        public bool Filled { get => filled;}
        public bool Deleted { get => deleted;}

        public EditPatient(int id, string lname, string fname, string patro, DateTime bdate, string gender, string phone, string address, int category, List<int> categories, bool isRemovable, DataTable doctors)
        {
            this.id = id;
            this.Lname = lname;
            this.Fname = fname;
            this.Patro = patro;
            this.Bdate = bdate;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
            this.Category = category;
            this.categories = categories;
            this.isRemovable = isRemovable;
            this.Doctors = doctors;

            InitializeComponent();
        }

        private void EditPatient_Load(object sender, EventArgs e)
        {
            textBoxLname.Text = Lname;
            textBoxFname.Text = Fname;
            textBoxPatro.Text = Patro;
            dateTimePicker.Value = Bdate;
            comboBoxGender.DataSource = new char[] { 'М', 'Ж' };
            comboBoxGender.SelectedItem = comboBoxGender.FindStringExact(Gender);
            maskedTextBoxPhone.Text = Phone;
            textBoxAddress.Text = Address;
            comboBoxCategory.DataSource = categories;
            comboBoxCategory.SelectedItem = Category;

            if (!isRemovable)
            {
                buttonDel.Enabled = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
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

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете видалити пацієнта з системи?", "Підтвердіть дію", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleted = true;
                this.Close();
            }
        }

        private void buttonNewApp_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable patient = new DataTable();
                patient.Columns.Add("pa_id", typeof(Int32));
                patient.Columns.Add("PPIB", typeof(String));
                patient.Rows.Add(id, Lname+" "+Fname+" "+Patro);
                NewAppointment form = new NewAppointment(Doctors, patient);
                form.ShowDialog();

                if (form.Filled)
                {
                    Application.OpenForms.OfType<Registrator>().First().AddNewApp(form.Do_id, form.Pa_id, form.Date);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
