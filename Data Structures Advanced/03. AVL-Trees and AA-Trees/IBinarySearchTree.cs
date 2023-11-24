namespace AA_Tree
{
    using System;

    public interface IBinarySearchTree<T>
    {
        int Count();

        void Insert(T element);

        bool Contains(T element);

        void InOrder(Action<T> action);

        void PreOrder(Action<T> action);

        void PostOrder(Action<T> action);
    }
}
