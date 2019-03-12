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
    public partial class USC_user : UserControl
    {
        MySqlConnection conn;
        MySqlDataAdapter adp;
        DataTable dt;
        private static USC_user _instance;

        public static USC_user Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new USC_user();
                return _instance;
            }
        }
        public USC_user()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root ");
        }

        private void USC_user_Load(object sender, EventArgs e)
        {
            loadAll();
        }

        private void loadAll()
        {
            string query = "SELECT * from user";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["user_id"].Visible = false;
            dataGridView1.Columns["user_firstname"].HeaderText = "Firstname";
            dataGridView1.Columns["user_lastname"].HeaderText = "Lastname";
            dataGridView1.Columns["user_username"].HeaderText = "Username";
            dataGridView1.Columns["user_password"].HeaderText = "password";
            dataGridView1.Columns["user_type"].HeaderText = "Role";
            

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if (textBox_firstname.Text == " " || textBox_lastname.Text == " " || textBox_username.Text == " " || textBox_password.Text == " " || combo_usertype.Text == " ")

            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {


                String username = textBox_username.Text;
                String query = "SELECT *FROM user WHERE user_username = '" + username + "'";
                conn.Open();

                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Username Already Taken!");
                }
                else
                {


                    String query3 = "INSERT INTO user(user_firstname, user_lastname,user_username, user_password, user_type) " +
                                   "VALUES('" + textBox_firstname.Text + "', '" + textBox_lastname.Text + "', '" + textBox_username.Text + "', '" + textBox_password.Text + "', '" + combo_usertype.Text + "')";

                    
                    MySqlCommand comm = new MySqlCommand(query3, conn);


                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadAll();
                    MessageBox.Show("Created Successfully!");

                }

            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == " " || textBox_password.Text == " " || textBox_firstname.Text == " " || textBox_lastname.Text == " ")
            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {
                String id = userlabel_id.Text;
                String query5 = "SELECT *FROM user WHERE user_id ='" + id + "'";
                conn.Open();

                MySqlCommand com = new MySqlCommand(query5, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();


                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Username Already Taken!");
                }
                else
                {


                    String query4 = "Update user set user_firstname='" + textBox_firstname.Text + "', user_lastname='" + textBox_lastname.Text + "', user_username = '" + textBox_username.Text + "', user_password = '" + textBox_password.Text + "', user_type = '" + combo_usertype.Text + "' where user_id = '" + userlabel_id.Text + "'";


                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query4, conn);


                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadAll();
                    MessageBox.Show("Updated Successfully!");
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            userlabel_id.Text = dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value.ToString();
            textBox_firstname.Text = dataGridView1.Rows[e.RowIndex].Cells["user_firstname"].Value.ToString();
            textBox_lastname.Text = dataGridView1.Rows[e.RowIndex].Cells["user_lastname"].Value.ToString();
            textBox_username.Text = dataGridView1.Rows[e.RowIndex].Cells["user_username"].Value.ToString();
            textBox_password.Text = dataGridView1.Rows[e.RowIndex].Cells["user_password"].Value.ToString();
            combo_usertype.Text = dataGridView1.Rows[e.RowIndex].Cells["user_type"].Value.ToString();



            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                button_create.Hide();

            }
        }

      

        private void button_reset_Click_1(object sender, EventArgs e)
        {
            userlabel_id.Text = "";
            textBox_firstname.Text = "";
            textBox_lastname.Text = "";
            textBox_username.Text = "";
            textBox_password.Text = "";
            combo_usertype.Text = "";

            textBox_username.Focus();

            button_create.Show();
        }

        private void textBox_search_OnTextChange(object sender, EventArgs e)
        {
            MySqlDataAdapter adp;
            DataTable dt;

            conn.Open();
            adp = new MySqlDataAdapter("SELECT * FROM user WHERE user_firstname like '%"+ aa.Text+ "%'", conn);
           
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void aa_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adp;
            DataTable dt;

            conn.Open();
            adp = new MySqlDataAdapter("SELECT * FROM user WHERE user_firstname like '%" + aa.Text + "%'", conn);

            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }
    }
}
