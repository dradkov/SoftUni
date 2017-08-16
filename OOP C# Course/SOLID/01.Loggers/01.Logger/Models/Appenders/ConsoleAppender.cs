using _01.Logger.Enums;

namespace _01.Logger.Models
{
    using System;
    using _01.Logger.Interfaces;

    public  class ConsoleAppender : IAppender
   {
    

        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

       public ILayout Layout { get; }

       public ReportLevel ReportLevel { get; internal set; }

       public void Append(string time,string reportLevel, string message)
       {
           var formatedMessage = this.Layout.FormatedMessage(time, reportLevel, message);
           Console.WriteLine(formatedMessage);

       }
   }
}
