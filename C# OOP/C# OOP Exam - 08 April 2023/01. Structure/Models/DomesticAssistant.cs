namespace RobotService.Models;

public class DomesticAssistant : Robot
{
    private const int batteryCapacity = 20000;
    private const int conversionCapacityIndex = 2000;
    public DomesticAssistant(string model) : base(model, batteryCapacity, conversionCapacityIndex)
    {
    }
}