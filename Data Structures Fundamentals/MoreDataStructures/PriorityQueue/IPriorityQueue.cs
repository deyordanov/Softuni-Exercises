namespace PriorityQueue;

public interface IPriorityQueue<T> : IEnumerable<T>
{
    void Enqueue(T item);
    T Dequeue();
    bool Contains(T item);
    T Peek();
}