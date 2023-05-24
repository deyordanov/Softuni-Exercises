namespace LogForU.Core.Exceptions
{
    public class InvalidTimeException : Exception
    {
        private const string DefaultMessage = "Time cannot be null or whitespace!";

        public InvalidTimeException()   
            : base(DefaultMessage) { }

        public InvalidTimeException(string message)
            : base(message) { }
    }
}
