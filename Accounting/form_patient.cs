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
    public partial class form_patient : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter adp;
        DataTable dt;
        public form_patient()
        {

            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root ");
        }

        private void form_patient_Load(object sender, EventArgs e)
        {
            tab_medicalhist.Hide();
            panelmedhist.Hide();
            paneldental.Hide();
            panel1.Hide();
            panel_hist.Hide();
            tab_dentalchart.Hide();
            loadAll();
            panel_pending.Hide();
            panel_accounts.Hide();



        }
        private void loadAll()
        {
            string query = "SELECT * from dc_pr WHERE user_type = 'Patient'";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["pr_id"].Visible = false;
            dataGridView1.Columns["name"].HeaderText = "Name";
            dataGridView1.Columns["fname"].HeaderText = "Firstname";
            dataGridView1.Columns["lname"].HeaderText = "Lastname";
            dataGridView1.Columns["bday"].HeaderText = "Birthdate";
            dataGridView1.Columns["address"].HeaderText = "Address";
            dataGridView1.Columns["age"].HeaderText = "Age";
            dataGridView1.Columns["gender"].HeaderText = "Gender";
            dataGridView1.Columns["contact1"].HeaderText = "Contact 1";

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

        }





        private void tab_patientinfo_Click(object sender, EventArgs e)
        {
            patientinfo.Show();
            paneldental.Hide();
            panelmedhist.Hide();

        }

        private void panelpatientinfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tab_medicalhist_Click(object sender, EventArgs e)
        {
            patientinfo.Hide();
            panelmedhist.Show();
            //

            string joiners = "SELECT dc_appnt.app_id, dc_sched.sched_date, dc_appnt.status FROM dc_appnt, dc_sched WHERE dc_appnt.pr_id = '"+label_id.Text+"' and dc_sched.sched_id = dc_appnt.sched_id; ";
            string list = "SELECT p1.* FROM payment AS p1 LEFT JOIN payment AS p2 on p1.appointment_id = p2.appointment_id AND (p1.patient_id > p2.patient_id OR (p1.appointment_id = p1.appointment_id AND p1.patient_id = p2.patient_id AND p1.payment_id > p2.payment_id)) WHERE p2.patient_id IS NULL AND p1.patient_id= '" + label_id.Text + "'; ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(joiners, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            MySqlCommand comm1 = new MySqlCommand(list, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            adp.Fill(dt);
            adp1.Fill(dt1);
            conn.Close();


            DGV_appointment.DataSource = dt;
            DGV_appointment.RowHeadersVisible = false;

            DGV_appointment.Columns["status"].HeaderText = "Status";
            DGV_appointment.Columns["sched_date"].HeaderText = "Schedule Date";
            DGV_appointment.Columns["app_id"].HeaderText = "Appointment No.";

            DGV_applist.DataSource = dt1;
            DGV_applist.RowHeadersVisible = false;

            try
            {
                DGV_applist.Columns["payment_id"].HeaderText = "Payment ID";
                DGV_applist.Columns["app_id"].HeaderText = "Appointment ID";
                DGV_applist.Columns["mop"].HeaderText = "Payment Mode";
                DGV_applist.Columns["type"].HeaderText = "Payment Type";
                DGV_applist.Columns["grandtotal"].HeaderText = "Grand Total";
                DGV_applist.Columns["amount_paid"].HeaderText = "Amount Paid";
                DGV_applist.Columns["payment_date"].HeaderText = "Payment Date";
                DGV_applist.Columns["checknumber"].HeaderText = "Check Number";
                DGV_applist.Columns["payment_due"].HeaderText = "Payment Due";
                DGV_applist.Columns["bank"].HeaderText = "Bank";
                DGV_applist.Columns["Postdatedcheck"].HeaderText = "Post Date";
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }

            //
            paneldental.Hide();
            panel1.Hide();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void load()
        {
            String data = "SELECT treatment,payment_date, toothinvolved FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved != ' '";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(data, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            comm.ExecuteNonQuery();

            date_due.DataSource = dt;
            date_due.Columns["treatment"].HeaderText = "Treatment";
            date_due.Columns["payment_date"].HeaderText = "Payment Date";
            date_due.Columns["toothinvolved"].HeaderText = "Tooth Involved";


            conn.Close();
            try
            {
                foreach (DataGridViewRow row in date_due.Rows)
                {
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U1"))
                        U1.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U2"))
                        U2.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U3"))
                        U3.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U4"))
                        U4.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U5"))
                        U5.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U6"))
                        U6.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U7"))
                        U7.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U8"))
                        U8.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U9"))
                        U9.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U10"))
                        U10.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U11"))
                        U11.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U12"))
                        U12.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U13"))
                        U13.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U14"))
                        U14.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U15"))
                        U15.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("U16"))
                        U16.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L17"))
                        L17.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L18"))
                        L18.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L19"))
                        L19.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L20"))
                        L20.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L21"))
                        L21.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L22"))
                        L22.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L23"))
                        L23.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L24"))
                        L24.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L25"))
                        L25.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L26"))
                        L26.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L27"))
                        L27.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L28"))
                        L28.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L29"))
                        L29.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L30"))
                        L30.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L31"))
                        L31.CheckState = CheckState.Checked;
                    if (row.Cells["toothinvolved"].Value.ToString().Contains("L32"))
                        L32.CheckState = CheckState.Checked;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }


        }
        private void tab_dentalchart_Click(object sender, EventArgs e)
        {
            panelmedhist.Hide();
            patientinfo.Hide();
            paneldental.Show();
            load();

            // String checkdata = "SELECT treatment, toothinv FROM payment WHERE patient_id = + '" + label_id.Text + "'" 
            //charaaan


            String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved = ' '";
            String data = "SELECT treatment,payment_date, toothinvolved FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved != ' '";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(like, conn);
            MySqlCommand comm1 = new MySqlCommand(data, conn);

            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            adp.Fill(dt);
            adp1.Fill(dt1);

            comm.ExecuteNonQuery();
            comm1.ExecuteNonQuery();


            dataGridView_ov.DataSource = dt;
            dataGridView_ov.Columns["treatment"].HeaderText = "Treatment";
            dataGridView_ov.Columns["payment_date"].HeaderText = "Payment Date";


            date_due.DataSource = dt1;
            date_due.Columns["treatment"].HeaderText = "Treatment";
            date_due.Columns["payment_date"].HeaderText = "Payment Date";
            date_due.Columns["toothinvolved"].HeaderText = "Tooth Involved";
            conn.Close();
        }
            private void button_create_Click_1(object sender, EventArgs e)
        {
            if (textBox_firstname.Text == " " || textBox_lastname.Text == " " || textBox_address.Text == " " || textBox_age.Text == " "
              || combo_gender.Text == " " || textBox_contact1.Text == " ")
            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {
                string fname = textBox_firstname.Text;
                string lname = textBox_lastname.Text;
                string fullname = fname + " " + lname;

                String query6 = "INSERT INTO dc_pr (name, fname, lname, bday, address, age, gender, contact1, user_type) " +
                               "VALUES('" + fullname + "','" + fname + "', '" + lname + "', '" + birth_date.Value.ToString("yyyy-MM-dd") + "', '" + textBox_address.Text + "', '" + textBox_age.Text + "', '" + combo_gender.Text + "', '" + textBox_contact1.Text + "', 'Patient')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query6, conn);

                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();
            }
        }

        private void button_update_Click_1(object sender, EventArgs e)
        {
            if (textBox_firstname.Text == " " || textBox_lastname.Text == " " || textBox_address.Text == " ")
            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {
                string fname = textBox_firstname.Text;
                string lname = textBox_lastname.Text;
                string fullname = fname + " " + lname;
                String id = label_id.Text;
                String query5 = "SELECT * FROM dc_pr WHERE pr_id ='" + id + "'";
                conn.Open();

                MySqlCommand com = new MySqlCommand(query5, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();





                String query4 = "Update dc_pr set name ='" + fullname + "',fname='" + textBox_firstname.Text + "', lname='" + textBox_lastname.Text + "', address = '" + textBox_address.Text + "', age = '" + textBox_age.Text + "', gender = '" + combo_gender.Text + "', contact1 = '" + textBox_contact1.Text + "' where pr_id = '" + label_id.Text + "'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(query4, conn);


                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();
                MessageBox.Show("Updated Successfully!");

            }

        }

        private void button_reset_Click_1(object sender, EventArgs e)
        {
            label_id.Text = "";
            textBox_firstname.Text = "";
            textBox_lastname.Text = "";
            birth_date.Text = "";
            textBox_address.Text = "";
            textBox_age.Text = "";
            combo_gender.Text = "";
            textBox_contact1.Text = "";
            textBox_firstname.Focus();

            DGV_appointment.DataSource = null;
            DGV_appointment.Rows.Clear();
            DGV_dentaloperation.DataSource = null;
            DGV_dentaloperation.Rows.Clear();
            DGV_accounts.DataSource = null;
            DGV_accounts.Rows.Clear();
            label_treatment_id.Text = "";
            label_appointmentt_id.Text = "";
            //textBox_treatmentt.Text = "";
            textBox_mop.Text = "";
            textBox_type.Text = "";
            //textBox_toothinv.Text = "";
            textBox_grandtotal.Text = "";
            textBox_amount_paid.Text = "";
            textBox_Checknumber.Text = "";
            date_payment.Text = "";
            due_payment.Text = "";
            text_balance.Text = "";

            patient_name.Text = "";
            date_due.DataSource = null;
            date_due.Rows.Clear();


            button_create.Show();
            reset1();
            reset2();
        }

        public void reset1()
        {
            U1.CheckState = CheckState.Unchecked;
            U2.CheckState = CheckState.Unchecked;
            U3.CheckState = CheckState.Unchecked;
            U4.CheckState = CheckState.Unchecked;
            U5.CheckState = CheckState.Unchecked;
            U6.CheckState = CheckState.Unchecked;
            U7.CheckState = CheckState.Unchecked;
            U8.CheckState = CheckState.Unchecked;
            U9.CheckState = CheckState.Unchecked;
            U10.CheckState = CheckState.Unchecked;
            U11.CheckState = CheckState.Unchecked;
            U12.CheckState = CheckState.Unchecked;
            U13.CheckState = CheckState.Unchecked;
            U14.CheckState = CheckState.Unchecked;
            U15.CheckState = CheckState.Unchecked;
            U16.CheckState = CheckState.Unchecked;
            L17.CheckState = CheckState.Unchecked;
            L18.CheckState = CheckState.Unchecked;
            L19.CheckState = CheckState.Unchecked;
            L20.CheckState = CheckState.Unchecked;
            L21.CheckState = CheckState.Unchecked;
            L22.CheckState = CheckState.Unchecked;
            L23.CheckState = CheckState.Unchecked;
            L24.CheckState = CheckState.Unchecked;
            L25.CheckState = CheckState.Unchecked;
            L26.CheckState = CheckState.Unchecked;
            L27.CheckState = CheckState.Unchecked;
            L28.CheckState = CheckState.Unchecked;
            L29.CheckState = CheckState.Unchecked;
            L30.CheckState = CheckState.Unchecked;
            L31.CheckState = CheckState.Unchecked;
            L32.CheckState = CheckState.Unchecked;
        }

        public void reset2()
        {
            U1.CheckState = CheckState.Unchecked;
            U2.CheckState = CheckState.Unchecked;
            U3.CheckState = CheckState.Unchecked;
            U4.CheckState = CheckState.Unchecked;
            U5.CheckState = CheckState.Unchecked;
            U6.CheckState = CheckState.Unchecked;
            U7.CheckState = CheckState.Unchecked;
            U8.CheckState = CheckState.Unchecked;
            U9.CheckState = CheckState.Unchecked;
            U10.CheckState = CheckState.Unchecked;
            U11.CheckState = CheckState.Unchecked;
            U12.CheckState = CheckState.Unchecked;
            U13.CheckState = CheckState.Unchecked;
            U14.CheckState = CheckState.Unchecked;
            U15.CheckState = CheckState.Unchecked;
            U16.CheckState = CheckState.Unchecked;
            L17.CheckState = CheckState.Unchecked;
            L18.CheckState = CheckState.Unchecked;
            L19.CheckState = CheckState.Unchecked;
            L20.CheckState = CheckState.Unchecked;
            L21.CheckState = CheckState.Unchecked;
            L22.CheckState = CheckState.Unchecked;
            L23.CheckState = CheckState.Unchecked;
            L24.CheckState = CheckState.Unchecked;
            L25.CheckState = CheckState.Unchecked;
            L26.CheckState = CheckState.Unchecked;
            L27.CheckState = CheckState.Unchecked;
            L28.CheckState = CheckState.Unchecked;
            L29.CheckState = CheckState.Unchecked;
            L30.CheckState = CheckState.Unchecked;
            L31.CheckState = CheckState.Unchecked;
            L32.CheckState = CheckState.Unchecked;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DGV_appointment.DataSource = null;
            DGV_appointment.Rows.Clear();
            DGV_dentaloperation.DataSource = null;
            DGV_accounts.DataSource = null;
            DGV_accounts.Rows.Clear();
            DGV_dentaloperation.Rows.Clear();
            label_treatment_id.Text = "";
            label_appointmentt_id.Text = "";
            //textBox_treatmentt.Text = "";
            textBox_mop.Text = "";
            textBox_type.Text = "";
            //textBox_toothinv.Text = "";
            textBox_grandtotal.Text = "";
            textBox_amount_paid.Text = "";
            textBox_Checknumber.Text = "";
            date_payment.Text = "";
            due_payment.Text = "";

            patient_name.Text = "";
            date_due.DataSource = null;
            date_due.Rows.Clear();
            panel_hist.Hide();
            panel_accounts.Hide();


            button_create.Show();
            reset1();
            reset2();

            label_id.Text = dataGridView1.Rows[e.RowIndex].Cells["pr_id"].Value.ToString();
            patient_name.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            textBox_firstname.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
            textBox_lastname.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
            textBox_address.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
            textBox_age.Text = dataGridView1.Rows[e.RowIndex].Cells["age"].Value.ToString();
            combo_gender.Text = dataGridView1.Rows[e.RowIndex].Cells["gender"].Value.ToString();
            textBox_contact1.Text = dataGridView1.Rows[e.RowIndex].Cells["contact1"].Value.ToString();

            birth_date.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["bday"].Value.ToString());

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                button_create.Hide();

            }
            tab_dentalchart.Show();
            tab_medicalhist.Show();



            //

            string sel = "SELECT amount_paid, grandtotal FROM payment WHERE patient_id = '" + label_id.Text + "'";
            conn.Open();
            MySqlCommand comm12 = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm12);
            conn.Close();
            DataTable dtt = new DataTable();
            adp1.Fill(dtt);
            

        }

        private void tab_invoicerecord_Click(object sender, EventArgs e)
        {
            patientinfo.Hide();
            panelmedhist.Hide();
            paneldental.Hide();
        }

        private void combo_when_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelmedhist_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGV_appointment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string appid;
            appid = DGV_appointment.Rows[e.RowIndex].Cells["app_id"].Value.ToString();

            string query = "SELECT payment_id, appointment_id, treatment , mop, type, toothinvolved, charges, grandtotal, payment_date, checknumber, amount_paid, payment_due, Postdatedcheck from payment WHERE appointment_id = '" + appid + "'";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();

            DGV_dentaloperation.DataSource = dt;
            DGV_dentaloperation.Columns["payment_id"].Visible = false;
            DGV_dentaloperation.Columns["appointment_id"].Visible = false;
            DGV_dentaloperation.Columns["treatment"].HeaderText = "Treatment";
            DGV_dentaloperation.Columns["mop"].Visible = false;
            DGV_dentaloperation.Columns["type"].Visible = false;
            DGV_dentaloperation.Columns["toothinvolved"].Visible = false;
            DGV_dentaloperation.Columns["charges"].HeaderText = "Charges";
            DGV_dentaloperation.Columns["grandtotal"].Visible = false;
            DGV_dentaloperation.Columns["payment_date"].Visible = false;
            DGV_dentaloperation.Columns["checknumber"].Visible = false;
            DGV_dentaloperation.Columns["amount_paid"].Visible = false;
            DGV_dentaloperation.Columns["payment_due"].Visible = false;
            DGV_dentaloperation.Columns["Postdatedcheck"].Visible = false;

            DGV_dentaloperation.Sort(DGV_dentaloperation.Columns[1], ListSortDirection.Ascending);
            DGV_dentaloperation.Sort(DGV_dentaloperation.Columns[0], ListSortDirection.Ascending);
            DGV_dentaloperation.Columns[2].Width = 200;

            try
            {
                label_treatment_id.Text = DGV_applist.Rows[e.RowIndex].Cells["payment_id"].Value.ToString();
                label_appointmentt_id.Text = DGV_applist.Rows[e.RowIndex].Cells["appointment_id"].Value.ToString();
                //textBox_treatmentt.Text = DGV_applist.Rows[e.RowIndex].Cells["treatment"].Value.ToString();
                textBox_mop.Text = DGV_applist.Rows[e.RowIndex].Cells["mop"].Value.ToString();
                textBox_type.Text = DGV_applist.Rows[e.RowIndex].Cells["type"].Value.ToString();
                //textBox_toothinv.Text = DGV_applist.Rows[e.RowIndex].Cells["toothinvolved"].Value.ToString();
                textBox_grandtotal.Text = DGV_applist.Rows[e.RowIndex].Cells["grandtotal"].Value.ToString();
                date_payment.Text = DGV_applist.Rows[e.RowIndex].Cells["payment_date"].Value.ToString();
                due_payment.Text = DGV_applist.Rows[e.RowIndex].Cells["payment_due"].Value.ToString();
                textBox_amount_paid.Text = DGV_applist.Rows[e.RowIndex].Cells["amount_paid"].Value.ToString();
                textBox_Checknumber.Text = DGV_applist.Rows[e.RowIndex].Cells["checknumber"].Value.ToString();
                dateTimePicker_pdc.Text = DGV_applist.Rows[e.RowIndex].Cells["Postdatedcheck"].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }


            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            panel1.Hide();
            if (textBox_grandtotal.Text == textBox_amount_paid.Text)
            {
                //button_add_payment.Hide();
            }
            else if (textBox_grandtotal.Text != textBox_amount_paid.Text)
            {
                //button_add_payment.Show();
            }


            if (textBox_mop.Text == "Cash")
            {
                checknumber.Hide();
                textBox_Checknumber.Hide();
                dateTimePicker_pdc.Hide();
                label__pdc.Hide();

                if (textBox_type.Text == "Full")
                {
                    //button_add_payment.Hide();
                    label_paymentdue.Hide();
                    due_payment.Hide();
                    button_paymenthist.Hide();
                    label_balance.Hide();
                    textBox_balance.Hide();

                }
                else
                {

                    button_paymenthist.Show();
                    label_paymentdue.Show();
                    due_payment.Show();
                    dateTimePicker_pdc.Hide();
                    label__pdc.Hide();
                    label_balance.Show();
                    textBox_balance.Show();

                }
            }
            else
            {


                if (textBox_type.Text == "Full")
                {
                    //button_add_payment.Hide();
                    button_paymenthist.Hide();
                    due_payment.Hide();
                    dateTimePicker_pdc.Show();
                    label__pdc.Show();
                    label_balance.Hide();
                    textBox_balance.Hide();
                    checknumber.Show();
                    textBox_Checknumber.Show();


                }
                else
                {
                    //button_add_payment.Show();
                    button_paymenthist.Show();
                    dateTimePicker_pdc.Hide();
                    label__pdc.Hide();
                    label_balance.Show();
                    textBox_balance.Show();
                    label_paymentdue.Show();
                    due_payment.Show();

                }
            }


            if (textBox_amount_paid.Text == textBox_grandtotal.Text)
            {
                //button_add_payment.Hide();
                label_balance.Hide();
                textBox_balance.Hide();
            }
            else
            {
                label_balance.Show();
                textBox_balance.Show();
                int a = Convert.ToInt32(textBox_amount_paid.Text);

                int b = Convert.ToInt32(textBox_grandtotal.Text);

                int c = a - b;

                textBox_balance.Text = Convert.ToString(c);
            }

            if (textBox_type.Text == "Staggered")
            {
                textBox_Checknumber.Hide();
                checknumber.Hide();
            }




        }

        private void DGV_dentaloperation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*label_treatment_id.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["payment_id"].Value.ToString();
            label_appointmentt_id.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["appointment_id"].Value.ToString();
            //textBox_treatmentt.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["treatment"].Value.ToString();
            textBox_mop.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["mop"].Value.ToString();
            textBox_type.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["type"].Value.ToString();
            //textBox_toothinv.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["toothinvolved"].Value.ToString();
            textBox_grandtotal.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["grandtotal"].Value.ToString();
            date_payment.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["payment_date"].Value.ToString();
            due_payment.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["payment_due"].Value.ToString();
            textBox_amount_paid.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["amount_paid"].Value.ToString();
            textBox_Checknumber.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["checknumber"].Value.ToString();
            dateTimePicker_pdc.Text = DGV_dentaloperation.Rows[e.RowIndex].Cells["Postdatedcheck"].Value.ToString();


            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            panel1.Hide();
            if(textBox_grandtotal.Text == textBox_amount_paid.Text)
            {
                button_add_payment.Hide();
            }else if(textBox_grandtotal.Text != textBox_amount_paid.Text)
            {
                button_add_payment.Show();
            }
        

            if (textBox_mop.Text == "Cash")
            {
                checknumber.Hide();
                textBox_Checknumber.Hide();
                dateTimePicker_pdc.Hide();
                label__pdc.Hide();

                if (textBox_type.Text == "Full")
                {
                    button_add_payment.Hide();
                    label_paymentdue.Hide();
                    due_payment.Hide();
                    button_paymenthist.Hide();
                    label_balance.Hide();
                    textBox_balance.Hide();

}
                else
                {

                    button_paymenthist.Show();
                    label_paymentdue.Show();
                    due_payment.Show();
                    dateTimePicker_pdc.Hide();
                    label__pdc.Hide();
                    label_balance.Show();
                    textBox_balance.Show();

                }
            }
            else
            {
              

                if (textBox_type.Text == "Full")
                {
                    button_add_payment.Hide();
                    button_paymenthist.Hide();
                    due_payment.Hide();
                    dateTimePicker_pdc.Show();
                    label__pdc.Show();
                    label_balance.Hide();
                    textBox_balance.Hide();
                    checknumber.Show();
                    textBox_Checknumber.Show();


                }
                else
                {
                    button_add_payment.Show();
                    button_paymenthist.Show();
                    dateTimePicker_pdc.Hide();
                    label__pdc.Hide();
                    label_balance.Show();
                    textBox_balance.Show();
                    label_paymentdue.Show();
                    due_payment.Show();

                }
            }


            if(textBox_amount_paid.Text == textBox_grandtotal.Text)
            {
                button_add_payment.Hide();
                label_balance.Hide();
                textBox_balance.Hide();
            }else
            {
                label_balance.Show();
                textBox_balance.Show();
                int a = Convert.ToInt32(textBox_amount_paid.Text);

                int b = Convert.ToInt32(textBox_grandtotal.Text);

                int c = a - b;

                textBox_balance.Text = Convert.ToString(c);
            }

            if (textBox_type.Text == "Staggered")
            {
                textBox_Checknumber.Hide();
                checknumber.Hide();
            }*/
            



        }

        private void checknumber_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_mop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_mop.Text == "Cash")
            {
                labelcheck.Hide();
                textBox_checknumber_cheque.Hide();
                label_bank.Hide();
                comboBox_bank.Hide();
                label_pdc.Hide();
                date_pdc.Hide();

            }
            else if (comboBox_mop.Text == "Cheque")
            {
                labelcheck.Show();
                textBox_checknumber_cheque.Show();
                label_bank.Show();
                comboBox_bank.Show();
                label_pdc.Show();
                date_pdc.Show();
               
            }
        }

        private void button_payy_Click(object sender, EventArgs e)
        {

            if (comboBox_mop.Text == "Cash")
            {
                decimal paid = 0;
                decimal paid1 = 0;

                paid = (Convert.ToDecimal(textBox_amount_paid.Text)) + (Convert.ToDecimal(textBox_amount_cashcheque.Text));
                paid1 = (Convert.ToDecimal(chosen_balance.Text)) + (Convert.ToDecimal(textBox_amount_cashcheque.Text));

                String querycash = "INSERT INTO payment_line_cashcheque(payment_id,appointment_id,cash_paid,date,checknumber,bank, plc_postdatedcheck) VALUES('" + label_treatment_id.Text + "','" + label_appointmentt_id.Text + "','" + textBox_amount_cashcheque.Text + "',CURDATE(),NULL ,NULL, NULL); ";
                MySqlCommand comm = new MySqlCommand(querycash, conn);
                conn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();

                String querycash2 = "Update payment set amount_paid = '" + paid + "' WHERE appointment_id = " + label_appointmentt_id.Text + ";";
                MySqlCommand comm1 = new MySqlCommand(querycash2, conn);
                comm1.ExecuteNonQuery();

                String querycash4 = "Update dc_accounts set balance = '" + paid1 + "' WHERE app_id = " + label_appointmentt_id.Text + ";";
                MySqlCommand comm3 = new MySqlCommand(querycash4, conn);
                comm3.ExecuteNonQuery();


                //
                String querycash3 = "INSERT INTO payment_hist(payment_appid, payment_id, name, payment_amount, payment_date) VALUES('" + label_appointmentt_id.Text + "','" +label_treatment_id.Text+"','"+patient_name.Text+"','"+textBox_amount_cashcheque.Text+"',now())";
                MySqlCommand comm2 = new MySqlCommand(querycash3, conn);
                  comm2.ExecuteNonQuery();
                MessageBox.Show("Payment update was successful, Thank you!");
                conn.Close();
                //
                string sel = "SELECT amount_paid FROM payment WHERE payment_id = '" + label_treatment_id.Text + "'";
                conn.Open();
                MySqlCommand comm12 = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm12);
                conn.Close();
                DataTable dtt = new DataTable();
                adp1.Fill(dtt);
                if (dtt.Rows.Count == 1)
                {
                    textBox_amount_paid.Text = dtt.Rows[0][0].ToString();
                }

                textBox_amount_cashcheque.Text = " ";
                comboBox_mop.Text = " ";
                panel1.Hide();



            }
            else
            {
                decimal paid = 0;

                paid = (Convert.ToDecimal(textBox_amount_paid.Text)) + (Convert.ToDecimal(textBox_amount_cashcheque.Text));

                String querycash = "INSERT INTO payment_line_cashcheque(payment_id,appointment_id,cash_paid,date,checknumber,bank, plc_postdatedcheck) VALUES('" + label_treatment_id.Text + "','" + label_appointmentt_id.Text + "','" + textBox_amount_cashcheque.Text + "',CURDATE(),'" + textBox_checknumber_cheque.Text + "','" + comboBox_bank.Text + "','" + date_pdc.Value.ToString("yyyy-MM-dd")+"')";
                MySqlCommand comm = new MySqlCommand(querycash, conn);
                conn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                String querycash2 = "Update payment set amount_paid = '" + paid + "' WHERE payment_id = " + label_treatment_id.Text + ";";
                MySqlCommand comm1 = new MySqlCommand(querycash2, conn);
                comm1.ExecuteNonQuery();
                MessageBox.Show("Stocked in Succesfully!");


                String querycash3 = "INSERT INTO payment_hist(payment_appid, payment_id, name, payment_amount, payment_date) VALUES('" + label_appointmentt_id.Text + "','" + label_id.Text + "','" + patient_name.Text + "','" + textBox_amount_cashcheque.Text + "',now())";
                MySqlCommand comm2 = new MySqlCommand(querycash3, conn);
                comm2.ExecuteNonQuery();
                MessageBox.Show("Payment update was successful, Thank you!");
                conn.Close();

        

                string sel = "SELECT amount_paid FROM payment WHERE payment_id = '" + label_treatment_id.Text + "'";
                conn.Open();
                MySqlCommand comm12 = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm12);
                conn.Close();
                DataTable dtt = new DataTable();
                adp1.Fill(dtt);
                if (dtt.Rows.Count == 1)
                {
                    textBox_amount_paid.Text = dtt.Rows[0][0].ToString();
                }

                textBox_amount_cashcheque.Text = " ";
                comboBox_mop.Text = " ";
                panel1.Hide();
                
                if(textBox_grandtotal.Text == textBox_amount_paid.Text)
                {
                    //button_add_payment.Hide();
                    textBox_balance.Hide();
                    label_balance.Hide();

                }
            }
            //
            //// // ///////////////////////////////////////////////
          


            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            panel1.Hide();
            if (textBox_grandtotal.Text == textBox_amount_paid.Text)
            {
                //button_add_payment.Hide();
            }
            else if (textBox_grandtotal.Text != textBox_amount_paid.Text)
            {
                //button_add_payment.Show();
            }


            if (textBox_mop.Text == "Cash")
            {
                checknumber.Hide();
                textBox_Checknumber.Hide();
                dateTimePicker_pdc.Hide();
                label__pdc.Hide();

                if (textBox_type.Text == "Full")
                {
                   // button_add_payment.Hide();
                    label_paymentdue.Hide();
                    due_payment.Hide();
                    button_paymenthist.Hide();
                    label_balance.Hide();
                    textBox_balance.Hide();

                }
                else
                {

                    button_paymenthist.Show();
                    label_paymentdue.Show();
                    due_payment.Show();
                    dateTimePicker_pdc.Show();
                    label__pdc.Show();
                    label_balance.Show();
                    textBox_balance.Show();

                }
            }
            else
            {


                if (textBox_type.Text == "Full")
                {
                    //button_add_payment.Hide();
                    button_paymenthist.Hide();
                    due_payment.Hide();
                    dateTimePicker_pdc.Show();
                    label__pdc.Show();
                    label_balance.Hide();
                    textBox_balance.Hide();
                    checknumber.Show();
                    textBox_Checknumber.Show();


                }
                else
                {
                   // button_add_payment.Show();
                    button_paymenthist.Show();
                    dateTimePicker_pdc.Hide();
                    label__pdc.Hide();
                    label_balance.Show();
                    textBox_balance.Show();
                    label_paymentdue.Show();
                    due_payment.Show();

                }
            }
            if (textBox_amount_paid.Text == textBox_grandtotal.Text)
            {
               // button_add_payment.Hide();
                label_balance.Hide();
                textBox_balance.Hide();
            }
            else
            {
                int a = Convert.ToInt32(textBox_amount_paid.Text);

                int b = Convert.ToInt32(textBox_grandtotal.Text);

                int c = a - b;

                textBox_balance.Text = Convert.ToString(c);
            }

            if (textBox_type.Text == "Staggered")
            {
                textBox_Checknumber.Hide();
                checknumber.Hide();
            }


        }

        private void button_cancell_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }
        

        private void button_paymenthist_Click(object sender, EventArgs e)
        {
            panel_hist.Show();
            button_paymenthist.Hide();
            

            string query = "SELECT cash_paid, date, checknumber, bank, plc_postdatedcheck FROM payment_line_cashcheque WHERE appointment_id = " + label_appointmentt_id.Text + "";
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
            


            dataGridView_hist.DataSource = dt;

            dataGridView_hist.Columns["cash_paid"].HeaderText = "Amount";

            dataGridView_hist.Columns["date"].HeaderText = "Date of Transaction";
            dataGridView_hist.Columns["bank"].HeaderText = "Bank";
            dataGridView_hist.Columns["plc_postdatedcheck"].HeaderText = "PDC";
            dataGridView_hist.Columns["checknumber"].HeaderText = "Cheque Number";

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }
        }


        private void button_paymenthist_back_Click(object sender, EventArgs e)
        {
           
            button_paymenthist.Show();
            DGV_paymenthist.Hide();

        }

        private void U1_CheckedChanged(object sender, EventArgs e)
        {

            if (U1.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U1.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }

        }

        private void U2_CheckedChanged(object sender, EventArgs e)
        {
            if (U2.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U2.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }

            else
            {
                load();

            }

        }

        private void U3_CheckedChanged(object sender, EventArgs e)
        {
            if (U3.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U3.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U4_CheckedChanged(object sender, EventArgs e)
        {
            if (U4.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U4.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U5_CheckedChanged(object sender, EventArgs e)
        {
            if (U5.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U5.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U6_CheckedChanged(object sender, EventArgs e)
        {
            if (U6.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U6.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U7_CheckedChanged(object sender, EventArgs e)
        {
            if (U7.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U7.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U8_CheckedChanged(object sender, EventArgs e)
        {
            if (U8.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U8.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U9_CheckedChanged(object sender, EventArgs e)
        {
            if (U9.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U9.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U10_CheckedChanged(object sender, EventArgs e)
        {
            if (U10.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U10.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U11_CheckedChanged(object sender, EventArgs e)
        {
            if (U11.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U11.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U12_CheckedChanged(object sender, EventArgs e)
        {
            if (U12.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U12.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U13_CheckedChanged(object sender, EventArgs e)
        {
            if (U13.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U13.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U14_CheckedChanged(object sender, EventArgs e)
        {
            if (U14.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U14.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U15_CheckedChanged(object sender, EventArgs e)
        {
            if (U15.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U15.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void U16_CheckedChanged(object sender, EventArgs e)
        {
            if (U16.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + U16.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L17_CheckedChanged(object sender, EventArgs e)
        {
            if (L17.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L17.Name + "%'";


                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L18_CheckedChanged(object sender, EventArgs e)
        {
            if (L18.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L18.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L19_CheckedChanged(object sender, EventArgs e)
        {
            if (L19.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L19.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();


            }
        }

        private void L20_CheckedChanged(object sender, EventArgs e)
        {
            if (L20.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L20.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L21_CheckedChanged(object sender, EventArgs e)
        {
            if (L21.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L21.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L22_CheckedChanged(object sender, EventArgs e)
        {
            if (L22.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L22.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L_Click(object sender, EventArgs e)
        {

        }

        private void L23_CheckedChanged(object sender, EventArgs e)
        {
            if (L23.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L23.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L24_CheckedChanged(object sender, EventArgs e)
        {
            if (L24.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L24.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L25_CheckedChanged(object sender, EventArgs e)
        {
            if (L25.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L25.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L26_CheckedChanged(object sender, EventArgs e)
        {
            if (L26.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L26.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L27_CheckedChanged(object sender, EventArgs e)
        {
            if (L27.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L27.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L28_CheckedChanged(object sender, EventArgs e)
        {
            if (L28.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L28.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L29_CheckedChanged(object sender, EventArgs e)
        {
            if (L29.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L29.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L30_CheckedChanged(object sender, EventArgs e)
        {
            if (L30.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L30.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L31_CheckedChanged(object sender, EventArgs e)
        {
            if (L31.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L31.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void L32_CheckedChanged(object sender, EventArgs e)
        {
            if (L32.Checked == false)
            {


                String like = "SELECT treatment,payment_date FROM payment WHERE patient_id = '" + label_id.Text + "%' && toothinvolved like '%" + L32.Name + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(like, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comm.ExecuteNonQuery();


                conn.Close();

                date_due.DataSource = dt;
                date_due.Columns["treatment"].HeaderText = "Treatment";
                date_due.Columns["payment_date"].HeaderText = "Payment Date";

            }
            else
            {
                load();

            }
        }

        private void button_close_hist_Click(object sender, EventArgs e)
        {
            panel_hist.Hide();
            button_paymenthist.Show();
        }

        private void textBox_search_OnTextChange(object sender, EventArgs e)
        {

        }

        private void button_add_supplier_Click(object sender, EventArgs e)
        {
            panel_pending.Show();

            string query = "SELECT name,payment_id, treatment, amount_paid,grandtotal, payment_date FROM payment,dc_pr WHERE payment.patient_id = dc_pr.pr_id AND grandtotal != amount_paid";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();

            dataGridView_pending.DataSource = dt;
            dataGridView_pending.Columns["payment_id"].Visible = false;
            dataGridView_pending.Columns["name"].HeaderText = "Name";
            dataGridView_pending.Columns["treatment"].HeaderText = "Treatment";
            dataGridView_pending.Columns["amount_paid"].HeaderText = "Amount_paid";
            dataGridView_pending.Columns["grandtotal"].HeaderText = "Grandtotal";
            dataGridView_pending.Columns["payment_date"].HeaderText = "Date";
           

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

        }

        private void button_exit_pending_Click(object sender, EventArgs e)
        {
            panel_pending.Hide();
        }

        private void aa_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter adp;
            DataTable dt;

            conn.Open();
            adp = new MySqlDataAdapter("SELECT * FROM dc_pr WHERE fname like '%" + aa.Text + "%' OR lname like '%"+ aa.Text + "%'", conn);

            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void button_view_Click(object sender, EventArgs e)
        {

        }

        private void date_due_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_accounts.Show();
            //button_paymenthist.Hide();


            string query = "SELECT * FROM dc_accounts where patient_id = " + label_id.Text + " GROUP BY app_id;";
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);



                DGV_accounts.DataSource = dt;
                DGV_accounts.RowHeadersVisible = false;

                DGV_accounts.Columns["acc_id"].Visible = false;
                DGV_accounts.Columns["app_id"].HeaderText = "Appointment ID";
                DGV_accounts.Columns["patient_id"].Visible = false;
                DGV_accounts.Columns["grandtotal"].HeaderText = "Grand Total";
                DGV_accounts.Columns["payment"].HeaderText = "Payments";
                DGV_accounts.Columns["balance"].HeaderText = "Balance";

                DGV_accounts.Sort(DGV_accounts.Columns[1], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }

            int sum = 0;
            for (int i = 0; i < DGV_accounts.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(DGV_accounts.Rows[i].Cells["balance"].Value);
            }
            text_balance.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_accounts.Hide();
        }

        private void DGV_accounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            chosen_balance.Text = DGV_accounts.Rows[e.RowIndex].Cells["balance"].Value.ToString();
            //DGV_accounts.Columns["balance"].HeaderText = "Balance";

            if(chosen_balance.Text == "0")
            {
                panel1.Hide();
            }
            else
            {
                panel1.Show();

            labelcheck.Hide();
            textBox_checknumber_cheque.Hide();
            DGV_paymenthist.Hide();
            label_bank.Hide();
            comboBox_bank.Hide();
            label_pdc.Hide();
            date_pdc.Hide();
            }
            
        }

        private void DGV_applist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string appid;
            appid = DGV_applist.Rows[e.RowIndex].Cells["appointment_id"].Value.ToString();

            string query = "SELECT payment_id, appointment_id, treatment , mop, type, toothinvolved, charges, grandtotal, payment_date, checknumber, amount_paid, payment_due, Postdatedcheck from payment WHERE appointment_id = '" + appid + "'";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();

            DGV_dentaloperation.DataSource = dt;
            DGV_dentaloperation.Columns["payment_id"].Visible = false;
            DGV_dentaloperation.Columns["appointment_id"].Visible = false;
            DGV_dentaloperation.Columns["treatment"].HeaderText = "Treatment";
            DGV_dentaloperation.Columns["mop"].Visible = false;
            DGV_dentaloperation.Columns["type"].Visible = false;
            DGV_dentaloperation.Columns["toothinvolved"].Visible = false;
            DGV_dentaloperation.Columns["charges"].HeaderText = "Charges";
            DGV_dentaloperation.Columns["grandtotal"].Visible = false;
            DGV_dentaloperation.Columns["payment_date"].Visible = false;
            DGV_dentaloperation.Columns["checknumber"].Visible = false;
            DGV_dentaloperation.Columns["amount_paid"].Visible = false;
            DGV_dentaloperation.Columns["payment_due"].Visible = false;
            DGV_dentaloperation.Columns["Postdatedcheck"].Visible = false;

            DGV_dentaloperation.Sort(DGV_dentaloperation.Columns[1], ListSortDirection.Ascending);
            DGV_dentaloperation.Sort(DGV_dentaloperation.Columns[0], ListSortDirection.Ascending);
            DGV_dentaloperation.Columns[2].Width = 200;

            try
            {
                label_treatment_id.Text = DGV_applist.Rows[e.RowIndex].Cells["payment_id"].Value.ToString();
                label_appointmentt_id.Text = DGV_applist.Rows[e.RowIndex].Cells["appointment_id"].Value.ToString();
                //textBox_treatmentt.Text = DGV_applist.Rows[e.RowIndex].Cells["treatment"].Value.ToString();
                textBox_mop.Text = DGV_applist.Rows[e.RowIndex].Cells["mop"].Value.ToString();
                textBox_type.Text = DGV_applist.Rows[e.RowIndex].Cells["type"].Value.ToString();
                //textBox_toothinv.Text = DGV_applist.Rows[e.RowIndex].Cells["toothinvolved"].Value.ToString();
                textBox_grandtotal.Text = DGV_applist.Rows[e.RowIndex].Cells["grandtotal"].Value.ToString();
                date_payment.Text = DGV_applist.Rows[e.RowIndex].Cells["payment_date"].Value.ToString();
                due_payment.Text = DGV_applist.Rows[e.RowIndex].Cells["payment_due"].Value.ToString();
                textBox_amount_paid.Text = DGV_applist.Rows[e.RowIndex].Cells["amount_paid"].Value.ToString();
                textBox_Checknumber.Text = DGV_applist.Rows[e.RowIndex].Cells["checknumber"].Value.ToString();
                dateTimePicker_pdc.Text = DGV_applist.Rows[e.RowIndex].Cells["Postdatedcheck"].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }



            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            panel1.Hide();
            if (textBox_grandtotal.Text == textBox_amount_paid.Text)
            {
                //button_add_payment.Hide();
            }
            else if (textBox_grandtotal.Text != textBox_amount_paid.Text)
            {
                //button_add_payment.Show();
            }


            if (textBox_mop.Text == "Cash")
            {
                checknumber.Hide();
                textBox_Checknumber.Hide();
                dateTimePicker_pdc.Hide();
                label__pdc.Hide();

                if (textBox_type.Text == "Full")
                {
                    //button_add_payment.Hide();
                    label_paymentdue.Hide();
                    due_payment.Hide();
                    button_paymenthist.Hide();
                    label_balance.Hide();
                    textBox_balance.Hide();

                }
                else
                {

                    button_paymenthist.Show();
                    label_paymentdue.Show();
                    due_payment.Show();
                    dateTimePicker_pdc.Hide();
                    label__pdc.Hide();
                    label_balance.Show();
                    textBox_balance.Show();

                }
            }
            else
            {


                if (textBox_type.Text == "Full")
                {
                    //button_add_payment.Hide();
                    button_paymenthist.Hide();
                    label_paymentdue.Hide();
                    due_payment.Hide();
                    dateTimePicker_pdc.Show();
                    label__pdc.Show();
                    label_balance.Hide();
                    textBox_balance.Hide();
                    checknumber.Show();
                    textBox_Checknumber.Show();


                }
                else
                {
                    //button_add_payment.Show();
                    button_paymenthist.Show();
                    dateTimePicker_pdc.Hide();
                    label__pdc.Hide();
                    label_balance.Show();
                    textBox_balance.Show();
                    label_paymentdue.Show();
                    due_payment.Show();

                }
            }


            if (textBox_amount_paid.Text == textBox_grandtotal.Text)
            {
                //button_add_payment.Hide();
                label_balance.Hide();
                textBox_balance.Hide();
            }
            else
            {
                label_balance.Show();
                textBox_balance.Show();
                int a = Convert.ToInt32(textBox_amount_paid.Text);

                int b = Convert.ToInt32(textBox_grandtotal.Text);

                int c = a - b;

                textBox_balance.Text = Convert.ToString(c);
            }

            if (textBox_type.Text == "Staggered")
            {
                textBox_Checknumber.Hide();
                checknumber.Hide();
            }



        }
    }
 }
