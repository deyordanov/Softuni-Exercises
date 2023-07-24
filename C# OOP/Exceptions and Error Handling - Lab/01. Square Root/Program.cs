int number = int.Parse(Console.ReadLine());

try
{
    Console.WriteLine(CalculateSquareRoot(number));
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}

int CalculateSquareRoot(int num)
{
    if (num < 0)
    {
        throw new ArgumentException("Invalid number.");
    }

    return (int)Math.Sqrt(num);
}