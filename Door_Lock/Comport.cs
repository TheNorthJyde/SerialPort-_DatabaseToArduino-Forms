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
        public static string comPort = "Select a COMPort";

        public Comport()
        {
            serialPort = new SerialPort("COM4", 9600);
            
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
            testString = serialPort.ReadLine();

            
        }
    }
}
