namespace SeminarHub.Common.Constants;

public static class ExceptionMessages
{
    public static class Seminar
    {
        public const string SeminarNotFoundExceptionMessage = "The seminar with id: '{0}' has not been found!";
    }

    public static class SeminarParticipant
    {
        public const string SeminarParticipantNotFoundExceptionMessage =
            "The given record with id: '{0}-{1}' has not been found!";
    }
}