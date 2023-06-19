using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace _06.Word_Cruncher
{
    internal class Program
    {
        private static string target;
        private static Dictionary<int, List<string>> wordsByIdx;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            target = Console.ReadLine();

            wordsByIdx = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();

            foreach (string word in words)
            {
                int index = target.IndexOf(word);   
                if (!target.Contains(word))
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                    continue;
                }

                wordsCount[word] = 1;

                while (index != -1)
                {
                    if (!wordsByIdx.ContainsKey(index))
                    {
                        wordsByIdx.Add(index, new List<string>());
                    }

                    wordsByIdx[index].Add(word);    

                    index = target.IndexOf(word, index + 1);
                }
            }

            Generate(0);
        }

        public static void Generate(int index)
        {
            if (index == target.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }

            if (!wordsByIdx.ContainsKey((index)))
            {
                return;
            }

            foreach (string word in wordsByIdx[index])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word]--;
                usedWords.AddLast(word);

                Generate(index + word.Length);

                wordsCount[word]++;
                usedWords.RemoveLast();
            }
        }
    }
}
