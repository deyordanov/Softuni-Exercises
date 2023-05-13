namespace LogForU.Core.Utilities.Validators
{
    using System.Globalization;

    public static class TimeValidator
    {
        private static readonly ICollection<string> formats = new HashSet<string>() { "M/dd/yyyy h:mm:ss tt" };
        public static bool ValidateTime(string time)
        {
            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(time, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return true;
                }
            }

            return false;
        }

        public static void AddFormat(string format)
            => formats.Add(format);
    }
}
