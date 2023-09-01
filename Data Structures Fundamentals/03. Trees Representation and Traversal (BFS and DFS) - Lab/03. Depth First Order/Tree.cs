namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private Tree<T> parent;
        private T value;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parentNode = this.DfsNodeByKey(parentKey);
            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }

            parentNode.children.Add(child);
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();
                result.Add(node.value);

                foreach (Tree<T> child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            Stack<T> result = new Stack<T>();
            return this.StackDfs(result);
        }

        private IEnumerable<T> StackDfs(Stack<T> result)
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                Tree<T> node = stack.Pop();

                foreach (Tree<T> child in node.children)
                {
                    stack.Push(child);
                }

                result.Push(node.value);
            }

            return result;
        }

        private void RecursiveDfs(Tree<T> node, Stack<T> result)
        {
            foreach (Tree<T> child in node.children)
            {
                RecursiveDfs(child, result);
            }

            result.Push(node.value);
        }

        private Tree<T> BfsNodeByKey(T key)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();

                if (node.value.Equals(key))
                {
                    return node;
                }

                foreach (Tree<T> child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> DfsNodeByKey(T key)
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                Tree<T> node = stack.Pop();

                foreach (Tree<T> child in node.children)
                {
                    stack.Push(child);
                }

                if (node.value.Equals(key))
                {
                    return node;
                }
            }

            return null;
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> node = this.BfsNodeByKey(nodeKey);

            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (node.parent == null)
            {
                throw new ArgumentException();
            }

            node.parent.children.Remove(node);
            node.parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = this.BfsNodeByKey(firstKey);
            Tree<T> secondNode = this.BfsNodeByKey(secondKey);

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }

            Tree<T> firstNodeParent = firstNode.parent;
            Tree<T> secondNodeParent = secondNode.parent;
            if (firstNodeParent == null || secondNodeParent == null)
            {
                throw new ArgumentException();
            }

            //This approach keeps the order of the children
            int firstIndex = firstNodeParent.children.IndexOf(firstNode);
            int secondIndex = secondNodeParent.children.IndexOf(secondNode);

            firstNodeParent.children[firstIndex] = secondNode;
            secondNodeParent.children[secondIndex] = firstNode;

            //This approach changes the order of the children
            // firstNodeParent.children.Remove(firstNode);
            // firstNodeParent.children.Add(secondNode);
            //
            // secondNodeParent.children.Remove(secondNode);
            // secondNodeParent.children.Add(firstNode);

            firstNode.parent = secondNodeParent;
            secondNode.parent = firstNodeParent;
        }
    }
}
