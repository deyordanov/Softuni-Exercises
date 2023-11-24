namespace AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Value = element;
            }

            public T Value { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public int Level { get; set; }
        }
        private Node root;
        public int Count() => this.Count(this.root);
        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + this.Count(node.Left) + this.Count(node.Right);
        }
        public void Insert(T element)
        {
            this.root = this.Insert(this.root, element);
        }
        private Node Insert(Node node, T element)
        {
            //If the node is null - we create a new node
            if (node == null)
            {
                return new Node(element);
            }

            //If the element we want to insert is less than the current node's value, we go into the left subtree
            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(node.Left, element);
            }
            //Otherwise we go into the right subtree
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(node.Right, element);
            }

            //First we perform the Skew operation on the given node 
            node = this.Skew(node);
            //Secondly we perform the Split operation on the given node
            node = this.Split(node);

            return node;
        }
        private Node Skew(Node node)
        {
            //If we have a node to the left and it is at the same level as its parent, we perform a left roation
            if (node.Left != null && node.Left.Level == node.Level)
            {
                node = this.LeftRotation(node);
            }

            return node;
        }
        private Node Split(Node node)
        {
            //If either the node to the right or the grandchild of the current node are not present, or it is not at the same level as its parent, we return the same node
            //Otherwise if the current node and its grandchild's level are the same we perform a right rotation and increase the level of the node which is promoted (the one in the middle)
            if (node.Right != null && node.Right.Right != null && node.Right.Right.Level == node.Level)
            {
                node = this.RightRotation(node);
                node.Level++;
            }

            return node;
        }
        private Node RightRotation(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            return temp;
        }
        private Node LeftRotation(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            return temp;
        }
        public bool Contains(T element) => this.Contains(this.root, element);
        private bool Contains(Node node, T element)
        {
            while (node != null)
            {
                if (element.CompareTo(node.Value) == 0)
                {
                    return true;
                }
                else if (element.CompareTo(node.Value) < 0)
                {
                    return this.Contains(node.Left, element);
                }
                else
                {
                    return this.Contains(node.Right, element);
                }
            }

            return false;
        }
        public void InOrder(Action<T> action) => this.InOrder(this.root, action);
        private void InOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.InOrder(node.Left, action);
            action(node.Value);
            this.InOrder(node.Right, action);
        }
        public void PreOrder(Action<T> action) => this.PreOrder(this.root, action);
        private void PreOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Value);
            this.PreOrder(node.Left, action);
            this.PreOrder(node.Right, action);
        }
        public void PostOrder(Action<T> action) => this.PostOrder(this.root, action);
        private void PostOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.PostOrder(node.Left, action);
            this.PostOrder(node.Right, action);
            action(node.Value);
        }
    }
}