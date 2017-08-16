using System;
using _01.Logger.Enums;

namespace _01.Logger.Models
{
    using _01.Logger.Interfaces;

    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Log(string time, string reportLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                ReportLevel currentReport = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);

                if (appender.ReportLevel <= currentReport)
                {
                    appender.Append(time, reportLevel, message);
                }
                //appender.Append(time, reportLevel,message);
            }
        }



        public void Error(string time, string message)
        {
            this.Log(time, "Error", message);
        }

        public void Info(string time, string message)
        {
            this.Log(time, "Info", message);
        }
        public void Fatal(string time, string message)
        {
            this.Log(time, "Fatal", message);
        }

        public void Warn(string time, string message)
        {
            this.Log(time, "Warning", message);
        }

        public void Critical(string time, string message)
        {
            this.Log(time, "Critical", message);
        }
    }
}
