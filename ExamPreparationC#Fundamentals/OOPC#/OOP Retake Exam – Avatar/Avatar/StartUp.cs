namespace Avatar
{

    using Avatar.Core;
    using Avatar.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
