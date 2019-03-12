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
    public partial class form_appointment : Form
    {
        MySqlConnection conn;
        public form_appointment()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root ");
            dgv_sched.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_app.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void loadAll()
        {

            string dtoday = DateTime.Today.ToString("yyyy-MM-dd");

            string suko = "SELECT p.name AS 'Patient', d.name AS 'Doctor', s.* FROM fdc1.dc_sched s LEFT JOIN dc_pr p ON s.pr_id = p.pr_id LEFT JOIN dc_pr d ON d.pr_id = s.dct_id WHERE s.status = 'Scheduled' AND s.sched_date >= '" + dtoday + "' ORDER BY s.sched_date";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(suko, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgv_sched.DataSource = dt;
            dgv_sched.RowHeadersVisible = false;
            dgv_sched.Columns["sched_id"].Visible = false;
            dgv_sched.Columns["dct_id"].Visible = false;
            dgv_sched.Columns["pr_id"].Visible = false;
            dgv_sched.Columns["Patient"].HeaderText = "Patient's Name";
            dgv_sched.Columns["sched_date"].HeaderText = "Schedule Date";
            dgv_sched.Columns["start_time"].HeaderText = "Start Time";
            dgv_sched.Columns["end_time"].HeaderText = "End Time";
            dgv_sched.Columns["Doctor"].HeaderText = "Doctor In-Charge";
            dgv_sched.Columns["sched_start"].Visible = false;
            dgv_sched.Columns["sched_end"].Visible = false;
            dgv_sched.Columns["shour"].Visible = false;
            dgv_sched.Columns["sminute"].Visible = false;
            dgv_sched.Columns["sday"].Visible = false;
            dgv_sched.Columns["ehour"].Visible = false;
            dgv_sched.Columns["eminute"].Visible = false;
            dgv_sched.Columns["eday"].Visible = false;
            dgv_sched.Columns["status"].Visible = false;
        }

        public void loadAll2()
        {
            string datetoday = DateTime.Today.ToString("yyyy-MM-dd");

            string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', a.* , s.* FROM fdc1.dc_appnt a LEFT JOIN dc_pr p ON p.pr_id = a.pr_id LEFT JOIN dc_pr d ON d.pr_id = a.dct_id LEFT JOIN dc_sched s ON s.sched_id = a.sched_id WHERE s.status = 'Appointed' AND a.status = 'Ongoing' ORDER BY s.sched_date";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(joiners, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgv_app.DataSource = dt;
            dgv_app.DataSource = dt;
            dgv_app.RowHeadersVisible = false;
            dgv_app.Columns["Patient"].HeaderText = "Patient's Name";
            dgv_app.Columns["app_id"].Visible = false;
            dgv_app.Columns["sched_id"].Visible = false;
            dgv_app.Columns["pr_id"].Visible = false;
            dgv_app.Columns["sched_id1"].Visible = false;
            dgv_app.Columns["pr_id1"].Visible = false;
            dgv_app.Columns["dct_id"].Visible = false;
            dgv_app.Columns["dct_id1"].Visible = false;
            dgv_app.Columns["status1"].Visible = false;
            dgv_app.Columns["sched_date"].HeaderText = "Schedule Date";
            dgv_app.Columns["start_time"].HeaderText = "Start Time";
            dgv_app.Columns["end_time"].HeaderText = "End Time";
            dgv_app.Columns["Doctor"].HeaderText = "Doctor In-Charge";
            dgv_app.Columns["status"].HeaderText = "Status";
            dgv_app.Columns["sched_start"].Visible = false;
            dgv_app.Columns["sched_end"].Visible = false;
            dgv_app.Columns["shour"].Visible = false;
            dgv_app.Columns["sminute"].Visible = false;
            dgv_app.Columns["sday"].Visible = false;
            dgv_app.Columns["ehour"].Visible = false;
            dgv_app.Columns["eminute"].Visible = false;
            dgv_app.Columns["eday"].Visible = false;
            dgv_app.Columns["pay_status"].Visible = false;
            dgv_app.Columns["tooth_upd"].Visible = false;



        }
        public void showTreat()
        {

            string sell = "SELECT Treatment FROM fdc1.dc_sched_line sl LEFT JOIN dc_trtmnt t ON t.trt_id = sl.trt_id WHERE sl.sched_id = '" + sched_id1.Text + "' AND sl.status = 'Chosen'";
            conn.Open();
            MySqlCommand commm = new MySqlCommand(sell, conn);
            MySqlDataAdapter adpp = new MySqlDataAdapter(commm);
            commm.ExecuteNonQuery();
            DataTable dtt = new DataTable();
            adpp.Fill(dtt);
            trt_grid.DataSource = dtt;
            conn.Close();


        }
        private void loadDoctor()
        {
            string select = "SELECT * FROM dc_pr WHERE user_type = 'Doctor'";

            conn.Open();
            MySqlCommand ace = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(ace);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dct_dgv.DataSource = dt;
            dct_dgv.RowHeadersVisible = false;
            dct_dgv.Columns["pr_id"].Visible = false;
            dct_dgv.Columns["name"].HeaderText = "Name";
            dct_dgv.Columns["fname"].Visible = false;
            dct_dgv.Columns["lname"].Visible = false;
            dct_dgv.Columns["bday"].Visible = false;
            dct_dgv.Columns["address"].Visible = false;
            dct_dgv.Columns["age"].Visible = false;
            dct_dgv.Columns["gender"].Visible = false;
            dct_dgv.Columns["contact1"].Visible = false;
            dct_dgv.Columns["user_type"].Visible = false;
        }
        private void loadPatient()
        {
            string select = "SELECT * FROM dc_pr WHERE user_type = 'Patient'";

            conn.Open();
            MySqlCommand ace = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(ace);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            ptn_grid.DataSource = dt;
            ptn_grid.RowHeadersVisible = false;
            ptn_grid.Columns["pr_id"].Visible = false;
            ptn_grid.Columns["name"].HeaderText = "Name";
            ptn_grid.Columns["fname"].Visible = false;
            ptn_grid.Columns["lname"].Visible = false;
            ptn_grid.Columns["bday"].Visible = false;
            ptn_grid.Columns["address"].Visible = false;
            ptn_grid.Columns["age"].Visible = false;
            ptn_grid.Columns["gender"].Visible = false;
            ptn_grid.Columns["contact1"].Visible = false;
            ptn_grid.Columns["user_type"].Visible = false;
        }



        private void Reset()
        {
            patn.Text = "";
            dtpkr.Text = "";
            shr.Text = "";
            sm.Text = "";
            ss.Text = "";
            ehr.Text = "";
            em.Text = "";
            es.Text = "";
            dctr_nm.Text = "";
            trt_grid.DataSource = null;
        }
        public void reset1()
        {
            dct_fn.Text = "";
            dct_ln.Text = "";
            dct_bd.Text = "";
            dct_adr.Text = "";
            dct_age.Text = "";
            dct_gnd.Text = "";
            dct_cn.Text = "";
        }
        public void reset()
        {
            ptn_fn.Text = "";
            ptn_ln.Text = "";
            ptn_bd.Text = "";
            ptn_adr.Text = "";
            ptn_age.Text = "";
            ptn_gnd.Text = "";
            ptn_cn.Text = "";
        }

        private void add_ptn_Click(object sender, EventArgs e)
        {
            ptn_pnl.Show();
            ptn_lst_pnl.Hide();
            trmnt_pnl.Hide();
            dctr_pnl.Hide();
            dct_lst_pnl.Hide();
        }

        private void src_ptn_Click(object sender, EventArgs e)
        {
            ptn_lst_pnl.Show();
            dctr_pnl.Hide();
            dct_lst_pnl.Hide();
            loadPatient();
            trmnt_pnl.Hide();

        }

        private void shr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trt_btn_Click(object sender, EventArgs e)
        {
            trmnt_pnl.Show();
            dctr_pnl.Hide();
            dct_lst_pnl.Hide();
            ptn_pnl.Hide();
            ptn_lst_pnl.Hide();
        }

        private void src_dct_Click(object sender, EventArgs e)
        {
            dct_lst_pnl.Show();
            ptn_pnl.Hide();
            ptn_lst_pnl.Hide();
            trmnt_pnl.Hide();
            loadDoctor();
        }

        private void add_dtr_Click(object sender, EventArgs e)
        {
            dctr_pnl.Show();
            dct_lst_pnl.Hide();
            ptn_pnl.Hide();
            ptn_lst_pnl.Hide();
            trmnt_pnl.Hide();
        }

        private void AddS_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed to appointment?", "Appointment Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                string upd = "UPDATE dc_pr SET user_type = 'Patient' WHERE pr_id = '" + patientname.Text + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(upd, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();

                string update = "UPDATE dc_sched SET status = 'Appointed' WHERE sched_id = '" + sched_id1.Text + "'";
                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(update, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                comm1.ExecuteNonQuery();
                conn.Close();

                string ins = "INSERT INTO dc_appnt(sched_id, pr_id, dct_id, status, pay_status) VALUES('" + sched_id1.Text + "', '" + patientname.Text + "', '" + docid.Text + "', 'Ongoing', 'Unpaid')";
                conn.Open();
                MySqlCommand comm2 = new MySqlCommand(ins, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                comm2.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Appointment Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadAll();
                loadAll2();
            }

            dgv_app.Show();
            btn_allapp.Show();
            dgv_sched.Hide();
            btn_allsched.Hide();


            panelista.Controls.Clear();
            form_dentalchart formdentalchart = new form_dentalchart();
            formdentalchart.FormBorderStyle = FormBorderStyle.None;
            formdentalchart.Dock = DockStyle.Fill;
            formdentalchart.BringToFront();
            formdentalchart.TopLevel = false;
            formdentalchart.AutoScroll = true;
            panelista.Controls.Add(formdentalchart);


            formdentalchart.Show();

        }

        private void EditS_Click(object sender, EventArgs e)
        {
            if (patn.Text == "" || dtpkr.Text == "" || shr.Text == "" || sm.Text == "" || ss.Text == "" || ehr.Text == "" || em.Text == "" || es.Text == "" || dctr_nm.Text == "" || trt_grid.Rows.Count == 0)
            {
                MessageBox.Show("Please fill up all data.", "Appointment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string start;
                string end;
                string date = dtpkr.Text;

                int shour = int.Parse(shr.Text);
                int ehour = int.Parse(ehr.Text);

                dtpkr.MinDate = DateTime.Today;

                if (ss.Text == "AM")
                {
                    shour = shour + 0;
                }
                else if (ss.Text == "PM")
                {
                    if (shour == 12)
                    {
                        shour = shour + 0;
                    }
                    else
                    {
                        shour = shour + 12;
                    }
                }
                else
                {
                    MessageBox.Show("Please select desired meridiem.", "Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (es.Text == "AM")
                {
                    ehour = ehour + 0;
                }
                else if (es.Text == "PM")
                {
                    if (ehour == 12)
                    {
                        ehour = ehour + 0;
                    }
                    else
                    {
                        ehour = ehour + 12;
                    }
                }
                else
                {
                    MessageBox.Show("Please select desired meridiem.", "Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int sminute = int.Parse(sm.Text);
                int eminute = int.Parse(em.Text);

                start = date + " " + shour + ":" + sm.Text + ":00";
                end = date + " " + ehour + ":" + em.Text + ":00";




                if ((shour >= 8 && ehour < 18))
                {
                    if ((shour == ehour && sminute > eminute) || ((shour > ehour) && (ss.Text == "AM" && es.Text == "AM")) || ((shour > ehour) && (ss.Text == "PM" && es.Text == "PM")))
                    {
                        MessageBox.Show("End time is Invalid. Please select new End Time.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (dtpkr.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        MessageBox.Show("Reminder: Clinic is closed every Sunday.", "Closed on Sundays", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        string sel = "SELECT * FROM dc_pr WHERE name = '" + patn.Text + "' AND user_type LIKE 'Patient%'";
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(sel, conn);
                        MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                        comm.ExecuteNonQuery();
                        DataTable dat = new DataTable();
                        adp.Fill(dat);
                        conn.Close();
                        if (dat.Rows.Count == 1)
                        {
                            string prof_id = dat.Rows[0][0].ToString();
                            patientname.Text = prof_id;
                        }
                        else
                        {
                            string fname = ptn_fn.Text;
                            string lname = ptn_ln.Text;
                            string fullname = fname + " " + lname;

                            string inquery = "INSERT INTO dc_pr(name, fname, lname, bday, address, age, gender, contact1, utype) VALUES('" + fullname + "', '" + fname + "', '" + lname + "', '" + dtpkr.Value.ToString("yyyy-MM-dd") + "', '" + ptn_adr.Text + "', '" + ptn_age.Text + "', '" + ptn_gnd.Text + "', '" + ptn_cn.Text + "', 'Patient-Temporary')";
                            conn.Open();
                            MySqlCommand commin = new MySqlCommand(inquery, conn);
                            MySqlDataAdapter adp7 = new MySqlDataAdapter(commin);
                            commin.ExecuteNonQuery();
                            conn.Close();

                            string selection = "SELECT max(pr_id) FROM dc_pr";
                            conn.Open();
                            MySqlCommand commaa = new MySqlCommand(selection, conn);
                            MySqlDataAdapter adp10 = new MySqlDataAdapter(commaa);
                            commaa.ExecuteNonQuery();
                            DataTable dtt = new DataTable();
                            adp10.Fill(dtt);
                            conn.Close();
                            if (dtt.Rows.Count == 1)
                            {
                                string prof_id = dtt.Rows[0][0].ToString();
                                patientname.Text = prof_id;
                            }
                        }

                        string doc = "SELECT * FROM dc_pr WHERE name = '" + dctr_nm.Text + "' AND user_type = 'Doctor'";
                        conn.Open();
                        MySqlCommand comdoc = new MySqlCommand(doc, conn);
                        MySqlDataAdapter adpdoc = new MySqlDataAdapter(comdoc);
                        comdoc.ExecuteNonQuery();
                        DataTable dtdoc = new DataTable();
                        adpdoc.Fill(dtdoc);
                        conn.Close();
                        if (dtdoc.Rows.Count == 1)
                        {
                            string doc_id = dtdoc.Rows[0][0].ToString();
                            docid.Text = doc_id;
                        }
                        else
                        {
                            string fname = dct_fn.Text;
                            string lname = dct_ln.Text;

                            string fullname = fname + " " + lname;

                            string inquery = "INSERT INTO dc_pr(name, fname, lname, bday, address, age, gender, contact1, user_type) VALUES('" + fullname + "', '" + fname + "', '" + lname + "', '" + dct_bd.Value.ToString("yyyy-MM-dd") + "', '" + dct_adr.Text + "', '" + dct_age.Text + "', '" + dct_gnd.Text + "', '" + dct_cn.Text + "', 'Doctor')";
                            conn.Open();
                            MySqlCommand siq = new MySqlCommand(inquery, conn);
                            MySqlDataAdapter adp7 = new MySqlDataAdapter(siq);
                            siq.ExecuteNonQuery();
                            conn.Close();

                            string selection = "SELECT max(pr_id) FROM dc_pr";
                            conn.Open();
                            MySqlCommand mirth = new MySqlCommand(selection, conn);
                            MySqlDataAdapter adp20 = new MySqlDataAdapter(mirth);
                            mirth.ExecuteNonQuery();
                            DataTable dtt = new DataTable();
                            adp20.Fill(dtt);
                            conn.Close();
                            if (dtt.Rows.Count == 1)
                            {
                                string doc_id = dtt.Rows[0][0].ToString();
                                docid.Text = doc_id;
                            }
                        }

                        string stquery = "SELECT * FROM dc_sched WHERE ('" + start + "' BETWEEN sched_start AND sched_end) OR ('" + end + "' BETWEEN sched_start AND sched_end)";
                        string etquery = "SELECT * FROM dc_sched WHERE (sched_start BETWEEN '" + start + "' AND '" + end + "') OR  (sched_end BETWEEN '" + start + "' AND '" + end + "')";

                        conn.Open();
                        MySqlCommand commStartSelect = new MySqlCommand(stquery, conn);
                        MySqlDataAdapter adps = new MySqlDataAdapter(commStartSelect);
                        MySqlCommand commEndSelect = new MySqlCommand(etquery, conn);
                        MySqlDataAdapter adpe = new MySqlDataAdapter(commEndSelect);
                        conn.Close();

                        DataTable dtst = new DataTable();
                        adps.Fill(dtst);
                        DataTable dtet = new DataTable();
                        adpe.Fill(dtet);

                        if (dtst.Rows.Count > 0 || dtet.Rows.Count > 0)
                        {
                            MessageBox.Show("Time in Conflict with another schedule!", "Conflict Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update schedule?", "Schedule Update", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if ((shour > 12) || (ehour > 12))
                                {
                                    string start_time = (shour - 12) + ":" + sm.Text + " " + ss.Text;
                                    string end_time = (ehour - 12) + ":" + em.Text + " " + es.Text;

                                    string uquery = "UPDATE dc_sched SET pr_id='" + patientname.Text + "', dct_id = '" + docid.Text + "', sched_date='" + dtpkr.Value.ToString("yyyy-MM-dd") + "', start_time ='" + start_time + "', end_time ='" + end_time + "', sched_start ='" + start + "', sched_end ='" + end + "', shour ='" + shr.Text + "', sminute ='" + sm.Text + "', sday ='" + ss.Text + "', ehour ='" + ehr.Text + "', eminute ='" + em.Text + "', eday ='" + es.Text + "', status = 'Scheduled' where sched_id = '" + sched_id1.Text + "'";

                                    conn.Open();
                                    MySqlCommand commi = new MySqlCommand(uquery, conn);
                                    MySqlDataAdapter adp30 = new MySqlDataAdapter(commi);
                                    commi.ExecuteNonQuery();
                                    conn.Close();

                                    string selecta = "SELECT max(sched_id) FROM dc_sched";
                                    conn.Open();
                                    MySqlCommand comma = new MySqlCommand(selecta, conn);
                                    MySqlDataAdapter adp2 = new MySqlDataAdapter(comma);
                                    comma.ExecuteNonQuery();
                                    DataTable dt = new DataTable();
                                    adp2.Fill(dt);
                                    conn.Close();
                                    if (dt.Rows.Count == 1)
                                    {
                                        string maximum = dt.Rows[0][0].ToString();


                                        for (int i = 0; i < trt_grid.Rows.Count; i++)
                                        {

                                            countrows.Text = trt_grid.Rows.Count.ToString();


                                            string sell = "SELECT trt_id FROM dc_trtmnt WHERE Treatment = '" + trt_grid.Rows[i].Cells["Treatment"].Value.ToString() + "'";
                                            conn.Open();
                                            MySqlCommand commm = new MySqlCommand(sell, conn);
                                            MySqlDataAdapter adpp = new MySqlDataAdapter(commm);
                                            commm.ExecuteNonQuery();
                                            DataTable dtt = new DataTable();
                                            adpp.Fill(dtt);
                                            conn.Close();


                                            if (dtt.Rows.Count == 1)
                                            {
                                                string treat_id = dtt.Rows[0][0].ToString();

                                                string select = "SELECT * from dc_sched_line WHERE sched_id = '" + sched_id.Text + "' AND treat_id = '" + treat_id + "' AND status = 'Chosen'";
                                                conn.Open();
                                                MySqlCommand comm1 = new MySqlCommand(select, conn);
                                                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                                                comm1.ExecuteNonQuery();
                                                DataTable datt = new DataTable();
                                                adp1.Fill(datt);
                                                conn.Close();
                                                if (datt.Rows.Count != 1)
                                                {
                                                    string qquery = "INSERT INTO dc_sched_line(sched_id, trt_id, status) VALUES('" + maximum + "', '" + treat_id + "', '" + "Chosen" + "')";
                                                    conn.Open();
                                                    MySqlCommand commqq = new MySqlCommand(qquery, conn);
                                                    commqq.ExecuteNonQuery();
                                                    conn.Close();
                                                }
                                            }
                                        }
                                    }

                                    MessageBox.Show("Schedule updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    loadAll();
                                }
                                else
                                {
                                    string start_time = shour + ":" + sm.Text + " " + ss.Text;
                                    string end_time = ehour + ":" + em.Text + " " + es.Text;

                                    //string iquery = "INSERT INTO schedule(prof_id, user_id, doc_id, sched_date, start_time, end_time, sched_stime, sched_etime, starthour, startmin, startapm, endhour, endmin, endapm) VALUES('" + patientname.Text + "', '" + encoderid.Text + "', '" + docid.Text + "', '" + dtpscheddate.Value.ToString("yyyy-MM-dd") + "', '" + start_time + "' ,'" + end_time + "', '" + start + "', '" + end + "', '" + txtstarthour.Text + "', + '" + txtstartmin.Text + "' , + '" + txtstartapm.Text + "' , + '" + txtendhour.Text + "' , + '" + txtendmin.Text + "', + '" + txtendapm.Text + "')";
                                    string uquery = "UPDATE dc_sched SET pr_id='" + patientname.Text + "', dct_id = '" + docid.Text + "', sched_date='" + dtpkr.Value.ToString("yyyy-MM-dd") + "', start_time ='" + start_time + "', end_time ='" + end_time + "', sched_start ='" + start + "', sched_end ='" + end + "', shour ='" + shr.Text + "', sminute ='" + sm.Text + "', sday ='" + ss.Text + "', ehour ='" + ehr.Text + "', eminute ='" + em.Text + "', eday ='" + es.Text + "', status = 'Scheduled' where sched_id = '" + sched_id.Text + "'";

                                    conn.Open();
                                    MySqlCommand commi = new MySqlCommand(uquery, conn);
                                    MySqlDataAdapter adp30 = new MySqlDataAdapter(commi);
                                    commi.ExecuteNonQuery();
                                    conn.Close();

                                    string selecta = "SELECT max(sched_id) FROM dc_Sched";
                                    conn.Open();
                                    MySqlCommand comma = new MySqlCommand(selecta, conn);
                                    MySqlDataAdapter adp2 = new MySqlDataAdapter(comma);
                                    comma.ExecuteNonQuery();
                                    DataTable dt = new DataTable();
                                    adp2.Fill(dt);
                                    conn.Close();
                                    if (dt.Rows.Count == 1)
                                    {
                                        string maximum = dt.Rows[0][0].ToString();


                                        for (int i = 0; i < trt_grid.Rows.Count; i++)
                                        {

                                            countrows.Text = trt_grid.Rows.Count.ToString();

                                            string sell = "SELECT trt_id FROM dc_trtmnt WHERE Treatment = '" + trt_grid.Rows[i].Cells["Treatment"].Value.ToString() + "'";
                                            conn.Open();
                                            MySqlCommand commm = new MySqlCommand(sell, conn);
                                            MySqlDataAdapter adpp = new MySqlDataAdapter(commm);
                                            commm.ExecuteNonQuery();
                                            DataTable dtt = new DataTable();
                                            adpp.Fill(dtt);
                                            conn.Close();


                                            if (dtt.Rows.Count == 1)
                                            {
                                                string treat_id = dtt.Rows[0][0].ToString();

                                                string equery = "INSERT INTO dc_sched_line(sched_id, trt_id, status) VALUES('" + maximum + "', '" + treat_id + "', '" + "Chosen" + "')";
                                                conn.Open();
                                                MySqlCommand commqq = new MySqlCommand(equery, conn);
                                                commqq.ExecuteNonQuery();
                                                conn.Close();
                                            }
                                        }
                                    }

                                    MessageBox.Show("Schedule updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    loadAll();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The clinic is only open from 8 AM to 6 PM", "TIME!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Reset();
        }

        private void CancelS_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel schedule?", "Schedule Cancellation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //string iquery = "INSERT INTO schedule(prof_id, user_id, doc_id, sched_date, start_time, end_time, sched_stime, sched_etime, starthour, startmin, startapm, endhour, endmin, endapm) VALUES('" + patientname.Text + "', '" + encoderid.Text + "', '" + docid.Text + "', '" + dtpscheddate.Value.ToString("yyyy-MM-dd") + "', '" + start_time + "' ,'" + end_time + "', '" + start + "', '" + end + "', '" + txtstarthour.Text + "', + '" + txtstartmin.Text + "' , + '" + txtstartapm.Text + "' , + '" + txtendhour.Text + "' , + '" + txtendmin.Text + "', + '" + txtendapm.Text + "')";
                string uquery = "UPDATE dc_sched SET status = 'Cancelled' where sched_id = '" + sched_id.Text + "'";

                conn.Open();
                MySqlCommand commi = new MySqlCommand(uquery, conn);
                MySqlDataAdapter adp30 = new MySqlDataAdapter(commi);
                commi.ExecuteNonQuery();
                conn.Close();

                string upquery = "UPDATE dc_sched SET status = 'Cancelled Schedule' where sched_id = '" + sched_id.Text + "'";

                conn.Open();
                MySqlCommand commii = new MySqlCommand(upquery, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(commii);
                commii.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Schedule Cancelled", "Schedule Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadAll();

                adschp.Hide();
                patn.Clear();
                dtpkr.Text = "";
                shr.Text = "";
                sm.Text = "";
                ss.Text = "";
                ehr.Text = "";
                em.Text = "";
                es.Text = "";
                dctr_nm.Text = "";
                patn.Focus();
            }
        }

        private void addsch_Click(object sender, EventArgs e)
        {


            if (patn.Text == "" || dtpkr.Text == "" || shr.Text == "" || sm.Text == "" || ss.Text == "" || ehr.Text == "" || em.Text == "" || es.Text == "" || dctr_nm.Text == "" || trt_grid.Rows.Count == 0)
            {
                MessageBox.Show("Please fill up all data.", "Appointment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string start;
                string end;
                string date = dtpkr.Text;

                int shour = int.Parse(shr.Text);
                int ehour = int.Parse(ehr.Text);

                dtpkr.MinDate = DateTime.Today;

                if (ss.Text == "AM")
                {
                    shour = shour + 0;
                }
                else if (ss.Text == "PM")
                {
                    if (shour == 12)
                    {
                        shour = shour + 0;
                    }
                    else
                    {
                        shour = shour + 12;
                    }
                }
                else
                {
                    MessageBox.Show("Please select desired meridiem.", "Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (es.Text == "AM")
                {
                    ehour = ehour + 0;
                }
                else if (es.Text == "PM")
                {
                    if (ehour == 12)
                    {
                        ehour = ehour + 0;
                    }
                    else
                    {
                        ehour = ehour + 12;
                    }
                }
                else
                {
                    MessageBox.Show("Please select desired meridiem.", "Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int sminute = int.Parse(sm.Text);
                int eminute = int.Parse(em.Text);

                start = date + " " + shour + ":" + sm.Text + ":00";
                end = date + " " + ehour + ":" + em.Text + ":00";




                if ((shour >= 8 && ehour < 18))
                {
                    if ((shour == ehour && sminute > eminute) || ((shour > ehour) && (ss.Text == "AM" && es.Text == "AM")) || ((shour > ehour) && (ss.Text == "PM" && es.Text == "PM")))
                    {
                        MessageBox.Show("End time is Invalid. Please select new end time.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (dtpkr.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        MessageBox.Show("Reminder: Clinic is closed every Sunday.", "Closed on Sundays", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        string sel = "SELECT * FROM dc_pr WHERE name = '" + patn.Text + "' AND user_type LIKE 'Patient%'";
                        conn.Open();
                        MySqlCommand ace = new MySqlCommand(sel, conn);
                        MySqlDataAdapter adp = new MySqlDataAdapter(ace);
                        ace.ExecuteNonQuery();
                        DataTable dat = new DataTable();
                        adp.Fill(dat);
                        conn.Close();
                        if (dat.Rows.Count == 1)
                        {
                            string prof_id = dat.Rows[0][0].ToString();
                            patientname.Text = prof_id;
                        }
                        else
                        {
                            string fname = ptn_fn.Text;
                            string lname = ptn_ln.Text;
                            string datereg = DateTime.Now.ToString("yyyy-MM-dd");

                            string fullname = fname + " " + lname;

                            string inquery = "INSERT INTO dc_pr(name, fname, lname, bday, address, age, gender, contact1, user_type) VALUES('" + fullname + "', '" + fname + "', '" + lname + "', '" + ptn_bd.Value.ToString("yyyy-MM-dd") + "', '" + ptn_adr.Text + "', '" + ptn_age.Text + "', '" + ptn_gnd.Text + "', '" + ptn_cn.Text + "', 'Patient-Temporary')";
                            conn.Open();
                            MySqlCommand sith = new MySqlCommand(inquery, conn);
                            MySqlDataAdapter adp7 = new MySqlDataAdapter(sith);
                            sith.ExecuteNonQuery();
                            conn.Close();

                            string selection = "SELECT max(pr_id) FROM dc_pr";
                            conn.Open();
                            MySqlCommand assn = new MySqlCommand(selection, conn);
                            MySqlDataAdapter adp10 = new MySqlDataAdapter(assn);
                            assn.ExecuteNonQuery();
                            DataTable dtt = new DataTable();
                            adp10.Fill(dtt);
                            conn.Close();
                            if (dtt.Rows.Count == 1)
                            {
                                string pr_id = dtt.Rows[0][0].ToString();
                                patientname.Text = pr_id;
                            }
                        }

                        string doc = "SELECT * FROM dc_pr WHERE name = '" + dctr_nm.Text + "' AND user_type = 'Doctor'";
                        conn.Open();
                        MySqlCommand gndc = new MySqlCommand(doc, conn);
                        MySqlDataAdapter adpdoc = new MySqlDataAdapter(gndc);
                        gndc.ExecuteNonQuery();
                        DataTable dtdoc = new DataTable();
                        adpdoc.Fill(dtdoc);
                        conn.Close();
                        if (dtdoc.Rows.Count == 1)
                        {
                            string doc_id = dtdoc.Rows[0][0].ToString();
                            docid.Text = doc_id;
                        }
                        else
                        {
                            string fname = dct_fn.Text;
                            string lname = dct_ln.Text;
                            string datereg = DateTime.Now.ToString("yyyy-MM-dd");

                            string fullname = fname + " " + lname;

                            string inquery = "INSERT INTO dc_pr(name, fname, lname, bday, address, age, gender, contact1, user_type) VALUES('" + fullname + "', '" + fname + "', '" + lname + "', '" + dct_bd.Value.ToString("yyyy-MM-dd") + "', '" + dct_adr.Text + "', '" + dct_age.Text + "', '" + dct_gnd.Text + "', '" + dct_cn.Text + "', 'Doctor')";
                            conn.Open();
                            MySqlCommand siq = new MySqlCommand(inquery, conn);
                            MySqlDataAdapter adp7 = new MySqlDataAdapter(siq);
                            siq.ExecuteNonQuery();
                            conn.Close();

                            string selection = "SELECT max(pr_id) FROM dc_pr";
                            conn.Open();
                            MySqlCommand mirth = new MySqlCommand(selection, conn);
                            MySqlDataAdapter adp20 = new MySqlDataAdapter(mirth);
                            mirth.ExecuteNonQuery();
                            DataTable dtt = new DataTable();
                            adp20.Fill(dtt);
                            conn.Close();
                            if (dtt.Rows.Count == 1)
                            {
                                string doc_id = dtt.Rows[0][0].ToString();
                                docid.Text = doc_id;
                            }
                        }

                        string stquery = "SELECT * FROM dc_sched WHERE ('" + start + "' BETWEEN sched_start AND sched_end) OR ('" + end + "' BETWEEN sched_start AND sched_end)";
                        string etquery = "SELECT * FROM dc_sched WHERE (sched_start BETWEEN '" + start + "' AND '" + end + "') OR  (sched_end BETWEEN '" + start + "' AND '" + end + "')";
                        string doct = "SELECT * FROM dc_sched WHERE dct_id = '" + docid.Text + "' AND sched_start = '" + start + "' AND sched_end = '" + end + "' AND status = 'Scheduled'";
                        string doct2 = "SELECT * FROM dc_sched WHERE dct_id = '" + docid.Text + "' AND ((sched_start BETWEEN '" + start + "' AND '" + end + "') OR  (sched_end BETWEEN '" + start + "' AND '" + end + "')) AND status = 'Scheduled'";
                        string doct3 = "SELECT * FROM dc_sched WHERE dct_id = '" + docid.Text + "' AND (('" + start + "' BETWEEN sched_start AND sched_end) OR ('" + end + "' BETWEEN sched_start AND sched_end)) AND status = 'Scheduled'";

                        conn.Open();
                        MySqlCommand commStartSelect = new MySqlCommand(stquery, conn);
                        MySqlDataAdapter adps = new MySqlDataAdapter(commStartSelect);
                        MySqlCommand commEndSelect = new MySqlCommand(etquery, conn);
                        MySqlDataAdapter adpe = new MySqlDataAdapter(commEndSelect);
                        MySqlCommand commdoct = new MySqlCommand(doct, conn);
                        MySqlDataAdapter rdde = new MySqlDataAdapter(commdoct);

                        MySqlCommand commdoct2 = new MySqlCommand(doct2, conn);
                        MySqlDataAdapter rdde2 = new MySqlDataAdapter(commdoct2);
                        MySqlCommand commdoct3 = new MySqlCommand(doct3, conn);
                        MySqlDataAdapter rdde3 = new MySqlDataAdapter(commdoct3);


                        conn.Close();

                        DataTable dtst = new DataTable();
                        adps.Fill(dtst);
                        DataTable dtet = new DataTable();
                        adpe.Fill(dtet);
                        DataTable dtid = new DataTable();
                        rdde.Fill(dtid);

                        DataTable dtid2 = new DataTable();
                        rdde2.Fill(dtid2);
                        DataTable dtid3 = new DataTable();
                        rdde3.Fill(dtid3);



                        if (dtid.Rows.Count > 0)
                        {
                            MessageBox.Show("Time in Conflict with another schedule!", "Conflict Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (dtid2.Rows.Count > 0 || dtid3.Rows.Count > 0)
                        {
                            MessageBox.Show("Time in Conflict with another schedule!", "Conflict Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to add to schedule?", "Schedule Confirmation", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if ((shour > 12) || (ehour > 12))
                                {
                                    string start_time = (shour - 12) + ":" + sm.Text + " " + ss.Text;
                                    string end_time = (ehour - 12) + ":" + em.Text + " " + es.Text;


                                    string iquery = "INSERT INTO dc_sched(dct_id, pr_id, sched_start, sched_end, sched_date, start_time, end_time, shour, sminute, sday, ehour, eminute, eday, status) VALUES('" + docid.Text + "', '" + patientname.Text + "', '" + start + "', '" + end + "' ,'" + dtpkr.Value.ToString("yyyy-MM-dd") + "', '" + start_time + "', '" + end_time + "', '" + shr.Text + "', + '" + sm.Text + "' , + '" + ss.Text + "' , + '" + ehr.Text + "' , + '" + em.Text + "', + '" + es.Text + "', 'Scheduled')";
                                    conn.Open();
                                    MySqlCommand commi = new MySqlCommand(iquery, conn);
                                    MySqlDataAdapter adp30 = new MySqlDataAdapter(commi);
                                    commi.ExecuteNonQuery();
                                    conn.Close();

                                    string selecta = "SELECT max(sched_id) FROM dc_sched";
                                    conn.Open();
                                    MySqlCommand comma = new MySqlCommand(selecta, conn);
                                    MySqlDataAdapter adp2 = new MySqlDataAdapter(comma);
                                    comma.ExecuteNonQuery();
                                    DataTable dt = new DataTable();
                                    adp2.Fill(dt);
                                    conn.Close();
                                    if (dt.Rows.Count == 1)
                                    {
                                        string maximum = dt.Rows[0][0].ToString();


                                        for (int i = 0; i < trt_grid.Rows.Count; i++)
                                        {

                                            countrows.Text = trt_grid.Rows.Count.ToString();

                                            string sell = "SELECT trt_id FROM dc_trtmnt WHERE treatment = '" + trt_grid.Rows[i].Cells["Treatment"].Value.ToString() + "'";
                                            conn.Open();
                                            MySqlCommand commm = new MySqlCommand(sell, conn);
                                            MySqlDataAdapter adpp = new MySqlDataAdapter(commm);
                                            commm.ExecuteNonQuery();
                                            DataTable dtt = new DataTable();
                                            adpp.Fill(dtt);
                                            conn.Close();


                                            if (dtt.Rows.Count == 1)
                                            {
                                                string treat_id = dtt.Rows[0][0].ToString();

                                                string qquery = "INSERT INTO dc_sched_line(sched_id, trt_id, status) VALUES('" + maximum + "', '" + treat_id + "', '" + "Chosen" + "')";
                                                conn.Open();
                                                MySqlCommand commqq = new MySqlCommand(qquery, conn);
                                                commqq.ExecuteNonQuery();
                                                conn.Close();
                                            }




                                        }
                                    }

                                    MessageBox.Show("Appointment Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    loadAll();
                                }
                                else
                                {

                                    string start_time = shour + ":" + sm.Text + " " + ss.Text;
                                    string end_time = ehour + ":" + em.Text + " " + es.Text;


                                    string iquery = "INSERT INTO dc_sched(dct_id, pr_id, sched_start, sched_end, sched_date, start_time, end_time, shour, sminute, sday, ehour, eminute, eday, status) VALUES('" + docid.Text + "', '" + patientname.Text + "', '" + start + "', '" + end + "' ,'" + dtpkr.Value.ToString("yyyy-MM-dd") + "', '" + start_time + "', '" + end_time + "', '" + shr.Text + "', + '" + sm.Text + "' , + '" + ss.Text + "' , + '" + ehr.Text + "' , + '" + em.Text + "', + '" + es.Text + "', 'Scheduled')";
                                    conn.Open();
                                    MySqlCommand commi = new MySqlCommand(iquery, conn);
                                    MySqlDataAdapter adp30 = new MySqlDataAdapter(commi);
                                    commi.ExecuteNonQuery();
                                    conn.Close();

                                    string selecta = "SELECT max(sched_id) FROM dc_sched";
                                    conn.Open();
                                    MySqlCommand comma = new MySqlCommand(selecta, conn);
                                    MySqlDataAdapter adp2 = new MySqlDataAdapter(comma);
                                    comma.ExecuteNonQuery();
                                    DataTable dt = new DataTable();
                                    adp2.Fill(dt);
                                    conn.Close();
                                    if (dt.Rows.Count == 1)
                                    {
                                        string maximum = dt.Rows[0][0].ToString();


                                        for (int i = 0; i < trt_grid.Rows.Count; i++)
                                        {

                                            countrows.Text = trt_grid.Rows.Count.ToString();

                                            string sell = "SELECT trt_id FROM dc_trtmnt WHERE Treatment = '" + trt_grid.Rows[i].Cells["Treatment"].Value.ToString() + "'";
                                            conn.Open();
                                            MySqlCommand commm = new MySqlCommand(sell, conn);
                                            MySqlDataAdapter adpp = new MySqlDataAdapter(commm);
                                            commm.ExecuteNonQuery();
                                            DataTable dtt = new DataTable();
                                            adpp.Fill(dtt);
                                            conn.Close();


                                            if (dtt.Rows.Count == 1)
                                            {
                                                string treat_id = dtt.Rows[0][0].ToString();

                                                string qquery = "INSERT INTO dc_sched_line(sched_id, trt_id, status) VALUES('" + maximum + "', '" + treat_id + "', '" + "Chosen" + "')";
                                                conn.Open();
                                                MySqlCommand commqq = new MySqlCommand(qquery, conn);
                                                commqq.ExecuteNonQuery();
                                                conn.Close();
                                            }
                                        }
                                    }
                                    MessageBox.Show("Appointment Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    loadAll();
                                }
                            }
                        }
  
                    }
                }
                else
                {
                    MessageBox.Show("The clinic is only open from 8 AM to 6 PM", "TIME!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            dgv_sched.Show();
            btn_allsched.Show();
            dgv_app.Hide();
            btn_allapp.Hide();
            Reset();

        }

        private void trt_add1_Click(object sender, EventArgs e)
        {
            Boolean rafa = false;

            if (trmnt_cmb.Text == "")
            {
                MessageBox.Show("Please select treatment to be done.", "Treatment Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                for (int i = 0; i < trt_grid.Rows.Count; i++)
                {
                    if (trmnt_cmb.Text == trt_grid.Rows[i].Cells["Treatment"].Value.ToString())
                    {
                        rafa = true;
                    }

                }

                if (rafa == true)
                {
                    MessageBox.Show("Duplicate Entry.", "Treatment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    string qquery = "INSERT INTO dc_sched_line(sched_id, trt_id, status) VALUES('" + sched_id1.Text + "', '" + romeo.Text + "', '" + "Chosen" + "')";
                    conn.Open();
                    MySqlCommand commqq = new MySqlCommand(qquery, conn);
                    commqq.ExecuteNonQuery();
                    conn.Close();

                    showTreat();
                }
            }
        }

        private void trt_sve_Click(object sender, EventArgs e)
        {
            trmnt_pnl.Hide();
        }

        private void trt_rmv_Click(object sender, EventArgs e)
        {
            string selection = "SELECT * from dc_trtmnt WHERE Treatment = '" + alpha.Text + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(selection, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                int treat_id = (int)dt.Rows[0][0];

                string remove = "UPDATE dc_sched_line SET status = 'Cancelled Treatment' WHERE sched_id = '" + sched_id.Text + "' AND trt_id = '" + treat_id + "'";
                conn.Open();
                MySqlCommand commm = new MySqlCommand(remove, conn);
                MySqlDataAdapter adpp = new MySqlDataAdapter(commm);
                commm.ExecuteNonQuery();
                conn.Close();


                showTreat();

            }
            else
            {
                for (int i = 0; i < trt_grid.Rows.Count; i++)
                {
                    DataGridViewRow delrow = trt_grid.Rows[i];
                    if (delrow.Selected == true)
                    {
                        trt_grid.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void trt_cncl_Click(object sender, EventArgs e)
        {
            trmnt_pnl.Hide();
        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            dgv_app.Hide();
            dgv_sched.Show();
            ptn_lst_pnl.Hide();
            dct_lst_pnl.Hide();
            trmnt_pnl.Hide();
            ptn_pnl.Hide();
            dctr_pnl.Hide();
            btn_allapp.Hide();
            btn_allsched.Show();
        }

        private void Appointment_Click(object sender, EventArgs e)
        {
            dgv_app.Show();
            dgv_sched.Hide();
            ptn_lst_pnl.Hide();
            dct_lst_pnl.Hide();
            trmnt_pnl.Hide();
            ptn_pnl.Hide();
            dctr_pnl.Hide();
            btn_allapp.Show();
            btn_allsched.Hide();
        }

        private void form_appointment_Load(object sender, EventArgs e)
        {
            datetime.Text = DateTime.Now.ToString();

            btn_allapp.Hide();
            btn_allsched.Hide();

            loadAll();
            loadAll2();

            label8.Text = "Today: " + DateTime.Now.ToString();

            dtpkr.MinDate = DateTime.Today;
            trt_add1.Hide();
            trt_add.Show();
            FinishS.Hide();

            loadPatient();

            string sel = "SELECT * FROM dc_trtmnt";
            conn.Open();
            MySqlCommand rin = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(rin);
            rin.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trmnt_cmb.Items.Add(dt.Rows[i][1].ToString());
            }

            dgv_sched.Hide();
            dgv_app.Show();

            MySqlConnection ace = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root; Pwd=root;");
            MySqlCommand krt = new MySqlCommand("SELECT name FROM dc_pr WHERE user_type = 'Patient'", ace);
            ace.Open();
            MySqlDataReader reader = krt.ExecuteReader();
            AutoCompleteStringCollection SCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                SCollection.Add(reader.GetString(0));
            }
            patn.AutoCompleteCustomSource = SCollection;
            ace.Close();


            MySqlConnection aces = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root; Pwd=root;");
            MySqlCommand shu = new MySqlCommand("SELECT name FROM dc_pr WHERE user_type = 'Doctor'", aces);
            aces.Open();
            MySqlDataReader readerr = shu.ExecuteReader();
            AutoCompleteStringCollection SaCollection = new AutoCompleteStringCollection();
            while (readerr.Read())
            {
                SaCollection.Add(readerr.GetString(0));
            }
            dctr_nm.AutoCompleteCustomSource = SaCollection;
            aces.Close();
            panelista.Hide();
            


        }

        private void btn_allapp_Click(object sender, EventArgs e)
        {
            form_viewapp schedules = new form_viewapp();
            schedules.ShowDialog();
        }

        private void btn_allsched_Click(object sender, EventArgs e)
        {
            form_viewsched schedules = new form_viewsched();
            schedules.ShowDialog();
        }

        private void trmnt_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sel = "SELECT trt_id FROM dc_trtmnt WHERE Treatment = '" + trmnt_cmb.Text + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                int r = int.Parse(trmnt_cmb.SelectedIndex.ToString());
                int y = r + 1;
                romeo.Text = y.ToString();
            }
        }

        private void dgv_sched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            addsch.Enabled = false;
            adschp.Show();
            trt_add1.Show();
            trt_add.Hide();
            sched_id1.Text = dgv_sched.Rows[e.RowIndex].Cells["sched_id"].Value.ToString();
            patientname.Text = dgv_sched.Rows[e.RowIndex].Cells["pr_id"].Value.ToString();
            docid.Text = dgv_sched.Rows[e.RowIndex].Cells["dct_id"].Value.ToString();
            patn.Text = dgv_sched.Rows[e.RowIndex].Cells["Patient"].Value.ToString();
            dtpkr.Value = DateTime.Parse(dgv_sched.Rows[e.RowIndex].Cells["sched_date"].Value.ToString());
            shr.Text = dgv_sched.Rows[e.RowIndex].Cells["shour"].Value.ToString();
            sm.Text = dgv_sched.Rows[e.RowIndex].Cells["sminute"].Value.ToString();
            ss.Text = dgv_sched.Rows[e.RowIndex].Cells["sday"].Value.ToString();
            ehr.Text = dgv_sched.Rows[e.RowIndex].Cells["ehour"].Value.ToString();
            em.Text = dgv_sched.Rows[e.RowIndex].Cells["eminute"].Value.ToString();
            es.Text = dgv_sched.Rows[e.RowIndex].Cells["eday"].Value.ToString();
            dctr_nm.Text = dgv_sched.Rows[e.RowIndex].Cells["Doctor"].Value.ToString();



            string treat = "SELECT Treatment FROM fdc1.dc_sched_line sl LEFT JOIN dc_trtmnt t ON t.trt_id = sl.trt_id WHERE sl.sched_id = '" + sched_id1.Text + "' AND sl.status = 'Chosen'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(treat, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            trt_grid.DataSource = dt;

            sched_id.Text = sched_id1.Text;
        }

        private void trmnt_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = "SELECT trt_id FROM dc_trtmnt WHERE Treatment = '" + trmnt_cmb.Text + "'";
            conn.Open();
            MySqlCommand row = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(row);
            row.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                int r = int.Parse(trmnt_cmb.SelectedIndex.ToString());
                int y = r + 1;
                romeo.Text = y.ToString();
            }
        }

        private void dct_nme_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adp;
            DataTable dt;

            conn.Open();
            adp = new MySqlDataAdapter("SELECT name FROM dc_pr WHERE name like '" + dct_nme.Text + "%' AND user_type = 'Doctor'", conn);
            dt = new DataTable();
            adp.Fill(dt);
            dct_dgv.DataSource = dt;
            conn.Close();
        }

        private void dct_rst_Click(object sender, EventArgs e)
        {
            dct_fn.Text = "";
            dct_ln.Text = "";
            dct_bd.Text = "";
            dct_adr.Text = "";
            dct_age.Text = "";
            dct_gnd.Text = "";
            dct_cn.Text = "";
        }

        private void dct_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected_name = dct_dgv.Rows[e.RowIndex].Cells["name"].Value.ToString();
            /*if (trt_grid.SelectedRows.Count > 0)
            {
                string treatment = trt_grid.SelectedRows[0].Cells["pr_id"].Value.ToString();
                dntid.Text = treatment;
            }*/

            dctr_nm.Text = selected_name;
            dct_lst_pnl.Hide();
        }

        private void dct_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected_name = dct_dgv.Rows[e.RowIndex].Cells["name"].Value.ToString();

            
            docid.Text = dct_dgv.Rows[e.RowIndex].Cells["pr_id"].Value.ToString();
            dctr_nm.Text = selected_name;
            dct_lst_pnl.Hide();
        }

        private void dct_close_Click(object sender, EventArgs e)
        {
            dct_lst_pnl.Hide();
        }

        private void trt_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (trt_grid.SelectedRows.Count > 0)
            {
                string trtmnt = trt_grid.SelectedRows[0].Cells["Treatment"].Value.ToString();
                alpha.Text = trtmnt;
            }
        }

        private void ptn_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected_name = ptn_grid.Rows[e.RowIndex].Cells["name"].Value.ToString();


            patn.Text = selected_name;
            ptn_lst_pnl.Hide();        
        }

        private void ptn_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected_name = ptn_grid.Rows[e.RowIndex].Cells["name"].Value.ToString();


            patn.Text = selected_name;
            ptn_lst_pnl.Hide();
        }

        private void dct_sve_Click(object sender, EventArgs e)
        {
            if (dct_fn.Text == "" || dct_ln.Text == "" || dct_adr.Text == "" || dct_age.Text == ""
          || dct_gnd.Text == "" || dct_cn.Text == "" || dct_bd.Text == "")
            {
                MessageBox.Show("Please input required fields.", "Doctor Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string fname = dct_fn.Text;
                string lname = dct_ln.Text;

                dctr_pnl.Hide();
                string fullname = fname + " " + lname;

                dctr_nm.Text = fullname;
            }
        }

        private void ptn_rst_Click(object sender, EventArgs e)
        {
            ptn_fn.Text = "";
            ptn_ln.Text = "";
            ptn_bd.Text = "";
            ptn_adr.Text = "";
            ptn_age.Text = "";
            ptn_gnd.Text = "";
            ptn_cn.Text = "";
        }

        private void pnl_sv_Click(object sender, EventArgs e)
        {
            if (ptn_fn.Text == "" || ptn_ln.Text == "" || ptn_adr.Text == "" || ptn_age.Text == ""
          || ptn_gnd.Text == "" || ptn_cn.Text == "" || ptn_bd.Text == "")
            {
                MessageBox.Show("Please input required fields.", "Patient Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string fname = ptn_fn.Text;
                string lname = ptn_ln.Text;


                ptn_pnl.Hide();

                string fullname = fname + " " + lname;

                patn.Text = fullname;
            }
        }

        private void ptn_nme_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adp;
            DataTable dt;

            conn.Open();
            adp = new MySqlDataAdapter("SELECT name FROM dc_pr WHERE name like '" + ptn_nme.Text + "%' AND user_type = 'Patient'", conn);
            dt = new DataTable();
            adp.Fill(dt);
            ptn_grid.DataSource = dt;
            conn.Close();
        }

        private void closeb_Click(object sender, EventArgs e)
        {
            ptn_lst_pnl.Hide();
        }

        private void rsts_Click(object sender, EventArgs e)
        {
            Reset();
            romeo.Text = "";
            adschp.Hide();
            patn.Focus();
            trmnt_cmb.Text = "";
            trmnt_pnl.Focus();
            FinishS.Hide();
            trt_grid.DataSource = null;
            trt_grid.Rows.Clear();

            string select = "SELECT max(sched_id) FROM dc_sched";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                int x;
                x = (int)dt.Rows[0][0];
                int y = x + 1;
                sched_id1.Text = y.ToString();
                sched_id.Text = sched_id1.Text;

            }
        }

        private void dct_ccl_Click(object sender, EventArgs e)
        {
            dctr_pnl.Hide();

        }

        private void ptn_ccl_Click(object sender, EventArgs e)
        {
            ptn_pnl.Hide();
        }

        private void trt_add_Click(object sender, EventArgs e)
        {
            Boolean see = false;

            if (trmnt_cmb.Text == "")
            {
                MessageBox.Show("Please select desired treatment for appointment.", "Treatment Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                for (int a = 0; a < trt_grid.Rows.Count; a++)
                {
                    if (trmnt_cmb.Text == trt_grid.Rows[a].Cells["Treatment"].Value.ToString())
                    {
                        see = true;
                    }

                }

                if (see == true)
                {
                    MessageBox.Show("Duplicate Entry.", "Treatment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    trt_grid.Columns.Add("Treatment", "Treatment");
                    trt_grid.Rows.Add(trmnt_cmb.Text);
                }
            }
        }

        private void dgv_app_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            adschp.Show();
            trt_add1.Show();
            trt_add.Hide();
            FinishS.Show();
            AddS.Hide();
            CancelS.Hide();
            EditS.Hide();
            addsch.Enabled = false;
            app_id.Text = dgv_app.Rows[e.RowIndex].Cells["app_id"].Value.ToString();
            sched_id1.Text = dgv_app.Rows[e.RowIndex].Cells["sched_id"].Value.ToString();
            patientname.Text = dgv_app.Rows[e.RowIndex].Cells["pr_id"].Value.ToString();
            docid.Text = dgv_app.Rows[e.RowIndex].Cells["dct_id"].Value.ToString();
            patn.Text = dgv_app.Rows[e.RowIndex].Cells["Patient"].Value.ToString();
            dtpkr.Value = DateTime.Parse(dgv_app.Rows[e.RowIndex].Cells["sched_date"].Value.ToString());
            shr.Text = dgv_app.Rows[e.RowIndex].Cells["shour"].Value.ToString();
            sm.Text = dgv_app.Rows[e.RowIndex].Cells["sminute"].Value.ToString();
            ss.Text = dgv_app.Rows[e.RowIndex].Cells["sday"].Value.ToString();
            ehr.Text = dgv_app.Rows[e.RowIndex].Cells["ehour"].Value.ToString();
            em.Text = dgv_app.Rows[e.RowIndex].Cells["eminute"].Value.ToString();
            es.Text = dgv_app.Rows[e.RowIndex].Cells["eday"].Value.ToString();
            dctr_nm.Text = dgv_app.Rows[e.RowIndex].Cells["Doctor"].Value.ToString();



            string treat = "SELECT Treatment FROM fdc1.dc_sched_line sl LEFT JOIN dc_trtmnt t ON t.trt_id = sl.trt_id WHERE sl.sched_id = '" + sched_id1.Text + "' AND sl.status = 'Chosen'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(treat, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            trt_grid.DataSource = dt;

            sched_id.Text = sched_id1.Text;
        }

        private void FinishS_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Appointment completed?", "Appointment Completion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string upd = "UPDATE dc_appnt set status = 'Finished' WHERE app_id = '" + app_id.Text + "'";
                string ins = "INSERT into dc_appnt(date_fin) values ('" + DateTime.Now.ToString("yyyy-MM-dd") + "');";
                conn.Open();
                MySqlCommand commm = new MySqlCommand(upd, conn);
                MySqlDataAdapter adpp = new MySqlDataAdapter(commm);
                commm.ExecuteNonQuery();
    
                MySqlCommand commmm = new MySqlCommand(ins, conn);
                MySqlDataAdapter adppp = new MySqlDataAdapter(commmm);
                commm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Finished Appointment!", "Appointment Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadAll2();

                dgv_sched.Show(); ;

            }
            adschp.Hide();
            Reset();

            panelista.Show();
            panelista.Controls.Clear();


            form_dentalchart formdentalchart = new form_dentalchart();
            formdentalchart.FormBorderStyle = FormBorderStyle.None;
            formdentalchart.Dock = DockStyle.Fill;
            formdentalchart.BringToFront();
            formdentalchart.TopLevel = false;
            formdentalchart.AutoScroll = true;
            panelista.Controls.Add(formdentalchart);


            formdentalchart.Show();

        }

        private void ptn_age_TextChanged(object sender, EventArgs e)
        {
        }

        private void dct_age_TextChanged(object sender, EventArgs e)
        {

        }

        private void dct_bd_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dct_bd.Value;
            DateTime to = DateTime.Now;
            TimeSpan span = to - from;
            double days = span.TotalDays;
            dct_age.Text = (days / 365).ToString("0");
        }

        private void ptn_bd_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = ptn_bd.Value;
            DateTime to = DateTime.Now;
            TimeSpan span = to - from;
            double days = span.TotalDays;
            ptn_age.Text = (days / 365).ToString("0");
        }
    }

}
