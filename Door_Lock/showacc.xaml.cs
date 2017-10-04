using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Door_Lock
{
    /// <summary>
    /// Interaction logic for showacc.xaml
    /// </summary>
    public partial class showacc : Window
    {
        public showacc()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("host=10.11.42.216;user=rfiddoorlock;password=SbGvS9L8RdFZiNas;database=rfiddoorlock;");
            string query = "SELECT * FROM accounts";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            log1.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
