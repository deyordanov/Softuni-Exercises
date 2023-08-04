namespace RobotService.Models;

public class IndustrialAssistant : Robot
{
    private const int batteryCapacity = 40000;
    private const int conversionCapacityIndex = 5000;
    public IndustrialAssistant(string model) : base(model, batteryCapacity, conversionCapacityIndex)
    {
    }
}