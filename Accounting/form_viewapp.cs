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
    public partial class form_viewapp : Form
    {
        MySqlConnection conn;

        public form_appointment appointmentform;

        public form_viewsched schedules;
        public form_viewapp appointments;
        public form_viewapp()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root; Pwd=root;");
            app_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void USC_viewapp_Load(object sender, EventArgs e)
        {
            loadAll();
            panel1.Hide();
        }

        public void loadAll()
        {
            string datetoday = DateTime.Today.ToString("yyyy-MM-dd");

            string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', a.* , s.* FROM fdc1.dc_appnt a LEFT JOIN dc_pr p ON p.pr_id = a.pr_id LEFT JOIN dc_pr d ON d.pr_id = a.dct_id LEFT JOIN dc_sched s ON s.sched_id = a.sched_id WHERE a.status = 'Finished' ORDER BY s.sched_date";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(joiners, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            app_dgv.DataSource = dt;
            app_dgv.RowHeadersVisible = false;
            app_dgv.Columns["Patient"].HeaderText = "Patient's Name";
            app_dgv.Columns["app_id"].Visible = false;
            app_dgv.Columns["status"].HeaderText = "Status";
            app_dgv.Columns["sched_id"].Visible = false;
            app_dgv.Columns["pr_id"].Visible = false;
            app_dgv.Columns["sched_id1"].Visible = false;
            app_dgv.Columns["pr_id1"].Visible = false;
            app_dgv.Columns["dct_id"].Visible = false;
            app_dgv.Columns["dct_id1"].Visible = false;
            app_dgv.Columns["status1"].Visible = false;
            app_dgv.Columns["sched_date"].HeaderText = "Schedule Date";
            app_dgv.Columns["start_time"].HeaderText = "Start Time";
            app_dgv.Columns["end_time"].HeaderText = "End Time";
            app_dgv.Columns["Doctor"].HeaderText = "Doctor In-Charge";
            app_dgv.Columns["sched_start"].Visible = false;
            app_dgv.Columns["sched_end"].Visible = false;
            app_dgv.Columns["shour"].Visible = false;
            app_dgv.Columns["sminute"].Visible = false;
            app_dgv.Columns["sday"].Visible = false;
            app_dgv.Columns["ehour"].Visible = false;
            app_dgv.Columns["eminute"].Visible = false;
            app_dgv.Columns["eday"].Visible = false;
            app_dgv.Columns["tooth_upd"].Visible = false;
            app_dgv.Columns["pay_status"].HeaderText = "Payment Status";

        }

        private void cmb_stat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fltr_cmb.Text == "Status")
            {
                string datepast = DateTime.Today.ToString("yyyy-MM-dd");
                string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', a.* , s.* FROM fdc1.dc_appnt a LEFT JOIN dc_pr p ON p.pr_id = a.pr_id LEFT JOIN dc_pr d ON d.pr_id = a.dct_id LEFT JOIN dc_sched s ON s.sched_id = a.sched_id WHERE a.status = 'Finished' ORDER BY s.sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable("Schedule");
                adp.Fill(dt);
                app_dgv.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("status like '%{0}%'", cmb_stat.Text);
                app_dgv.DataSource = dv.ToTable();
            }
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
                string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', a.* , s.* FROM fdc1.dc_appnt a LEFT JOIN dc_pr p ON p.pr_id = a.pr_id LEFT JOIN dc_pr d ON d.pr_id = a.dct_id LEFT JOIN dc_sched s ON s.sched_id = a.sched_id WHERE a.status = 'Finished' ORDER BY s.sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable("Schedule");
                adp.Fill(dt);
                app_dgv.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("doctor like '%{0}%'", txtsrc.Text);
                app_dgv.DataSource = dv.ToTable();

            }
            else if (fltr_cmb.Text == "Patient Name")
            {
                string datepast = DateTime.Today.ToString("yyyy-MM-dd");
                string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', a.* , s.* FROM fdc1.dc_appnt a LEFT JOIN dc_pr p ON p.pr_id = a.pr_id LEFT JOIN dc_pr d ON d.pr_id = a.dct_id LEFT JOIN dc_sched s ON s.sched_id = a.sched_id WHERE a.status = 'Finished' ORDER BY s.sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable("Schedule");
                adp.Fill(dt);
                app_dgv.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("patient like '%{0}%'", txtsrc.Text);
                app_dgv.DataSource = dv.ToTable();

            }
        }

        private void fnd_btn_Click(object sender, EventArgs e)
        {
            if (fltr_cmb.Text == "Date")
            {
                string datepast = DateTime.Today.ToString("yyyy-MM-dd");
                string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', a.* , s.* FROM fdc1.dc_appnt a LEFT JOIN dc_pr p ON p.pr_id = a.pr_id LEFT JOIN dc_pr d ON d.pr_id = a.dct_id LEFT JOIN dc_sched s ON s.sched_id = a.sched_id WHERE a.status = 'Finished' ORDER BY s.sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(joiners, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable("Schedule");
                adp.Fill(dt);
                app_dgv.DataSource = dt;


                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("sched_date >= '{0:yyyy-MM-dd}' AND sched_date <= '{1:yyyy-MM-dd}'", frm_dtpkr.Value.ToString("yyyy-MM-dd"), to_dtpkr.Value.ToString("yyyy-MM-dd"));
                app_dgv.DataSource = dv.ToTable();



            }
        }

        private void app_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
