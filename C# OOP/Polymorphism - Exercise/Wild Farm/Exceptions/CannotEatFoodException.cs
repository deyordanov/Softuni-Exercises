namespace WildFarm.Exceptions
{
    public class CannotEatFoodException : Exception
    {
        public CannotEatFoodException(string message) 
            : base(message) { }
    }
}
