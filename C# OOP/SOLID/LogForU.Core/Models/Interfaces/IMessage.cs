namespace LogForU.Core.Models.Interfaces
{
    using Enums;

    public interface IMessage
    {
        string Time { get; }
        string Text { get; }
        ReportLevel ReportLevel { get; }
    }
}
