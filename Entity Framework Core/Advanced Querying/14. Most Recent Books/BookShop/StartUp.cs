namespace BookShop
{
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);

            Console.WriteLine(GetMostRecentBooks(context));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories  = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate!.Value)
                        .Select(b => new 
                        {
                            b.Book.Title,
                            Year = b.Book.ReleaseDate!.Value.Year,
                        })
                        .Take(3)
                        .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                sb.AppendLine(string.Join(Environment.NewLine, category.Books.Select(b => $"{b.Title} ({b.Year})")));
            }

            return sb.ToString().TrimEnd();
        }
    }
}