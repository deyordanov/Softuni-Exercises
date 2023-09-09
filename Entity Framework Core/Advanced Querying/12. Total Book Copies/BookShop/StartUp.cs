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

            Console.WriteLine(CountCopiesByAuthor(context));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books
                        .Sum(b => b.Copies)
                })
                .ToArray()
                .OrderByDescending(b => b.TotalCopies); // This is optimization

            foreach (var a in books)
            {
                sb.AppendLine($"{a.FullName} - {a.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}