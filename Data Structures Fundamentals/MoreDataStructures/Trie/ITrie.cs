namespace Trie;

public interface ITrie
{
    void Insert(string word);

    bool Search(string word);

    bool StartsWith(string prefix);

    bool Delete(string word);

    IEnumerable<string> AutoComplete(string prefix);
}