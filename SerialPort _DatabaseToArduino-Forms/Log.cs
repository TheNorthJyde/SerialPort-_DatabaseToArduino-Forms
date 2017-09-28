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
    public partial class Log : Form
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;database=rfid;");
        public Log()
        {
            InitializeComponent();
            datalog();
        }
        void datalog()
        {
            string query = "SELECT * FROM log";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            log1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearLog_Click(object sender, EventArgs e)
        {            
            try
            {
                MySqlCommand cmd;  
                string query = "Delete FROM log";
                cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string sql = "INSERT INTO log (`Initials`, `Dato & Time`, `Message`) VALUES ('ADMIN','" + DateTime.UtcNow + "','Have been Cleared')";
                cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            datalog();
        }
    }
}
