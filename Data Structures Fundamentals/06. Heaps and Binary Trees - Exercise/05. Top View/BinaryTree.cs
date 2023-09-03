namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        private Dictionary<int, (T nodeValue, int level)> dictionary;

        private BinaryTree()
        {
            this.dictionary = new Dictionary<int, (T nodeValue, int level)>();
        }

        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
            : this()
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            this.TopView(this, 0, 0);
            return this.dictionary.Select(kvp => kvp.Value.nodeValue).ToList();
        }

        private void TopView(BinaryTree<T> node, int level, int distance)
        {
            if (node == null) return;

            if (!this.dictionary.ContainsKey(distance))
            {
                this.dictionary.Add(distance, (node.Value, level));
            }

            this.TopView(node.LeftChild, level + 1, distance - 1);
            this.TopView(node.RightChild, level + 1, distance + 1);
        }
    }
}
