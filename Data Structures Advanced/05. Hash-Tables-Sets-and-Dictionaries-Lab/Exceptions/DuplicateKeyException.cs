namespace HashTable.Exceptions
{
    using System;

    public class DuplicateKeyException : ArgumentException
    {
        private const string DefaultMessage = "A duplicate key has been added!";

        public DuplicateKeyException()
            : base(DefaultMessage) { }

        public DuplicateKeyException(string errorMessage, string value)
            : base(errorMessage, value) { }
    }
}