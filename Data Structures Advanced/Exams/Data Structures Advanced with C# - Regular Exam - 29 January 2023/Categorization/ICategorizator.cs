using System.Collections.Generic;

namespace Exam.Categorization
{
    public interface ICategorizator
    {
        void AddCategory(Category category);

        void AssignParent(string childCategoryId, string parentCategoryId);

        void RemoveCategory(string categoryId);

        bool Contains(Category category);

        int Size();

        IEnumerable<Category> GetChildren(string categoryId);

        IEnumerable<Category> GetHierarchy(string categoryId);

        IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName();
    }
}
