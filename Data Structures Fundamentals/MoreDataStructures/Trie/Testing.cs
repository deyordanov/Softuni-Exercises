namespace Trie
{
    internal class Testing
    {
        static void Main(string[] args)
        {
            TrieImplementation trie = new TrieImplementation();
            trie.Insert("apple");
            trie.Insert("appetite");
            trie.Insert("applied");
            trie.Insert("bat");
            trie.Insert("ball");

            List<string> suggestions = trie.AutoComplete("app").ToList();
            Console.WriteLine(string.Join(Environment.NewLine, suggestions));
            // suggestions will contain ["apple", "appetite", "applied"]
        }
    }
}