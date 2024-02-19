namespace SeminarHub.Common.Exceptions;

public class SeminarParticipantNotFoundException : ApplicationException
{
    private const string DefaultMessage = "The given record has not been found!";

    public SeminarParticipantNotFoundException()
        : base(DefaultMessage) { }

    public SeminarParticipantNotFoundException(string message)
        : base(message) { }
}