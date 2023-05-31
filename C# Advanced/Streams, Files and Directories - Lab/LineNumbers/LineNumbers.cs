using System.IO;
using System;

namespace LineNumbers;
public class LineNumbers
{
    static void Main()
    {
        string inputPath = @"..\..\..\Files\input.txt";
        string outputPath = @"..\..\..\Files\output.txt";

        RewriteFileWithLineNumbers(inputPath, outputPath);
    }

    public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
    {
        int row = 0;
        using(StreamReader reader = new StreamReader(inputFilePath))
        {
            using(StreamWriter writer = new StreamWriter(outputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    writer.WriteLine($"{++row}. {reader.ReadLine()}");
                }
            }
        }
    }
}
