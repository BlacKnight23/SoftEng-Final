using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Accounting
{
    public partial class log_in : Form
    {
        MySqlConnection conn;
        public log_in()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root ");
        }

        private void log_in_Load(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void button_connect_Click_1(object sender, EventArgs e)
        {
            string uname = username.Text;
            string pword = password.Text;
            string query = "SELECT * FROM user WHERE user_username = '" + uname + "' AND user_password = '" + pword + "'";

            conn.Open(); //open MySql connection
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                string firstname = dt.Rows[0]["user_firstname"].ToString();
                string lastname = dt.Rows[0][2].ToString();
                string username = dt.Rows[0][3].ToString();
                string user_type = dt.Rows[0][5].ToString();

                



                MessageBox.Show("Welcome " + firstname + " " + lastname + " (" + username + ")");



                main_menu form_mainmenu = new main_menu();
                form_mainmenu.getuser = username;
                form_mainmenu.form_login = this;
                form_mainmenu.getusertype = user_type;
                form_mainmenu.Show(); 
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong information!", "Index", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button_connect_Enter(object sender, EventArgs e)
        {

        }

        private void connect_Click(object sender, EventArgs e)
        {
            string uname = username.Text;
            string pword = password.Text;
            string query = "SELECT * FROM user WHERE user_username = '" + uname + "' AND user_password = '" + pword + "'";

            conn.Open(); //open MySql connection
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                string firstname = dt.Rows[0]["user_firstname"].ToString();
                string lastname = dt.Rows[0][2].ToString();
                string username = dt.Rows[0][3].ToString();
                string user_type = dt.Rows[0][5].ToString();





                MessageBox.Show("Welcome " + firstname + " " + lastname + " (" + username + ")");



                main_menu form_mainmenu = new main_menu();
                form_mainmenu.getuser = username;
                form_mainmenu.form_login = this;
                form_mainmenu.getusertype = user_type;
                form_mainmenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong information!", "Index", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
