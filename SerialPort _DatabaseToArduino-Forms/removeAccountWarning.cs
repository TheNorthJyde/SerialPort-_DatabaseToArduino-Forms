﻿using System;
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
    public partial class removeAccountWarning : Form
    {
        //MySQL Connection
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;database=rfid;");
        
        //This handles the connection and the query
        MySqlCommand cmd;

        //database
        database database = new database();

        
        MySqlDataAdapter adapter;

        string query;
        string id;


        public removeAccountWarning()
        {
            InitializeComponent();

            id = removeID.TextToBring;
            
            text();
        }     


        void text()
        {
            Userinitials userinitials = new Userinitials();
            userinitials.Inital();
            try
            {
                string sql = "SELECT `First_name`, `Middle_name`, `Last_name` FROM `accounts` WHERE ID ='" + id + "'";
                adapter = new MySqlDataAdapter(sql, con);
                DataSet DS = new DataSet();
                adapter.Fill(DS);
                accountInfo.Text = DS.Tables[0].Rows[0][0].ToString() + " " + DS.Tables[0].Rows[0][1].ToString() + " " + DS.Tables[0].Rows[0][2].ToString();
                Initials.Text = Userinitials.initials;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeAcc_Click(object sender, EventArgs e)
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
                string sql = "INSERT INTO log (`ID`, `Initials`, `Dato & Time`, `Message`) VALUES ('" + id + "','" + Userinitials.initials + "','" + DateTime.UtcNow + "','Have been Removed')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
