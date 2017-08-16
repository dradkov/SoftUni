namespace _01.Logger.Models
{
    using _01.Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
      

        public string FormatedMessage(string time,string reportLevel, string message)
        {
            return $"{time} - {reportLevel} - {message}";
        }
    }
}
