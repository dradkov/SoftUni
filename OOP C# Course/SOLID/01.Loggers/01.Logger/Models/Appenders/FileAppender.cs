using _01.Logger.Enums;

namespace _01.Logger.Models
{
    using _01.Logger.Interfaces;

    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }


        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; }

        public LogFile File { get; internal set; }

        public void Append(string time, string reportLevel, string message)
        {
            var formatedMessage = this.Layout.FormatedMessage(time, reportLevel, message);        
            this.File.Write(formatedMessage);
        }
    }
}
