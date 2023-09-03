namespace BinomialHeap;

public interface IBinomialHeap<T>
{
    public void Insert(T value);
    public T Minimum();
    public void Merge(BinomialHeapImplementation<T> heap);
    public T ExtractMin();
    public void Delete(Node<T> node);
    public void DecreaseKey(Node<T> node, T newValue);
}