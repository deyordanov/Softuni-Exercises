namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            int row = 1;
            using StreamReader reader = new StreamReader(inputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);
            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                int[] info = Check(line);
                int letters = info[0];
                int punctuation = info[1];
                writer.WriteLine($"Line {row++}: {line} ({letters})({punctuation})");
            }
        }

        private static int[] Check(string text)
        {
            int letters = 0;
            int punctuation = 0;
            string[] words = text.Split(" ");
            foreach(string word in words)
            {
                foreach(char letter in word)
                {
                    if (char.IsLetter(letter))
                    {
                        letters++;
                    }
                    else if (char.IsPunctuation(letter))
                    {
                        punctuation++;
                    }
                }
            }
            return new int[] { letters, punctuation};
        }
    }
}
