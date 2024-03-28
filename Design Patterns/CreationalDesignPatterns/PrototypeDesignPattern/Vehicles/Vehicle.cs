namespace PrototypeDesignPattern.Vehicles;

using System.Text;

public abstract class Vehicle
{
    private readonly string _brand;
    private readonly string _model;
    private readonly string _color;

    protected Vehicle(
        string brand, 
        string model,
        string color)
    {
        this._brand = brand;
        this._model = model;
        this._color = color;
    }

    protected Vehicle(Vehicle vehicle)
    {
        this._brand = vehicle._brand;
        this._model = vehicle._model;
        this._color = vehicle._color;
    }

    public abstract Vehicle Clone();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb
            .AppendLine($"Brand: {this._brand}")
            .AppendLine($"Model: {this._model}")
            .AppendLine($"Color: {this._color}");

        return sb
            .ToString()
            .TrimEnd();
    }
}