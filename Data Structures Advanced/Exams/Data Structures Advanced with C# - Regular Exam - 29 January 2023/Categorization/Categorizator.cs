using System.Collections.Generic;

namespace Exam.Categorization
{
    using System;
    using System.Linq;

    public class Categorizator : ICategorizator
    {
        private Dictionary<string, Category> categories;

        public Categorizator()
        {
            this.categories = new Dictionary<string, Category>();
        }

        public void AddCategory(Category category)
        {
            if (this.categories.ContainsKey(category.Id))
            {
                throw new ArgumentException();
            }

            this.categories.Add(category.Id, category);
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!categories.ContainsKey(childCategoryId) || !categories.ContainsKey(parentCategoryId))
            {
                throw new ArgumentException();
            }
            Category child = categories[childCategoryId];
            Category parent = categories[parentCategoryId];


            if (child.Parent == parent)
            {
                throw new ArgumentException();
            }
            child.Parent = parent;
            parent.Children.Add(child);

            this.CalculateDepth(parent);
        }

        private int CalculateDepth(Category category)
        {
            if (category == null)
            {
                return 0;
            }

            int depth = 0;
            foreach (Category child in category.Children)
            {
                depth = Math.Max(CalculateDepth(child), depth);
            }

            category.Depth = depth + 1;

            return category.Depth;
        }

        public bool Contains(Category category) => this.categories.ContainsKey(category.Id);

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            if (!this.categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            Category category = this.categories[categoryId];

            return this.GetChildrenBfs(category);
        }

        private IEnumerable<Category> GetChildrenBfs(Category category)
        {
            List<Category> result = new List<Category>();
            Queue<Category> queue = new Queue<Category>();

            foreach (Category child in category.Children)
            {
                queue.Enqueue(child);
            }

            while (queue.Count > 0)
            {
                Category currentCategory = queue.Dequeue();

                result.Add(currentCategory);

                foreach (Category child in currentCategory.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!this.categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            Category category = this.categories[categoryId];

            Stack<Category> result = new Stack<Category>();

            while (category != null)
            {
                result.Push(category);
                category = category.Parent;
            }

            return result;
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
        {
            return this.categories
                .Select(kvp => kvp.Value)
                .OrderByDescending(c => c.Depth)
                .ThenBy(c => c.Name)
                .Take(3);
        }

        public void RemoveCategory(string categoryId)
        {
            if (!this.categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            Category category = this.categories[categoryId];

            if (category.Parent != null)
            {
                category.Parent.Children.Remove(category);
                category.Parent = null;
            }

            this.RemoveAllChildrenBfs(category);
        }

        private void RemoveAllChildrenBfs(Category category)
        {
            Queue<Category> queue = new Queue<Category>();
            queue.Enqueue(category);

            while (queue.Count > 0)
            {
                Category currentCategory = queue.Dequeue();

                this.categories.Remove(currentCategory.Id);

                foreach (Category child in currentCategory.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public int Size() => this.categories.Count;
    }
}