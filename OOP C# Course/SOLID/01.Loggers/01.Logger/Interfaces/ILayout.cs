namespace _01.Logger.Interfaces
{
   public interface ILayout
    {
      

        string FormatedMessage(string time,string reportLevel, string message);
    }
}
