namespace FlyweightDesignPattern.Models;

using System.Text;

public class BookType
{
    private readonly string _type;
    private readonly string _distributor;
    private readonly string _data;

    public BookType(
        string type, 
        string distributor, 
        string data)
    {
        this._type = type;
        this._distributor = distributor;
        this._data = data;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb
            .AppendLine($"{this._type}")
            .AppendLine($"{this._distributor}")
            .AppendLine($"{this._distributor}");

        return sb.ToString().TrimEnd();
    }
}