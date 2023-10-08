// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
namespace AVLTree;

public class CustomAVLTree<T> : IAVLTree<T>
    where T : IComparable<T>
{
    //Making this field public for testing purposes - should be private
    public Node? root;
    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
            //Definition of height: The longest route from a node to another node which has no children (leaf).
            this.Height = 1; //We start from 1 since the path from one leaf node to another is itself (1).

            //Explicitly assign value of children.
            this.LeftChild = null;
            this.RightChild = null;
        }

        public T Value { get; set; }
        public int Height { get; set; }
        public Node? LeftChild { get; set; }
        public Node? RightChild { get; set; }
    }

    public void Insert(T value)
    {
        this.root = this.Insert(this.root, value);
    }

    private Node Insert(Node? node, T value)
    {
        if(node == null) return new Node(value);

        int comparison = value.CompareTo(node.Value);

        if (comparison < 0)
        {
            node.LeftChild = this.Insert(node.LeftChild, value);
        }
        else if (comparison > 0)
        {
            node.RightChild = this.Insert(node.RightChild, value);
        }
        else
        {
            return node; // If such a node already exists => we return the same root and do not change anything -> duplicates are not allowed.
        }

        node.Height = 1 + Math.Max(this.GetHeight(node.LeftChild), this.GetHeight(node.RightChild));

        int nodeBalance = this.GetBalance(node);

        //Left Heavy
        if (nodeBalance > 1)
        {
            if (value.CompareTo(node.LeftChild.Value) < 0)
            {
                //LL rotation => Right rotation
                node = this.RightRotation(node);
            }
            else
            {
                //else if(value.CompareTo(node.LeftChild.Value) > 0)
                //LR rotation => Left rotation + Right rotation
                node.LeftChild = this.LeftRotation(node.LeftChild);
                node = this.RightRotation(node);
            }
        }

        //Right Heavy
        if (nodeBalance < -1)
        {
            if (value.CompareTo(node.RightChild.Value) > 0)
            {
                //RR rotation => Left rotation
                node = this.LeftRotation(node);
            }
            else
            {
                //else if(value.CompareTo(node.RightChild.Value) < 0)
                //RL rotation => Right rotation + Left rotation
                node.RightChild = this.RightRotation(node.RightChild);
                node = this.LeftRotation(node);
            }
        }

        return node;
    }

    public void Delete(T value)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.root = this.Delete(this.root, value);
    }

    private Node? Delete(Node? node, T value)
    {
        if (node == null) return null;

        int comparison = value.CompareTo(node.Value);

        if (comparison < 0)
        {
            node.LeftChild = this.Delete(node.LeftChild, value);
        }
        else if (comparison > 0)
        {
            node.RightChild = this.Delete(node.RightChild, value);
        }
        else
        {
            //If the node we are about to delete has 0 / 1 child
            if (node.LeftChild == null || node.RightChild == null)
            {
                //1 child case -> simply promote the child
                Node? temp = node.LeftChild ?? node.RightChild;

                //0 children case -> simply delete the node
                if (temp == null) node = null;
                else node = temp;
            }
            else
            {
                //In case we have 2 children we perform deletion like in a BST -> the root would become the smallest node of the right subtree
                node.Value = this.GetMinValue(node.RightChild);
                node.RightChild = this.Delete(node.RightChild, node.Value);
            }
        }

        if(node == null) return null;

        node.Height = 1 + Math.Max(this.GetHeight(node.LeftChild), this.GetHeight(node.RightChild));

        int balance = this.GetBalance(node);

        //Left Heavy
        if (balance > 1)
        {
            if (this.GetBalance(node.LeftChild) >= 0)
            {
                //LL rotation => Right rotation
                node = this.RightRotation(node);
            }
            else
            {
                //LR rotation => Left rotation + Right rotation
                node.LeftChild = this.LeftRotation(node.LeftChild);
                node = this.RightRotation(node);
            }
        }

        //Right Heavy
        if (balance < -1)
        {
            if (this.GetHeight(node.RightChild) <= 0)
            {
                //RR rotation => Left rotation
                node = this.LeftRotation(node);
            }
            else
            {
                //RL rotation => Right rotation + Left rotation
                node.RightChild = this.RightRotation(node.RightChild);
                node = this.LeftRotation(node);
            }
        }

        return node;
    }

    public bool Search(T value)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        return this.Search(this.root, value);
    }

    private bool Search(Node? node, T value)
    {
        while (node != null)
        {
            int comparison = value.CompareTo(node.Value);
            if (comparison < 0)
            {
                node = node.LeftChild;
            }
            else if (comparison > 0)
            {
                node = node.RightChild;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public T GetMinValue(Node node)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        while (node.LeftChild != null)
        {
            node = node.LeftChild;
        }

        return node.Value;
    }

    public T GetMaxValue(Node node)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        while (node.RightChild != null)
        {
            node = node.RightChild;
        }

        return node.Value;
    }

    public IEnumerable<T> PreOrderTraversal()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        List<T> result = new List<T>();
        this.PreOrderTraversal(this.root, result);
        return result;
    }

    private void PreOrderTraversal(Node? node, List<T> result)
    {
        if (node == null) return;

        result.Add(node.Value);
        this.PreOrderTraversal(node.LeftChild, result);
        this.PreOrderTraversal(node.RightChild, result);
    }

    public IEnumerable<T> InOrderTraversal()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        List<T> result = new List<T>();
        this.InOrderTraversal(this.root, result);
        return result;
    }

    private void InOrderTraversal(Node? node, List<T> result)
    {
        if(node == null) return;

        this.InOrderTraversal(node.LeftChild, result);
        result.Add(node.Value);
        this.InOrderTraversal(node.RightChild, result);
    }

    public IEnumerable<T> PostOrderTraversal()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        List<T> result = new List<T>();
        this.PostOrderTraversal(this.root, result);
        return result;
    }

    private void PostOrderTraversal(Node? node, List<T> result)
    {
        if(node == null) return;

        this.PostOrderTraversal(node.LeftChild, result);
        this.PostOrderTraversal(node.RightChild, result);
        result.Add(node.Value);
    }

    public IEnumerable<T> BFS()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        return this.BFS(this.root);
    }

    private IEnumerable<T> BFS(Node? root)
    {
        Queue<Node?> queue = new Queue<Node?>();
        List<T> result = new List<T>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node? node = queue.Dequeue();
            result.Add(node.Value);

            if(node.LeftChild != null) queue.Enqueue(node.LeftChild);

            if(node.RightChild != null) queue.Enqueue(node.RightChild);
        }

        return result;
    }

    //Miscellaneous methods

    private int GetHeight(Node? node)
    {
        if (node == null) return 0;

        return node.Height;
    }

    private int GetBalance(Node? node)
    {
        if(node == null) return 0;

        return this.GetHeight(node.LeftChild) - this.GetHeight(node.RightChild);
    }

    //Rotations

    private Node RightRotation(Node? y)
    {
        //If we do not have a RL rotation => xRightChild will be null
        Node? x = y.LeftChild;
        Node? xRightChild = x.RightChild;

        //We make y the right child of x (right rotation)
        x.RightChild = y;
        //Since we need to keep the binary property of the AVL tree, we have to find a place to put the original right child of x
        //The original right child of x is greater than x (it's to the right side) and it's less than y (y was the root), this is why we put it
        //to the left of y.
        y.LeftChild = xRightChild;

        y.Height = 1 + Math.Max(this.GetHeight(y.LeftChild), this.GetHeight(y.RightChild));
        x.Height = 1 + Math.Max(this.GetHeight(x.LeftChild), this.GetHeight(x.RightChild));

        //Return new root
        return x;
    }

    private Node LeftRotation(Node? x)
    {
        //If we do not have a LR rotation => yLeftChild will be null
        Node? y = x.RightChild;
        Node? yLeftChild = y.LeftChild;

        //Same principle as the RightRotation
        y.LeftChild = x;
        x.RightChild = yLeftChild;

        y.Height = 1 + Math.Max(this.GetHeight(y.LeftChild), this.GetHeight(y.RightChild));
        x.Height = 1 + Math.Max(this.GetHeight(x.LeftChild), this.GetHeight(x.RightChild));

        //Return new root
        return y;
    }
}