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

namespace SerialPort__DatabaseToArduino_Forms
{

    public partial class Form1 : Form
    {
        database db;
        
        public Form1()
        {
            InitializeComponent();
            serialPort.DataReceived += serialPort_DataReceived;
            comPort.Text = "Select a COMPort";
            CheckForIllegalCrossThreadCalls = false;
            db = new database();

            output.Items.Add("Connect to a COM port to begin");

            filToolStripMenuItem.Enabled = false;
            showAccounts.Enabled = false;
            clear.Enabled = false;

            MessageBox.Show("remeber to save adn upload new code");
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();

            //data = data.Replace("\r", "");
            
            if (db.checkID(data))
            {
                output.Items.Add("ID: " + data);
                serialPort.WriteLine("A");
            }
            else
            {
                output.Items.Add("ID Not Available");
                serialPort.WriteLine("D");
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
                showAccounts.Enabled = false;
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
                    showAccounts.Enabled = true;
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
            serialPort.DataReceived -= serialPort_DataReceived;
            addAccount addAccount = new addAccount(serialPort);
            addAccount.StartPosition = FormStartPosition.CenterParent;
            addAccount.ShowDialog();
            serialPort.DataReceived += serialPort_DataReceived;
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort.DataReceived -= serialPort_DataReceived;
            removeAccount removeAccount = new removeAccount(serialPort);
            removeAccount.StartPosition = FormStartPosition.CenterParent;
            removeAccount.ShowDialog();
            serialPort.DataReceived += serialPort_DataReceived;
        }

        private void showAccounts_Click(object sender, EventArgs e)
        {
            ok_button test = new ok_button();
            test.StartPosition = FormStartPosition.CenterParent;
            test.ShowDialog();
        }
    }
}
