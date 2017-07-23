namespace GroupNumbers
{
    using System;
    using System.Linq;

    public class NumbersGtoup
    {
        static void Main()
        {
            var inputInfo = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            var zero = inputInfo.Where(n => Math.Abs(n) % 3 == 0);
            var one = inputInfo.Where(n => Math.Abs(n) % 3 == 1);
            var two = inputInfo.Where(n => Math.Abs(n) % 3 == 2);

            Console.WriteLine(string.Join(" ",zero));
            Console.WriteLine(string.Join(" ",one));
            Console.WriteLine(string.Join(" ",two));

        }
    }
}
