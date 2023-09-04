// ReSharper disable SwapViaDeconstruction
namespace LeftistTree;

public class LeftistNode<T>
{
    public LeftistNode(T value)
    {
        this.Value = value;
    }

    public T Value { get; set; }
    public LeftistNode<T>? LeftChild { get; set; }
    public LeftistNode<T>? RightChild { get; set; }
    public int NullPathValue { get; set; }
}

public class LeftistTreeImplementation<T> : ILeftistTree<T>
    where T : IComparable<T>
{
    private LeftistNode<T>? root;

    public bool IsEmpty()
        => this.root == null;

    public void Insert(T value)
    {
        this.root = this.Merge(this.root, new LeftistNode<T>(value));
    }

    public T FindMin()
    {
        if (this.IsEmpty()) throw new InvalidOperationException();
        //The smallest value is the root since we tree has min-heap properties
        return this.root.Value;
    }

    public T DeleteMin()
    {
        if(this.IsEmpty()) throw new InvalidOperationException();

        T value = this.root.Value;
        this.root = this.Merge(this.root.LeftChild, this.root.RightChild);
        return value;
    }

    public void Merge(LeftistTreeImplementation<T> tree)
    {
        if (this == tree) return;
        this.root = this.Merge(this.root, tree.root);
        tree.root = null;
    }

    private LeftistNode<T> Merge(LeftistNode<T>? x, LeftistNode<T>? y)
    {
        if (x == null) return y;
        if (y == null) return x;

        if (x.Value.CompareTo(y.Value) > 0)
        {
            //Making sure 'x' is the smaller root
            LeftistNode<T> temp = x;
            x = y;
            y = temp;
        }

        //The leftist tree excels at merging due to its right spine being a lot shorter, that is why we merge the second node with the right spine of the smaller root
        x.RightChild = this.Merge(x.RightChild, y);

        //We need to preserve the leftist property where the NullPathValue of every left subtree is >= to the NullPathValue of the right tree
        if (x.LeftChild == null || x.LeftChild.NullPathValue.CompareTo(x.RightChild.NullPathValue) < 0)
        {
            LeftistNode<T>? temp = x.LeftChild;
            x.LeftChild = x.RightChild;
            x.RightChild = temp;
        }

        x.NullPathValue = x.RightChild == null ? 0 : x.RightChild.NullPathValue + 1;

        return x;
    }
}