namespace CubicRube
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int dimensionSize = int.Parse(Console.ReadLine());

            long sumAllcells = 0;
            long amountCellSum = 0;

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "Analyze")
            {
                int[] token = inputLine.Split().Select(int.Parse).ToArray();

                if (token.Take(3).Any(x => x < 0 || x >= dimensionSize))
                {
                    continue;
                }
                if (token[3] != 0)
                {
                    sumAllcells += token[3];
                    amountCellSum++;
                }

            }
            Console.WriteLine(sumAllcells);
            Console.WriteLine(Math.Pow(dimensionSize, 3) - amountCellSum);
        }


    }
}



