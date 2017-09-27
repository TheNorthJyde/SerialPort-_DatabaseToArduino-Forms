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

namespace SerialPort__DatabaseToArduino_Forms
{
    public partial class ok_button : Form
    {
        public ok_button()
        {
            InitializeComponent();

            MySqlConnection con = new MySqlConnection("host=localhost;user=root;database=rfid;");
            string query = "SELECT * FROM accounts";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            accounts.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }            
    }
}
