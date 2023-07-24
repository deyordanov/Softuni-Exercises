List<int> validNumbers = new List<int>();
while (validNumbers.Count < 10)
{
    string input = Console.ReadLine();
    try
    {
        if(!input.All(c => char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid Number!");
        }

        int number = int.Parse(input);

        if (number <= 1 || number >= 100)
        {
            throw new ArgumentException("Your number is not in range (1 - 100)");
        }

        validNumbers.Add(number);
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(ae.Message);
    }
}

Console.WriteLine(string.Join(", ", validNumbers));