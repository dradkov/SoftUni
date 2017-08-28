using System.ComponentModel.Design;
using System.Data;

namespace KnightGame
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());

            char[][] matrix = FillMatrix(matrixSize);

            int count = 0;



            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == 'K')
                    {
                        if (iSInTheMatrix(matrix, rowIndex + 1, colIndex + 2))
                        {
                            if (matrix[rowIndex + 1][colIndex + 2] == 'K')
                            {
                                matrix[rowIndex + 1][colIndex + 2] = 'O';
                                count++;
                              
                            }
                        }
                        if (iSInTheMatrix(matrix, rowIndex + 1, colIndex - 2))
                        {
                            if (matrix[rowIndex + 1][colIndex - 2] == 'K')
                            {
                                matrix[rowIndex + 1][colIndex - 2] = 'O';
                                count++;
                               
                            }
                        }
                        if (iSInTheMatrix(matrix, rowIndex + 2, colIndex - 1))
                        {
                            if (matrix[rowIndex + 2][colIndex - 1] == 'K')
                            {
                                matrix[rowIndex + 2][colIndex - 1] = 'O';
                                count++;
                              
                            }
                        }
                        if (iSInTheMatrix(matrix, rowIndex + 2, colIndex + 1))
                        {
                            if (matrix[rowIndex + 2][colIndex + 1] == 'K')
                            {
                                matrix[rowIndex + 2][colIndex + 1] = 'O';
                                count++;
                              
                            }
                        }

                    }
                }
            }

            Console.WriteLine(count);
        }

        private static bool iSInTheMatrix(char[][] matrix, int rowIndex, int colIndex)
        {
            return (rowIndex >= 0 && rowIndex < matrix.Length) && (colIndex >= 0 && colIndex < matrix.Length);
        }

        private static char[][] FillMatrix(int matrixSize)
        {
            char[][] matrix = new char[matrixSize][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().ToCharArray();
            }

            return matrix;
        }
    }
}
