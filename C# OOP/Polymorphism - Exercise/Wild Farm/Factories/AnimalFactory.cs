
namespace WildFarm.Factories
{
    using Interfaces;
    using Models.Interfaces;
    using Exceptions;
    using Models.Animals;
    using Models.Animals.Mammals;
    using Models.Animals.Mammals.Felines;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalArgs)
        {
            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);
            if(type == "Hen")
            {
                return new Hen(name, weight, double.Parse(animalArgs[3]));
            }
            else if(type == "Owl")
            {
                return new Owl(name, weight, double.Parse(animalArgs[3]));
            }
            else if(type == "Mouse")
            {
                return new Mouse(name, weight, animalArgs[3]);
            }
            else if(type == "Dog")
            {
                return new Dog(name, weight, animalArgs[3]);
            }
            else if(type == "Cat")
            {
                return new Cat(name, weight, animalArgs[3], animalArgs[4]);
            }
            else if(type == "Tiger")
            {
                return new Tiger(name, weight, animalArgs[3], animalArgs[4]);
            }
            else
            {
                throw new InvalidAnimalTypeException();
            }
        }
    }
}
