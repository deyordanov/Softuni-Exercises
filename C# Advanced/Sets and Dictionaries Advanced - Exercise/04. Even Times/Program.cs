int n = int.Parse(Console.ReadLine());
Dictionary<int, int> result = new Dictionary<int, int>();
for(int i = 0; i < n; i++)
{
    int number = int.Parse(Console.ReadLine());
    if (!result.ContainsKey(number))
        result.Add(number, 0);
    result[number]++;
}

Console.WriteLine(string.Join(" ", result.Keys.Where(x => result[x] % 2 == 0)));