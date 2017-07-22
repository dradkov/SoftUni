namespace TriFunction
{
    using System;

    public class TriFunctions
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var currentSum = 0;

            var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < line.Length; i++)
            {
                var lineSum = line[i].ToCharArray();

                for (int k = 0; k < lineSum.Length; k++)
                {
                    currentSum += lineSum[k];
                }
                if (currentSum >= n)
                {
                    Console.WriteLine(string.Join("", lineSum));
                    return;
                }
                currentSum = 0;
            }

        }
    }
}
