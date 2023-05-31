namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "Peter";
            person1.Age = 20;
            Person person2 = new Person();
            person2.Name = "George";
            person2.Age = 18;
            Person person3 = new Person();
            person3.Name = "Jose";
            person3.Age = 43;
        }
    }
}