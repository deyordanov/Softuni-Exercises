namespace BookShop
{
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

            Console.WriteLine(GetBooksByCategory(context, input).Length);
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] genres = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(g => g.ToLower())
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories
                    .Any(c => genres.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }
    }
}


