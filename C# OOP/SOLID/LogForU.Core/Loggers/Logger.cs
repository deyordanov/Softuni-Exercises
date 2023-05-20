namespace LogForU.Core.Loggers
{
    using Appenders.Interfaces;
    using Enums;
    using Interfaces;
    using Models;

    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateTime, string message)
            => AppendAll(dateTime, message, ReportLevel.Info);

        public void Warning(string dateTime, string message)
            => AppendAll(dateTime, message, ReportLevel.Warning);

        public void Error(string dateTime, string message)
            => AppendAll(dateTime, message, ReportLevel.Error);

        public void Critical(string dateTime, string message)
            => AppendAll(dateTime, message, ReportLevel.Critical);

        public void Fatal(string dateTime, string message)
            => AppendAll(dateTime, message, ReportLevel.Fatal);

        private void AppendAll(string dateTime, string text, ReportLevel reportLevel)
        {
            Message message = new Message(dateTime, text, reportLevel);
            foreach (IAppender appender in appenders)
            {
                if (message.ReportLevel >= appender.ReportLevel)
                {
                    appender.AppendMessage(message);
                }
            }
        }
    }
}
