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
        private const int DataSize = 1024;    //  я так и не понял, какой размер данных нужен. Укажите правильное число в байтах
        private byte[] _bufer = new byte[DataSize];
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
        //  открываем порт передав туда имя
        public void Open(string portName)
        {
            if (base.IsOpen)
            {
                base.Close();
            }
            base.PortName = portName;
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
