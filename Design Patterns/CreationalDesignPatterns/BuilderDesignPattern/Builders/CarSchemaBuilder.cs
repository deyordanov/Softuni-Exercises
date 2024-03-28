using BuilderDesignPattern.Builders.Contracts;
using BuilderDesignPattern.Models;

namespace BuilderDesignPattern.Builders;

public class CarSchemaBuilder : IBuilder
{
    private int _id;
    private string _brand;
    private string _model;
    private string _color;
    private string _engine;
    private string _horsepower;

    public IBuilder Id(int id)
    {
        this._id = id;
        return this;
    }

    public IBuilder Brand(string brand)
    {
        this._brand = brand;
        return this;
    }

    public IBuilder Model(string model)
    {
        this._model = model;
        return this;
    }

    public IBuilder Color(string color)
    {
        this._color = color;
        return this;
    }

    public IBuilder Engine(string engine)
    {
        this._engine = engine;
        return this;
    }

    public IBuilder Horsepower(string horsepower)
    {
        this._horsepower = horsepower;
        return this;
    }

    public CarSchema Build()
        => new CarSchema(
            this._id,
            this._brand,
            this._model,
            this._color,
            this._engine,
            this._horsepower);
}