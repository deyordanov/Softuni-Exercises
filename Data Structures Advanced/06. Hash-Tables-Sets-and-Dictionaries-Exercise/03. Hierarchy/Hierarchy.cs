namespace Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private class Node
        {
            public Node(T value, Node parent)
            {
                this.Value = value;
                this.Children = new List<Node>();
                this.Parent = parent;
            }

            public T Value { get; set; }

            public List<Node> Children { get; set; }

            public Node Parent { get; set; }
        }

        private Dictionary<T, Node> hierarchy;
        public Hierarchy(T value)
        {
            this.hierarchy = new Dictionary<T, Node> { { value, new Node(value, null) } };
            this.root = this.hierarchy[value];
        }

        private Node root;

        public int Count => this.hierarchy.Count;

        public void Add(T element, T child)
        {
            if (!Contains(element) || Contains(child))
            {
                throw new ArgumentException();
            }

            Node parent = this.hierarchy[element];

            Node parentChild = new Node(child, parent);

            parent.Children.Add(parentChild);

            this.hierarchy.Add(child, parentChild);
        }

        public bool Contains(T element) => this.hierarchy.ContainsKey(element);

        public IEnumerable<T> GetChildren(T element)
        {
            if (!Contains(element))
            {
                throw new ArgumentException();
            }

            return this.hierarchy[element].Children.Select(c => c.Value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other) =>
            this.hierarchy.Keys.Intersect(other.hierarchy.Keys);

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                yield return node.Value;

                foreach (Node child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public T GetParent(T element)
        {
            if (!Contains(element))
            {
                throw new ArgumentException();
            }

            if (element.Equals(this.root.Value))
            {
                return default(T);
            }

            return this.hierarchy[element].Parent.Value;
        }

        public void Remove(T element)
        {
            if (!Contains(element))
            {
                throw new ArgumentException();
            }

            if (element.Equals(this.root.Value))
            {
                throw new InvalidOperationException();
            }

            Node parent = this.hierarchy[element].Parent;

            Node nodeToRemove = this.hierarchy[element];

            parent.Children.Remove(nodeToRemove);

            parent.Children.AddRange(nodeToRemove.Children);

            hierarchy.Remove(element);

            foreach (Node child in nodeToRemove.Children)
            {
                child.Parent = parent;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}