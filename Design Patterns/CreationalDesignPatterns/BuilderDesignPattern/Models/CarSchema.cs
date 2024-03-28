using System.Text;

namespace BuilderDesignPattern.Models;

public class CarSchema
{
    private readonly int _id;
    private readonly string _brand;
    private readonly string _model;
    private readonly string _color;
    private readonly string _engine;
    private readonly string _horsepower;

    public CarSchema(
        int id,
        string brand,
        string model,
        string color,
        string engine,
        string horsepower)
    {
        _id = id;
        _brand = brand;
        _model = model;
        _color = color;
        _engine = engine;
        _horsepower = horsepower;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb
            .AppendLine($"Car id: {_id}")
            .AppendLine($"Car brand: {_brand}")
            .AppendLine($"Car model: {_model}")
            .AppendLine($"Car color: {_color}")
            .AppendLine($"Car engine: {_engine}")
            .AppendLine($"Car horsepower: {_horsepower}");

        return sb
            .ToString()
            .TrimEnd();
    }
}