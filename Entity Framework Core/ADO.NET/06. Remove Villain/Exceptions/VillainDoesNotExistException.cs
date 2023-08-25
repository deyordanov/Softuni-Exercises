namespace _06._Remove_Villain.Exceptions;

public class VillainDoesNotExistException : Exception
{
    private const string DefaultMessage = "No such villain was found.";

    public VillainDoesNotExistException()
    : base(DefaultMessage) { }
}