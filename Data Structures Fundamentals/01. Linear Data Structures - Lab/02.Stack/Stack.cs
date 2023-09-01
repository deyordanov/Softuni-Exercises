namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> currentNode = this.top;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Peek()
        {
            this.IsEmpty();

            return this.top.Value;
        }

        public T Pop()
        {
            this.IsEmpty();

            T value = this.top.Value;
            this.top = this.top.Next;
            this.Count--;

            return value;
        }

        public void Push(T item)
        {
            Node<T> newTop = new Node<T>(item);
            newTop.Next = this.top;
            this.top = newTop;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.top;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}