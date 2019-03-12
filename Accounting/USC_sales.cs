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
    public partial class USC_sales : UserControl
    {
        MySqlConnection conn;
        private static USC_sales _instance;

        public static USC_sales Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new USC_sales();
                return _instance;
            }
        }
        public USC_sales()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=fdc;Uid=root; ");
        }

        private void USC_sales_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewall_button_Click(object sender, EventArgs e)
        {

        }
    }
}
