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
using MySql.Data.MySqlClient;
using System.Data;

namespace Door_Lock
{
    /// <summary>
    /// Interaction logic for Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        MySqlConnection con = new MySqlConnection("host=10.11.42.216;user=rfiddoorlock;password=SbGvS9L8RdFZiNas;database=rfiddoorlock;");
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
            log1.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearLog_Click(object sender, RoutedEventArgs e)
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
