namespace LeftistTree;

public interface ILeftistTree<T>
    where T : IComparable<T>
{
    bool IsEmpty();

    void Insert(T value);

    T FindMin();

    T DeleteMin();

    void Merge(LeftistTreeImplementation<T> node);
}