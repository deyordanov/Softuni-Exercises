using System.Text;

namespace PrototypeDesignPattern.Vehicles;

public class Bus : Vehicle
{
    private readonly int _doorsCount;
    public Bus(
        string brand,
        string model,
        string color,
        int doorsCount)
        : base(
            brand,
            model,
            color)
    {
        this._doorsCount = doorsCount;
    }

    private Bus(Bus vehicle)
        : base(vehicle)
    {
        this._doorsCount = vehicle._doorsCount;
    }

    public override Vehicle Clone()
        => new Bus(this);

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();


        sb
            .AppendLine(base.ToString())
            .AppendLine($"Doors Count: {this._doorsCount}");

        return sb
            .ToString()
            .TrimEnd();
    }
}