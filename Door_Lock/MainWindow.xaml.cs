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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using System.Threading;
using System.ComponentModel;

namespace Door_Lock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection con = new MySqlConnection("host=10.11.42.216;user=rfiddoorlock;password=SbGvS9L8RdFZiNas;database=rfiddoorlock;");
        MySqlCommand cmd;
        SerialPort serialPort;
        extra db;
        
        public MainWindow()
        {
            InitializeComponent();
            db = new extra();
            
            comPorts.Items.Add("Select a COMPort");            
            output.Items.Add("Select a COM port and Connect");

            clear.IsEnabled = false;
            dropdown.IsEnabled = false;            

            serialPort = new SerialPort();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);                        
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {            
            string data = serialPort.ReadLine();
            if (db.checkID(data))
            {
                extra.TextToBring = data;
                data = data.Replace("\r", "");                
                extra init = new extra();
                init.Inital();
                Dispatcher.BeginInvoke((Action)(() => output.Items.Add("ID: " + data + " Initials: " + extra.initials)));
                serialPort.WriteLine("A");
                try
                {
                    string sql = "INSERT INTO log (`ID`, `Initials`, `Dato & Time`, `Message`) VALUES ('" + data + "','" + extra.initials + "','" + DateTime.UtcNow + "','Have open door')";
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
            else
            {
                Dispatcher.BeginInvoke((Action)(() => output.Items.Add("ID Not Authorized")));
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
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            serialPort.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
            AddAcc add = new AddAcc(serialPort);
            add.Owner = this;
            add.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            add.ShowDialog();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            //serialPort.DiscardInBuffer();
            //serialPort.DiscardOutBuffer();
            //serialPort.Close();
            //serialPort.Open();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            serialPort.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
            RemoveAcc re = new RemoveAcc(serialPort);
            re.Owner = this;
            re.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            re.ShowDialog();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            //serialPort.DiscardInBuffer();
            //serialPort.DiscardOutBuffer();
            //serialPort.Close();
            //serialPort.Open();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            output.Items.Clear();
            output.Items.Add("Connected to " + serialPort.PortName);
        }

        private void showLog_Click(object sender, RoutedEventArgs e)
        {
            Log log = new Log();
            log.Owner = this;
            log.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            log.ShowDialog();
        }

        private void showAccounts_Click(object sender, RoutedEventArgs e)
        {
            showacc show = new showacc();
            show.Owner = this;
            show.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            show.ShowDialog();
        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                connect.Content = "Connect";
                output.Items.Clear();
                output.Items.Add("Disconnected");
                output.Items.Add("Select a COM port and Connect");
                clear.IsEnabled = false;
                dropdown.IsEnabled = false;
                comPorts.IsEnabled = true;
            }
            else
            {
                try
                {
                    serialPort.PortName = comPorts.SelectedItem.ToString();
                    serialPort.BaudRate = 9600;
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.DataBits = 8;
                    serialPort.Handshake = Handshake.None;
                    serialPort.Open();

                    connect.Content = "Disconnect";
                    output.Items.Clear();
                    output.Items.Add("Connected to " + serialPort.PortName);
                    clear.IsEnabled = true;
                    dropdown.IsEnabled = true;
                    comPorts.IsEnabled = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void main_Loaded(object sender, RoutedEventArgs e)
        {
            string[] ports = new string[SerialPort.GetPortNames().Length];
            ports = SerialPort.GetPortNames();
            int i = 0;
            foreach (var item in SerialPort.GetPortNames())
            {
                comPorts.Items.Add(ports[i]);
                i++;
            }            
        }
    }
}
