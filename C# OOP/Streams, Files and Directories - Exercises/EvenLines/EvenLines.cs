namespace EvenLines;

using System;
using System.IO;
using System.Linq;
using System.Text;

public class EvenLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\text.txt";

        Console.WriteLine(ProcessLines(inputFilePath));
    }

    public static string ProcessLines(string inputFilePath)
    {
        StringBuilder sb = new StringBuilder();
        int row = 1;
        using StreamReader reader = new StreamReader(inputFilePath);
        while(!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            line = Replace(line);
            line = Reverse(line);
            if(row++ % 2 != 0)
            {
                sb.AppendLine(line);
            }
        }
        return sb.ToString();
    }

    private static string Replace(string text)
    {
        StringBuilder sb = new StringBuilder(text);
        char[] symbolToReplace = new char[] { '-', ',','.', '!', '?' };
        foreach(char symbol in symbolToReplace)
        {
            sb.Replace(symbol, '@');
        }
        return sb.ToString();
    }

    private static string Reverse(string text)
    {
        string[] reversed = text.Split(" ").Reverse().ToArray();
        return new string(string.Join(" ", reversed));
    }
}