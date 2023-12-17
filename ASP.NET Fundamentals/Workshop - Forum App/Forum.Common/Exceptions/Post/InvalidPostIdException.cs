namespace Forum.Common.Exceptions.Post;

using static ExceptionMessages.Post;

public class InvalidPostIdException : Exception
{
    public InvalidPostIdException(string message)
        : base(message) { }

    public InvalidPostIdException()
        : base(InvalidPostIdMessage) { }
}