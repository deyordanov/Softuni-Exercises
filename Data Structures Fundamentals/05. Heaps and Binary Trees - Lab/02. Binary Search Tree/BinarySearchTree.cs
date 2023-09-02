namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }
            public T Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.CopyNodesPreOrder(node);
        }

        public BinarySearchTree() { }

        public bool Contains(T element)
            => this.FindNode(element) != null;

        private Node FindNode(T element)
        {
            Node node = this.root;
            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
            => this.EachInOrder(action, this.root);

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null) return;

            this.EachInOrder(action, node.LeftChild);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.RightChild);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(this.root, element);
        }

        private Node Insert(Node node, T element)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.LeftChild = this.Insert(node.LeftChild, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.RightChild = this.Insert(node.RightChild, element);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = this.FindNode(element);

            if(node == null) return null;

            return new BinarySearchTree<T>(node);
        }

        private void CopyNodesPreOrder(Node node)
        {
            if (node == null) return;

            this.Insert(node.Value);
            this.CopyNodesPreOrder(node.LeftChild);
            this.CopyNodesPreOrder(node.RightChild);
        }
    }
}
