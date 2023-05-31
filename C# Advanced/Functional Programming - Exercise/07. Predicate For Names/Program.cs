int length = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Func<string, int, bool> filter = (name, length) => { return name.Length <= length ? true : false; };
Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => filter(x, length))));