long rows = long.Parse(Console.ReadLine());
long[][] jagged = new long[rows][];
jagged[0] = new long[1] { 1 };
Console.WriteLine(1);
for (long row = 1; row < rows; row++)
{
    jagged[row] = new long[row + 1];
    for(long i = 0; i < jagged[row].Length; i++)
    {
        if(i - 1 < 0)
        {
            jagged[row][i] = jagged[row - 1][i];
        }
        else if(i >= jagged[row - 1].Length)
        {
            jagged[row][i] = jagged[row - 1][i - 1];
        }
        else
        {
            jagged[row][i] = jagged[row - 1][i] + jagged[row - 1][i - 1];
        }
    }
    Console.WriteLine(string.Join(" ", jagged[row]));
}