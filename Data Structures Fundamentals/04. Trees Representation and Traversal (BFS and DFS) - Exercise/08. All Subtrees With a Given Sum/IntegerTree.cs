namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public List<List<int>> PathsWithGivenSum(int sum)
        {
            List<Tree<int>> nodes = new List<Tree<int>>();
            this.PathsWithGivenSumDfs(this.GetRoot(this), this.Key, nodes, sum);
            return nodes.Select(n => this.GetPath(n).ToList()).ToList();
        }

        public List<Tree<int>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<int>> subtreeRoots = new List<Tree<int>>();
            Tree<int> root = this.GetRoot(this);
            foreach (Tree<int> tree in this.GetAllNodesBfs(root))
            {
                int currentSum = tree.Key;
                    this.GetSubtreesWithGivenSumDfs(tree, ref currentSum);

                if (currentSum == sum)
                {
                    subtreeRoots.Add(tree);
                }
            }

            return subtreeRoots;
        }

        private void PathsWithGivenSumDfs(Tree<int> tree, int currentSum, List<Tree<int>> nodes, int sum)
        {
            foreach (Tree<int> child in tree.Children)
            {
                PathsWithGivenSumDfs(child, currentSum + child.Key, nodes, sum);
            }

            if (tree.Children.Count == 0 && currentSum == sum)
            {
                nodes.Add(tree);
            }
        }

        private IntegerTree GetRoot(IntegerTree tree)
        {
            Queue<IntegerTree> queue = new Queue<IntegerTree>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IntegerTree node = queue.Dequeue();

                if (node.Parent == null)
                {
                    return node;
                }

                foreach (IntegerTree child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private IEnumerable<int> GetPath(Tree<int> node)
        {
            Stack<int> path = new Stack<int>();

            while (node != null)
            {
                path.Push(node.Key);
                node = node.Parent;
            }

            return path;
        }

        private IEnumerable<Tree<int>> GetAllNodesBfs(Tree<int> tree)
        {
            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            List<Tree<int>> result = new List<Tree<int>>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                Tree<int> node = queue.Dequeue();

                result.Add(node);

                foreach (Tree<int> child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private void GetSubtreesWithGivenSumDfs(Tree<int> tree, ref int currentSum)
        {
            foreach (Tree<int> child in tree.Children)
            {
                currentSum = currentSum + child.Key;
                this.GetSubtreesWithGivenSumDfs(child, ref currentSum);
            }
        }
    }
}
