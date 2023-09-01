using System.IO.Ports;
using TestApp_HFS;
Console.WriteLine("Available ports:");
string[] ports = SerialPort.GetPortNames();
string portName = null;
foreach (string availablePort in ports)
{
    Console.WriteLine(availablePort);
}
Console.WriteLine("Input port name");
portName = Console.ReadLine();
while (ports.All(x => x != portName))
{
    Console.WriteLine("Incorrect port name");
    Console.WriteLine("Input port name");
    portName = Console.ReadLine();
}

Console.WriteLine($"Press Enter to start listening port {portName}");
if (Console.ReadLine() == string.Empty)
{
    var port = new CustomSerialPort(portName);
    port.Open();
}
while (true)
{
    //Отправка данных в NATS

}