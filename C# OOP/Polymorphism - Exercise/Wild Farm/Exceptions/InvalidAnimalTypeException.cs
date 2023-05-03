namespace WildFarm.Exceptions
{
    public class InvalidAnimalTypeException : Exception
    {
        private const string DefaultMessage = "Animal type not supported!";
        public InvalidAnimalTypeException() 
            : base(DefaultMessage) { }

        public InvalidAnimalTypeException(string message) 
            : base(message) { }
    }
}
