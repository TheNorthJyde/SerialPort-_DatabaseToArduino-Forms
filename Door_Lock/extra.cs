using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Door_Lock
{
    class extra
    {
        MySqlConnection con;

        //MySQL Command
        MySqlCommand cmd;

        MySqlDataReader reader;

        public static string initials { get; set; }
        public static string TextToBring { get; set; }
        public static string SqlServer { get; set; }

        

        public void Inital()
        {
            con = new MySqlConnection(SqlServer);
            string id = extra.TextToBring;
            string sql = "SELECT `First_name`, `Middle_name`, `Last_name` FROM `accounts` WHERE ID ='" + id + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet DS = new DataSet();
            adapter.Fill(DS);
            string firstName = DS.Tables[0].Rows[0][0].ToString();
            string middleName = DS.Tables[0].Rows[0][1].ToString();
            string lastName = DS.Tables[0].Rows[0][2].ToString();
            string Initials = firstName[0].ToString() + middleName[0].ToString() + lastName[0].ToString();
            extra.initials = Initials;
        } 

        /// <summary>
        /// Cheks to see if the id on the card matches an id on the database
        /// </summary>
        public bool checkID(string id)
        {
            con = new MySqlConnection(SqlServer);
            try
            {
                bool result = false;

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
            catch (Exception)
            {
                return false;
            }
        }
    }
}
