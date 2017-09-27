using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using MySql.Data.MySqlClient;

namespace SerialPort__DatabaseToArduino_Forms
{
    public partial class addAccount : Form
    {
        SerialPort myserialPort;
        
        private addAccount()
        {
            InitializeComponent();

        }

        public addAccount(SerialPort mySerialPort)
        {
            InitializeComponent();
            this.myserialPort = mySerialPort;
            myserialPort.DataReceived += MySerialPort_DataReceived;
        }

        ~addAccount()
        {
            myserialPort.DataReceived -= MySerialPort_DataReceived;
        }

        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            id.Text = myserialPort.ReadLine();
        }

        private void addAccount_button_Click(object sender, EventArgs e)
        {
            //MySQL Connection
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;database=rfid;");

            try
            {
                string checkCuery = "SELECT * FROM accounts WHERE ID = '" + id.Text + "'";

                MySqlCommand check = new MySqlCommand(checkCuery,con);
                con.Open();
                MySqlDataReader rdr = check.ExecuteReader();

                if (!rdr.Read())
                {
                    con.Close();

                    string query = "INSERT INTO accounts (ID,First_name,Middle_name,Last_name) VALUES('" + this.id.Text + "','" + this.firstName.Text + "','" + this.middleName.Text + "','" + this.lastName.Text + "')";

                    //This handles the connection and the query
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Opens the connection to the SQL database
                    con.Open();

                    //Executes the query and saves the data to the database
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Account successfully added!");

                    //Closes the connection to the database
                    con.Close();

                    this.Close();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("User allready excist");
                    id.Text = "";
                    firstName.Text = "";
                    middleName.Text = "";
                    lastName.Text = "";
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
