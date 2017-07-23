namespace SumMatrixElements
{
    using System;
    using System.Linq;


    public class MatrixElementsSum
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

            var sum = 0;

            for (int row = 0; row < rowsLenght; row++)
            {
                for (int col = 0; col < colsLenght; col++)
                {
                    sum += matrix[row][col];
                }
            }

            Console.WriteLine($"{rowsLenght}\n{colsLenght}\n{sum}");
        }
    }
}
