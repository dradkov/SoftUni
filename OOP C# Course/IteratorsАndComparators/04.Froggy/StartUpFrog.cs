namespace _04.Froggy
{
    using System;
    using System.Linq;
    using _04.Froggy.Models;

    public static  class StartUpFrog
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ',',' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

           var lake = new Lake(numbers);

           
                Console.WriteLine(string.Join(", ",lake));
            

        }
        
    }
}
