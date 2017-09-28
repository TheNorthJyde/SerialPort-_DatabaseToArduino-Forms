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
            serialPort = new SerialPort("COM4", 9600);
            comPorts.Text = "Select a COMPort";
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort.Open();
        }
        ~MainWindow()
        {
            serialPort.Close();
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string testString = null;
            string indata = sp.ReadLine();
            if (indata.Length >= 4)
            {
                testString = indata.Substring(0, 4);
                // Update the value
                //if (testString == "x1-1") EllipseBrush = Brushes.Blue;
                //else EllipseBrush = Brushes.Red;
            }
            Console.Write(testString);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
