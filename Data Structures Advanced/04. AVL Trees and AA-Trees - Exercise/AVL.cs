namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Height = 1;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }
        }

        public Node Root { get; private set; }

        public bool Contains(T element) => this.Contains(this.Root, element);

        private bool Contains(Node node, T element)
        {
            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Delete(T element)
        {
            this.Root = this.Delete(this.Root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null) return null;

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Delete(node.Right, element);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    Node temp = this.FindSmallestChild(node.Right);

                    node.Value = temp.Value;

                    node.Right = this.Delete(node.Right, temp.Value);
                }
            }

            node = this.Balance(node);
            this.UpdateHeight(node);

            return node;
        }

        private Node FindSmallestChild(Node node)
        {
            if(node.Left == null) return node;

            return this.FindSmallestChild(node.Left);
        }

        public void DeleteMin()
        {
            this.Root = this.DeleteMin(this.Root);
        }

        private Node DeleteMin(Node node)
        {
            if (node == null)
            {
                return null;
            }

            Node temp = this.FindSmallestChild(node);

            return this.Delete(node, temp.Value);
        }

        public void Insert(T element)
        {
            this.Root = this.Insert(this.Root, element);
        }

        private Node Insert(Node node, T element)
        {
            if (node == null) return new Node(element);

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(node.Left, element);
            }else
            {
                node.Right = this.Insert(node.Right, element);
            }

            node =this.Balance(node);
            this.UpdateHeight(node);
            return node;
        }

        private Node Balance(Node node)
        {
            int balance = this.GetBalance(node.Left, node.Right);

            if (balance > 1)
            {
                int childBalance = this.GetBalance(node.Left.Left, node.Left.Right);
                if (childBalance <= -1)
                {
                    node.Left = this.LeftRotation(node.Left);
                }
                node = this.RightRotation(node);
            }
            else if (balance < -1)
            {
                int childBalance = this.GetBalance(node.Right.Left, node.Right.Right);
                if (childBalance >= 1)
                {
                    node.Right = this.RightRotation(node.Right);
                }

                node = this.LeftRotation(node);
            }

            return node;
        }

        private Node LeftRotation(Node node)
        {
            Node temp = node.Right;
            node.Right = node.Right.Left;
            temp.Left = node;

            this.UpdateHeight(node);

            return temp;
        }

        private Node RightRotation(Node node)
        {
            Node temp = node.Left;
            node.Left = node.Left.Right;
            temp.Right = node;

            this.UpdateHeight(node);

            return temp;
        }

        public void EachInOrder(Action<T> action) => this.EachInOrder(this.Root, action);

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private int Height(Node node)
        {
            if(node == null) return 0;

            return node.Height;
        }

        private int GetBalance(Node left, Node right) => this.Height(left) - this.Height(right);

        private void UpdateHeight(Node node)
        {
            node.Height = Math.Max(this.Height(node.Left), this.Height(node.Right)) + 1;
        }
    }
}
