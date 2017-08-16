using System.Text;

namespace _01.Logger.Models.Layouts
{
    using _01.Logger.Interfaces;

    public class XmlLayout : ILayout
    {




        public string FormatedMessage(string time, string reportLevel, string message)
        {
          
          var sb = new StringBuilder();

            sb.AppendLine("<log>");
            sb.AppendLine($"   <date>{time}</date>");
            sb.AppendLine($"   <level>{reportLevel}</level>");
            sb.AppendLine($"   <message>{message}</message>");
            sb.Append("</log>");

            return sb.ToString();

        }
    }
}
