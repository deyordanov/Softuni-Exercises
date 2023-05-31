namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> occurances = new Dictionary<string, int>();
            using(StreamReader words = new StreamReader(wordsFilePath))
            {
                using (StreamReader text = new StreamReader(textFilePath))
                {
                    using (StreamWriter output = new StreamWriter(outputFilePath))
                    {
                        List<string> wordsToFind = words.ReadLine().Split(" ").ToList();
                        foreach(string word in wordsToFind)
                        {
                            if (!occurances.ContainsKey(word))
                            {
                                occurances.Add(word, 0);
                            }
                        }
                        while (!text.EndOfStream)
                        {
                            foreach(string word in text.ReadLine().Split(new[] { ' ', '.', ',', '-', '?', '!' }))
                            {
                                if (wordsToFind.Contains(word.ToLower()))
                                {
                                    occurances[word.ToLower()]++;
                                }
                            }
                        }
                        foreach(var occurance in occurances.OrderByDescending(x => x.Value))
                        {
                            output.WriteLine($"{occurance.Key} - {occurance.Value}");
                        }
                    }
                }
            }
        }
    }
}
