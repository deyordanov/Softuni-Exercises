namespace Problem03.Queue
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
    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> currentNode = this.head;
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

        public T Dequeue()
        {
            this.IsEmpty();

            T value = this.head.Value;
            this.head = this.head.Next;
            this.Count--;

            return value;
        }

        public void Enqueue(T item)
        {
            Node<T> node = new Node<T>(item);
            Node<T> currentNode = this.head;
    
            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = node;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.IsEmpty();

            return this.head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.head;
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
            if(this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}