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
    public partial class adddeduct : Form
    {
        MySqlConnection conn;
        public string getid { get; set; }
        public string getopt { get; set; }
        public string getnm { get; set; }

        public string getpr { get; set; }
        public string getapp { get; set; }
        public adddeduct()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root");
        }

        private void adddeduct_Load(object sender, EventArgs e)

        {
            patient_name.Text = this.getpr;
            appointment_id.Text = this.getapp;
            label1.Text = this.getid;
            label2.Text = this.getopt;
            label3.Text = this.getnm;


            if (label2.Text == "in")
            {
                combo_description.Items.Insert(0, "Purchased");
                combo_description.Items.Insert(1, "Wrong Input");
                
            } else
            {
                combo_description.Items.Insert(0, "Wrong input");
                combo_description.Items.Insert(1, "Operation");
                combo_description.Items.Insert(2, "Damaged");
                combo_description.Items.Insert(3, "Expired");
            }
            
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (textBox_noitem.Text == "")
            {
                MessageBox.Show("Please input the no. of items");
            }
            else
            {

                String idd = label1.Text;
                String app = appointment_id.Text;
                String nme = patient_name.Text;
                String optt = label2.Text;
                String nmm = label3.Text;
                String noo = textBox_noitem.Text;
                String desc = combo_description.Text;

                String query = "SELECT * FROM stock ;";

                conn.Open();

                MySqlCommand com = new MySqlCommand(query, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);



                String query3 = "INSERT INTO stock(stock_inventory_id, stock_name, stock_value,stock_label,stock_description, stock_date, stock_appointment_id, stock_appointment_name) " +
                               "VALUES('" + idd + "', '" + nmm + "', '" + noo + "','" + optt + "','" + desc + "',now(),'" + app + "','" + nme + "')";
                MySqlCommand comm = new MySqlCommand(query3, conn);
                comm.ExecuteNonQuery();



                if (optt == "in")
                {

                    String query4 = "Update inventory set item_quantity = item_quantity +" + noo + " where item_id = "+idd+";";

                    MySqlCommand comm1 = new MySqlCommand(query4, conn);
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("Stocked in Succesfully!");
                }
                else
                {
                    String query4 = "Update inventory set item_quantity = item_quantity -" + noo + " where item_id = " + idd + ";";

                    MySqlCommand comm1 = new MySqlCommand(query4, conn);
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("Stocked out Succesfully!");
                }





                this.Close();



            }


        }
        private void loadAll()
        {
           

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

       
        private void button_cancel_supplier_Click(object sender, EventArgs e)
        {
         
        }

        
        private void combo_description_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}
