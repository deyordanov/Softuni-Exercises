Func<double, double> vat = x => x += x * 0.2;
Func<double, string> func = x => $"{x:F2}";

double[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .Select(vat)
    .ToArray();

Console.WriteLine(string.Join(Environment.NewLine, numbers.Select(func)));