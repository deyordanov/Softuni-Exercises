namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public int Count { get; set; }
            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            this.root = this.Delete(element, this.root);
        }

        private Node Delete(T element, Node node)
        {
            if (node == null) return null;

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Delete(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Delete(element, node.Right);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }
                else if (node.Left == null)
                {
                    return node.Right;
                }
                else
                {
                    Node temp = node;
                    node = this.GetMin(temp.Right);
                    node.Right = this.DeleteMin(temp.Right);
                    node.Left = temp.Left;
                }
            }
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

        private Node GetMin(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }


        public void DeleteMax()
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMax(this.root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = this.DeleteMax(node.Right);
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

        public void DeleteMin()
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMin(this.root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

        public int Count()
            => this.Count(this.root);

        private int Count(Node node)
        {
            if(node == null) return 0;
            return node.Count;
        }

        public int Rank(T element)
            => this.Rank(element, this.root);

        private int Rank(T element, Node node)
        {
            if (node == null) return 0;

            if (element.CompareTo(node.Value) < 0)
            {
                return this.Rank(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
            }

            return this.Count(node.Left);
        }


        public T Select(int rank)
        {
            Node node = this.Select(rank, this.root);
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        private Node Select(int rank, Node node)
        {
            if (node == null) return null;

            int leftCount = this.Count(node.Left);
            if (rank == leftCount)
            {
                return node;
            }
            else if (rank < leftCount)
            {
                return this.Select(rank, node.Left);
            }

            return this.Select(rank - (leftCount + 1), node.Right);
        }

        public T Ceiling(T element)
            => this.Select(this.Rank(element) + 1);

        public T Floor(T element)
            => this.Select(this.Rank(element) - 1);

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            List<T> list = new List<T>();

            this.Range(this.root, startRange, endRange, list);

            return list;
        }

        private void Range(Node node, T startRange, T endRange, List<T> list)
        {
            if (node == null) return;

            if (node.Value.CompareTo(startRange) > 0)
            {
                this.Range(node.Left, startRange, endRange, list);
            }

            if (node.Value.CompareTo(startRange) >= 0 && node.Value.CompareTo(endRange) <= 0)
            {
                list.Add(node.Value);
            }

            if (node.Value.CompareTo(endRange) < 0)
            {
                this.Range(node.Right, startRange, endRange, list);
            }
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

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
    }
}
