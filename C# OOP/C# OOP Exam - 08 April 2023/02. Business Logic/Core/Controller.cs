namespace RobotService.Core;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Models;
using Models.Contracts;
using Repositories;
using Repositories.Contracts;
using Utilities.Messages;

public class Controller : IController
{
    private IRepository<ISupplement> supplements;
    private IRepository<IRobot> robots;

    public Controller()
    {
        this.supplements = new SupplementRepository();
        this.robots = new RobotRepository();
    }
    public string CreateRobot(string model, string typeName)
    {
        if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
        {
            return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
        }

        IRobot robot = null;
        if (typeName == nameof(DomesticAssistant))
        {
            robot = new DomesticAssistant(model);
        }
        else if (typeName == nameof(IndustrialAssistant))
        {
            robot = new IndustrialAssistant(model);
        }

        this.robots.AddNew(robot);
        return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
    }

    public string CreateSupplement(string typeName)
    {
        if (typeName != nameof(LaserRadar) && typeName != nameof(SpecializedArm))
        {
            return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
        }

        ISupplement supplement = null;
        if (typeName == nameof(LaserRadar))
        {
            supplement = new LaserRadar();
        }
        else if (typeName == nameof(SpecializedArm))
        {
            supplement = new SpecializedArm();
        }

        this.supplements.AddNew(supplement);
        return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
    }

    public string UpgradeRobot(string model, string supplementTypeName)
    {
        ISupplement supplement = this.supplements.Models().First(s => s.GetType().Name == supplementTypeName);
        List<IRobot>  needUpgrade = this.robots.Models().Where(r => !r.InterfaceStandards.Contains(supplement.InterfaceStandard) && r.Model == model).ToList();

        if (!needUpgrade.Any())
        {
            return string.Format(OutputMessages.AllModelsUpgraded, model);
        }

        IRobot toBeUpgraded = needUpgrade.First();
        toBeUpgraded.InstallSupplement(supplement);
        this.supplements.RemoveByName(supplement.GetType().Name);

        return string.Format(OutputMessages.UpgradeSuccessful, model, supplement.GetType().Name);
    }

    public string RobotRecovery(string model, int minutes)
    {
        List<IRobot> toBeFed = this.robots.Models().Where(r => r.Model == model && r.BatteryLevel <
            (r.BatteryCapacity * 0.5)).ToList();

        foreach (IRobot robot in toBeFed)
        {
            robot.Eating(minutes);
        }

        return string.Format(OutputMessages.RobotsFed, toBeFed.Count());
    }

    public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
    {
        List<IRobot> neededRobots = this.robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).OrderByDescending(r => r.BatteryLevel).ToList();

        if (!neededRobots.Any())
        {
            return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
        }

        int batteryLevelSum = neededRobots.Sum(r => r.BatteryLevel);

        if (batteryLevelSum < totalPowerNeeded)
        {
            return string.Format(OutputMessages.MorePowerNeeded, serviceName, (totalPowerNeeded - batteryLevelSum));
        }

        int counter = 0;
        foreach (IRobot robot in neededRobots)
        {
            if (robot.BatteryLevel >= totalPowerNeeded)
            {
                robot.ExecuteService(totalPowerNeeded);
                counter++;
                break;
            }
            else
            {
                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(robot.BatteryLevel);
                counter++;
            }
        }

        return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
    }

    public string Report()
    {
        StringBuilder sb = new StringBuilder();
        foreach (IRobot robot in this.robots.Models().OrderByDescending(r => r.BatteryLevel)
                     .ThenBy(r => r.BatteryCapacity))
        {
            sb.AppendLine(robot.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}