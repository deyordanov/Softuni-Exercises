int[] lengths = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
HashSet<double> one = new HashSet<double>();
HashSet<double> two = new HashSet<double>();
for(int i = 0; i < lengths[0]; i++)
{
    one.Add(int.Parse(Console.ReadLine()));
}
for(int i = 0; i < lengths[1]; i++)
{
    two.Add(int.Parse(Console.ReadLine()));
}
one.IntersectWith(two);
Console.WriteLine(string.Join(" ", one));