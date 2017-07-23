namespace MaximalSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumMaximal
    {
        static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var rowsSize = matrixSize[0];
            var colsSize = matrixSize[1];

            var matrix = new long[rowsSize][];

            for (int row = 0; row < rowsSize; row++)
            {
                matrix[row] = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            }

            long maxSum = int.MinValue;

            var bestRow = 0;
            var bestCol = 0;


            for (int row = 0; row < rowsSize - 2; row++)
            {
                for (int col = 0; col < colsSize - 2; col++)
                {
                    var currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                                     matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                                     matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }


            Console.WriteLine($"Sum = {maxSum}");
            for (int row = bestRow; row < bestRow+3; row++)
            {
                for (int col = bestCol; col < bestCol+3; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
