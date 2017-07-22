namespace CustomMinFunction
{
    using System;
    using System.Linq;

    public class MinFunction
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, bool> smalestOne = x => x == numbers.Min();

            numbers.Where(smalestOne).Distinct().ToList().ForEach(n => Console.WriteLine(string.Join(" ", n)));
            

        }
    }
}
