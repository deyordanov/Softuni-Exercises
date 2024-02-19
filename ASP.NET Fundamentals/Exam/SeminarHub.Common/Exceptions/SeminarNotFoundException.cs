namespace SeminarHub.Common.Exceptions;

public class SeminarNotFoundException : ApplicationException
{
    private const string DefaultMessage = "The given seminar has not been found!";

    public SeminarNotFoundException()
        : base(DefaultMessage) { }

    public SeminarNotFoundException(string message)
        : base(message) { }
}