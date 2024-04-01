namespace FlyweightDesignPattern.Factories;

using Models;

public class BookFactory
{
    private static readonly Dictionary<string, BookType> _bookTypes
        = new Dictionary<string, BookType>();

    public static BookType GetBookType(string type, string distributor, string data)
    {
        if (!_bookTypes.ContainsKey(type))
        {
            _bookTypes.Add(type, new BookType(type, distributor, data));
        }

        return _bookTypes[type];
    }
}