using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Accounting
{
    public partial class form_dentalchart : Form
    {
        MySqlConnection conn;
        public decimal all { get; set; }

        public form_dentalchart()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root;");
        }

        DataTable tablecheck = new DataTable();
        private void form_dentalchart_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(patn.Text))
            {
                //  button_create.Enabled = false; // <<== No double-quotes around false
            }
            else
            {
                // Don't forget to re-enable the button
                //  button_create.Enabled = true;
            }


            panel_pay.Hide();
            ptn_lst_pnl.Hide();
            panel_chart.Hide();
            groupBox_dccash.Hide();
            panel_pay2.Hide();
            panel_pay.Hide();
            panel_Check.Hide();
            loadAll();

            button_finalizecash.Hide();
            button_edit.Hide();
            panel_inv.Hide();
            panel_alert.Hide();
            button_finish.Hide();

            try
            {
                string selectQuery = "SELECT Treatment FROM dc_trtmnt";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //     treatment text comboBox1.Items.Add(reader.GetString("Treatment"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();


        }

        private void textBox_toothinv_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            var word = false;

            foreach (char symbol in textBox_toothinv.Text)
            {
                if (!char.IsLetter(symbol))
                {
                    word = false;
                    continue;
                }

                if (word)
                {
                    continue;
                }

                count++;
                word = true;
            }

            String cnt = count.ToString();
            toothcnt.Text = cnt;



            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
        }

        private void dpt2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dpt1_ValueChanged(object sender, EventArgs e)
        {
            DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void button_Addcheck_Click(object sender, EventArgs e)
        {
            // combobox na to cash check full stag


            //panel_pay.Show();
            groupBox_dccash.Show();
            panel_chart.Hide();

            treatmentcash.Text = textBox_trtment1.Text;
            toothinvcash.Text = textBox_toothinv.Text;
            chargescash.Text = textBox_Charges.Text;
            grandtotalcash.Text = textBox_grandtotal.Text;

        }


        private void resetbut_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button_finalizecash_Click(object sender, EventArgs e)
        {
            

            for (int y = 0; y < summary_grd.Rows.Count; y++)
            {
                string treatment = summary_grd.Rows[y].Cells[4].Value.ToString();
                string tooth = summary_grd.Rows[y].Cells[5].Value.ToString();
                string charges = summary_grd.Rows[y].Cells[7].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Do you wish to finalize your payment?", "Payment Finalization", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (comboBox_Type.Text == "Staggered")
                    {
                        string querycash = "INSERT INTO payment_line_cashcheque(appointment_id, cash_paid, date, checknumber, bank) VALUES(@aid, @paid, @date, @check, @bank)";

                        MySqlConnection conn;
                        conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root;");

                        conn.Open();
                        MySqlCommand cmd1 = new MySqlCommand(querycash, conn);
                        cmd1.Parameters.AddWithValue("@aid", appid.Text);
                        cmd1.Parameters.AddWithValue("@paid", textBox_total_paid.Text);
                        cmd1.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));
                        cmd1.Parameters.AddWithValue("@check", textBox_Checknumber.Text);
                        cmd1.Parameters.AddWithValue("@bank", comboBox_bank.Text);

                        MySqlDataAdapter adp0 = new MySqlDataAdapter(cmd1);
                        cmd1.ExecuteNonQuery();
                    }
                    //string querycash = "INSERT INTO payment(appointment_id, patient_id, checknumber, amount_paid, treatment, mop, type, toothinvolved, charges, grandtotal, payment_due, payment_date) VALUES ('" + appid.Text + "','" + patid.Text + "','" + "','" + textBox_Checknumber.Text + "','" + textBox_total_paid.Text + "','" + treatment + "','" + comboBox_mode.Text + "','" + comboBox_Type.Text + "','" + tooth + "','" + charges + "','" + amnt_due.Text + "','" + dptdue.Value.ToString("yyyy-MM-dd") + "','" + scd_dte.Value.ToString("yyyy-MM-dd") + "')";

                    string querycash1 = "INSERT INTO payment(appointment_id, patient_id, checknumber, amount_paid, treatment, mop, type, toothinvolved, charges, grandtotal, payment_due, payment_date, bank) VALUES(@aid, @pid, @check, @paid, @treatment, @mop, @pt, @tooth, @charges, @grand, @due, @date, @bank)";

                    MySqlConnection conn1;
                    conn1 = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root;");

                    conn1.Open();
                    MySqlCommand cmd = new MySqlCommand(querycash1, conn1);
                    cmd.Parameters.AddWithValue("@aid", appid.Text);
                    cmd.Parameters.AddWithValue("@pid", patid.Text);
                    cmd.Parameters.AddWithValue("@check", textBox_Checknumber.Text);
                    cmd.Parameters.AddWithValue("@paid", textBox_total_paid.Text);
                    cmd.Parameters.AddWithValue("@treatment", treatment);
                    cmd.Parameters.AddWithValue("@mop", comboBox_mode.Text);
                    cmd.Parameters.AddWithValue("@pt", comboBox_Type.Text);
                    cmd.Parameters.AddWithValue("@tooth", tooth);
                    cmd.Parameters.AddWithValue("@charges", charges);
                    cmd.Parameters.AddWithValue("@grand", charges);
                    cmd.Parameters.AddWithValue("@due", dptdue.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@bank",comboBox_bank.Text);


                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    


                   string update = "UPDATE dc_appnt SET pay_status = 'Paid' WHERE app_id = '" + appid.Text + "'";
                   MySqlCommand comm2 = new MySqlCommand(update, conn1);
                   MySqlDataAdapter adp1 = new MySqlDataAdapter(comm2);
                   comm2.ExecuteNonQuery();

                   string update1 = "UPDATE dc_tooth SET status = 'Paid' WHERE app_id = '" + appid.Text + "'";
                   MySqlCommand comm3 = new MySqlCommand(update1, conn1);
                   MySqlDataAdapter adp2 = new MySqlDataAdapter(comm3);
                   comm3.ExecuteNonQuery();
                   conn1.Close();

                    /* string paymeny = "INSERT INTO payment_line_cashcheque(payment_id, appointment_id, cash_paid, date, checknumber, bank) VALUES('" + label_treatment_id.Text + "', '" + label_appointmentt_id.Text + "', '" + textBox_amount_cashcheque.Text + "', CURDATE(), '" + textBox_Checknumber.Text + "', '" + comboBox_bank.Text + "'); ";
                     MySqlCommand comm4 = new MySqlCommand(update1, conn1);
                     MySqlDataAdapter adp4 = new MySqlDataAdapter(comm4);
                     comm3.ExecuteNonQuery();
                     conn1.Close();
                     */
                    MessageBox.Show("Finished Payment!", "Appointment Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            
            }

            groupBox_dccash.Hide();
            button_finalizecash.Hide();
            button_edit.Hide();
            panel_pay2.Hide();

            reset();
            reset2();
            resetcheck();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {

        }



        public void reset()
        {
            U1.Checked = false;
            U2.Checked = false;
            U3.Checked = false;
            U4.Checked = false;
            U5.Checked = false;
            U6.Checked = false;
            U7.Checked = false;
            U8.Checked = false;
            U9.Checked = false;
            U10.Checked = false;
            U11.Checked = false;
            U12.Checked = false;
            U13.Checked = false;
            U14.Checked = false;
            U15.Checked = false;
            U16.Checked = false;
            L17.Checked = false;
            L18.Checked = false;
            L19.Checked = false;
            L20.Checked = false;
            L21.Checked = false;
            L22.Checked = false;
            L23.Checked = false;
            L24.Checked = false;
            L25.Checked = false;
            L26.Checked = false;
            L27.Checked = false;
            L28.Checked = false;
            L29.Checked = false;
            L30.Checked = false;
            L31.Checked = false;
            L32.Checked = false;


            textBox_toothinv.Text = "";

            textBox_Checknumber.Text = "";
            dptdue.Text = "";
            scd_dte.Text = "";
            patid.Text = "";
            appid.Text = "";
            patn.Text = "";
            ptn_nme.Text = "";


        }
        public void resetcheck()
        {
            U1.Checked = false;
            U2.Checked = false;
            U3.Checked = false;
            U4.Checked = false;
            U5.Checked = false;
            U6.Checked = false;
            U7.Checked = false;
            U8.Checked = false;
            U9.Checked = false;
            U10.Checked = false;
            U11.Checked = false;
            U12.Checked = false;
            U13.Checked = false;
            U14.Checked = false;
            U15.Checked = false;
            U16.Checked = false;
            L17.Checked = false;
            L18.Checked = false;
            L19.Checked = false;
            L20.Checked = false;
            L21.Checked = false;
            L22.Checked = false;
            L23.Checked = false;
            L24.Checked = false;
            L25.Checked = false;
            L26.Checked = false;
            L27.Checked = false;
            L28.Checked = false;
            L29.Checked = false;
            L30.Checked = false;
            L31.Checked = false;
            L32.Checked = false;
        }


        public void reset2()
        {

            textBox_Checknumber.Text = "";
            //appid.Text = "";
           // patid.Text = "";
           // patn.Text = "";
            //trt_grd.DataSource = null;
            //trt_grd.Rows.Clear();
            textBox_trtment1.Text = "";
            textBox_toothinv.Text = "";
            toothcnt.Text = "";
            textBox_Charges.Text = "";
            textBox_grandtotal.Text = "";
            comboBox_mode.Text = "";
            comboBox_Type.Text = "";
            dptdue.Text = "";
            textBox_Checknumber.Text = "";
            textBox_amntpaid.Text = "";
            textBox_change.Text = "";
            treatment_id.Text = "";
            trt_chart.Text = "";
            scd_id.Text = "";
            sched_id1.Text = "";
            pr_id.Text = "";
            treatmentcash.Text = "";
            toothinvcash.Text = "";
            chargescash.Text = "";
            grandtotalcash.Text = "";
            textBox_total_paid.Text = "";




        }


        private void treatprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void U1_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U2_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U3_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U4_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U5_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U6_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U7_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U8_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U9_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U10_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U11_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U12_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U13_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U14_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U15_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void U16_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L17_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L18_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L19_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L20_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L21_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L22_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L23_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L24_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L25_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L26_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L27_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L28_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L29_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L30_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L31_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void L32_CheckedChanged(object sender, EventArgs e)
        {
            String ClientString;
            ClientString = String.Empty;
            if (U1.Checked)
                ClientString = U1.Name;
            if (U2.Checked)
                ClientString += " " + U2.Name;
            if (U3.Checked)
                ClientString += " " + U3.Name;
            if (U4.Checked)
                ClientString += " " + U4.Name;
            if (U5.Checked)
                ClientString += " " + U5.Name;
            if (U6.Checked)
                ClientString += " " + U6.Name;
            if (U7.Checked)
                ClientString += " " + U7.Name;
            if (U8.Checked)
                ClientString += " " + U8.Name;
            if (U9.Checked)
                ClientString += " " + U9.Name;
            if (U10.Checked)
                ClientString += " " + U10.Name;
            if (U11.Checked)
                ClientString += " " + U11.Name;
            if (U12.Checked)
                ClientString += " " + U12.Name;
            if (U13.Checked)
                ClientString += " " + U13.Name;
            if (U14.Checked)
                ClientString += " " + U14.Name;
            if (U15.Checked)
                ClientString += " " + U15.Name;
            if (U16.Checked)
                ClientString += " " + U16.Name;
            if (L32.Checked)
                ClientString += " " + L32.Name;
            if (L31.Checked)
                ClientString += " " + L31.Name;
            if (L30.Checked)
                ClientString += " " + L30.Name;
            if (L29.Checked)
                ClientString += " " + L29.Name;
            if (L28.Checked)
                ClientString += " " + L28.Name;
            if (L27.Checked)
                ClientString += " " + L27.Name;
            if (L26.Checked)
                ClientString += " " + L26.Name;
            if (L25.Checked)
                ClientString += " " + L25.Name;
            if (L24.Checked)
                ClientString += " " + L24.Name;
            if (L23.Checked)
                ClientString += " " + L23.Name;
            if (L22.Checked)
                ClientString += " " + L22.Name;
            if (L21.Checked)
                ClientString += " " + L21.Name;
            if (L20.Checked)
                ClientString += " " + L20.Name;
            if (L19.Checked)
                ClientString += " " + L19.Name;
            if (L18.Checked)
                ClientString += " " + L18.Name;
            if (L17.Checked)
                ClientString += " " + L17.Name;

            textBox_toothinv.Text = ClientString;
            Int32 val1 = Convert.ToInt32(textBox_Charges.Text);
            Int32 val2 = Convert.ToInt32(toothcnt.Text);
            Int32 val3 = val1 * val2;
            textBox_grandtotal.Text = Convert.ToString(val3);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ptn_lst_pnl.Show();

        }



        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void ptn_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void loadTreats()
        {
            string joiners = "SELECT s.*, t.* FROM fdc1.dc_sched_line s LEFT JOIN fdc1.dc_trtmnt t ON s.trt_id = t.trt_id WHERE s.sched_id = '" + scd_id.Text + "' AND s.status = 'Chosen'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(joiners, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            trt_grd.DataSource = dt;
            trt_grd.RowHeadersVisible = false;
            trt_grd.Columns["line_id"].Visible = false;
            trt_grd.Columns["sched_id"].Visible = false;
            trt_grd.Columns["trt_id"].Visible = false;
            trt_grd.Columns["status"].Visible = false;
            trt_grd.Columns["trt_id1"].Visible = false;
            trt_grd.Columns["Price"].Visible = false;
            trt_grd.Columns["status1"].Visible = false;
            trt_grd.Columns["Treatment"].HeaderText = "Treatment";
            trt_grd.Columns["chart"].Visible = false;
        }

        private void ptn_grid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            appid.Text = ptn_grid.Rows[e.RowIndex].Cells["app_id"].Value.ToString();
            patid.Text = ptn_grid.Rows[e.RowIndex].Cells["pr_id"].Value.ToString();
            patn.Text = ptn_grid.Rows[e.RowIndex].Cells["Patient"].Value.ToString();
            scd_id.Text = ptn_grid.Rows[e.RowIndex].Cells["sched_id"].Value.ToString();
            scd_dte.Text = ptn_grid.Rows[e.RowIndex].Cells["sched_date"].Value.ToString();


            loadTreats();
            ptn_lst_pnl.Hide();


        }

        public void loadAll()
        {
            string datetoday = DateTime.Today.ToString("yyyy-MM-dd");

            string joiners = "SELECT p.name AS 'Patient', d.name AS 'Doctor', a.* , s.* FROM fdc1.dc_appnt a LEFT JOIN dc_pr p ON p.pr_id = a.pr_id LEFT JOIN dc_pr d ON d.pr_id = a.dct_id LEFT JOIN dc_sched s ON s.sched_id = a.sched_id WHERE s.status = 'Appointed' AND (a.status = 'Ongoing' OR a.status = 'Finished') AND a.pay_status = 'Unpaid' ORDER BY s.sched_date";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(joiners, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            ptn_grid.DataSource = dt;
            ptn_grid.RowHeadersVisible = false;
            ptn_grid.Columns["Patient"].HeaderText = "Patient's Name";
            ptn_grid.Columns["app_id"].Visible = false;
            ptn_grid.Columns["status"].HeaderText = "Status";
            ptn_grid.Columns["sched_id"].Visible = false;
            ptn_grid.Columns["pr_id"].Visible = false;
            ptn_grid.Columns["sched_id1"].Visible = false;
            ptn_grid.Columns["pr_id1"].Visible = false;
            ptn_grid.Columns["dct_id"].Visible = false;
            ptn_grid.Columns["dct_id1"].Visible = false;
            ptn_grid.Columns["status1"].Visible = false;
            ptn_grid.Columns["sched_date"].HeaderText = "Schedule Date";
            ptn_grid.Columns["start_time"].HeaderText = "Start Time";
            ptn_grid.Columns["end_time"].HeaderText = "End Time";
            ptn_grid.Columns["Doctor"].HeaderText = "Doctor In-Charge";
            ptn_grid.Columns["sched_start"].Visible = false;
            ptn_grid.Columns["sched_end"].Visible = false;
            ptn_grid.Columns["shour"].Visible = false;
            ptn_grid.Columns["sminute"].Visible = false;
            ptn_grid.Columns["sday"].Visible = false;
            ptn_grid.Columns["ehour"].Visible = false;
            ptn_grid.Columns["eminute"].Visible = false;
            ptn_grid.Columns["eday"].Visible = false;
            ptn_grid.Columns["pay_status"].HeaderText = "Payment Status";
            ptn_grid.Columns["tooth_upd"].HeaderText = "Tooth Chart Update";
        }

        private void closeb_Click_1(object sender, EventArgs e)
        {
            ptn_lst_pnl.Hide();
        }

        private void ptn_nme_TextChanged_1(object sender, EventArgs e)
        {
            MySqlDataAdapter adp;
            DataTable dt;

            conn.Open();
            adp = new MySqlDataAdapter("SELECT p.name AS 'Patient', d.name AS 'Doctor', a.* , s.* FROM fdc1.dc_appnt a LEFT JOIN dc_pr p ON p.pr_id = a.pr_id LEFT JOIN dc_pr d ON d.pr_id = a.dct_id LEFT JOIN dc_sched s ON s.sched_id = a.sched_id WHERE a.status = 'Finished' ORDER BY s.sched_date", conn);
            dt = new DataTable();
            adp.Fill(dt);
            ptn_grid.DataSource = dt;
            conn.Close();
        }

        private void ptn_add_Click(object sender, EventArgs e)
        {

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ptn_lst_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            for (int y = 0; y < summary_grd.Rows.Count; y++)
            {
                string treatment = summary_grd.Rows[y].Cells[4].Value.ToString();
                string tooth = summary_grd.Rows[y].Cells[5].Value.ToString();
                string charges = summary_grd.Rows[y].Cells[7].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Do you wish to finalize your payment?", "Payment Finalization", MessageBoxButtons.YesNo);

                MySqlConnection conn1;
                conn1 = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root;");
                if (dialogResult == DialogResult.Yes)
                {
                    if (comboBox_mode.Text == "Cash" && comboBox_Type.Text == "Full")
                    {
                        //string querycash = "INSERT INTO payment(appointment_id, patient_id, checknumber, amount_paid, treatment, mop, type, toothinvolved, charges, grandtotal, payment_due, payment_date) VALUES ('" + appid.Text + "','" + patid.Text + "','" + "','" + textBox_Checknumber.Text + "','" + textBox_total_paid.Text + "','" + treatment + "','" + comboBox_mode.Text + "','" + comboBox_Type.Text + "','" + tooth + "','" + charges + "','" + amnt_due.Text + "','" + dptdue.Value.ToString("yyyy-MM-dd") + "','" + scd_dte.Value.ToString("yyyy-MM-dd") + "')";
                        string querycash1 = "INSERT INTO payment(appointment_id, patient_id, amount_paid, treatment, mop, type, toothinvolved, charges, grandtotal, payment_date) VALUES(@aid, @pid, @paid, @treatment, @mop, @pt, @tooth, @charges, @grand, @date)";

                        conn1.Open();
                        MySqlCommand cmd = new MySqlCommand(querycash1, conn1);
                        cmd.Parameters.AddWithValue("@aid", appid.Text);
                        cmd.Parameters.AddWithValue("@pid", patid.Text);
                        //cmd.Parameters.AddWithValue("@check", textBox_Checknumber.Text);
                        cmd.Parameters.AddWithValue("@paid", textBox_amntpaid.Text);
                        cmd.Parameters.AddWithValue("@treatment", treatment);
                        cmd.Parameters.AddWithValue("@mop", comboBox_mode.Text);
                        cmd.Parameters.AddWithValue("@pt", comboBox_Type.Text);
                        cmd.Parameters.AddWithValue("@tooth", tooth);
                        cmd.Parameters.AddWithValue("@charges", charges);
                        cmd.Parameters.AddWithValue("@grand", amnt_due.Text);
                        //cmd.Parameters.AddWithValue("@due", dptdue.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));
                        //cmd.Parameters.AddWithValue("@bank", comboBox_bank.Text);
                        //cmd.Parameters.AddWithValue("@datepdc", date_pdc.Value.ToString("yyyy-MM-dd"));

                        try
                        {
                            foreach (SqlParameter Parameter in cmd.Parameters)
                            {
                                if (Parameter.Value == null)
                                {
                                    Parameter.Value = DBNull.Value;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0} Exception caught.", ex);

                        }

                        //////////////////////
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                        conn1.Close();
                    }
                    else if (comboBox_mode.Text == "Check" && comboBox_Type.Text == "Full")
                    {
                        string querycash1 = "INSERT INTO payment(appointment_id, patient_id, checknumber, amount_paid, treatment, mop, type, toothinvolved, charges, grandtotal, payment_date, bank, Postdatedcheck) VALUES(@aid, @pid, @check, @paid, @treatment, @mop, @pt, @tooth, @charges, @grand, @date, @bank, @datepdc)";

                        conn1.Open();
                        MySqlCommand cmd = new MySqlCommand(querycash1, conn1);
                        cmd.Parameters.AddWithValue("@aid", appid.Text);
                        cmd.Parameters.AddWithValue("@pid", patid.Text);
                        cmd.Parameters.AddWithValue("@check", textBox_Checknumber.Text);
                        cmd.Parameters.AddWithValue("@paid", textBox_amntpaid.Text);
                        cmd.Parameters.AddWithValue("@treatment", treatment);
                        cmd.Parameters.AddWithValue("@mop", comboBox_mode.Text);
                        cmd.Parameters.AddWithValue("@pt", comboBox_Type.Text);
                        cmd.Parameters.AddWithValue("@tooth", tooth);
                        cmd.Parameters.AddWithValue("@charges", charges);
                        cmd.Parameters.AddWithValue("@grand", amnt_due.Text);
                        //cmd.Parameters.AddWithValue("@due", dptdue.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@bank", comboBox_bank.Text);
                        cmd.Parameters.AddWithValue("@datepdc", date_pdc.Value.ToString("yyyy-MM-dd"));

                        try
                        {
                            foreach (SqlParameter Parameter in cmd.Parameters)
                            {
                                if (Parameter.Value == null)
                                {
                                    Parameter.Value = DBNull.Value;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0} Exception caught.", ex);

                        }

                        //////////////
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                        conn1.Close();
                    }
                    else if (comboBox_mode.Text == "Cash" && comboBox_Type.Text == "Staggered")
                    {
                        //string querycash = "INSERT INTO payment(appointment_id, patient_id, checknumber, amount_paid, treatment, mop, type, toothinvolved, charges, grandtotal, payment_due, payment_date) VALUES ('" + appid.Text + "','" + patid.Text + "','" + "','" + textBox_Checknumber.Text + "','" + textBox_total_paid.Text + "','" + treatment + "','" + comboBox_mode.Text + "','" + comboBox_Type.Text + "','" + tooth + "','" + charges + "','" + amnt_due.Text + "','" + dptdue.Value.ToString("yyyy-MM-dd") + "','" + scd_dte.Value.ToString("yyyy-MM-dd") + "')";
                        string querycash1 = "INSERT INTO payment(appointment_id, patient_id, amount_paid, treatment, mop, type, toothinvolved, charges, grandtotal,payment_due, payment_date) VALUES(@aid, @pid, @paid, @treatment, @mop, @pt, @tooth, @charges, @grand, @due, @date)";

                        conn1.Open();
                        MySqlCommand cmd = new MySqlCommand(querycash1, conn1);
                        cmd.Parameters.AddWithValue("@aid", appid.Text);
                        cmd.Parameters.AddWithValue("@pid", patid.Text);
                        //cmd.Parameters.AddWithValue("@check", textBox_Checknumber.Text);
                        cmd.Parameters.AddWithValue("@paid", textBox_amntpaid.Text);
                        cmd.Parameters.AddWithValue("@treatment", treatment);
                        cmd.Parameters.AddWithValue("@mop", comboBox_mode.Text);
                        cmd.Parameters.AddWithValue("@pt", comboBox_Type.Text);
                        cmd.Parameters.AddWithValue("@tooth", tooth);
                        cmd.Parameters.AddWithValue("@charges", charges);
                        cmd.Parameters.AddWithValue("@grand", amnt_due.Text);
                        cmd.Parameters.AddWithValue("@due", dptdue.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));
                        //cmd.Parameters.AddWithValue("@bank", comboBox_bank.Text);
                        //cmd.Parameters.AddWithValue("@datepdc", date_pdc.Value.ToString("yyyy-MM-dd"));

                        try
                        {
                            foreach (SqlParameter Parameter in cmd.Parameters)
                            {
                                if (Parameter.Value == null)
                                {
                                    Parameter.Value = DBNull.Value;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0} Exception caught.", ex);

                        }

                        //////////////////////
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                        conn1.Close();
                    }
                    else if (comboBox_mode.Text == "Check" && comboBox_Type.Text == "Staggered")
                    {
                        string querycash1 = "INSERT INTO payment(appointment_id, patient_id, checknumber, amount_paid, treatment, mop, type, toothinvolved, charges, grandtotal, payment_due, payment_date, bank, Postdatedcheck) VALUES(@aid, @pid, @check, @paid, @treatment, @mop, @pt, @tooth, @charges, @grand, @due, @date, @bank, @datepdc)";

                        conn1.Open();
                        MySqlCommand cmd = new MySqlCommand(querycash1, conn1);
                        cmd.Parameters.AddWithValue("@aid", appid.Text);
                        cmd.Parameters.AddWithValue("@pid", patid.Text);
                        cmd.Parameters.AddWithValue("@check", textBox_Checknumber.Text);
                        cmd.Parameters.AddWithValue("@paid", textBox_amntpaid.Text);
                        cmd.Parameters.AddWithValue("@treatment", treatment);
                        cmd.Parameters.AddWithValue("@mop", comboBox_mode.Text);
                        cmd.Parameters.AddWithValue("@pt", comboBox_Type.Text);
                        cmd.Parameters.AddWithValue("@tooth", tooth);
                        cmd.Parameters.AddWithValue("@charges", charges);
                        cmd.Parameters.AddWithValue("@grand", amnt_due.Text);
                        cmd.Parameters.AddWithValue("@due", dptdue.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@bank", comboBox_bank.Text);
                        cmd.Parameters.AddWithValue("@datepdc", date_pdc.Value.ToString("yyyy-MM-dd"));

                        try
                        {
                            foreach (SqlParameter Parameter in cmd.Parameters)
                            {
                                if (Parameter.Value == null)
                                {
                                    Parameter.Value = DBNull.Value;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0} Exception caught.", ex);

                        }

                        //////////////
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                        conn1.Close();
                    }



                    String queryy = "SELECT last_insert_id() FROM payment";
                    MySqlCommand commmm = new MySqlCommand(queryy, conn);
                    conn.Open();


                    MySqlDataReader r = commmm.ExecuteReader();
                    while (r.Read())
                    {
                        label_unq.Text = (r["last_insert_id()"].ToString());

                    }
                    r.Close();

                    commmm.ExecuteNonQuery();
                    conn.Close();

                    /////////////////////////////
                    if (comboBox_mode.Text == "Check" && comboBox_Type.Text == "Staggered")
                    {
                        MySqlConnection conn;
                        conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root;");

                        string querycash = "INSERT INTO payment_line_cashcheque(appointment_id, payment_id, cash_paid, date, checknumber, bank,plc_postdatedcheck) VALUES(@aid,@pay, @paid, @date, @check, @bank, @datepdc)";

                        conn.Open();
                        MySqlCommand cmd1 = new MySqlCommand(querycash, conn);
                        cmd1.Parameters.AddWithValue("@aid", appid.Text);
                        cmd1.Parameters.AddWithValue("@pay", label_unq.Text);
                        cmd1.Parameters.AddWithValue("@paid", textBox_amntpaid.Text);
                        cmd1.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));
                        cmd1.Parameters.AddWithValue("@check", textBox_Checknumber.Text);
                        cmd1.Parameters.AddWithValue("@bank", comboBox_bank.Text);
                        cmd1.Parameters.AddWithValue("@datepdc", date_pdc.Value.ToString("yyyy-MM-dd"));

                        MySqlDataAdapter adp0 = new MySqlDataAdapter(cmd1);
                        cmd1.ExecuteNonQuery();
                    }
                    else if (comboBox_mode.Text == "Cash" && comboBox_Type.Text == "Staggered")
                    {
                        MySqlConnection conn;
                        conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root;");

                        string querycash = "INSERT INTO payment_line_cashcheque(appointment_id, payment_id, cash_paid, date) VALUES(@aid,@pay, @paid, @date)";
                        try
                        {
                        conn.Open();
                        MySqlCommand cmd1 = new MySqlCommand(querycash, conn);
                        cmd1.Parameters.AddWithValue("@aid", appid.Text);
                        cmd1.Parameters.AddWithValue("@pay", label_unq.Text);
                        cmd1.Parameters.AddWithValue("@paid", textBox_amntpaid.Text);
                        cmd1.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));
                        //cmd1.Parameters.AddWithValue("@check", textBox_Checknumber.Text);
                        //cmd1.Parameters.AddWithValue("@bank", comboBox_bank.Text);
                        //cmd1.Parameters.AddWithValue("@datepdc", date_pdc.Value.ToString("yyyy-MM-dd"));

                        MySqlDataAdapter adp0 = new MySqlDataAdapter(cmd1);
                        cmd1.ExecuteNonQuery();

                        
                            foreach (SqlParameter Parameter in cmd1.Parameters)
                            {
                                if (Parameter.Value == null)
                                {
                                    Parameter.Value = DBNull.Value;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0} Exception caught.", ex);

                        }
                    }

                    ////////////////
                    string addhis = "SELECT * FROM dc_accounts WHERE app_id = '" + appid.Text + "'";
                    conn.Open();
                    MySqlCommand addhs = new MySqlCommand(addhis, conn);
                    MySqlDataAdapter sds = new MySqlDataAdapter(addhs);
                    conn.Close();
                    DataTable adhs = new DataTable();
                    sds.Fill(adhs);

                    if (adhs.Rows.Count > 0)
                    {
                        MessageBox.Show("Payment is already inside the history. Thank you.", "Record History", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string querycashhist = "INSERT INTO payment_hist(payment_appid, payment_id, name, payment_amount, payment_date) VALUES(@aid, @pid, @pn, @paid, @date)";
                        MySqlConnection conn2;
                        conn2 = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root;");

                        conn2.Open();
                        MySqlCommand cmdd = new MySqlCommand(querycashhist, conn2);
                        cmdd.Parameters.AddWithValue("@aid", appid.Text);
                        cmdd.Parameters.AddWithValue("@pid", patid.Text);
                        cmdd.Parameters.AddWithValue("@pn", patn.Text);
                        cmdd.Parameters.AddWithValue("@paid", textBox_amntpaid.Text);
                        cmdd.Parameters.AddWithValue("@date", scd_dte.Value.ToString("yyyy-MM-dd"));

                        MySqlDataAdapter adppp = new MySqlDataAdapter(cmdd);
                        cmdd.ExecuteNonQuery();
                        conn2.Close();
                    }

                    /////////////////
                    string addacc = "SELECT * FROM dc_accounts WHERE app_id = '" + appid.Text + "'";
                    conn.Open();
                    MySqlCommand accad = new MySqlCommand(addacc, conn);
                    MySqlDataAdapter adps = new MySqlDataAdapter(accad);
                    conn.Close();
                    DataTable addac = new DataTable();
                    adps.Fill(addac);

                    if (addac.Rows.Count > 0)
                    {
                        MessageBox.Show("Payment has already been recorded. Thank you.", "Record Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        string accounts = "INSERT INTO dc_accounts(app_id, patient_id, grandtotal, payment, balance) VALUES(@aid, @pid, @grand, @paid, @balance)";
                        MySqlConnection conn3;
                        conn3 = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;pwd=root;");

                        conn3.Open();
                        MySqlCommand cmd01 = new MySqlCommand(accounts, conn3);
                        cmd01.Parameters.AddWithValue("@aid", appid.Text);
                        cmd01.Parameters.AddWithValue("@pid", patid.Text);
                        cmd01.Parameters.AddWithValue("@paid", textBox_amntpaid.Text);
                        cmd01.Parameters.AddWithValue("@grand", amnt_due.Text);
                        cmd01.Parameters.AddWithValue("@balance", balance.Text);

                        MySqlDataAdapter adp3 = new MySqlDataAdapter(cmd01);
                        cmd01.ExecuteNonQuery();
                        conn3.Close();
                    }

                    /////////////////
                    conn1.Open();
                    string update = "UPDATE dc_appnt SET pay_status = 'Paid' WHERE app_id = '" + appid.Text + "'";
                    MySqlCommand comm2 = new MySqlCommand(update, conn1);
                    MySqlDataAdapter adp1 = new MySqlDataAdapter(comm2);
                    comm2.ExecuteNonQuery();
                    conn1.Close();

                    conn1.Open();
                    string update1 = "UPDATE dc_tooth SET status = 'Paid' WHERE app_id = '" + appid.Text + "'";
                    MySqlCommand comm3 = new MySqlCommand(update1, conn1);
                    MySqlDataAdapter adp2 = new MySqlDataAdapter(comm3);
                    comm3.ExecuteNonQuery();
                    conn1.Close();

                    MessageBox.Show("Finished Payment!", "Appointment Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //////////////////////

                }

            }
            reset2();
            button_finish.Show();
        }

        private void patid_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox_total_paid.Text = textBox_amntpaid.Text;

            if (trt_chart.Text == "2")
            {
                string drd = "SELECT * FROM dc_tooth WHERE pr_id = '" + patid.Text + "' AND app_id = '" + appid.Text + "' AND sched_id = '" + scd_id.Text + "' AND treatment = '" + textBox_trtment1.Text + "'";
                conn.Open();
                MySqlCommand comm4 = new MySqlCommand(drd, conn);
                MySqlDataAdapter asd = new MySqlDataAdapter(comm4);
                conn.Close();
                DataTable dt = new DataTable();
                asd.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to enter the same treatment and price?", "Duplicate Entry", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string ins = "INSERT INTO dc_tooth(pr_id, app_id, sched_id, treatment, tooth_inv, quantity, charges, total, status) VALUES('" + patid.Text + "', '" + appid.Text + "', '" + scd_id.Text + "', '" + textBox_trtment1.Text + "', '" + toothinvcash.Text + "', '" + "0" + "', '" + chargescash.Text + "', '" + textBox_grandtotal.Text + "', '" + "Unpaid" + "')";
                        conn.Open();
                        MySqlCommand comm3 = new MySqlCommand(ins, conn);
                        comm3.ExecuteNonQuery();
                        conn.Close();

                    }
                }
                else
                {
                    string ins = "INSERT INTO dc_tooth(pr_id, app_id, sched_id, treatment, tooth_inv, quantity, charges, total, status) VALUES('" + patid.Text + "', '" + appid.Text + "', '" + scd_id.Text + "', '" + textBox_trtment1.Text + "', '" + toothinvcash.Text + "', '" + "0" + "', '" + chargescash.Text + "', '" + textBox_grandtotal.Text + "', '" + "Unpaid" + "')";
                    conn.Open();
                    MySqlCommand run = new MySqlCommand(ins, conn);
                    run.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {
                if (trt_chart.Text == "1")
                {
                    string ins = "INSERT INTO dc_tooth(pr_id, app_id, sched_id, treatment, tooth_inv, quantity, charges, total, status) VALUES('" + patid.Text + "', '" + appid.Text + "', '" + scd_id.Text + "', '" + textBox_trtment1.Text + "', '" + toothinvcash.Text + "', '" + toothcnt.Text + "', '" + chargescash.Text + "', '" + textBox_grandtotal.Text + "', '" + "Unpaid" + "')";
                    conn.Open();
                    MySqlCommand comm3 = new MySqlCommand(ins, conn);
                    comm3.ExecuteNonQuery();
                    conn.Close();

                }
            }
            
            loadSummary();
        }
                

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void L_Click(object sender, EventArgs e)
        {

        }

        private void trt_grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_mode.Text == "Check")
              {
                textBox_Checknumber.Show();
                checknumber.Show();
                comboBox_bank.Show();
                label_bank.Show();
                label_pdc.Show();
                date_pdc.Show();
            }else
            {
                textBox_Checknumber.Hide();
                checknumber.Hide();
                comboBox_bank.Hide();
                label_bank.Hide();
                label_pdc.Hide();
                date_pdc.Hide();

            }


        }

        private void panel_pay_Paint(object sender, PaintEventArgs e)
        {
            if (comboBox_mode.Text == "Cash" && comboBox_Type.Text == "Staggered")
            {
                dptdue.Enabled = true;
                paymentdue.Enabled = true;
                textBox_Checknumber.Enabled = false;
                checknumber.Enabled = false;
            }

            else if (comboBox_mode.Text == "Check"  && comboBox_Type.Text == "Staggered")
            {
                dptdue.Enabled = true;
                paymentdue.Enabled = true;
                textBox_Checknumber.Enabled = true;
                checknumber.Enabled = true;

            }
            else if (comboBox_mode.Text == "Check" && comboBox_Type.Text == "Full")
            {
                dptdue.Enabled = false;
                paymentdue.Enabled = false;
                textBox_Checknumber.Enabled = true;
                checknumber.Enabled = true;
            }
            else if (comboBox_mode.Text == "Cash" && comboBox_Type.Text == "Full")
            {
                dptdue.Enabled = false;
                paymentdue.Enabled = false;
                textBox_Checknumber.Enabled = false;
                checknumber.Enabled = false;
            }
                


        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void treatmentcash_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if(textBox_amntpaid.Text == "")
            {
                MessageBox.Show("Please imput amount paid.", "Amount Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                textBox_total_paid.Text = textBox_amntpaid.Text;
                

            }

            button_finalizecash.Show();

        }

        static int change = 0, amp, result;

        private void textBox_amntpaid_TextChanged(object sender, EventArgs e)
        {

            //int amp = 0;
            //if (int.TryParse(textBox_amntpaid.Text, out amp)) ;
            //int change = 0 - amp;
            //textBox_change.Text = change;
            //if (int.TryParse(textBox_amntpaid.Text, out change));


            if (Int32.TryParse(textBox_amntpaid.Text, out amp))
            {
                textBox_change.Text = (change + amp - this.all).ToString();
            }

            try
            {
                int total;
                amp = int.Parse(textBox_amntpaid.Text);
                total = int.Parse(amnt_due.Text);
                change = 0;
                result = amp - total;
                balance.Text = result.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }

            private void textBox_change_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel_Check_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trt_grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel_chart.Show();
            panel_Check.Show();
            groupBox_dccash.Hide();
            panel_pay2.Hide();
            panel_pay.Enabled = false;
            button_finalizecash.Hide();


            textBox_trtment1.Text = trt_grd.Rows[e.RowIndex].Cells["Treatment"].Value.ToString();
            textBox_Charges.Text = trt_grd.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            textBox_grandtotal.Text = trt_grd.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            treatment_id.Text = trt_grd.Rows[e.RowIndex].Cells["trt_id"].Value.ToString();
            trt_chart.Text = trt_grd.Rows[e.RowIndex].Cells["chart"].Value.ToString();
            toothcnt.Text = "";

            if (trt_chart.Text == "2")
            {
                panel_chart.Hide();
            } else if(trt_chart.Text == "1")
            {
                panel_chart.Show();
            }


        }

        private void summary_grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void summary_grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*treatmentcash.Text = summary_grd.Rows[e.RowIndex].Cells["treatment"].Value.ToString();
            toothinvcash.Text = summary_grd.Rows[e.RowIndex].Cells["tooth_inv"].Value.ToString();
            chargescash.Text = summary_grd.Rows[e.RowIndex].Cells["charges"].Value.ToString();
            grandtotalcash.Text = summary_grd.Rows[e.RowIndex].Cells["total"].Value.ToString();
            panel_pay.Show();
            panel_pay.Enabled = true;*/
        }

        private void button_inventory_Click(object sender, EventArgs e)
        {
            panel_inv.Show();
            loadAllInv();
        }

        private void panel_pay2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_inventory_name_Click(object sender, EventArgs e)
        {

        }

        private void button_cancel_pay_Click(object sender, EventArgs e)
        {

        }

        public void loadSummary()
        {
            string sel = "SELECT * FROM dc_tooth WHERE app_id = '" + appid.Text + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            summary_grd.DataSource = dt;
            summary_grd.RowHeadersVisible = false;
            summary_grd.Columns["tooth_id"].Visible = false;
            summary_grd.Columns["pr_id"].Visible = false;
            summary_grd.Columns["app_id"].Visible = false;
            summary_grd.Columns["sched_id"].Visible = false;
            summary_grd.Columns["treatment"].HeaderText = "Treatment";
            summary_grd.Columns["tooth_inv"].Visible = false;
            summary_grd.Columns["quantity"].HeaderText = "Quantity";
            summary_grd.Columns["charges"].Visible = false;
            summary_grd.Columns["total"].HeaderText = "Total";
            summary_grd.Columns["status"].Visible = false;


            decimal sum = 0;

            for (int y = 0; y < summary_grd.Rows.Count; y++)
            {
                sum = sum + (((decimal)Convert.ToDecimal(summary_grd.Rows[y].Cells[8].Value.ToString())));

            }
            this.all = sum;
            amnt_due.Text = sum.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label_inv_id.Text = dataGridView_inventory.Rows[e.RowIndex].Cells["item_id"].Value.ToString();
            label_item.Text = dataGridView_inventory.Rows[e.RowIndex].Cells["item_name"].Value.ToString();
            label_desc.Text = dataGridView_inventory.Rows[e.RowIndex].Cells["item_description"].Value.ToString();
            label_quant.Text = dataGridView_inventory.Rows[e.RowIndex].Cells["item_quantity"].Value.ToString();
            box_expiry.Text = dataGridView_inventory.Rows[e.RowIndex].Cells["item_expiry"].Value.ToString();
            label4.Show();
            button_add.Show();
            button_deduct.Show();

            
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            label_label.Text = "in";
            String nm = label_item.Text;
            String opt = label_label.Text;
            String init = label_inv_id.Text;
            adddeduct aw = new adddeduct();
            aw.getnm = nm;
            aw.getopt = opt;
            aw.getid = init;
            aw.ShowDialog();
            loadAll();
        }

        private void button_deduct_Click(object sender, EventArgs e)
        {
            label_label.Text = "out";
            String pr = patn.Text;
            String app = appid.Text;
            String nm = label_item.Text;
            String opt = label_label.Text;
            String init = label_inv_id.Text;
            adddeduct aw = new adddeduct();
            aw.getpr = pr;
            aw.getapp = app;
            aw.getnm = nm;
            aw.getopt = opt;
            aw.getid = init;

            aw.ShowDialog();
            loadAll();
        }

        private void button_cancel_inv_Click(object sender, EventArgs e)
        {
            panel_inv.Hide();
            
        }

        private void z(object sender, PaintEventArgs e)
        {

        }

        private void button_finish_Click(object sender, EventArgs e)
        {
            panel_alert.Show();
        }

        private void button_check_inv_Click(object sender, EventArgs e)
        {
            panel_alert.Hide();
            panel_inv.Show();
            loadAllInv();
        }

        private void button_yes_Click(object sender, EventArgs e)
        {
            panel_alert.Hide();
            button_finish.Hide();
            textBox_Checknumber.Text = "";
            //appid.Text = "";
            // patid.Text = "";
            // patn.Text = "";
            //trt_grd.DataSource = null;
            //trt_grd.Rows.Clear();
            textBox_trtment1.Text = "";
            textBox_toothinv.Text = "";
            toothcnt.Text = "";
            textBox_Charges.Text = "";
            textBox_grandtotal.Text = "";
            comboBox_mode.Text = "";
            comboBox_Type.Text = "";
            dptdue.Text = "";
            textBox_Checknumber.Text = "";
            textBox_amntpaid.Text = "";
            textBox_change.Text = "";
            treatment_id.Text = "";
            trt_chart.Text = "";
            scd_id.Text = "";
            sched_id1.Text = "";
            pr_id.Text = "";
            treatmentcash.Text = "";
            toothinvcash.Text = "";
            chargescash.Text = "";
            grandtotalcash.Text = "";
            textBox_total_paid.Text = "";
            if (this.summary_grd.DataSource != null)
            {
                this.summary_grd.DataSource = null;
            }
            else
            {
                this.summary_grd.Rows.Clear();
            }
            if (this.trt_grd.DataSource != null)
            {
                this.summary_grd.DataSource = null;
            }
            else
            {
                this.summary_grd.Rows.Clear();
            }
        }

        private void button_pay_Click(object sender, EventArgs e)
        {
            panel_pay.Show();
            panel_pay.Enabled = true;
        }

        private void textBox_grandtotal_TextChanged(object sender, EventArgs e)
        {

        }
        private void loadAllInv()
        {
            string query = "SELECT * from inventory";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView_inventory.DataSource = dt;
            dataGridView_inventory.Columns["item_id"].Visible = false;
            dataGridView_inventory.Columns["item_name"].HeaderText = "Item Name";
            dataGridView_inventory.Columns["item_description"].HeaderText = "Description";
            dataGridView_inventory.Columns["item_quantity"].HeaderText = "Quantity";
            dataGridView_inventory.Columns["item_expiry"].HeaderText = "Expiry Date";


            dataGridView_inventory.Sort(dataGridView_inventory.Columns[1], ListSortDirection.Ascending);

        }

    }
}
