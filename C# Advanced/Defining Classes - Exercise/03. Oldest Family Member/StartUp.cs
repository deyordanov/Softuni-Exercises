namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for(int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(int.Parse(info[1]), info[0]);
                people.Add(person);
            }

            int age = int.MinValue;
            foreach(Person person in people)
            {
                if(person.Age > age)
                {
                    age = person.Age;
                }
            }

            Console.WriteLine($"{people.Where(p => p.Age == age).First().Name} {age}");
        }
    }
}