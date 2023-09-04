namespace DoubleEndedQueue;

public interface IDoubleEndedQueue<T> : IEnumerable<T>
{
    void AddFirst(T item);
    void AddLast(T item);
    T RemoveFirst();
    T RemoveLast();
    bool Contains(T item);
}