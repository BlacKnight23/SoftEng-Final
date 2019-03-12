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
    public partial class form_sales : Form
    {
        MySqlConnection conn;
        public form_sales()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root; password=root");
        }

        private void form_sales_Load(object sender, EventArgs e)
        {
            button_go.Text = "View All";
            loadAll();
            
        }

        public void loadAll()
        {
            // string sel = "SELECT d.payment_date, d.amount_paid, p.name FROM fdc1.payment d LEFT JOIN dc_pr p ON d.patient_id = p.pr_id";

            string sel = "SELECT  name, payment_amount, payment_date FROM payment_hist";
            conn.Open();
            MySqlCommand com = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgv_sales.DataSource = dt;
            dgv_sales.RowHeadersVisible = false;
            dgv_sales.Columns["name"].HeaderText = "Name";
            dgv_sales.Columns["payment_amount"].HeaderText = "Amount";
            dgv_sales.Columns["payment_date"].HeaderText = "Date";

            
            /*decimal total = 0;

            for (int i = 0; i <= dgv_sales.Rows.Count - 1; i++)
            {
                total += Convert.ToDecimal(dgv_sales.Rows[i].Cells[1].Value.ToString());
            }

            textBox1.Text = total.ToString("c");*/

            int sum = 0;
            try
            {
                for (int i = 0; i < dgv_sales.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgv_sales.Rows[i].Cells["payment_amount"].Value);
                }
                text_total.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }

        }

        private void button_search1_Click(object sender, EventArgs e)
        {
            var x = date_from.Value.ToString("yyyy-MM-dd");
            var y = date_to.Value.ToString("yyyy-MM-dd");

            string sel = "SELECT name, payment_amount, payment_date FROM payment_hist WHERE payment_date BETWEEN '" + x + "' AND '" + y + "'";
            conn.Open();
            MySqlCommand com = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);


            dgv_sales.DataSource = dt;
            dgv_sales.RowHeadersVisible = false;
            dgv_sales.Columns["name"].HeaderText = "Name";
            dgv_sales.Columns["payment_amount"].HeaderText = "Amount";
            dgv_sales.Columns["payment_date"].HeaderText = "Patient Name";


            int sum = 0;
            for (int i = 0; i < dgv_sales.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgv_sales.Rows[i].Cells["payment_amount"].Value);
            }
            text_total.Text = sum.ToString();

        }

        private void dgv_sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            
        }

        private void dgv_sales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
