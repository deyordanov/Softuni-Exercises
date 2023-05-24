namespace LogForU.Core.Exceptions
{
    public class InvalidTimeFormatException : Exception
    {
        private const string DefaultMessage = "Time format is not supported!";

        public InvalidTimeFormatException()
            :base(DefaultMessage) { }

        public InvalidTimeFormatException(string message)
            :base(message) { }
    }
}
