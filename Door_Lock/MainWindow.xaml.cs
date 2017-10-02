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
            output.Items.Add("Select a COM port and Connect");

            clear.IsEnabled = false;
            dropdown.IsEnabled = false;

            serialPort = new SerialPort();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                        
        }

        ~MainWindow()
        {
            serialPort.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.Close();
        }
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {            
            string data = serialPort.ReadLine();
            if (db.checkID(data))
            {
                data = data.Replace("\r", "");
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => this.output.Items.Add("ID: " + data)));
                serialPort.WriteLine("A");
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => this.output.Items.Add("ID Not Available")));
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
            output.Items.Clear();
            output.Items.Add("Connected to " + serialPort.PortName);

        }

        private void showLog_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void showAccounts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                connect.Content = "Connect";
                output.Items.Add("Disconnected");
                clear.IsEnabled = false;
                dropdown.IsEnabled = false;

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
