namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        private Tree()
        {
            this.children = new List<Tree<T>>();
        }

        public Tree(T key, params Tree<T>[] children)
            : this()
        {
            this.Key = key;

            foreach (Tree<T> child in children)
            {
                this.children.Add(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            this.DfsToString(sb, this, 0);
            return sb.ToString().TrimEnd();
        }

        public List<T> GetMiddleKeys()
            => this.InternalAndLeafKeysBfs(x => x.children.Count > 0 && x.Parent != null)
                .Select(tree => tree.Key)
                .ToList();

        public IEnumerable<T> GetLeafKeys()
            => this.InternalAndLeafKeysBfs(x => x.children.Count == 0 && x.Parent != null)
                .Select(tree => tree.Key);

        public Tree<T> GetDeepestLeftomostNode()
        {
            int minDepth = int.MinValue;
            Tree<T> deepestNode = this;
            foreach(Tree<T> leaf in this.InternalAndLeafKeysBfs((x => x.children.Count == 0 && x.Parent != null)))
            {
                int depth = this.GetNodeDepth(leaf);
                if (depth > minDepth)
                {
                    minDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        public List<T> GetLongestPath()
        {
            Tree<T> deepestNode = this.FindNodeByKey(this,this.GetDeepestLeftomostNode().Key);

            Stack<T> path = new Stack<T>();

            while (deepestNode != null)
            {
                path.Push(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            return path.ToList();
        }

        private IEnumerable<Tree<T>> InternalAndLeafKeysBfs(Predicate<Tree<T>> predicate)
        {
            List<Tree<T>> result = new List<Tree<T>>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();

                if (predicate(node))
                {
                    result.Add(node);
                }

                foreach (Tree<T> child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private void DfsToString(StringBuilder sb, Tree<T> tree, int level)
        {
            sb.AppendLine(new string(' ', level) + tree.Key);

            foreach (Tree<T> child in tree.Children)
            {
                this.DfsToString(sb, child, level + 2);
            }
        }

        private int GetNodeDepth(Tree<T> tree)
        {
            int depth = 0;
            while (tree.Parent != null)
            {
                tree = tree.Parent;
                depth++;
            }

            return depth;
        }

        private Tree<T> FindNodeByKey(Tree<T> tree, T key)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();

                if (node.Key.Equals(key))
                {
                    return node;
                }

                foreach (Tree<T> child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
