using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.Windows.Threading;
using System.Data;

namespace Door_Lock
{
    /// <summary>
    /// Interaction logic for AddAcc.xaml
    /// </summary>
    public partial class AddAcc : Window
    {
        SerialPort myserialPort;

        private AddAcc()
        {
            InitializeComponent();
        }

        public AddAcc(SerialPort mySerialPort)
        {
            
            InitializeComponent();
            this.myserialPort = mySerialPort;
            myserialPort.DataReceived += MySerialPort_DataReceived;
            myserialPort.DiscardInBuffer();
            mySerialPort.DiscardOutBuffer();
            id.IsReadOnly = true;
        }

        ~AddAcc()
        {
            //myserialPort.DiscardInBuffer();
            //myserialPort.DiscardOutBuffer();

            myserialPort.DataReceived -= MySerialPort_DataReceived;
        }

        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string ID = myserialPort.ReadLine();
                Dispatcher.BeginInvoke((Action)(() => id.AppendText(ID)));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("host=10.11.42.216;user=rfiddoorlock;password=SbGvS9L8RdFZiNas;database=rfiddoorlock;");
            try
            {
                string checkCuery = "SELECT * FROM accounts WHERE ID = '" + id.Text + "'";

                MySqlCommand check = new MySqlCommand(checkCuery, con);
                con.Open();
                MySqlDataReader rdr = check.ExecuteReader();

                if (!rdr.Read())
                {
                    con.Close();

                    string query = "INSERT INTO accounts (ID,First_name,Middle_name,Last_name) VALUES('" + this.id.Text + "','" + this.first_name.Text + "','" + this.middle_name.Text + "','" + this.last_name.Text + "')";

                    //This handles the connection and the query
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Opens the connection to the SQL database
                    con.Open();

                    //Executes the query and saves the data to the database
                    cmd.ExecuteNonQuery();
                    string Initials = first_name.Text[0].ToString() + middle_name.Text[0].ToString() + last_name.Text[0].ToString();
                    MessageBox.Show("User successfully added!\n" + "Initials: " + Initials);

                    //Closes the connection to the database
                    con.Close();
                    //Log
                    string sql = "INSERT INTO log (`ID`, `Initials`, `Dato & Time`, `Message`) VALUES ('" + id.Text + "','" + Initials + "','" + DateTime.UtcNow + "','Have been Added')";
                    cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("User already exists");
                    id.Text = "";
                    first_name.Text = "";
                    middle_name.Text = "";
                    last_name.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            first_name.Text = "";
            middle_name.Text = "";
            last_name.Text = "";
            id.Text = "";            
        }
    }
}
