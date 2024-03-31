namespace AdapterDesignPattern.Models;

using Contracts;
using Data;

public class MultiRestoApp : IMultiRestoApp
{
    public void DisplayMenus(XmlData data)
    {
        Console.WriteLine("Displaying the menus using XML data...");
    }

    public void DisplayRecommendations(XmlData data)
    {
        Console.WriteLine("Displaying the recommendations using XML data...");
    }
}