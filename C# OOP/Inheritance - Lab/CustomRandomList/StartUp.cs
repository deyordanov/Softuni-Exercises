namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            string str = list.RandomString();
        }
    }
}