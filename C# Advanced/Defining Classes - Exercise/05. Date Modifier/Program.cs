namespace DateeModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second  = Console.ReadLine();
            DateModifier date = new DateModifier();
            Console.WriteLine(date.CalculateDays(first, second));
        }
    }
}