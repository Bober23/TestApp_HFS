// See https://aka.ms/new-console-template for more information
using System.IO.Ports;
using TestApp_HFS;
Console.WriteLine("Cписок доступных портов:");
string[] ports = SerialPort.GetPortNames();
string portName = null;
foreach (string availablePort in ports)
{
    Console.WriteLine(availablePort);
}
Console.WriteLine("Введите порт");
portName = Console.ReadLine();
while (ports.All(x => x != portName))
{
    Console.WriteLine("Неправильный порт");
    Console.WriteLine("Введите порт");
    portName = Console.ReadLine();
}

Console.WriteLine($"Чтобы начать чтение данных из порта {portName} нажмите Enter");
if (Console.ReadLine() == String.Empty)
{
    var port = new CustomSerialPort(portName);
    port.Open(portName);
}
while (true)
{
    //Отправка данных в NATS

}