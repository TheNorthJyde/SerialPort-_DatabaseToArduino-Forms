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
using System.Windows.Shapes;
using System.IO.Ports;

namespace Door_Lock
{
    /// <summary>
    /// Interaction logic for RemoveAcc.xaml
    /// </summary>
    public partial class RemoveAcc : Window
    {
        SerialPort myserialPort;

        extra database = new extra();

        private RemoveAcc()
        {

            InitializeComponent();
        }

        public RemoveAcc(SerialPort mySerialPort)
        {
            InitializeComponent();
            this.myserialPort = mySerialPort;
            myserialPort.DataReceived += MySerialPort_DataReceived;
            myserialPort.DiscardInBuffer();
            mySerialPort.DiscardOutBuffer();
            id.IsReadOnly = true;
        }

        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string ID = myserialPort.ReadLine();
                Dispatcher.BeginInvoke((Action)(() => id.AppendText(ID)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            if (database.checkID(id.Text))
            {
                extra.TextToBring = id.Text;
                RemoveAccWarning warning = new RemoveAccWarning();
                warning.Owner = this;
                warning.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                warning.ShowDialog();
                myserialPort.DataReceived -= MySerialPort_DataReceived;
                this.Close();
            }
            else
            {
                MessageBox.Show("This ID: " + id.Text + " is never used");
                id.Text = "";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myserialPort.DataReceived -= MySerialPort_DataReceived;
        }
    }
}
