namespace SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareMaxSum
    {
        static void Main()
        {
            var matrixSize = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var rowsInMatrix = matrixSize[0];
            var colsInMatrix = matrixSize[1];

            var matrix = new int[rowsInMatrix][];

            for (int row = 0; row < rowsInMatrix; row++)
            {
                matrix[row] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            }

            var maxSum = int.MinValue;
            var bestRow = 0;
            var bestCol = 0;



            for (int row = 0; row < rowsInMatrix-1; row++)
            {
                for (int col = 0; col < colsInMatrix-1; col++)
                {
                    var currentSum = matrix[row][col] +
                                     matrix[row][col + 1] +
                                     matrix[row + 1][col] +
                                     matrix[row + 1][col+1];

                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            //First Way To Print;
            //Console.WriteLine($"{matrix[bestRow][bestCol]} {matrix[bestRow][bestCol + 1]}\n{matrix[bestRow + 1][bestCol]} {matrix[bestRow + 1][bestCol + 1]}\n{maxSum}");

            //Second Way To Print
            for (int row = bestRow; row < bestRow+2; row++)
            {
                for (int col = bestCol; col < bestCol+2; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
