using _01.Logger.Enums;

namespace _01.Logger.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        void Append(string time, string reportLevel,string message);
    }
}
