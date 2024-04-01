namespace FlyweightDesignPattern.Models;

using System.Text;

public class Book
{
    private readonly string _name;
    private readonly double _price;
    private readonly BookType _bookType;

    public Book(
        string name,
        double price,
        BookType bookType)
    {
        this._name = name;
        this._price = price;
        this._bookType = bookType;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb
            .AppendLine($"{this._name}")
            .AppendLine($"{this._price}")
            .AppendLine($"{this._bookType}");

        return sb.ToString().TrimEnd();
    }
}