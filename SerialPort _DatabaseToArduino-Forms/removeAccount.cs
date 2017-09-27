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
    public partial class removeAccount : Form
    {
        SerialPort myserialPort;

        database database = new database();
        private removeAccount()
        {
            InitializeComponent();
        }
        public removeAccount(SerialPort mySerialPort)
        {
            InitializeComponent();
            this.myserialPort = mySerialPort;
            myserialPort.ReadExisting();
            myserialPort.DataReceived += MySerialPort_DataReceived;
        }

        ~removeAccount()
        {
            myserialPort.DataReceived -= MySerialPort_DataReceived;
        }
        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            id.Text = myserialPort.ReadLine();

            if (id.TextLength == 11)
            {
                id.Text += " \r";
            }
        }

        private void removeAccount_button_Click(object sender, EventArgs e)
        {
            if(database.checkID(id.Text))
            {
                removeID.TextToBring = id.Text;
                removeAccountWarning warning = new removeAccountWarning();
                warning.StartPosition = FormStartPosition.CenterParent;
                warning.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("This ID: " + id.Text + " is never used");
                id.Text = "";
            }            
        }        
    }
}
