namespace Tree
{
    using System.Collections.Generic;

    public interface IAbstractTree<T>
    {
        T Key { get; }
        IReadOnlyCollection<Tree<T>> Children { get; }

        void AddParent(Tree<T> parent);

        void AddChild(Tree<T> child);

        string GetAsString();

        IEnumerable<T> GetLeafKeys();

        List<T> GetMiddleKeys();

        Tree<T> GetDeepestLeftomostNode();

        List<T> GetLongestPath();
    }
}
