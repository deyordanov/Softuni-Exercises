string[] people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

print(people);