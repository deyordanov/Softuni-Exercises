using WildFarm.Core.Interfaces;
using WildFarm.Exceptions;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private IAnimalFactory animalFactory;
        private IFoodFactory foodFactory;

        private ICollection<IAnimal> animals;

        private Engine()
        {
            animals = new HashSet<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }
        public void Run()
        {
            string end;
            while((end = reader.ReadLine()) != "End")
            {
                string[] animalArgs = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodArgs = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    IAnimal animal = this.animalFactory.CreateAnimal(animalArgs);
                    IFood food = this.foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));
                    animals.Add(animal);

                    this.writer.WriteLine(animal.MakeSound());
                    animal.Eat(food);
                }
                catch(CannotEatFoodException cefe)
                {
                    this.writer.WriteLine(cefe.Message);
                }
                catch(InvalidAnimalTypeException iate)
                {
                    this.writer.WriteLine(iate.Message);
                }
                catch(InvalidFoodTypeException ifte)
                {
                    this.writer.WriteLine(ifte.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            } 
            
            foreach(IAnimal animal in animals)
            {
                this.writer.WriteLine(animal);
            }
        }
    }
}
