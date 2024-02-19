namespace SeminarHub.Common.Constants;

public static class ValidationConstants
{
    public static class Seminar
    {
        public const int SeminarTopicMaxLength = 100;
        public const int SeminarTopicMinLength = 3;

        public const int SeminarLecturerMaxLength = 60;
        public const int SeminarLecturerMinLength = 5;

        public const int SeminarDetailsMaxLength = 500;
        public const int SeminarDetailsMinLength = 10;

        public const string DateFormat = "dd/MM/yyyy HH:mm";

        public const int SeminarDurationMaxRange = 180;
        public const int SeminarDurationMinRange = 30;
    }

    public static class Category
    {
        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 3;
    }
}