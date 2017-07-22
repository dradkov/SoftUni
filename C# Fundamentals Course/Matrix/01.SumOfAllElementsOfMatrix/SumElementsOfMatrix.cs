namespace SumOfAllElementsOfMatrix
{
    using System;
    using System.Linq;

    public class SumElementsOfMatrix
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var rowsInMatrix = matrixSize[0];
            var colsInMatrix = matrixSize[1];

            var matrix = new int[rowsInMatrix][];

            for (int row = 0; row < rowsInMatrix; row++)
            {
                matrix[row] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            }


            var maxSum = 0;

            for (int row = 0; row < rowsInMatrix; row++)
            {
                for (int col = 0; col < colsInMatrix; col++)
                {
                    maxSum += matrix[row][col];
                }
            }

            Console.WriteLine($"{rowsInMatrix}\n{colsInMatrix}\n{maxSum}");
        }
    }
}
