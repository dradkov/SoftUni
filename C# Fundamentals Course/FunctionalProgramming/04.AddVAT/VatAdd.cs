namespace AddVAT
{
    using System;
    using System.Linq;

    public class VatAdd
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(',').Select(double.Parse).Select(x => x * 1.20).ToList();

            foreach (var num in nums)
            {
                Console.WriteLine($"{num:F2}");
            }        

        }
    }
}
