namespace PrototypeDesignPattern.Vehicles;

using System.Text;

public class Car : Vehicle
{
    private readonly string _topSpeed;

    public Car(
        string brand,
        string model,
        string color,
        string topSpeed)
        : base(
            brand,
            model,
            color)
    {
        this._topSpeed = topSpeed;
    }

    public Car(Car vehicle)
        : base(vehicle)
    {
        this._topSpeed = vehicle._topSpeed;
    }

    public override Vehicle Clone()
        => new Car(this);

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();


        sb
            .AppendLine(base.ToString())
            .AppendLine($"Top Speed: {this._topSpeed}");

        return sb
            .ToString()
            .TrimEnd();
    }
}