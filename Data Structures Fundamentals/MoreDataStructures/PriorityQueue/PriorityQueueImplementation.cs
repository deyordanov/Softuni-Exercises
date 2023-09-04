namespace PriorityQueue;

using System.Collections;

public class PriorityQueueImplementation<T> : IPriorityQueue<T>
    where T : IComparable<T>
{
    class Node
    {
        public Node(T value, Node? next = null)
        {
            this.Value = value;
            this.Next = next;
        }
        public T Value { get; set; }
        public Node? Next { get; set; }
    }

    private Node? head;

    public int Count { get; set; }

    public void Enqueue(T item)
    {
        Node newNode = new Node(item);

        //If we want the nodes with a lesser value to be of higher priority => if(... this.head.Value.CompareTo(item) > 0)
        if (this.head == null || this.head.Value.CompareTo(item) < 0)
        {
            newNode.Next = this.head;
            this.head = newNode;
        }
        else
        {
            Node currentNode = this.head;

            //If we want the nodes with a lesser value to be of higher priority => if(... currentNode.Next.Value.CompareTo(item) <= 0)
            while (currentNode.Next != null && currentNode.Next.Value.CompareTo(item) >= 0)
            {
                currentNode = currentNode.Next;
            }

            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        this.IsEmpty();

        T value = this.head.Value;

        this.head = this.head.Next;
        this.Count--;

        return value;
    }

    public bool Contains(T item)
    {
        Node? currentNode = this.head;
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

        return this.head.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? currentNode = this.head;
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
            throw new InvalidOperationException("Priority queue is empty!");
        }
    }
}