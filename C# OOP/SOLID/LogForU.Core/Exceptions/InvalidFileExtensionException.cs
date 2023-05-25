namespace LogForU.Core.Exceptions
{
    public class InvalidFileExtensionException : Exception
    {
        private const string DefaultMessage = "File extension cannot be null or whitespace!";

        public InvalidFileExtensionException()
            : base(DefaultMessage) { }

        public InvalidFileExtensionException(string message)
            : base(message) { }       
    }
}
