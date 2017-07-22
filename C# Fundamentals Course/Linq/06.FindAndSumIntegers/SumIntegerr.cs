namespace FindAndSumIntegers
{
    using System;
    using System.Linq;

    public class SumIntegerr
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var sum = text.Split()
                .Select(w =>
                {
                    long value;
                    bool succses = long.TryParse(w, out value);
                    return new { value, succses };

                })
            .Where(s => s.succses)
            .Select(s => s.value)
            .ToList();


            if (sum.Any())
            {
                Console.WriteLine(sum.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }

        }
    }
}
