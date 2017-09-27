using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SerialPort__DatabaseToArduino_Forms
{
    class database
    {
        //MySQL Connection
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;database=rfid;");

        //MySQL Command
        MySqlCommand cmd;

        MySqlDataReader reader;

        /// <summary>
        /// Cheks to see if the id on the card matches an id on the database
        /// </summary>
        public bool checkID(string id)
        {
            bool result = false;
            int a = 0;
            string sql = "SELECT * FROM accounts WHERE ID = '" + id + "'";

            cmd = new MySqlCommand(sql, con);

            //Opens the connection to the SQL database
            con.Open();

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                result = true;
            }

            con.Close();

            return result;
        }
    }
}
