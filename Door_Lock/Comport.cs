using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Door_Lock
{
    class Comport
    {
        SerialPort serialPort;

        public Comport()
        {
            serialPort = new SerialPort("COM4", 9600);
            comPorts.Text = "Select a COMPort";
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort.Open();
        }
        ~Comport()
        {
            serialPort.Close();
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            string testString = null;
            string indata = serialPort.ReadLine();

            
        }
    }
}
