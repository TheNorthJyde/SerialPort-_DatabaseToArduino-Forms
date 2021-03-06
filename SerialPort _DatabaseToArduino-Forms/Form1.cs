﻿using System;
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

    public partial class Form1 : Form
    {
        database db;
        
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;database=rfid;");
        MySqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
            serialPort.DataReceived += serialPort_DataReceived;
            comPort.Text = "Select a COMPort";
            CheckForIllegalCrossThreadCalls = false;
            db = new database();

            output.Items.Add("Connect to a COM port to begin");

            filToolStripMenuItem.Enabled = false;
            clear.Enabled = false;            
            MessageBox.Show("Remeber to save and upload new code");            
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            
            //data = data.Replace("\r", "");

            if (db.checkID(data))
            {
                output.Items.Add("ID: " + data);
                serialPort.WriteLine("A");
                removeID.TextToBring = data;
                Userinitials userinitials = new Userinitials();
                userinitials.Inital();
                try
                {
                    string sql = "INSERT INTO log (`ID`, `Initials`, `Dato & Time`, `Message`) VALUES ('" + data + "','" + Userinitials.initials +"','" + DateTime.UtcNow + "','Have open door')";
                    cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                output.Items.Add("ID Not Available");
                serialPort.WriteLine("D");
                try
                {
                    string sql = "INSERT INTO log (`ID`, `Initials`, `Dato & Time`, `Message`) VALUES ('" + data + "',' ','" + DateTime.UtcNow + "','Have tried to open door')";
                    cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                connect.Text = "Connect";
                output.Items.Add("Disconnected");

                filToolStripMenuItem.Enabled = false;
                clear.Enabled = false;
            }
            else
            {
                try
                {
                    serialPort.Open();

                    connect.Text = "Disconnect";
                    output.Items.Clear();
                    output.Items.Add("Connected to " + serialPort.PortName);

                    filToolStripMenuItem.Enabled = true;
                    clear.Enabled = true;
                }
                catch (Exception exc)
                {
                    output.Items.Add("Der var en fejl:");
                    output.Items.Add(exc.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comPort.Items.AddRange(SerialPort.GetPortNames());
        }

        private void comPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = comPort.SelectedItem.ToString();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            output.Items.Clear();
            connect.Select();
            if(serialPort.IsOpen)
            {
                output.Items.Add("Connected to " + serialPort.PortName);
            }
            
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            serialPort.DataReceived -= serialPort_DataReceived;
            addAccount addAccount = new addAccount(serialPort);
            addAccount.StartPosition = FormStartPosition.CenterParent;
            addAccount.ShowDialog();
            serialPort.ReadExisting();
            serialPort.DataReceived += serialPort_DataReceived;
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            serialPort.DataReceived -= serialPort_DataReceived;
            removeAccount removeAccount = new removeAccount(serialPort);
            removeAccount.StartPosition = FormStartPosition.CenterParent;
            removeAccount.ShowDialog();
            serialPort.ReadExisting();
            serialPort.DataReceived += serialPort_DataReceived;
        }

        private void showAccounts_Click(object sender, EventArgs e)
        {
            ok_button test = new ok_button();
            test.StartPosition = FormStartPosition.CenterParent;
            test.ShowDialog();
        }

        private void showLog_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            log.StartPosition = FormStartPosition.CenterParent;
            log.ShowDialog();
        }
    }
}
