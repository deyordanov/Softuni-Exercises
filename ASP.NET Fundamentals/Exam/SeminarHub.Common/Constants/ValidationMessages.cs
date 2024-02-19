namespace SeminarHub.Common.Constants;

public static class ValidationMessages
{
    public static class Seminar
    {
        public const string SeminarTopicLengthMessage = "{0} has to be between {2} and {1} characters long!";
        public const string SeminarTopicRequiredMessage = "{0} is required!";

        public const string SeminarLecturerLengthMessage = "{0} has to be between {2} and {1} characters long!";
        public const string SeminarLecturerRequiredMessage = "{0} is required!";

        public const string SeminarDetailsLengthMessage = "{0} has to be between {2} and {1} characters long!";
        public const string SeminarDetailsRequiredMessage = "{0} is required!";

        public const string SeminarDurationRangeMessage = "{0} has to be between {1} and {2}!";

        public const string SeminarDateAndTimeRequiredMessage = "{0} is required!";
        public const string SeminarDateAndTimeInvalidDateMessage = "The date is invalid, format must be: {0}";


        public const string SeminarCategoryRequiredMessage = "{0} is required!";
    }
}