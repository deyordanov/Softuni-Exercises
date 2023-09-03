using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    //Heap-based implementation
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        private Dictionary<T, int> indexes;
        public PriorityQueue()
        {
            this.elements = new List<T>();
            this.indexes = new Dictionary<T, int>();
        }

        public void Enqueue(T element)
        {
            this.elements.Add(element);

            this.indexes.Add(element, this.elements.Count - 1);

            this.Promote(this.elements.Count - 1);
        }

        private void Promote(int childIndex)
        {
            int parentIndex = (childIndex - 1) / 2;
            while (parentIndex >= 0 && this.elements[parentIndex].CompareTo(this.elements[childIndex]) > 0)
            {
                this.Swap(childIndex, parentIndex);
                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2;
            }

        }

        private void Swap(int first, int second)
        {
           (this.elements[first], this.elements[second]) 
               = (this.elements[second], this.elements[first]);

           this.indexes[this.elements[first]] = first;
            this.indexes[this.elements[second]] = second;
        }

        public T Dequeue()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];

            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.indexes.Remove(element);
            this.Decrease(0);

            return element;
        }

        private void Decrease(int parentIndex)
        {
            int biggerChildIndex = this.GetSmallerChild(parentIndex);
            while (biggerChildIndex >= 0 && this.elements[parentIndex].CompareTo(this.elements[biggerChildIndex]) > 0)
            {
                this.Swap(biggerChildIndex, parentIndex);
                parentIndex = biggerChildIndex;
                biggerChildIndex = this.GetSmallerChild(parentIndex);
            }
        }

        private int GetSmallerChild(int parentIndex)
        {
            int firstChildIndex = parentIndex * 2 + 1;
            int secondChildIndex = parentIndex * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (this.elements[secondChildIndex].CompareTo(this.elements[firstChildIndex]) < 0)
                {
                    return secondChildIndex;
                }

                return firstChildIndex;
            }
            else if (firstChildIndex < this.elements.Count)
            {
                return firstChildIndex;
            }
            else
            {
                return -1;
            }
        }

        public void DecreaseKey(T key)
        {
            this.Promote(this.indexes[key]);
        }
    }
}
