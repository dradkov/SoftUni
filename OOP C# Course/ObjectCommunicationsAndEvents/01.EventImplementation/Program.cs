namespace _01.EventImplementation
{
    using System;
    using _01.EventImplementation.Models;

    public class StartUp
    {

        public static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string name ;

            while ((name = Console.ReadLine())!="End")
            {
                dispatcher.Name = name;
               
            }

        }

    }
}
