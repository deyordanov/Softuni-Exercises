namespace DeepCopy.IO;

using Contracts;

public class ConsoleReader : IReader
{
    public string ReadLine()
        => Console.ReadLine();
}