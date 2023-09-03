// ReSharper disable SwapViaDeconstruction
namespace BinomialHeap;

public class Node<T>
{
    public Node(T value)
    {
        this.Value = value;
        this.Children = new List<Node<T>>();
    }

    public T Value { get; set; }
    public int Degree { get; set; }
    public Node<T> Parent { get; set; }
    public List<Node<T>> Children { get; set; }
}

public class BinomialHeapImplementation<T> : IBinomialHeap<T>
    where T : IComparable<T>
{
    private List<Node<T>> forest;

    public BinomialHeapImplementation()
    {
        this.forest = new List<Node<T>>();
    }

    public void Insert(T value)
    {
        BinomialHeapImplementation<T> newHeap = new BinomialHeapImplementation<T>();
        newHeap.forest.Add(new Node<T>(value));
        this.Merge(newHeap);
    }

    public T Minimum()
    {
        if (!this.forest.Any()) throw new InvalidOperationException();

        return this.forest.Min(t => t.Value);
    }

    public void Merge(BinomialHeapImplementation<T> heap)
    {
        this.forest = this.Union(this.forest, heap.forest);
        heap.forest.Clear();
    }

    private List<Node<T>> Union(List<Node<T>> forest1, List<Node<T>> forest2)
    {
        List<Node<T>> newForest = new List<Node<T>>(forest1.Concat(forest2).OrderBy(t => t.Degree));
        int i = 0;
        //Since we want to compare two neighbouring nodes and the index have to be valid we iterate till newForest.Count - 1 
        while (i < newForest.Count - 1)
        {
            //We need to merge binomial trees of the same degree, if they differ -> we continue to the next pair;
            if (newForest[i].Degree != newForest[i + 1].Degree)
            {
                i++;
                continue;
            }

            //We are implemented a min-binomial heap
            Node<T> smaller = newForest[i].Value.CompareTo(newForest[i + 1].Value) < 0 ? newForest[i] : newForest[i + 1];
            Node<T> greater = smaller == newForest[i] ? newForest[i + 1] : newForest[i];

            smaller.Children.Add(greater);
            greater.Parent = smaller;
            smaller.Degree++;

            //Removing the tree that had been merged into the other one
            newForest.Remove(greater);

            //We do not increment i because the next node might of the same degree as the one we just merged
        }

        return newForest;
    }

    public T ExtractMin()
    {
        if (!this.forest.Any()) throw new InvalidOperationException();

        Node<T> minTree = this.forest[this.forest.FindIndex(t => t.Value.Equals(this.Minimum()))];

        this.Delete(minTree);

        return minTree.Value;
    }

    public void Delete(Node<T> node)
    {
        if (!this.forest.Any()) throw new InvalidOperationException();

        this.forest.Remove(node);

        this.forest = this.Union(this.forest, node.Children);
    }

    public void DecreaseKey(Node<T> node, T newValue)
    {
        if(newValue.CompareTo(node.Value) >= 0) throw new InvalidOperationException();

        node.Value = newValue;

        while (node.Parent != null && node.Value.CompareTo(node.Parent.Value) < 0)
        {
            T temp = node.Value;
            node.Value = node.Parent.Value;
            node.Parent.Value = temp;

            node = node.Parent;
        }
    }
}