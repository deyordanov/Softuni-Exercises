using System;
using System.Collections.Generic;

namespace Exam.Categorization
{
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Categorizator categorizer = new Categorizator();

            Category category1 = new Category("1", "a", "te");
            Category category2 = new Category("2", "b", "tet");
            Category category3 = new Category("3", "c", "te");
            Category category4 = new Category("4", "d", "te");
            Category category5 = new Category("5", "e", "te");

            categorizer.AddCategory(category1);
            categorizer.AddCategory(category2);
            categorizer.AddCategory(category3);
            categorizer.AddCategory(category4);
            categorizer.AddCategory(category5);

            categorizer.AssignParent(category2.Id, category1.Id);
            categorizer.AssignParent(category3.Id, category2.Id);
            categorizer.AssignParent(category4.Id, category3.Id);
            categorizer.AssignParent(category5.Id, category4.Id);

            HashSet<Category> set = categorizer.GetHierarchy(category5.Id).ToHashSet();

            Console.WriteLine(string.Join(" -> ", set.Select(c => c.Name)));
        }
    }
}
