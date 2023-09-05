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

            string date = Console.ReadLine()!;

            Console.WriteLine(GetBooksReleasedBefore(context, date));
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < parsedDate)
                .OrderByDescending(b => b.ReleaseDate!.Value)
                .Select(b => new { b.Title, b.EditionType, b.Price, ReleaseDate = b.ReleaseDate!.Value });

            foreach (var book in books)
            {
                Console.WriteLine(book.ReleaseDate);
                sb.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


