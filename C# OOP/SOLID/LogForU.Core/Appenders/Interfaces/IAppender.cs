namespace LogForU.Core.Appenders.Interfaces
{
    using Enums;
    using Layouts.Interfaces;
    using Models;

    public interface IAppender
    {
        ILayout Layout { get; }
        int MessagesAppended { get; }
        ReportLevel ReportLevel { get; set; }
        void AppendMessage(Message message);
    }
}
