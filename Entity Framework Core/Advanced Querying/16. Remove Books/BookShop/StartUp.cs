namespace BookShop
{
    using System.Globalization;
    using System.Text;
    using BookShop.Models;
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

            Console.WriteLine(RemoveBooks(context));
            ;
        }

        public static int RemoveBooks(BookShopContext context)
        {
            Book[] books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Length;
        }
    }
}