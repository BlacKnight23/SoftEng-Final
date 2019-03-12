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
    public partial class USC_credential : UserControl
    {
        MySqlConnection conn;
        private static USC_credential _instance;

        public main_menu form_mainmenu;

        public string getussr { get; set; }

    
        public USC_credential()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc;Uid=root;password=root");
        }

        private void USC_credential_Load(object sender, EventArgs e)
        {
            labelcredential_name.Text = this.getussr;
         

            //label_name.Text = this.getusertype;
            //mainmenulabel_id.Text = this.getuser;

        }

        private void button_update_Click(object sender, EventArgs e)
        {

            if (textBox_user.Text == "")
            {
                MessageBox.Show("You did not enter any username.");
            }

            else
            {

                String username = textBox_user.Text;
                String query5 = "SELECT *FROM user" + " WHERE username ='" + username + "'";
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


                    String query4 = "Update user SET user_username = '" + textBox_user.Text + "' WHERE user_id = '" + labelcredential_name.Text + "'";


                }


            }
        }

        private void button_update2_Click(object sender, EventArgs e)
        {
            if (textBox_oldp.Text == "" && textBox_newp.Text == "" && textBox_conp.Text == "")
            {
                MessageBox.Show("Please input all fields.");
            }

            else
            {
                String query7 = "SELECT *FROM user" + " WHERE user_id ='" + labelcredential_name.Text + "'";
                conn.Open();

                MySqlCommand com = new MySqlCommand(query7, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();


                string pass = dt.Rows[0]["user_password"].ToString();

                if (textBox_oldp.Text != pass)
                {
                    MessageBox.Show("Old password does not match.");

                }

                else if (textBox_newp.Text != textBox_conp.Text)

                {

                    MessageBox.Show("The two passwords do not match.");
                }
                else
                {

                    String query8 = "Update users SET password = '" + textBox_newp.Text + "' WHERE user_id = '" + labelcredential_name.Text + "'";


                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query8, conn);


                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Password Successfully Changed!");

                }

            }
        }

        private void labelcredential_name_Click(object sender, EventArgs e)
        {

        }
    }
}
