namespace CompositeDesignPattern.Products;

using Contracts;

public abstract class Product : IBox
{
    protected readonly string _title;
    protected readonly double _price;

    protected Product(
        string title, 
        double price)
    {
        this._title = title;
        this._price = price;
    }

    public double CalculatePrice()
    {
        return this._price;
    }
}