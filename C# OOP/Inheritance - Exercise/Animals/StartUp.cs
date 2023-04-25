using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Channels;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string end;
            List<Animal> animals = new List<Animal>();
            while((end = Console.ReadLine()) != "Beast!")
            {
                string type = end;
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (type)
                    {
                        case "Cat":
                            Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            animals.Add(cat);
                            break;
                        case "Dog":
                            Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                            animals.Add(tomcat);
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }           
            animals.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
