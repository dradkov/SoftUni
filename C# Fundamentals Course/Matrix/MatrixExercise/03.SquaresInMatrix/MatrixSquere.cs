namespace SquaresInMatrix
{
    using System;
    using System.Linq;

    public class MatrixSquere
    {
        static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsSize = matrixSize[0];
            var colsSize = matrixSize[1];

            var matrix = new char[rowsSize][];

            for (int row = 0; row < rowsSize; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }


            var numOfSqueres = 0;

            for (int row = 0; row < rowsSize - 1; row++)
            {
                for (int col = 0; col < colsSize - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] &&
                        matrix[row][col] == matrix[row + 1][col] &&
                        matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        numOfSqueres++;
                    }
                }
            }
            if (numOfSqueres>0)
            {
                Console.WriteLine(numOfSqueres);
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
