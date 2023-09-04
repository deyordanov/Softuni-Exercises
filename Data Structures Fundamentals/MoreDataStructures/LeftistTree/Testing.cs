namespace LeftistTree
{
    internal class Testing
    {
        static void Main(string[] args)
        {
            var tree1 = new LeftistTreeImplementation<int>();
            Console.WriteLine(tree1.IsEmpty());
            tree1.Insert(3);
            tree1.Insert(10);
            tree1.Insert(8);

            var tree2 = new LeftistTreeImplementation<int>();
            tree2.Insert(5);
            tree2.Insert(2);
            tree2.Insert(7);

            tree1.Merge(tree2);

            Console.WriteLine(tree1.FindMin()); // Should print 2
            Console.WriteLine(tree1.DeleteMin()); // Should remove and print 2
            Console.WriteLine(tree1.FindMin()); // Should now print 3
            Console.WriteLine(tree1.IsEmpty());
        }
    }
}