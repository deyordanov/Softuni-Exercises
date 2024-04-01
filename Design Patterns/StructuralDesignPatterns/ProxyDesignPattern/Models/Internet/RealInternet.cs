namespace ProxyDesignPattern.Models.Internet;

using Contracts;

public class RealInternet : IInternet
{
    public void ConnectTo(string host)
    {
        Console.WriteLine($"Successfully opened a connection to {host}");
    }
}