namespace ProxyDesignPattern.Proxies;

using Models.Internet;
using Models.Internet.Contracts;

public class InternetProxy : IInternet
{
    private readonly List<string> _bannedWebsites;
    private readonly IInternet _internet;

    public InternetProxy()
    {
        this._bannedWebsites = new List<string>()
        {
            "banned.com",
            "danger.com",
            "warning.com",
        };
        this._internet = new RealInternet();
    }

    public void ConnectTo(string host)
    {
        if (this._bannedWebsites.Contains(host))
        {
            Console.WriteLine($"Access denied: {host}");
            return;
        }

        this._internet.ConnectTo(host);
    }
}