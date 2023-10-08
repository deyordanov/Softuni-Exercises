namespace AVLTree
{
    internal class Testing
    {
        static void Main(string[] args)
        {
            CustomAVLTree<int> tree = new CustomAVLTree<int>();

            // Test Insertion
            tree.Insert(50);
            tree.Insert(60);
            tree.Insert(70);
            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(25);
            tree.Insert(5);

            Console.WriteLine("In-order Traversal after insertion:");
            foreach (var item in tree.InOrderTraversal())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            // Test Search
            Console.WriteLine("Search for 25: " + tree.Search(25));  // Should be true
            Console.WriteLine("Search for 100: " + tree.Search(100));  // Should be false

            // Test Min and Max values
            Console.WriteLine("Min Value: " + tree.GetMinValue(tree.root));
            Console.WriteLine("Max Value: " + tree.GetMaxValue(tree.root));

            // Test Deletion
            tree.Delete(5);
            tree.Delete(60);

            Console.WriteLine("In-order Traversal after deletion:");
            foreach (var item in tree.InOrderTraversal())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            // Test other Traversals
            Console.WriteLine("Pre-order Traversal:");
            foreach (var item in tree.PreOrderTraversal())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Post-order Traversal:");
            foreach (var item in tree.PostOrderTraversal())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("BFS/Level-order Traversal:");
            foreach (var item in tree.BFS())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }
    }
}