namespace IteratorDesignPattern.Models;

public class Route
{
    public Route(
        string name, 
        int distance,
        int scenicValue,
        int trafficLevel)
    {
        this.Name = name;
        this.Distance = distance;
        this.ScenicValue = scenicValue;
        this.TrafficLevel = trafficLevel;
    }

    public string Name { get; set; }
    public int Distance { get; set; }
    public int ScenicValue { get; set; }
    public int TrafficLevel { get; set; }
}