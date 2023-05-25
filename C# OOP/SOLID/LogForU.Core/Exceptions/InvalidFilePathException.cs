namespace LogForU.Core.Exceptions
{
    public class InvalidFilePathException : Exception
    {
        private const string DefaultMessage = "File path does not exist!";

        public InvalidFilePathException()
            : base(DefaultMessage) { }

        public InvalidFilePathException(string message)
            : base(message) { }       
    }
}
