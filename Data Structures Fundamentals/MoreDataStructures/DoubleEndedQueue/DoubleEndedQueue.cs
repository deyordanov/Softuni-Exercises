namespace DoubleEndedQueue;

using System.Collections;

public class DoubleEndedQueue<T> : IDoubleEndedQueue<T>
{
    class Node
    {
        public Node(T value, Node? next = null, Node? previous = null)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;
        }
        public T Value { get; set; }
        public Node? Next { get; set; }
        public Node? Previous { get; set; }
    }

    private Node head;
    private Node tail;

    public int Count { get; set; }
    public void AddFirst(T item)
    {
        Node newNode = new Node(item);

        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.head.Previous = newNode;
            newNode.Next = this.head;
            this.head = newNode;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node newNode = new Node(item);

        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail.Next = newNode;
            newNode.Previous = this.tail;
            this.tail = newNode;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        this.IsEmpty();

        T value = this.head.Value;
        this.head = this.head.Next;

        if (this.head == null)
        {
            this.tail = null;
        }
        else
        {
            this.head.Previous = null;
        }

        this.Count--;
        return value;
    }

    public T RemoveLast()
    {
        this.IsEmpty();

        T value = this.tail.Value;
        this.tail = this.tail.Previous;

        if (this.tail == null)
        {
            this.head = null;
        }
        else
        {
            this.tail.Next = null;
        }

        this.Count--;
        return value;
    }

    public bool Contains(T item)
    {
        Node currentNode = this.tail;
        while (currentNode != null)
        {
            if (currentNode.Value.Equals(item))
            {
                return true;
            }

            currentNode = currentNode.Previous;
        }

        return false;
    }

    private void IsEmpty()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Double-ended queue is empty!");
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
}