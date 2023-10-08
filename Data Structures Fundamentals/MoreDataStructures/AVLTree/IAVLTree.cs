// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
namespace AVLTree;

public interface IAVLTree<T>
    where T : IComparable<T>
{
    void Insert(T value);
    void Delete(T value);
    bool Search(T value);
    T GetMinValue(CustomAVLTree<T>.Node node);
    T GetMaxValue(CustomAVLTree<T>.Node node);
    IEnumerable<T> PreOrderTraversal();
    IEnumerable<T> InOrderTraversal();
    IEnumerable<T> PostOrderTraversal();
    IEnumerable<T> BFS();
}