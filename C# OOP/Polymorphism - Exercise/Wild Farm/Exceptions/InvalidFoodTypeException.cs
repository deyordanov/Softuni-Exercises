namespace WildFarm.Exceptions
{
    public class InvalidFoodTypeException : Exception
    {
        private const string DefaultMessage = "Food type not supported!";
        public InvalidFoodTypeException() 
            : base(DefaultMessage) { }

        public InvalidFoodTypeException(string message) 
            : base(message) { }
    }
}
