namespace FlyweightDesignPattern.Models;

public class Store
{
    private readonly List<Book> _books;

    public Store()
    {
        this._books = new List<Book>();
    }

    public void StoreBook(
        string name,
        double price,
        string type,
        string distributor,
        string data)
    {
        BookType bookType = new BookType(type, distributor, data);
        this._books.Add(new Book(name, price, bookType));
    }

    public void DisplayBooks()
    {
        foreach (Book book in this._books)
        {
            Console.WriteLine("<======================>");
            Console.WriteLine($"{book}");
            Console.WriteLine("<======================>");
        }
    }
}