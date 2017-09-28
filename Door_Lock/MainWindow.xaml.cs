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


namespace Door_Lock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort;
        database db;
        public MainWindow()
        {
            InitializeComponent();
            db = new database();

            comPorts.Items.Add("Select a COMPort");
            
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                        
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            
            
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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void showLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void showAccounts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            if(!serialPort.IsOpen)
            {
                
            }
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                connect.Content = "Connect";
                output.Items.Add("Disconnected");

                
            }
            else
            {
                try
                {
                    serialPort.PortName = comPorts.SelectedItem.ToString();
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.DataBits = 8;
                    serialPort.Handshake = Handshake.None;
                    serialPort.Open();

                    connect.Content = "Disconnect";
                    output.Items.Clear();
                    output.Items.Add("Connected to " + serialPort.PortName);

                    
                }
                catch (Exception exc)
                {
                    output.Items.Add("Error:");
                    output.Items.Add(exc.Message);
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
