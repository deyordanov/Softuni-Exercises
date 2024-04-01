using FlyweightDesignPattern.Models;

int bookTypes = 2;
int booksToInsert = 100;

Store store = new Store();
for (int i = 0; i < booksToInsert / bookTypes; i++)
{
    store.StoreBook("book1", 10, "Action", "Follett", "Stuff");
    store.StoreBook("book2", 20, "Fantasy", "Ingram", "Extra");
}
store.DisplayBooks();
Console.WriteLine($"{booksToInsert} Books Inserted");
Console.WriteLine("==========================================");
Console.WriteLine("Memory Usage: ");
Console.WriteLine($"Book Size (20 bytes) * {booksToInsert} + BookTypes Size (30 bytes) * {bookTypes}");
Console.WriteLine("==========================================");
Console.WriteLine($"Total: {(booksToInsert * 20 + bookTypes * 30) / 1024.0 / 1024.0}MB (instead of {(booksToInsert * 50) / 1024.0 / 1024.0}MB)");