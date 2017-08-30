namespace Minedraft
{
    using Minedraft.Core;
    using Minedraft.Interfaces;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
