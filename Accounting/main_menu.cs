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
    public partial class main_menu : Form
    {
        
        public string getusertype { get; set; }
        public string getuser { get; set; }

        public log_in form_login;
        
        MySqlConnection conn;
        public main_menu()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root; ");
        }

        private void main_menu_Load(object sender, EventArgs e)
        {
            label_name.Text = this.getusertype;
            mainmenulabel_id.Text = this.getuser;
            if(label_name.Text != "Admin")
            {
                tab_user.Hide();
            }


            
            // for the panel alert!!
            
            panel_alert.Show();

            // Stock 

            lowstock();
            expired();
            stat();

            // Expirey

           


            
           

        }
        private void lowstock()
        {
            string query = "SELECT * from inventory where item_quantity < item_reorder_point";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView_lowstocks.DataSource = dt;
            dataGridView_lowstocks.Columns["item_id"].Visible = false;
            dataGridView_lowstocks.Columns["item_name"].HeaderText = "Item Name";
            dataGridView_lowstocks.Columns["item_description"].HeaderText = "Description";
            dataGridView_lowstocks.Columns["item_quantity"].HeaderText = "Quantity";
            dataGridView_lowstocks.Columns["item_reorder_point"].HeaderText = "Reorder_point";

        }
        private void expired()
        {
            string query2 = "SELECT * from inventory where item_expiry < now()";

            conn.Open();
            MySqlCommand com2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(com2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            dataGridView_expired.DataSource = dt2;
            dataGridView_expired.Columns["item_id"].Visible = false;

            dataGridView_expired.Columns["item_name"].HeaderText = "Item Name";
            dataGridView_expired.Columns["item_description"].HeaderText = "Description";
            dataGridView_expired.Columns["item_quantity"].HeaderText = "Quantity";



            dataGridView_expired.Sort(dataGridView_expired.Columns[1], ListSortDirection.Ascending);
        }
        public void stat()
        {
            string query3 = "SELECT * from dc_equipments where equipment_status = 'Damage' OR equipment_status = 'Unavailable'";

            conn.Open();
            MySqlCommand com3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(com3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);

            dataGridView_eissue.DataSource = dt3;
            dataGridView_eissue.Columns["equipment_id"].Visible = false;

            dataGridView_eissue.Columns["equipment_name"].HeaderText = "Item Name";
            dataGridView_eissue.Columns["equipment_description"].HeaderText = "Description";
            dataGridView_eissue.Columns["equipment_status"].HeaderText = "Status";      
        }

        private void tab_appoinment_Click(object sender, EventArgs e)
        {
            panel_all.Controls.Clear();
            

            form_appointment formappointment = new form_appointment();
            formappointment.FormBorderStyle = FormBorderStyle.None;
            formappointment.Dock = DockStyle.Fill;
            formappointment.BringToFront();
            formappointment.TopLevel = false;
            formappointment.AutoScroll = true;
            panel_all.Controls.Add(formappointment);


            formappointment.Show();

        }
    

        private void tab_patient_Click(object sender, EventArgs e)
        {
            panel_all.Controls.Clear();


            form_patient formpatient = new form_patient();
            formpatient.FormBorderStyle = FormBorderStyle.None;
            formpatient.Dock = DockStyle.Fill;
            formpatient.BringToFront();
            formpatient.TopLevel = false;
            formpatient.AutoScroll = true;
            panel_all.Controls.Add(formpatient);


            formpatient.Show();
        }


        private void tab_dentalchart_Click(object sender, EventArgs e)
        {
            panel_all.Controls.Clear();


            form_dentalchart formdentalchart = new form_dentalchart();
            formdentalchart.FormBorderStyle = FormBorderStyle.None;
            formdentalchart.Dock = DockStyle.Fill;
            formdentalchart.BringToFront();
            formdentalchart.TopLevel = false;
            formdentalchart.AutoScroll = true;
            panel_all.Controls.Add(formdentalchart);


            formdentalchart.Show();
        }


        private void tab_sales_Click(object sender, EventArgs e)
        {
            panel_all.Controls.Clear();


            form_sales formsales = new form_sales();
            formsales.FormBorderStyle = FormBorderStyle.None;
            formsales.Dock = DockStyle.Fill;
            formsales.BringToFront();
            formsales.TopLevel = false;
            formsales.AutoScroll = true;
            panel_all.Controls.Add(formsales);


            formsales.Show();
        }

        private void tab_users_Click(object sender, EventArgs e)
        {
            if (!panel_all.Controls.Contains(USC_user.Instance))
            {
                panel_all.Controls.Add(USC_user.Instance);
                USC_user.Instance.Dock = DockStyle.Fill;
                USC_user.Instance.BringToFront();
            }
            else
                USC_user.Instance.BringToFront();
        }

   

        private void mainmenulabel_id_Click(object sender, EventArgs e)
        {

        }

        private void tab_credential_Click_1(object sender, EventArgs e)
        {
           
            panel_all.Controls.Clear();


            form_credentials formcredential = new form_credentials();
            formcredential.FormBorderStyle = FormBorderStyle.None;
            formcredential.Dock = DockStyle.Fill;
            formcredential.BringToFront();
            formcredential.TopLevel = false;
            panel_all.Controls.Add(formcredential);


            formcredential.Show();

        }

        private void tab_inventory_Click(object sender, EventArgs e)
        {
            if (!panel_all.Controls.Contains(USC_inventory.Instance))
            {
                panel_all.Controls.Add(USC_inventory.Instance);
                USC_inventory.Instance.Dock = DockStyle.Fill;
                USC_inventory.Instance.BringToFront();
            }
            else
                USC_inventory.Instance.BringToFront();
        }

        private void tab_user_Click(object sender, EventArgs e)
        {
            if (!panel_all.Controls.Contains(USC_user.Instance))
            {
                panel_all.Controls.Add(USC_user.Instance);
                USC_user.Instance.Dock = DockStyle.Fill;
                USC_user.Instance.BringToFront();
            }
            else
                USC_user.Instance.BringToFront();
        }

        private void tab_services_Click(object sender, EventArgs e)
        {
            panel_all.Controls.Clear();


            form_services formservices = new form_services();
            formservices.FormBorderStyle = FormBorderStyle.None;
            formservices.Dock = DockStyle.Fill;
            formservices.BringToFront();
            formservices.TopLevel = false;
            formservices.AutoScroll = true;
            panel_all.Controls.Add(formservices);


            formservices.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_lowstocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void button_viewinventory_Click(object sender, EventArgs e)
        {
            if (!panel_all.Controls.Contains(USC_inventory.Instance))
            {
                panel_all.Controls.Add(USC_inventory.Instance);
                USC_inventory.Instance.Dock = DockStyle.Fill;
                USC_inventory.Instance.BringToFront();
            }
            else
                USC_inventory.Instance.BringToFront();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            panel_alert.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel_alert.Show();
            lowstock();
            expired();
            stat();
            panel_alert.BringToFront();
        }
    }
}
