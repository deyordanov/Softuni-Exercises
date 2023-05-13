namespace LogForU.Core.Utilities.Validators
{
    public static class PathValidator
    {
        public static bool ValidatePath(string path)
            => Directory.Exists(path);
    }
}
