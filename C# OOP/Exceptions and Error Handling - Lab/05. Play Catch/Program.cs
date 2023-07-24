int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int exceptionsCaught = 0;
while (exceptionsCaught < 3)
{
    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    try
    {
        if (command[0] == "Replace")
        {
            int idx = int.Parse(command[1]);
            int element = int.Parse(command[2]);
            ValidateIndexes(idx);

            numbers[idx] = element;
        }
        else if (command[0] == "Print")
        {
            int idx1 = int.Parse(command[1]);
            int idx2 = int.Parse(command[2]);
            ValidateIndexes(idx1);
            ValidateIndexes(idx2);

            Console.WriteLine(string.Join(", ", numbers.Skip(idx1).Take(idx2 - idx1 + 1)));
        }
        else if (command[0] == "Show")
        {
            int idx = int.Parse(command[1]);
            ValidateIndexes(idx);
            Console.WriteLine(numbers[idx]);
        }
    }
    catch (FormatException fe)
    {
        exceptionsCaught++;
        Console.WriteLine("The variable is not in the correct format!");
    }
    catch (ArgumentException ae)
    {
        exceptionsCaught++;
        Console.WriteLine(ae.Message);
    }
}

Console.WriteLine(string.Join(", ", numbers));

void ValidateIndexes(int idx)
{
    if (idx < 0 || idx >= numbers.Length)
    {
        throw new ArgumentException("The index does not exist!");

    }
}