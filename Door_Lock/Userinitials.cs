using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Door_Lock
{
    class Userinitials
    {
        public static string initials { get; set; }
        public void Inital()
        {
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;database=rfid;");
            string id = RemoveID.TextToBring;
            string sql = "SELECT `First_name`, `Middle_name`, `Last_name` FROM `accounts` WHERE ID ='" + id + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet DS = new DataSet();
            adapter.Fill(DS);
            string firstName = DS.Tables[0].Rows[0][0].ToString();
            string middleName = DS.Tables[0].Rows[0][1].ToString();
            string lastName = DS.Tables[0].Rows[0][2].ToString();
            string Initials = firstName[0].ToString() + middleName[0].ToString() + lastName[0].ToString();
            Userinitials.initials = Initials;
        }
    }
}
