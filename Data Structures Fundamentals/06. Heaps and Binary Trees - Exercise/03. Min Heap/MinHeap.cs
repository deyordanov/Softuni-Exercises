using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size  => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);

            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int childIndex)
        {
            int parentIndex = (childIndex - 1) / 2;
            while (parentIndex >= 0 && this.elements[childIndex].CompareTo(this.elements[parentIndex]) < 0)
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
        }

        public T ExtractMin()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];

            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int parentIndex)
        {
            int smallerChildIndex = this.GetSmallerChild(parentIndex);
            while (smallerChildIndex >= 0 && this.elements[parentIndex].CompareTo(this.elements[smallerChildIndex]) > 0)
            {
                this.Swap(smallerChildIndex, parentIndex);
                parentIndex = smallerChildIndex;
                smallerChildIndex = this.GetSmallerChild(parentIndex);
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

            return -1;
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }
    }
}
