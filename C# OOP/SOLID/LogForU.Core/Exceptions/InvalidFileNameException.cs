namespace LogForU.Core.Exceptions
{
    public class InvalidFileNameException : Exception
    {
        private const string DefaultMessage = "File name cannot be null or whitespace!";

        public InvalidFileNameException()
            : base(DefaultMessage) { }

        public InvalidFileNameException(string message)
            : base(message) { }       
    }
}
