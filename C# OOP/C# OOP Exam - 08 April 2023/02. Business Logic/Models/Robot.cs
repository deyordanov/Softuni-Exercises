namespace RobotService.Models;

using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Utilities.Messages;

public abstract class Robot : IRobot
{
    private string model;
    private int batteryCapacity;
    private int batteryLevel;
    private int convertionCapacityIndex;
    private List<int> interfaceStandards;

    public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
    {
        this.Model = model;
        this.BatteryCapacity = batteryCapacity;
        this.convertionCapacityIndex = conversionCapacityIndex;
        this.batteryLevel = batteryCapacity;
        interfaceStandards = new List<int>();
    }

    public string Model
    {
        get => this.model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
            }

            this.model = value;
        }
    }

    public int BatteryCapacity
    {
        get
        {
            if (this.batteryCapacity < 0)
            {
                throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
            }

            return this.batteryCapacity;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
            }

            this.batteryCapacity = value;
        }
    }

    public int BatteryLevel => this.batteryLevel;
    public int ConvertionCapacityIndex => this.convertionCapacityIndex;
    public IReadOnlyCollection<int> InterfaceStandards => this.interfaceStandards.AsReadOnly();
    public void Eating(int minutes)
    {
        int energy = this.ConvertionCapacityIndex * minutes;
        this.batteryLevel += energy;
        if (this.batteryLevel > this.BatteryCapacity)
        {
            this.batteryLevel = this.BatteryCapacity;
        }
    }

    public void InstallSupplement(ISupplement supplement)
    {
        this.interfaceStandards.Add(supplement.InterfaceStandard);
        this.BatteryCapacity -= supplement.BatteryUsage;
        this.batteryLevel -= supplement.BatteryUsage;
    }

    public bool ExecuteService(int consumedEnergy)
    {
        int energy = this.batteryLevel - consumedEnergy;
        if (energy >= 0)
        {
            this.batteryLevel -= consumedEnergy;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string sups = this.interfaceStandards.Count == 0 ? "none" : string.Join(" ", this.interfaceStandards);

        sb.AppendLine($"{this.GetType().Name} {this.Model}:");
        sb.AppendLine($"--Maximum battery capacity: {this.BatteryCapacity}");
        sb.AppendLine($"--Current battery level: {this.BatteryLevel}");
        sb.AppendLine($"--Supplements installed: {sups}");

        return sb.ToString().TrimEnd();
    }
}