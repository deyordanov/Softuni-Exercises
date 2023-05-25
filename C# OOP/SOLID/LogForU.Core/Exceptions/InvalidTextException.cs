namespace LogForU.Core.Exceptions
{
    public class InvalidTextException : Exception
    {
        private const string DefaultMessage = "Text cannot be null or whitespace";

        public InvalidTextException()
            : base(DefaultMessage) { }

        public InvalidTextException(string message)
            : base(message) { }       
    }
}
