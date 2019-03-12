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
    public partial class form_services : Form
    {
        MySqlConnection conn;
        public form_services()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root ");
            trt_grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void form_services_Load(object sender, EventArgs e)
        {
            AddS.Enabled = true;
            Reset.Enabled = true;
            EditS.Enabled = false;
            DeleteS.Enabled = false;
            loadAll();
            S1.Hide();
            S2.Hide();
            label1.Hide();
            label2.Hide();
            


            string select = "SELECT max(trt_id) from dc_trtmnt";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                int treat_id = (int)dt.Rows[0][0];
                int add1 = treat_id + 1;
                label1.Text = "SC0" + add1;
                src_id.Text = label1.Text;
                src_id.Enabled = false;

            }

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            AddS.Enabled = true;
            EditS.Enabled = false;

            string select = "SELECT max(trt_id) from dc_trtmnt";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                int treat_id = (int)dt.Rows[0][0];
                int add1 = treat_id + 1;
                label1.Text = "SC0" + add1;
                src_id.Text = label1.Text;
                src_id.Enabled = false;

            }

            src_nme.Text = "";
            prc.Text = "";
            src_id.Text = "";
            src_nme.Focus();
            S2.Text = "";
            crt.Text = "";
        }

        public void loadAll()
        {
            string select = "SELECT * FROM dc_trtmnt WHERE status = 1 ORDER BY Treatment";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            trt_grid.DataSource = dt;
            trt_grid.RowHeadersVisible = false;
            trt_grid.Columns["trt_id"].Visible = false;
            trt_grid.Columns["Treatment"].HeaderText = "Treatment";
            trt_grid.Columns["Price"].HeaderText = "Price";
            
            



        }

        private void trt_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddS.Enabled = false;
            EditS.Enabled = true; ;
            DeleteS.Enabled = true;
            label1.Text = "SC0" + trt_grid.Rows[e.RowIndex].Cells["trt_id"].Value.ToString();
            label2.Text = trt_grid.Rows[e.RowIndex].Cells["trt_id"].Value.ToString();
            src_id.Text = label1.Text;
            src_id.Enabled = false;
            src_nme.Text = trt_grid.Rows[e.RowIndex].Cells["Treatment"].Value.ToString();
            prc.Text = trt_grid.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            trt_grid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            trt_grid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void AddS_Click(object sender, EventArgs e)
        {
            string service = src_nme.Text;
            string price = prc.Text;
            if (src_nme.Text == "" || prc.Text == "")
            {
                MessageBox.Show("Please input all fields.", "Treatment Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string dup = "SELECT Treatment from dc_trtmnt WHERE Treatment = '" + src_nme.Text + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(dup, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Treatment is already available.", "Existing Treatment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ins = "INSERT into dc_trtmnt(Treatment, Price, status) VALUES('" + service + "', '" + price + "', '1')";
                    conn.Open();
                    MySqlCommand cpd = new MySqlCommand(ins, conn);
                    MySqlDataAdapter fdr = new MySqlDataAdapter(cpd);
                    cpd.ExecuteNonQuery();
                    conn.Close();

                    if (crt.Text == "Yes")
                    {
                        string crt = "INSERT into dc_trtmnt(chart) VALUES ('1')";
                        conn.Open();
                        MySqlCommand dd = new MySqlCommand(crt, conn);
                        MySqlDataAdapter ln = new MySqlDataAdapter(dd);
                        cpd.ExecuteNonQuery();
                        conn.Close();

                    }
                    else
                    {
                        string crt = "INSERT into dc_trtmnt(chart) VALUES ('2')";
                        conn.Open();
                        MySqlCommand dd = new MySqlCommand(crt, conn);
                        MySqlDataAdapter ln = new MySqlDataAdapter(dd);
                        cpd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Service addition was successful!", "Service Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadAll();
                }
                
            }
        }

        private void EditS_Click(object sender, EventArgs e)
        {
            if (src_nme.Text == "" || prc.Text == "")
            {
                MessageBox.Show("Please input all fields.", "Treatment Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string upd = "UPDATE dc_trtmnt SET Treatment = '" + src_nme.Text + "', price = '" + prc.Text + "' WHERE trt_id = '" + label2.Text + "'";
                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(upd, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                comm1.ExecuteNonQuery();
                conn.Close();

                loadAll();
                MessageBox.Show("Service update was successful!", "Service Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (crt.Text == "Yes")
                {
                    string upd1 = "UPDATE dc_trtmnt SET chart = '1' WHERE trt_id = '" + label2.Text + "'";
                    conn.Open();
                    MySqlCommand comm2 = new MySqlCommand(upd1, conn);
                    MySqlDataAdapter adp3 = new MySqlDataAdapter(comm2);
                    comm2.ExecuteNonQuery();
                    conn.Close();
                }
                else if (crt.Text == "No")
                {
                    string upd3 = "UPDATE dc_trtmnt SET chart = '2' WHERE trt_id = '" + label2.Text + "'";
                    conn.Open();
                    MySqlCommand comm3 = new MySqlCommand(upd3, conn);
                    MySqlDataAdapter adp4 = new MySqlDataAdapter(comm3);
                    comm3.ExecuteNonQuery();
                    conn.Close();
                }

            }

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_src.Text == "All Fields*")
            {
                loadAll();
                S1.Hide();
                S2.Hide();
            }
            else if (cmb_src.Text == "Treatment Name")
            {
                S1.Show();
                S2.Show();
            }
            else if (cmb_src.Text == "Price")
            {
                S1.Show();
                S2.Show();
            }
        }

        private void S2_TextChanged(object sender, EventArgs e)
        {
            if (cmb_src.Text == "Treatment Name")
            {
                string joiners = "SELECT * FROM dc_trtmnt";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                trt_grid.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Treatment like '%{0}%'", S2.Text);
                trt_grid.DataSource = dv.ToTable();

                MySqlConnection com = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root; Pwd=root;");
                MySqlCommand cmd = new MySqlCommand("SELECT Treatment FROM dc_trtmnt", com);
                com.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection SCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    SCollection.Add(reader.GetString(0));
                }
                src_nme.AutoCompleteCustomSource = SCollection;
                com.Close();
            }
            else if (cmb_src.Text == "Price")
            {
                string joiners = "SELECT * FROM dc_trtmnt";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                trt_grid.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Price like '%{0}%'", S2.Text);
                trt_grid.DataSource = dv.ToTable();

                MySqlConnection com = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root; Pwd=root;");
                MySqlCommand cmd = new MySqlCommand("SELECT Price FROM dc_trtmnt", com);
                com.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection SCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    SCollection.Add(reader.GetString(0));
                }
                src_nme.AutoCompleteCustomSource = SCollection;
                com.Close();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (src_nme.Text == "" || prc.Text == "")
            {
                MessageBox.Show("Please input all fields.", "Treatment Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string upd = "UPDATE dc_trtmnt SET status = 0 WHERE trt_id = '" + label2.Text + "'";
                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(upd, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                comm1.ExecuteNonQuery();
                conn.Close();

                loadAll();
                MessageBox.Show("Service delete was successful!", "Service Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
