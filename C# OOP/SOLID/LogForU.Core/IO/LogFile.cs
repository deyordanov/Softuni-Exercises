namespace LogForU.Core.IO
{
    using System.Text;
    using Exceptions;
    using Interfaces;
    using Utilities.Validators;

    public class LogFile : ILogFile
    {
        private string DefaultName = $"Log_{DateTime.Now:yyyy-MM-dd-hh-mm-ss}";
        private const string DefaultExtension = "txt";
        private string DefaultPath = $"{Directory.GetCurrentDirectory()}";

        private string name;
        private string extension;
        private string path;

        private readonly StringBuilder content;

        public LogFile()
        {
            this.Name = DefaultName;
            this.Extension = DefaultExtension;
            this.Path = DefaultPath;

            content = new StringBuilder();
        }

        public LogFile(string name, string extension, string path)
            :this()
        {
            this.Name = name;
            this.Extension = extension;
            this.Path = path;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidFileNameException();
                }

                this.name = value;
            }
        }

        public string Extension
        {
            get => this.extension;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidFileExtensionException();
                }

                this.extension = value;
            }
        }

        public string Path
        {
            get => this.path;
            private set
            {
                if (!PathValidator.ValidatePath(value))
                {
                    throw new InvalidFilePathException();
                }

                this.path = value;
            }
        }

        public string FullPath => System.IO.Path.GetFullPath($"{this.Path}/{this.Name}.{this.Extension}");
        public string Content => this.content.ToString();
        public int Size => this.content.ToString().Sum(c => c);

        public void WriteLine(string text)
            => this.content.AppendLine(text);
    }
}
