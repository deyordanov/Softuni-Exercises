namespace _01.RedBlackTree
{
    using System;

    public class RedBlackTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                Color = Red;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }
        }
        public Node Root;
        public RedBlackTree()
        {

        }
        public RedBlackTree<T> Search(T element)
        {
            RedBlackTree<T> tree = new RedBlackTree<T>();
            Node node = this.FindNode(element);

            this.PreOrderTraversal(node, tree);

            return tree;
        }
        public void Insert(T value)
        {
            this.Root = Insert(Root, value);
            this.Root.Color = Black;
        }
        private Node Insert(Node node, T value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (AreEqual(value, node.Value))
            {
                node.Value = value;
            }
            else if (IsLesser(value, node.Value))
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            if (IsRed(node.Right))
            {
                node = LeftRotation(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RightRotation(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }
        public void Delete(T key)
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }

            this.Root = this.Delete(this.Root, key);

            if (this.Root != null)
            {
                this.Root.Color = Black;
            }
        }
        private Node Delete(Node node, T value)
        {
            if (IsLesser(value, node.Value))
            {
                if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                {
                    node = this.MoveRedLeft(node);
                }

                node.Left = this.Delete(node.Left, value);
            }
            else
            {
                if (IsRed(node.Left))
                {
                    node = this.RightRotation(node);
                }

                if (AreEqual(value, node.Value) && node.Right == null)
                {
                    return null;
                }

                if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                {
                    node = this.MoveRedRight(node);
                }

                if (AreEqual(value, node.Value))
                {
                    node.Value = this.FindMinValueInSubtree(node.Right);
                    node.Right = this.DeleteMin(node.Right);
                }
                else
                {
                    node.Right = this.Delete(node.Right, value);
                }
            }

            return this.FixUp(node);
        }
        private T FindMinValueInSubtree(Node node)
        {
            if (node.Left == null)
            {
                return node.Value;
            }

            return this.FindMinValueInSubtree(node.Left);
        }
        public void DeleteMin()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }

            this.Root = DeleteMin(Root);

            if (this.Root != null)
            {
                this.Root.Color = Black;
            }
        }
        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return null;
            }

            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
            {
                node = MoveRedLeft(node);
            }

            node.Left = DeleteMin(node.Left);

            return FixUp(node);
        }
        public void DeleteMax()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }

            this.Root = DeleteMax(Root);

            if (this.Root != null)
            {
                this.Root.Color = Black;
            }
        }
        private Node DeleteMax(Node node)
        {
            if (IsRed(node.Left))
            {
                node = this.RightRotation(node);
            } 

            if (node.Right == null)
            {
                return null;
            }

            if (!IsRed(node.Right) && !IsRed(node.Right.Left))
            {
                node = MoveRedRight(node);
            }

            node.Right = this.DeleteMax(node.Right);

            return this.FixUp(node);
        }
        private Node MoveRedRight(Node node)
        {
            this.FlipColors(node);

            if (IsRed(node.Left.Left))
            {
                node = this.RightRotation(node);
                this.FlipColors(node);
            }

            return node;
        }
        private Node MoveRedLeft(Node node)
        {
            FlipColors(node);
            if (IsRed(node.Right.Left))
            {
                node.Right = RightRotation(node.Right);
                node = LeftRotation(node);
                FlipColors(node);
            }
            return node;
        }
        private Node FixUp(Node node)
        {
            if (IsRed(node.Right))
            {
                node = LeftRotation(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RightRotation(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }
        private Node LeftRotation(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            temp.Color = temp.Left.Color;
            temp.Left.Color = Red;

            return temp;
        }
        private Node RightRotation(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            temp.Color = temp.Right.Color;
            temp.Right.Color = Red;

            return temp;
        }
        private void FlipColors(Node node)
        {
            node.Color = !node.Color;
            node.Left.Color = !node.Left.Color;
            node.Right.Color = !node.Right.Color;
        }
        private Node FindNode(T element)
        {
            Node current = this.Root;

            while (current != null)
            {
                if (IsGreater(element, current.Value))
                {
                    current = current.Right;
                }
                else if (IsLesser(element, current.Value))
                {
                    current = current.Left;
                }
                else
                {
                    break;
                }
            }

            return current;
        }
        public int Count() => this.Count(this.Root);
        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return Count(node.Left) + Count(node.Right) + 1;
        }
        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
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
        private void PreOrderTraversal(Node node, RedBlackTree<T> tree)
        {
            if (node == null)
            {
                return;
            }

            tree.Insert(node.Value);
            this.PreOrderTraversal(node.Left, tree);
            this.PreOrderTraversal(node.Right, tree);
        }
        private bool IsRed(Node node)
        {
            if (node == null) return false;
            return (node.Color == Red);
        }
        private static bool IsLesser(T value1, T value2) => value1.CompareTo(value2) < 0;
        private static bool IsGreater(T value1, T value2) => value1.CompareTo(value2) > 0;
        private static bool AreEqual(T value1, T value2) => value1.CompareTo(value2) == 0;
    }
}