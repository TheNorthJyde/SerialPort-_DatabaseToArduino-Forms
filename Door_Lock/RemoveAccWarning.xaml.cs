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
using System.Data;
using MySql.Data.MySqlClient;

namespace Door_Lock
{
    /// <summary>
    /// Interaction logic for RemoveAccWarning.xaml
    /// </summary>
    public partial class RemoveAccWarning : Window
    {
        MySqlConnection con = new MySqlConnection("host=10.11.42.216;user=rfiddoorlock;password=SbGvS9L8RdFZiNas;database=rfiddoorlock;");

        //This handles the connection and the query
        MySqlCommand cmd;

        MySqlDataAdapter adapter;

        //database
        extra database = new extra();

        string query;
        string id;

        public RemoveAccWarning()
        {
            InitializeComponent();
            id = extra.TextToBring;
            text();
        }

        void text()
        {
            extra userinitials = new extra();
            userinitials.Inital();
            try
            {
                string sql = "SELECT `First_name`, `Middle_name`, `Last_name` FROM `accounts` WHERE ID ='" + id + "'";
                adapter = new MySqlDataAdapter(sql, con);
                DataSet DS = new DataSet();
                adapter.Fill(DS);
                accountInfo.Content = DS.Tables[0].Rows[0][0].ToString() + " " + DS.Tables[0].Rows[0][1].ToString() + " " + DS.Tables[0].Rows[0][2].ToString();
                Initials.Content = extra.initials;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeAcc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // this is the command
                query = "DELETE FROM accounts WHERE ID = '" + id + "'";

                //This handles the connection and the query
                cmd = new MySqlCommand(query, con);

                //Opens the connection to the SQL database
                con.Open();

                //Executes the query and saves the data to the database
                cmd.ExecuteNonQuery();

                MessageBox.Show("Account successfully removed!");

                //Closes the connection to the database
                con.Close();
                string sql = "INSERT INTO log (`ID`, `Initials`, `Dato & Time`, `Message`) VALUES ('" + id + "','" + extra.initials + "','" + DateTime.UtcNow + "','Have been Removed')";
                cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
