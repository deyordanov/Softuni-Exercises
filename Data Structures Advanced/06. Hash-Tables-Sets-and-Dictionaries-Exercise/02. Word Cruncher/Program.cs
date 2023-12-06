using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
    using System.Text;

    class Program
    {
        static void Main()
        {
            string[] syllables = Console.ReadLine()!
                .Split(", ");

            string targetWord = Console.ReadLine();

            Cruncher cruncher = new Cruncher(syllables, targetWord);

            Console.WriteLine(string.Join(Environment.NewLine, cruncher.GetSyllablePaths()));
        }

        class Cruncher
        {
            private class Node
            {
                public Node(string syllable, List<Node> nextSyllables)
                {
                    this.Syllable = syllable;
                    this.NextSyllables = nextSyllables;
                }

                public List<Node> NextSyllables { get; set; }

                public string Syllable { get; set; }
            }

            private List<Node> syllableGroups;

            public Cruncher(string[] syllables, string targetWord)
            {
                this.syllableGroups = this.GenerateSyllableGroups(syllables, targetWord);
            }

            private List<Node> GenerateSyllableGroups(string[] syllables, string targetWord)
            {
                if (string.IsNullOrWhiteSpace(targetWord))
                {
                    return null;
                }

                List<Node> result = new List<Node>();

                for (int i = 0; i < syllables.Length; i++)
                {
                    string syllable = syllables[i];
                    if (targetWord.StartsWith(syllable))
                    {
                        List<Node> nextSyllables = this.GenerateSyllableGroups(
                            syllables.Where((s, index) => index != i).ToArray(),
                            targetWord.Substring(syllable.Length));

                        result.Add(new Node(syllable, nextSyllables));
                    }
                }

                return result;
            }

            public IEnumerable<string> GetSyllablePaths()
            {
                List<List<string>> allPaths = new List<List<string>>();

                this.GenerateAllPaths(this.syllableGroups, new List<string>(), allPaths);

                return new HashSet<string>(allPaths.Select(x => string.Join(" ", x)));
            }

            private void GenerateAllPaths(List<Node> syllableGroups, List<string> currentPath, List<List<string>> allPaths)
            {
                if (syllableGroups == null)
                {
                    allPaths.Add(new List<string>(currentPath));
                    return;
                }

                foreach (Node node in syllableGroups)
                {
                    currentPath.Add(node.Syllable);

                    this.GenerateAllPaths(node.NextSyllables, currentPath, allPaths);

                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }
    }
}
