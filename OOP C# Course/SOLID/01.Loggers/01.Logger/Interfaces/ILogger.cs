namespace _01.Logger.Interfaces
{
    public interface ILogger
    {
        void Error(string time, string message);

        void Info(string time, string message);

        void Critical(string time, string message);

        void Fatal(string time, string message);

        void Warn(string time, string message);
    }
}
