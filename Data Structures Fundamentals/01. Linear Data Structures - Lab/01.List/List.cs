namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int defaultCapacity = 4;
        private T[] items;
        public List(int capacity = defaultCapacity)
        {
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNeeded();
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNeeded();

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);

            ShrinkIfNeeded();

            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count] = default(T);
            this.Count--;

            ShrinkIfNeeded();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of the array!");
            }
        }

        private T[] Grow()
        {
            T[] newArray = new T[this.items.Length * 2];

            Array.Copy(this.items, newArray, this.items.Length);
            
            return newArray;
        }

        private void GrowIfNeeded()
        {
            if (this.Count == this.items.Length)
            {
                this.items = Grow();
            }
        }

        private T[] Shrink()
        {
            T[] newArray = new T[this.items.Length / 2];

            Array.Copy(this.items, newArray, this.items.Length);

            return newArray;
        }

        private void ShrinkIfNeeded()
        {
            if (this.Count == this.items.Length / 2)
            {
                this.items = Shrink();
            }
        }
    }
}