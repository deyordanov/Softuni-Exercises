namespace LogForU.Core.Appenders
{
    using Enums;
    using Interfaces;
    using IO.Interfaces;
    using Layouts.Interfaces;
    using Models;

    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = ReportLevel.Info)
        {
            this.Layout = layout;
            this.LogFile = logFile;
            this.ReportLevel = reportLevel;
        }
        public ILogFile LogFile { get; private set; }
        public ILayout Layout { get; private set; }
        public int MessagesAppended { get; private set; }
        public ReportLevel ReportLevel { get; set; }
        public void AppendMessage(Message message)
        {
            string content = string.Format(Layout.Format, message.Time, message.ReportLevel, message.Text) + Environment.NewLine;

            LogFile.WriteLine(content);
            
            File.AppendAllText(this.LogFile.FullPath, content); 

            this.MessagesAppended++;
        }
    }
}
