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
    public partial class form_viewsched : Form
    {
        MySqlConnection conn;

        public form_appointment appointmentform;

        public form_viewsched schedules;
        public form_viewsched()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root");
            sched_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void USC_viewsched_Load(object sender, EventArgs e)
        {
            loadAll();
            panel1.Hide();
        }

        public void loadAll()
        {
            string frmdte = DateTime.Today.ToString("yyyy-MM-dd");

            string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', s.* FROM fdc1.dc_sched s LEFT JOIN dc_pr p ON s.pr_id = p.pr_id LEFT JOIN dc_pr d ON d.pr_id = s.dct_id ORDER BY s.sched_date";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(joiners, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            sched_dgv.DataSource = dt;
            sched_dgv.RowHeadersVisible = false;
            sched_dgv.Columns["sched_id"].Visible = false;
            sched_dgv.Columns["dct_id"].Visible = false;
            sched_dgv.Columns["pr_id"].Visible = false;
            sched_dgv.Columns["Patient"].HeaderText = "Patient's Name";
            sched_dgv.Columns["sched_date"].HeaderText = "Schedule Date";
            sched_dgv.Columns["start_time"].HeaderText = "Start Time";
            sched_dgv.Columns["end_time"].HeaderText = "End Time";
            sched_dgv.Columns["Doctor"].HeaderText = "Doctor In-Charge";
            sched_dgv.Columns["sched_start"].Visible = false;
            sched_dgv.Columns["sched_end"].Visible = false;
            sched_dgv.Columns["shour"].Visible = false;
            sched_dgv.Columns["sminute"].Visible = false;
            sched_dgv.Columns["sday"].Visible = false;
            sched_dgv.Columns["ehour"].Visible = false;
            sched_dgv.Columns["eminute"].Visible = false;
            sched_dgv.Columns["eday"].Visible = false;
            sched_dgv.Columns["status"].HeaderText = "Status";
        }

        private void sched_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fltr_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (fltr_cmb.Text == "All Fields")
            {
                loadAll();
                panel1.Hide();
            }
            else if (fltr_cmb.Text == "Doctor")
            {
                panel1.Show();
                txtsrc.Show();
                cmb_stat.Hide();
                label3.Hide();
                label4.Hide();
                frm_dtpkr.Hide();
                to_dtpkr.Hide();
                fnd_btn.Hide();

            }
            else if (fltr_cmb.Text == "Patient Name")
            {
                panel1.Show();
                txtsrc.Show();
                cmb_stat.Hide();
                label3.Hide();
                label4.Hide();
                frm_dtpkr.Hide();
                to_dtpkr.Hide();
                fnd_btn.Hide();

            }
            else if (fltr_cmb.Text == "Status")
            {
                panel1.Show();
                txtsrc.Hide();
                cmb_stat.Show();
                label3.Hide();
                label4.Hide();
                frm_dtpkr.Hide();
                to_dtpkr.Hide();
                fnd_btn.Hide();

            }
            else if (fltr_cmb.Text == "Date")
            {
                panel1.Show();
                txtsrc.Hide();
                cmb_stat.Hide();
                label3.Show();
                label4.Show();
                frm_dtpkr.Show();
                to_dtpkr.Show();
                fnd_btn.Show();

            }
        }

        private void txtsrc_TextChanged(object sender, EventArgs e)
        {
            if (fltr_cmb.Text == "Doctor")
            {
                string datepast = DateTime.Today.ToString("yyyy-MM-dd");
                string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', s.* FROM fdc1.dc_sched s LEFT JOIN dc_pr p ON s.pr_id = p.pr_id LEFT JOIN dc_pr d ON d.pr_id = s.dct_id ORDER BY s.sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable("Schedule");
                adp.Fill(dt);
                sched_dgv.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("doctor like '%{0}%'", txtsrc.Text);
                sched_dgv.DataSource = dv.ToTable();

                MySqlConnection com = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root; Pwd=root;");
                MySqlCommand cmd = new MySqlCommand("SELECT name FROM dc_pr WHERE user_type = 'Doctor'", com);
                com.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection SCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    SCollection.Add(reader.GetString(0));
                }
                txtsrc.AutoCompleteCustomSource = SCollection;
                com.Close();

            }
            else if (fltr_cmb.Text == "Patient Name")
            {
                string datepast = DateTime.Today.ToString("yyyy-MM-dd");
                string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', s.* FROM fdc1.dc_sched s LEFT JOIN dc_pr p ON s.pr_id = p.pr_id LEFT JOIN dc_pr d ON d.pr_id = s.dct_id ORDER BY s.sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable("Schedule");
                adp.Fill(dt);
                sched_dgv.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("patient like '%{0}%'", txtsrc.Text);
                sched_dgv.DataSource = dv.ToTable();

                MySqlConnection com = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root; Pwd=root;");
                MySqlCommand cmd = new MySqlCommand("SELECT name FROM dc_pr WHERE user_type = 'Patient'", com);
                com.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection SCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    SCollection.Add(reader.GetString(0));
                }
                txtsrc.AutoCompleteCustomSource = SCollection;
                com.Close();

            }

        }

        private void cmb_stat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fltr_cmb.Text == "Status")
            {
                string datepast = DateTime.Today.ToString("yyyy-MM-dd");
                string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', s.* FROM fdc1.dc_sched s LEFT JOIN dc_pr p ON s.pr_id = p.pr_id LEFT JOIN dc_pr d ON d.pr_id = s.dct_id ORDER BY s.sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable("Schedule");
                adp.Fill(dt);
                sched_dgv.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("status like '%{0}%'", cmb_stat.Text);
                sched_dgv.DataSource = dv.ToTable();
            }
        }

        private void fnd_btn_Click(object sender, EventArgs e)
        {
            if (fltr_cmb.Text == "Date")
            {
                string datepast = DateTime.Today.ToString("yyyy-MM-dd");
                string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', s.* FROM fdc1.dc_sched s LEFT JOIN dc_pr p ON s.pr_id = p.pr_id LEFT JOIN dc_pr d ON d.pr_id = s.dct_id ORDER BY s.sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable("Schedule");
                adp.Fill(dt);
                sched_dgv.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("sched_date >= '{0:yyyy-MM-dd}' AND sched_date <= '{1:yyyy-MM-dd}'", frm_dtpkr.Value.ToString("yyyy-MM-dd"), to_dtpkr.Value.ToString("yyyy-MM-dd"));
                sched_dgv.DataSource = dv.ToTable();



            }
        }

    }
}
