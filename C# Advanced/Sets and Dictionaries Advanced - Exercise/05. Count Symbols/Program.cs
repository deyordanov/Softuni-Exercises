char[] input = Console.ReadLine().ToCharArray();
SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
foreach (char symbol in input)
{
    if (!symbols.ContainsKey(symbol))
        symbols.Add(symbol, 0);
    symbols[symbol]++;
}
Console.WriteLine(string.Join(Environment.NewLine, symbols.Select(x => $"{x.Key}: {symbols[x.Key]} time/s")));