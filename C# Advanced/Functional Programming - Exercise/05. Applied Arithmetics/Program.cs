using System.ComponentModel;

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Func<int, int> add = x => x += 1;
Func<int, int> multiply = x => x *= 2;
Func<int, int> subtract = x => x -= 1;
Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));
string end;
while((end = Console.ReadLine()) != "end")
{
    string command = end;
    switch (command)
    {
        case "add":
            numbers = numbers.Select(x => add(x)).ToArray();
            break;
        case "multiply":
            numbers = numbers.Select(x => multiply(x)).ToArray();
            break;
        case "subtract":
            numbers = numbers.Select(x => subtract(x)).ToArray();
            break;
        case "print":
            print(numbers);
            break;
    }
}