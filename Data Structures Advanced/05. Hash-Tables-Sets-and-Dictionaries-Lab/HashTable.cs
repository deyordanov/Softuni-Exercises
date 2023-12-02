// ReSharper disable InconsistentNaming
namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DefaultCapacity = 4;
        private const double LoadFactor = 0.75;
        private LinkedList<KeyValue<TKey, TValue>>[] cells;
        public int Count { get; private set; }

        public int Capacity => this.cells.Length;

        private HashTable(int capacity, IEnumerable<KeyValue<TKey, TValue>> keyValuePairs)
            : this(capacity)
        {
            foreach (KeyValue<TKey, TValue> keyValuePair in keyValuePairs)
            {
                this.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public HashTable() : this(DefaultCapacity) { }

        public HashTable(int capacity)
        {
            this.cells = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            this.Resize();

            int index = this.GetIndex(key);

            if (this.cells[index] == null)
            {
                this.cells[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            if (cells[index].Any(element => element.Key.Equals(key)))
            {
                throw new ArgumentException("A duplicate key has been added:", key.ToString());
                // throw new DuplicateKeyException("A duplicate key has been added:", key.ToString());
            }

            KeyValue<TKey, TValue> newElement = new KeyValue<TKey, TValue>(key, value);

            this.cells[index].AddLast(newElement);

            this.Count++; 
        }

        private void Resize()
        {
            if ((double)(this.Count + 1) / this.Capacity >= LoadFactor)
            {
                var newTable = new HashTable<TKey, TValue>(this.Capacity * 2, this);

                this.cells = newTable.cells;
            }
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            try
            {
                this.Add(key, value);
            }
            catch (ArgumentException ae)
            {
                if (ae.ParamName == key.ToString())
                {
                    int index = this.GetIndex(key);
                    var pair = this.cells[index].First(kvp => kvp.Key.Equals(key));
                    pair.Value = value;
                    return true;
                }

                throw;
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            var element = this.Find(key);

            if (element == null)
            {
                throw new KeyNotFoundException();
            }

            return element.Value;
        }

        public TValue this[TKey key]
        {
            get => this.Get(key);
            set => this.AddOrReplace(key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);

            if(element != null)
            {
                value = element.Value;
                return true;
            }

            value = default;
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int index = this.GetIndex(key);

            if (this.cells[index] != null)
            {
                foreach (var kvp in this.cells[index])
                {
                    if (kvp.Key.Equals(key))
                    {
                        return kvp;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key) => this.Find(key) != null;

        public bool Remove(TKey key)
        {
            int index = this.GetIndex(key);

            if (this.cells[index] != null)
            {
                var node = this.cells[index].First;

                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        this.cells[index].Remove(node);
                        this.Count--;
                        return true;
                    }

                    node = node.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.cells = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys => this.Select(kvp => kvp.Key);

        public IEnumerable<TValue> Values
        {
            get
            {
                // foreach (var kvp in this)
                // {
                //     yield return kvp.Value;
                // }

                List<TValue> result = new List<TValue>();
                foreach (var cell in this.cells)
                {
                    if (cell != null)
                    {
                        foreach (var kvp in cell)
                        {
                            result.Add(kvp.Value);
                        }
                    }
                }

                return result;
            }
        }

        private int GetIndex(TKey key) => Math.Abs(key.GetHashCode()) % this.Capacity;

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var cell in this.cells)
            {
                if (cell != null)
                {
                    foreach (var element in cell)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
