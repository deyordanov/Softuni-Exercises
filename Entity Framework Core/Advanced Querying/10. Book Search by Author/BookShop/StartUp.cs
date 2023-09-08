namespace BookShop
{
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);

            string input = Console.ReadLine()!;

            Console.WriteLine(GetBooksByAuthor(context, input));
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}


