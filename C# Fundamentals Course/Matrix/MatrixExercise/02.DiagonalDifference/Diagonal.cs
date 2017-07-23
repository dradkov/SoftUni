namespace DiagonalDifference
{
    using System;
    using System.Linq;

    public class Diagonal
    {
        static void Main()
        {
            var numberOfRows = int.Parse(Console.ReadLine());


            var matrix = new long[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse).ToArray();
            }

            long leftSum = 0;
            long rightSum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    if (row == col)
                    {
                        leftSum += matrix[row][col];
                    }
                    if (col == numberOfRows-row-1)
                    {
                        rightSum += matrix[row][col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(leftSum- rightSum));
           
        }
    }
}
