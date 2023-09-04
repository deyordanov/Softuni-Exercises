namespace Trie;

using System.Text;

public class TrieImplementation : ITrie
{
    private class TrieNode
    {
        public TrieNode()
        {
            this.Children = new Dictionary<char, TrieNode>();
        }

        public Dictionary<char, TrieNode> Children { get; private set; }
        public bool IsEndOfWord { get; set; }
    }

    private TrieNode root;

    public TrieImplementation()
    {
        this.root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode currentNode = this.root;

        foreach (char letter in word)
        {
            if (!currentNode.Children.ContainsKey(letter))
            {
                currentNode.Children.Add(letter, new TrieNode());
            }

            currentNode = currentNode.Children[letter];
        }

        currentNode.IsEndOfWord = true;
    }

    public bool Search(string prefix)
    {
        TrieNode? node = this.FindNode(prefix);
        return node != null && node.IsEndOfWord;
    }

    private TrieNode? FindNode(string prefix)
    {
        TrieNode currentNode = this.root;

        foreach (char letter in prefix)
        {
            if (currentNode.Children.TryGetValue(letter, out TrieNode? child))
            {
                currentNode = child;
            }
            else
            {
                return null;
            }
        }

        return currentNode;
    }

    public bool StartsWith(string prefix)
        => this.FindNode(prefix) != null;

    public bool Delete(string word)
        => this.DeleteRecursively(this.root, word, 0);

    private bool DeleteRecursively(TrieNode node, string word, int index)
    {
        if (index == word.Length)
        {
            if (node.IsEndOfWord)
            {
                node.IsEndOfWord = false;
                return node.Children.Count == 0;
            }

            return false;
        }

        char letter = word[index];

        if (!node.Children.ContainsKey(letter))
        {
            return false;
        }

        bool shouldDelete = this.DeleteRecursively(node.Children[letter], word, index + 1);

        if (shouldDelete)
        {
            node.Children.Remove(letter);

            return node.Children.Count == 0 && !node.IsEndOfWord;
        }

        return false;
    }

    public IEnumerable<string> AutoComplete(string prefix)
    {
        List<string> words = new List<string>();

        TrieNode node = this.FindNode(prefix);

        if (node != null)
        {
            DFS(node, prefix, words);
        }

        return words;
    }

    private void DFS(TrieNode node, string currentPrefix, List<string> words)
    {
        if (node.IsEndOfWord)
        {
            words.Add(currentPrefix);
        }

        foreach (var pair in node.Children)
        {
            DFS(pair.Value, currentPrefix + pair.Key, words);
        }
    }
}