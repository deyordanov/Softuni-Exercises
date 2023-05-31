string[] people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string, string> select = x => $"Sir {x}";
Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x.Select(select)));
print(people);