namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            int childIndex = this.elements.Count - 1;
            this.HeapifyUp(childIndex);
        }

        private void HeapifyUp(int childIndex)
        {
            int parentIndex = (childIndex - 1) / 2;

            while (parentIndex >= 0 && this.elements[childIndex].CompareTo(this.elements[parentIndex]) > 0)
            {
                this.Swap(childIndex, parentIndex);
                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2;
            }
        }

        private void Swap(int childIndex, int parentIndex)
        {
            (this.elements[childIndex], this.elements[parentIndex]) = 
                (this.elements[parentIndex], this.elements[childIndex]);
        }

        public T ExtractMax()
        {
            if(this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            this.Swap(this.elements.Count - 1, 0);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            int biggestChildIndex = this.GetBiggestChild(index);

            while (biggestChildIndex > 0 && this.elements[index].CompareTo(this.elements[biggestChildIndex]) < 0)
            {
                this.Swap(index, biggestChildIndex);
                index = biggestChildIndex;
                biggestChildIndex = this.GetBiggestChild(index);
            }
        }

        private int GetBiggestChild(int index)
        {
            int firstChildIndex = index * 2 + 1;
            int secondChildIndex = index * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (this.elements[secondChildIndex].CompareTo(this.elements[firstChildIndex]) > 0)
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
