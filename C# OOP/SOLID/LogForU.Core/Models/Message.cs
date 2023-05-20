namespace LogForU.Core.Models
{
    using Enums;
    using Exceptions;
    using Interfaces;
    using Utilities.Validators;

    public class Message : IMessage
    {
        private string time;
        private string text;
        public Message(string time, string text, ReportLevel reportLevel)
        {
            this.Time = time;
            this.Text = text;
            this.ReportLevel = reportLevel;
        }

        public string Time
        {
            get => this.time;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidTimeException();
                }


                if (!TimeValidator.ValidateTime(value))
                {
                    throw new InvalidTimeFormatException();
                }

                this.time = value;
            }
        }

        public string Text
        {
            get => this.text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidTextException();
                }

                this.text = value;
            }
        }
        public ReportLevel ReportLevel { get; private set; }
    }
}
