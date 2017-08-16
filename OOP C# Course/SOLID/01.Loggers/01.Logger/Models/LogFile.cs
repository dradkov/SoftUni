namespace _01.Logger.Models
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LogFile
    {

        private StringBuilder sbStorage;

        public LogFile()
        {
            this.sbStorage = new StringBuilder();
        }

        public int Size { get; private set; }

        private int GetLetterSum(string message)
        {
            var result = message.Where(x => char.IsLetter(x)).Sum(c => c);
            return result;

        }



        public void Write(string formatedMessage)
        {
            this.sbStorage.AppendLine(formatedMessage);
            File.AppendAllText("log.txt", formatedMessage + Environment.NewLine);
            this.Size = this.GetLetterSum(formatedMessage);
        }
    }
}
