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
        public MainWindow()
        {
            InitializeComponent();
            comPorts.Text = Comport.comPort;
            serialPort = new SerialPort("COM4", 9600);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort.Open();
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string testString = null;
            testString = serialPort.ReadLine();
            output.Items.Add(testString);
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

        }
    }
}
