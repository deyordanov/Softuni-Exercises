namespace LogForU.Core.Appenders
{
    using Enums;
    using Interfaces;
    using Layouts.Interfaces;
    using Models;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }
        public int MessagesAppended { get; private set; }
        public ReportLevel ReportLevel { get; set; }

        public void AppendMessage(Message message)
        {
            Console.WriteLine(string.Format(Layout.Format, message.Time, message.ReportLevel, message.Text));

            this.MessagesAppended++;
        }
    }
}
