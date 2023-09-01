namespace Problem04.SinglyLinkedList
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
    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newHead = new Node<T>(item);
            newHead.Next = this.head;
            this.head = newHead;
            this.Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            this.IsEmpty();

            return this.head.Value;
        }

        public T GetLast()
        {
            this.IsEmpty();

            Node<T> currentNode = this.head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }

        public T RemoveFirst()
        {
            this.IsEmpty();

            T value = this.head.Value;
            this.head = this.head.Next;
            this.Count--;

            return value;
        }

        public T RemoveLast()
        {
            this.IsEmpty();

            Node<T> currentNode = this.head;
            Node<T> lastNode = null;

            if (currentNode.Next == null)
            {
                lastNode = this.head;
                this.head = null;
            }
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.Next.Next == null)
                    {
                        lastNode = currentNode.Next;
                        currentNode.Next = null;
                        break;
                    }

                    currentNode = currentNode.Next;
                }
            }

            this.Count--;
            return lastNode.Value;
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
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }
        }
    }
}