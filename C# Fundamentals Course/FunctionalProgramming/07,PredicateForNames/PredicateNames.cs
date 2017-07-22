namespace PredicateForNames
{
    using System;
    using System.Linq;

    public class PredicateNames
    {
        static void Main(string[] args)
        {
            

            var len = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var result = names.Where(x => x.Length <= len).ToList();

            Console.WriteLine(string.Join("\n",result));

        }
    }
}
