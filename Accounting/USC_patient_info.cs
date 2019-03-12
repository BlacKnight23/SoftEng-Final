using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Accounting
{
    public partial class USC_patient_info : UserControl
    {
        MySqlConnection conn;
        MySqlDataAdapter adp;
        DataTable dt;

        private static USC_patient_info _instance;

        public static USC_patient_info Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new USC_patient_info();
                return _instance;
            }
        }
        public USC_patient_info()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root ");
        }

        private void USC_patient_info_Load(object sender, EventArgs e)
        {
            loadAll();
        }
        private void loadAll()
        {
            string query = "SELECT * from dc_pr WHERE user_type = 'Patient'";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["pr_id"].Visible = false;
            dataGridView1.Columns["name"].HeaderText = "Name";
            dataGridView1.Columns["fname"].HeaderText = "Firstname";
            dataGridView1.Columns["lname"].HeaderText = "Lastname";
            dataGridView1.Columns["bday"].HeaderText = "Birthdate";
            dataGridView1.Columns["address"].HeaderText = "Address";
            dataGridView1.Columns["age"].HeaderText = "Age";
            dataGridView1.Columns["gender"].HeaderText = "Gender";
            dataGridView1.Columns["contact1"].HeaderText = "Contact 1";

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if (textBox_firstname.Text == " " || textBox_lastname.Text == " " || textBox_address.Text == " " || textBox_age.Text == " "
              || combo_gender.Text == " " || textBox_contact1.Text == " ")
            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {
                string fname = textBox_firstname.Text;
                string lname = textBox_lastname.Text;
                string fullname = fname + " " + lname;

                String query6 = "INSERT INTO dc_pr (name, fname, lname, bday, address, age, gender, contact1, user_type) " +
                               "VALUES('" + fullname + "','" + fname + "', '" + lname + "', '" + birth_date.Value.ToString("yyyy-MM-dd") + "', '" + textBox_address.Text + "', '" + textBox_age.Text + "', '" + combo_gender.Text + "', '" + textBox_contact1.Text + "', 'Patient')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query6, conn);

                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();

            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {

        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            patientlabel_id.Text = "";
            textBox_firstname.Text = "";
            textBox_lastname.Text = "";
            birth_date.Text = "";
            textBox_address.Text = "";
            textBox_age.Text = "";
            combo_gender.Text = "";
            textBox_contact1.Text = "";
            textBox_firstname.Focus();

            button_create.Show();
        }
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            patientlabel_id.Text = dataGridView1.Rows[e.RowIndex].Cells["pr_id"].Value.ToString();
            textBox_firstname.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
            textBox_lastname.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
            textBox_address.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
            textBox_age.Text = dataGridView1.Rows[e.RowIndex].Cells["age"].Value.ToString();
            combo_gender.Text = dataGridView1.Rows[e.RowIndex].Cells["gender"].Value.ToString();
            textBox_contact1.Text = dataGridView1.Rows[e.RowIndex].Cells["contact1"].Value.ToString();

            birth_date.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["bday"].Value.ToString());

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                button_create.Hide();

            }
        }

        private void textBox_search_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            adp = new MySqlDataAdapter("SELECT * FROM dc_pr WHERE fname like '" + textBox_search.Text + "%' OR lname like '" + textBox_search.Text + "%' OR age like '" + textBox_search.Text + "%' OR address like '" + textBox_search.Text + "%' OR contact1 like '" + textBox_search + " %'", conn);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
    }
}
