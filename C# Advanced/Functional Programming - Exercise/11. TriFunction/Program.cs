int sum = int.Parse(Console.ReadLine());
string[] people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Func<int, string, bool> func = (int sum, string name) =>
{
    int charSum = 0;
    foreach(char letter in name)
    {
        charSum += letter;
    }
    return charSum >= sum ? true : false;
};

Print(people, func);

void Print(string[] people, Func<int, string, bool> function)
{
    Console.WriteLine(people.Where(x => function(sum ,x)).First());
}