namespace SquareWithMaximumSum
{
    using System;
    using System.Linq;
  
    public class SquareSum
    {
        static void Main()
        {
            var demention = Console.ReadLine().Split(',');

            var rowsLenght = int.Parse(demention[0]);
            var colsLenght = int.Parse(demention[1]);

            var matrix = new int[rowsLenght][];


            for (int row = 0; row < rowsLenght; row++)
            {
                matrix[row] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            }

            var maxSum = int.MinValue;
            var bestRow = 0;
            var bestCol = 0;

            for (int row = 0; row < rowsLenght-1; row++)
            {
                for (int col = 0; col < colsLenght-1; col++)
                {
                    var currentSum = matrix[row][col] + 
                                    matrix[row][col + 1] + 
                                    matrix[row + 1][col] + 
                                    matrix[row + 1][col + 1];

                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestRow][bestCol]} {matrix[bestRow][bestCol+1]}\n{matrix[bestRow+1][bestCol]} {matrix[bestRow+1][bestCol+1]}\n{maxSum}");
        }
    }
}
