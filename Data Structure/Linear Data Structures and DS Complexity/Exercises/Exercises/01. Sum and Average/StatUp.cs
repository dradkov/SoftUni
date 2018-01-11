namespace _01._Sum_and_Average
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static string OutputMsg = "Sum={0}; Average={1}";
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            if (numbers.Length == 0)
            {
                Console.WriteLine(string.Format(OutputMsg, 0, $"{0:f2}"));
                return;
            }


            Console.WriteLine(string.Format(OutputMsg, $"{numbers.Sum()}", $"{numbers.Average():f2}"));

        }
    }
}
