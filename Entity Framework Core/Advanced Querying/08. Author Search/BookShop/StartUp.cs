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

            Console.WriteLine(GetAuthorNamesEndingIn(context, input));
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { a.FirstName, a.LastName })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName);

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


