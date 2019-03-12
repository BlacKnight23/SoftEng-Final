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
    public partial class USC_inventory : UserControl
    {
        MySqlConnection conn;
        private static USC_inventory _instance;
        public USC_inventory()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc1;Uid=root;password=root ");
        }
        public static USC_inventory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new USC_inventory();
                return _instance;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void USC_inventory_Load(object sender, EventArgs e)
        {
            dataGridView3.Hide();
            dataGridView2.Hide();
            loadAll();
            loadAll2();
            label4.Hide();
            expiry_date.Enabled = false;
            button_add.Hide();
            button_deduct.Hide();
            Label_equipmentname.Hide();
            label_equipmentdesc.Hide();
            label_status.Hide();
            textBox_equipmentname.Hide();
            textBox_equipmentdesc.Hide();
            comboBox_status.Hide();
            button__create.Hide();
            button__update.Hide();
            button__reset.Hide();
            panel_supplier.Hide();
            panel_supplier_settings.Hide();
            label4.Hide();
            labelbel.Hide();

        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if (textBox_itemname.Text == "" && textBox_itemdescription.Text == "")
            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {

                if (checkbox_expiry.Checked == true)
                {
                    String item = textBox_itemname.Text;
                    String date = expiry_date.Text;
                    String query = "SELECT *FROM inventory WHERE item_name = '" + item + "' and item_expiry ='" + date + "'";


                    MySqlCommand com = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        MessageBox.Show("Item Already Taken!");
                    }
                    else
                    {


                        String query3 = "INSERT INTO inventory(item_name, item_description, item_quantity, item_expiry, item_supplier, item_reorder_point) " +
                                       "VALUES('" + textBox_itemname.Text + "', '" + textBox_itemdescription.Text + "', '" + textBox_initial_quant.Text + "', '" + expiry_date.Value.ToString("yyyy-MM-dd") + "','" + textBox_supplier.Text + "','" + textBox_initial_quant.Text + "')";


                        MySqlCommand comm = new MySqlCommand(query3, conn);
                        conn.Open();

                        comm.ExecuteNonQuery();
                        conn.Close();
                        loadAll();
                        MessageBox.Show("Created Successfully!");

                        ///////////////////////////////
                        String queryy = "SELECT last_insert_id() FROM inventory";
                        MySqlCommand commmm = new MySqlCommand(queryy, conn);
                        conn.Open();


                        MySqlDataReader r = commmm.ExecuteReader();
                        while (r.Read())
                        {
                            label10.Text = (r["last_insert_id()"].ToString());

                        }
                        r.Close();

                        commmm.ExecuteNonQuery();
                        conn.Close();
                        ////////////////////////////////


                        String query4 = "INSERT INTO stock(stock_inventory_id, stock_label, stock_name,stock_value, stock_description, stock_date) " +
                                      "VALUES('" + label10.Text + "', 'in', '" + textBox_itemname.Text + "', '" + textBox_initial_quant.Text + "','" + textBox_itemdescription.Text + "', now())";


                        MySqlCommand commm = new MySqlCommand(query4, conn);
                        conn.Open();

                        commm.ExecuteNonQuery();
                        conn.Close();
                        loadAll();
                        MessageBox.Show("Created Successfully!");




                    }
                }
                else
                {

                    String item = textBox_itemname.Text;
                    String date = null;
                    String query = "SELECT *FROM inventory WHERE item_name = '" + item + "' and item_expiry ='" + date + "'";


                    MySqlCommand com = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        MessageBox.Show("Item Already Taken!");
                    }
                    else
                    {


                        String query3 = "INSERT INTO inventory(item_name, item_description, item_quantity, item_supplier, item_reorder_point ) " +
                                       "VALUES('" + textBox_itemname.Text + "', '" + textBox_itemdescription.Text + "', '" + textBox_initial_quant.Text + "','" + textBox_supplier.Text + "','" + textBox_reorder.Text + "')";

                        MySqlCommand comm = new MySqlCommand(query3, conn);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();




                        String queryy = "SELECT last_insert_id() FROM inventory";
                        MySqlCommand commmm = new MySqlCommand(queryy, conn);
                        conn.Open();

                        MySqlDataReader r = commmm.ExecuteReader();
                        while (r.Read())
                        {
                            label10.Text = (r["last_insert_id()"].ToString());

                        }
                        r.Close();

                        commmm.ExecuteNonQuery();
                        conn.Close();



                        String query4 = "INSERT INTO stock(stock_inventory_id, stock_label, stock_name,stock_value, stock_description, stock_date) " +
                                      "VALUES('" + label10.Text + "', 'in', '" + textBox_itemname.Text + "', '" + textBox_initial_quant.Text + "','" + textBox_itemdescription.Text + "', now())";


                        MySqlCommand commm = new MySqlCommand(query4, conn);
                        conn.Open();

                        commm.ExecuteNonQuery();
                        conn.Close();
                        loadAll();
                        MessageBox.Show("Created Successfully!");





                    }



                }

            }

        }

        private void button_update_Click(object sender, EventArgs e)
        {

            if (checkbox_expiry.Checked == true)
            {
                if (textBox_itemname.Text == " " || textBox_itemdescription.Text == " ")
                {
                    MessageBox.Show("Please input required fields.");
                }
                else
                {
                    String query5 = "SELECT item_name, item_description,item_expiry, item_supplier, item_reorder_point FROM inventory WHERE item_id ='" + inventorylabel_id.Text + "'";
                    conn.Open();

                    MySqlCommand com = new MySqlCommand(query5, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    conn.Close();


                    String query4 = "Update inventory set item_name ='" + textBox_itemname.Text + "',item_description='" + textBox_itemdescription.Text + "', item_expiry='" + expiry_date.Value.ToString("yyyy-MM-dd") + "', item_supplier = '" + textBox_supplier.Text + "', item_reorder_point = '" + textBox_reorder.Text + "' WHERE item_id = '" + inventorylabel_id.Text + "' ";


                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query4, conn);
                    MySqlDataAdapter adp30 = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadAll();
                    MessageBox.Show("Updated Successfully!");

                }
            }
            else
            {
                if (textBox_itemname.Text == " " || textBox_itemdescription.Text == " ")
                {
                    MessageBox.Show("Please input required fields.");
                }
                else
                {
                    String query5 = "SELECT item_name, item_description, item_supplier, item_reorder_point FROM inventory WHERE item_id ='" + inventorylabel_id.Text + "'";
                    conn.Open();

                    MySqlCommand com = new MySqlCommand(query5, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    conn.Close();


                    String query4 = "Update inventory set item_name = '" + textBox_itemname.Text + "', item_description = '" + textBox_itemdescription.Text + "', item_supplier = '" + textBox_supplier.Text + "', item_reorder_point = '" + textBox_reorder.Text + "'WHERE item_id = '" + inventorylabel_id.Text + "' ";


                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query4, conn);
                    MySqlDataAdapter adp30 = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadAll();
                    MessageBox.Show("Updated Successfully!");

                }
            }
        }
                private void button_reset_Click(object sender, EventArgs e)
            {
                inventorylabel_id.Text = "";
                textBox_itemname.Text = "";
                textBox_itemdescription.Text = "";
                label4.Text = "";
                expiry_date.Text = "";
                label4.Hide();
                button_add.Hide();
                button_deduct.Hide();
                button_create.Show();
                label_initial_quant.Show();
                textBox_initial_quant.Show();

                expiry_date.Enabled = false;


                textBox_itemname.Focus();

                button_create.Enabled = true;
            }
            private void loadAll()
            {
                string query = "SELECT * from inventory";

                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["item_id"].Visible = false;
                dataGridView1.Columns["item_name"].HeaderText = "Item Name";
                dataGridView1.Columns["item_description"].HeaderText = "Description";
                dataGridView1.Columns["item_quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["item_expiry"].HeaderText = "Expiry Date";


                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            }

            private void loadAll2()
            {
                string query = "SELECT * from dc_equipments";

                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView3.DataSource = dt;
                dataGridView3.Columns["equipment_id"].Visible = false;
                dataGridView3.Columns["equipment_name"].HeaderText = "Equipment Name";
                dataGridView3.Columns["equipment_description"].HeaderText = "Description";
                dataGridView3.Columns["equipment_status"].HeaderText = "Status";


                dataGridView3.Sort(dataGridView3.Columns[1], ListSortDirection.Ascending);

            }
            private void loadAll3()
            {
                string query = "SELECT * from supp";

                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView_supplier.DataSource = dt;
                dataGridView_supplier.Columns["supplier_id"].Visible = false;
                dataGridView_supplier.Columns["supplier_name"].HeaderText = "Supplier Name";
                dataGridView_supplier.Columns["supplier_description"].HeaderText = "Description";
                dataGridView_supplier.Columns["supplier_contact"].HeaderText = "Contact";


                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            }
            private void loadAll4()
            {
                string query = "SELECT * from supp";

                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView_select_supplier.DataSource = dt;
                dataGridView_select_supplier.Columns["supplier_id"].Visible = false;
                dataGridView_select_supplier.Columns["supplier_name"].HeaderText = "Supplier Name";
                dataGridView_select_supplier.Columns["supplier_description"].HeaderText = "Description";
                dataGridView_select_supplier.Columns["supplier_contact"].HeaderText = "Contact";


                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            }

            private void button_add_Click(object sender, EventArgs e)
            {
                label5.Text = "in";
                String nm = textBox_itemname.Text;
                String opt = label5.Text;
                String init = inventorylabel_id.Text;
                adddeduct aw = new adddeduct();
                aw.getnm = nm;
                aw.getopt = opt;
                aw.getid = init;
                aw.ShowDialog();
                loadAll();
            }

            private void panel1_Paint_1(object sender, PaintEventArgs e)
            {

            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

                inventorylabel_id.Text = dataGridView1.Rows[e.RowIndex].Cells["item_id"].Value.ToString();
                textBox_itemname.Text = dataGridView1.Rows[e.RowIndex].Cells["item_name"].Value.ToString();
                textBox_itemdescription.Text = dataGridView1.Rows[e.RowIndex].Cells["item_description"].Value.ToString();
                label4.Text = dataGridView1.Rows[e.RowIndex].Cells["item_quantity"].Value.ToString();
                textBox_reorder.Text = dataGridView1.Rows[e.RowIndex].Cells["item_reorder_point"].Value.ToString();
                 expiry_date.Text = dataGridView1.Rows[e.RowIndex].Cells["item_expiry"].Value.ToString();
                textBox_supplier.Text = dataGridView1.Rows[e.RowIndex].Cells["item_supplier"].Value.ToString();

                label4.Show();
                labelbel.Show();
                button_add.Show();
                button_deduct.Show();
                label_initial_quant.Hide();
                textBox_initial_quant.Hide();


                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {

                    button_create.Hide();

                }




            }

            private void button_deduct_Click(object sender, EventArgs e)
            {
                label5.Text = "out";
                String opt = label5.Text;
                String init = inventorylabel_id.Text;
                adddeduct aw = new adddeduct();
                aw.getopt = opt;
                aw.getid = init;
                aw.ShowDialog();
                loadAll();


            }

            private void button_stock_Click(object sender, EventArgs e)
            {
                textBox_itemname.Hide();
                textBox_itemdescription.Hide();
                button_add.Hide();
                button_deduct.Hide();
                expiry_date.Hide();
                button_create.Hide();
                button_update.Hide();
                button_reset.Hide();
                label2.Hide();
                Item_name.Hide();
                labelbel.Hide();
                label3.Hide();
                checkbox_expiry.Hide();
                label4.Hide();
                dataGridView1.Hide();
                dataGridView2.Show();
                textBox_initial_quant.Hide();
                label_initial_quant.Hide();
                label9.Hide();
                textBox_reorder.Hide();
                label_supplier.Hide();
                textBox_supplier.Hide();
                bunifuFlatButton2.Hide();


                string query = "SELECT stock_id, stock_inventory_id, stock_label, stock_name, stock_value, stock_description, stock_date," +
                "stock_appointment_id, stock_appointment_name from stock";

                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView2.DataSource = dt;
                dataGridView2.Columns["stock_id"].Visible = false;
                dataGridView2.Columns["stock_inventory_id"].Visible = false;
                dataGridView2.Columns["stock_label"].HeaderText = "In / out";
                dataGridView2.Columns["stock_name"].HeaderText = "Item Name ";
                dataGridView2.Columns["stock_value"].HeaderText = "No. Items";
                dataGridView2.Columns["stock_description"].HeaderText = "Reason";
                dataGridView2.Columns["stock_date"].HeaderText = "Date issued";
                dataGridView2.Columns["stock_appointment_id"].HeaderText = "Appointment No.";
                dataGridView2.Columns["stock_appointment_name"].HeaderText = "Name";


            dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Ascending);
            }

            private void bunifuFlatButton1_Click(object sender, EventArgs e)
            {
                textBox_itemname.Show();
                textBox_itemdescription.Show();
                expiry_date.Show();
                button_create.Show();
                button_update.Show();
                button_reset.Show();
                label2.Show();
                Item_name.Show();
                labelbel.Show();
                label3.Show();
                textBox_initial_quant.Show();
                label_initial_quant.Show();
                label9.Show();
                textBox_reorder.Show();
                label_supplier.Show();
                textBox_supplier.Show();
                bunifuFlatButton2.Show();

                dataGridView2.Hide();
                dataGridView1.Show();
                comboBox_status.Hide();
                loadAll();
            }

            private void checkbox_expiry_CheckedChanged(object sender, EventArgs e)
            {
                if (checkbox_expiry.Checked == true)
                {
                    expiry_date.Enabled = true;
                    expiry_date.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    expiry_date.Enabled = false;
                    expiry_date.Format = DateTimePickerFormat.Custom;

                }
            }

            private void label_inventory_Click(object sender, EventArgs e)
            {
                dataGridView2.Hide();
                dataGridView1.Show();
                loadAll();
                label4.Show();
                label5.Show();
                expiry_date.Enabled = false;
                button_add.Hide();
                button_deduct.Hide();
                Item_name.Show();
                label2.Show();
                labelbel.Show();
                label3.Show();
                label4.Show();
                textBox_itemname.Show();
                textBox_itemdescription.Show();
                expiry_date.Show();
                checkbox_expiry.Show();
                button_create.Show();
                button_update.Show();
                button_reset.Show();
                bunifuFlatButton2.Show();
                textBox_supplier.Show();
                label_supplier.Show();


                dataGridView3.Hide();
                Label_equipmentname.Hide();
                label_equipmentdesc.Hide();
                label_status.Hide();
                textBox_equipmentname.Hide();
                textBox_equipmentdesc.Hide();
                comboBox_status.Hide();
                button__create.Hide();
                button__update.Hide();
                button__reset.Hide();
            }

            private void label_equip_Click(object sender, EventArgs e)
            {
                dataGridView2.Hide();
                dataGridView1.Hide();
                loadAll();
                label4.Hide();
                label5.Hide();
                expiry_date.Enabled = false;
                button_add.Hide();
                button_deduct.Hide();
                Item_name.Hide();
                label2.Hide();
                labelbel.Hide();
                label3.Hide();
                label4.Hide();
                textBox_itemname.Hide();
                textBox_itemdescription.Hide();
                expiry_date.Hide();
                checkbox_expiry.Hide();
                button_create.Hide();
                button_update.Hide();
                button_reset.Hide();
                bunifuFlatButton2.Hide();
                textBox_supplier.Hide();
                label_supplier.Hide();
                label_initial_quant.Hide();
                textBox_initial_quant.Hide();
                label9.Hide();
                textBox_reorder.Hide();


                dataGridView3.Show();
                Label_equipmentname.Show();
                label_equipmentdesc.Show();
                label_status.Show();
                textBox_equipmentname.Show();
                textBox_equipmentdesc.Show();
                comboBox_status.Show();
                button__create.Show();
                button__update.Show();
                button__reset.Show();

            }

            private void button__create_Click(object sender, EventArgs e)
            {
                if (textBox_equipmentname.Text == "" && textBox_equipmentdesc.Text == "" && comboBox_status.Text == "")
                {
                    MessageBox.Show("Please input required fields.");
                }
                else
                {

                    String equipment = textBox_equipmentname.Text;

                    String query5 = "SELECT * FROM dc_equipments WHERE equipment_name = '" + equipment + "'";


                    MySqlCommand drop = new MySqlCommand(query5, conn);
                    MySqlDataAdapter riku = new MySqlDataAdapter(drop);
                    DataTable shu = new DataTable();
                    riku.Fill(shu);
                    if (shu.Rows.Count > 0)
                    {

                        MessageBox.Show("Equipment Already Exist!");
                    }
                    else
                    {


                        String query6 = "INSERT INTO dc_equipments(equipment_name,equipment_description, equipment_status) " +
                                       "VALUES('" + equipment + "', '" + textBox_equipmentdesc.Text + "', '" + comboBox_status.Text + "')";


                        MySqlCommand shun = new MySqlCommand(query6, conn);
                        conn.Open();

                        shun.ExecuteNonQuery();
                        conn.Close();
                        loadAll2();
                        MessageBox.Show("Created Successfully!");

                    }

                }
            }

            private void button__update_Click(object sender, EventArgs e)
            {
                if (textBox_equipmentname.Text == "" || textBox_equipmentdesc.Text == "" || comboBox_status.Text == "")
                {
                    MessageBox.Show("Please input all fields.", "Treatment Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string upd = "UPDATE dc_equipments SET equipment_name= '" + textBox_equipmentname.Text + "', equipment_description = '" + textBox_equipmentdesc.Text + "', equipment_status = '" + comboBox_status.Text + "' WHERE equipment_id = '" + equipment_id.Text + "'";
                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand(upd, conn);
                    MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                    comm1.ExecuteNonQuery();
                    conn.Close();

                    loadAll2();
                    MessageBox.Show("equipments update was successful!", "Service Update", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }

            private void button__reset_Click(object sender, EventArgs e)
            {
                textBox_equipmentname.Text = "";
                textBox_equipmentdesc.Text = "";
                comboBox_status.Text = "";
                button__create.Enabled = true;
                button__update.Enabled = false;
            }

            private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                equipment_id.Text = dataGridView3.Rows[e.RowIndex].Cells["equipment_id"].Value.ToString();
                textBox_equipmentname.Text = dataGridView3.Rows[e.RowIndex].Cells["equipment_name"].Value.ToString();
                textBox_equipmentdesc.Text = dataGridView3.Rows[e.RowIndex].Cells["equipment_description"].Value.ToString();
                comboBox_status.Text = dataGridView3.Rows[e.RowIndex].Cells["equipment_status"].Value.ToString();
                button__create.Enabled = false;
                button__update.Enabled = true;

            }

            private void button_view_inventory_Click(object sender, EventArgs e)
            {

            }

            private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void bunifuFlatButton2_Click(object sender, EventArgs e)
            {
                panel_supplier.Show();
                loadAll3();
                loadAll4();
            }

            private void Supplier_exit_Click(object sender, EventArgs e)
            {
                panel_supplier.Hide();
            }

            private void button_add_supplier_Click(object sender, EventArgs e)
            {
                if (textBox_supplier_name.Text == "" && textBox_supplier_contact.Text == "")
                {
                    MessageBox.Show("Please input required fields.");
                }
                else
                {

                    String sup = textBox_supplier_name.Text;

                    String query5 = "SELECT * FROM supp WHERE supplier_name = '" + sup + "'";


                    MySqlCommand drop = new MySqlCommand(query5, conn);
                    MySqlDataAdapter riku = new MySqlDataAdapter(drop);
                    DataTable shu = new DataTable();
                    riku.Fill(shu);
                    if (shu.Rows.Count > 0)
                    {

                        MessageBox.Show("Equipment Already Exist!");
                    }
                    else
                    {


                        String query7 = "INSERT INTO supp(supplier_name,supplier_description, supplier_contact) " +
                                       "VALUES('" + sup + "', '" + textBox_supplier_desc.Text + "', '" + textBox_supplier_contact.Text + "')";


                        MySqlCommand shun = new MySqlCommand(query7, conn);
                        conn.Open();

                        shun.ExecuteNonQuery();
                        conn.Close();
                        loadAll3();
                        loadAll4();
                        MessageBox.Show("Created Successfully!");

                    }

                }
            }

            private void button_supplier_settings_Click(object sender, EventArgs e)
            {
                panel_supplier_settings.Show();
                loadAll3();
                loadAll4();
            }

            private void button_reset_supplier_Click(object sender, EventArgs e)
            {
                textBox_supplier_name.Text = "";
                textBox_supplier_desc.Text = "";
                textBox_supplier_contact.Text = "";
                loadAll3();
                loadAll4();
            }

            private void button_update_supplier_Click(object sender, EventArgs e)
            {
                if (textBox_supplier_name.Text == "" || textBox_supplier_contact.Text == "")
                {
                    MessageBox.Show("Please input all fields.", "Treatment Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string upd = "UPDATE supp SET supplier_name= '" + textBox_supplier_name.Text + "', supplier_description = '" + textBox_supplier_desc.Text + "', supplier_contact = '" + textBox_supplier.Text + "' WHERE supplier_id = '" + label_supplier_id.Text + "'";
                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand(upd, conn);
                    MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                    comm1.ExecuteNonQuery();
                    conn.Close();

                    loadAll3();
                    loadAll4();
                    MessageBox.Show("Supplier update was successful!", "Service Update", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }

            private void dataGridView_supplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                label_supplier_id.Text = dataGridView_supplier.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString();
                textBox_supplier_name.Text = dataGridView_supplier.Rows[e.RowIndex].Cells["supplier_name"].Value.ToString();
                textBox_supplier_desc.Text = dataGridView_supplier.Rows[e.RowIndex].Cells["supplier_description"].Value.ToString();
                textBox_supplier_contact.Text = dataGridView_supplier.Rows[e.RowIndex].Cells["supplier_contact"].Value.ToString();
            }

            private void dataGridView_select_supplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                textBox_supplier.Text = dataGridView_supplier.Rows[e.RowIndex].Cells["supplier_name"].Value.ToString();
            }

            private void bunifuFlatButton5_Click(object sender, EventArgs e)
            {
                panel_supplier_settings.Hide();
            }

            private void textBox_search_OnTextChange(object sender, EventArgs e)
            {

            }

            private void label_supplier_Click(object sender, EventArgs e)
            {

            }
        }
    }

