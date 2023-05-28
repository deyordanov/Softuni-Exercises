using System.IO;

namespace OddLines;
	
public class OddLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\Files\input.txt";
        string outputFilePath = @"..\..\..\Files\output.txt";

        ExtractOddLines(inputFilePath, outputFilePath);
    }

    public static void ExtractOddLines(string inputFilePath, string outputFilePath)
    {
        int row = 0;
        using(StreamReader reader = new StreamReader(inputFilePath))
        {
            using(StreamWriter writer = new StreamWriter(outputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();    
                    if (row++ % 2 != 0)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
        

    }
}
