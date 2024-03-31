namespace AdapterDesignPattern.Models;

using Data;

public class FancyUiService
{
    public void DisplayMenus(JsonData data)
    {
        Console.WriteLine("Displaying the menus using JSON data...");
    }

    public void DisplayRecommendations(JsonData data)
    {
        Console.WriteLine("Displaying the recommendations using JSON data...");
    }
}