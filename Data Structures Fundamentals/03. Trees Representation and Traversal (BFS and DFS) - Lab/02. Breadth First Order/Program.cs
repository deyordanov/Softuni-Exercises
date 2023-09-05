namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {

            Tree<int> tree = new Tree<int>(10,
                new Tree<int>(14),
                            new Tree<int>(28),
                            new Tree<int>(40,
                                                new Tree<int>(15),
                                                new Tree<int>(214),
                                                new Tree<int>(102)));

            Console.WriteLine(string.Join(" ", tree.OrderDfs()));
        }
    }
}
