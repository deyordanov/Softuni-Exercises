namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();

            this.AsIndentedPreOrder(sb, indent, this);

            return sb.ToString().TrimEnd();
        }

        private void AsIndentedPreOrder(StringBuilder sb, int indent, IAbstractBinaryTree<T> node)
        {
            if (node == null) return;

            sb.AppendLine(new string(' ', indent) + node.Value);
            this.AsIndentedPreOrder(sb, indent + 2, node.LeftChild);
            this.AsIndentedPreOrder(sb, indent + 2, node.RightChild);
        }

        public void ForEachInOrder(Action<T> action)
            => this.ForEachInOrder(this, action);

        private void ForEachInOrder(IAbstractBinaryTree<T> node, Action<T> action)
        {
            if (node == null) return;

            this.ForEachInOrder(node.LeftChild, action);
            action.Invoke(node.Value);
            this.ForEachInOrder(node.RightChild, action);
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
            => this.InOrder(this, new List<IAbstractBinaryTree<T>>());

        private IEnumerable<IAbstractBinaryTree<T>> InOrder(IAbstractBinaryTree<T> node,
            List<IAbstractBinaryTree<T>> list)
        {
            if(node == null) return new List<IAbstractBinaryTree<T>>();

            this.InOrder(node.LeftChild, list);
            list.Add(node);
            this.InOrder(node.RightChild, list);

            return list;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
            => this.PostOrder(this, new List<IAbstractBinaryTree<T>>());

        private IEnumerable<IAbstractBinaryTree<T>> PostOrder(IAbstractBinaryTree<T> node,
            List<IAbstractBinaryTree<T>> list)
        {
            if (node == null) return new List<IAbstractBinaryTree<T>>();

            this.PostOrder(node.LeftChild, list);
            this.PostOrder(node.RightChild, list);
            list.Add(node);

            return list;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
            => this.PreOrder(this, new List<IAbstractBinaryTree<T>>());

        private IEnumerable<IAbstractBinaryTree<T>> PreOrder(IAbstractBinaryTree<T> node,
            List<IAbstractBinaryTree<T>> list)
        {
            if(node == null) return new List<IAbstractBinaryTree<T>>();

            list.Add(node);
            this.PreOrder(node.LeftChild, list);
            this.PreOrder(node.RightChild, list);

            return list;
        }
    }
}
