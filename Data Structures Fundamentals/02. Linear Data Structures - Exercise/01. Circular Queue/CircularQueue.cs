namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] items;
        private int startIndex;
        private int endIndex;
        public CircularQueue(int capacity = DefaultCapacity)
        {
            this.items = new T[DefaultCapacity];
        }

        private const int DefaultCapacity = 4;
        public int Count { get; set; }
        public void Enqueue(T item)
        {
            if (this.Count >= this.items.Length)
            {
                Grow();
            }

            this.items[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.items.Length;
            this.Count++;
        }
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Circular queue is empty!");
            }

            T item = this.items[this.startIndex];
            this.startIndex = (this.startIndex + 1) % this.items.Length;
            this.Count--;

            return item;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Circular queue is empty!");
            }

            return this.items[this.startIndex];
        }

        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];
            int sourceIndex = this.startIndex;

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.items[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.items.Length;
            }

            return newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[(this.startIndex + i) % this.items.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Grow()
        {
            T[] newArray = new T[this.items.Length * 2];
            int sourceIndex = this.startIndex;

            for (int i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.items.Length;
            }

            this.startIndex = 0;
            this.endIndex = this.Count;
            this.items = newArray;
        }
    }

}
