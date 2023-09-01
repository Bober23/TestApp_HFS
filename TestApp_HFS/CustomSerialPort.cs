using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace TestApp_HFS
{
     class CustomSerialPort:SerialPort
     {
        public CustomSerialPort(string port)
            : base()
        {
            base.PortName = port;
            base.BaudRate = 9600;
            base.DataBits = 8;
            base.StopBits = StopBits.One;
            base.Parity = Parity.None;
            base.ReadTimeout = 1000;

            base.DataReceived += SerialPort_DataReceived;
        }
        public void Open()
        {
            if (base.IsOpen)
            {
                base.Close();
            }
            base.Open();
        }
        public void Print(byte[] massive)
        {
            foreach (byte b in massive)
            {
                Console.Write(b);
            }

        }
        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var port = (SerialPort)sender;
            try
            {
                if (port.BytesToRead > 0)
                {
                    byte[] answer = new byte[(int)port.BytesToRead];
                    port.Read(answer, 0, port.BytesToRead);
                    Print(answer);
                }
            }
            catch { }
            
        }
    }
}
