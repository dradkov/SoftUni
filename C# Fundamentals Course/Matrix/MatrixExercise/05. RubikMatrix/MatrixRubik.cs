namespace RubikMatrix
{
    using System;
    using System.Linq;


    public class MatrixRubik
    {

        private static void Main()
        {
            var rubicSize = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int
               .Parse)
               .ToArray();

            var rowsSize = rubicSize[0];
            var colsSize = rubicSize[1];

            var matrix = FillTheRubic(rowsSize, colsSize);

            var numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var index = int.Parse(command[0]);
                var direction = command[1];
                var numMoves = int.Parse(command[2]);

                switch (direction)
                {
                    case "up":
                        GetDirectionUpDown(index, matrix, numMoves);
                        break;
                    case "down":
                        GetDirectionUpDown(index, matrix, rowsSize-numMoves%rowsSize);
                        break;
                    case "left":
                        GetDirectionLeftRight(index, matrix, numMoves);
                        break;
                    case "right":
                        GetDirectionLeftRight(index, matrix, colsSize-numMoves%colsSize);
                        break;
                    default:
                        break;
                }
                 
            }

            var element = 1;

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    var currentElement = matrix[rowIndex][colIndex];
                                    matrix[rowIndex][colIndex] = element;
                                    matrix[r][c] = currentElement;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }

        }

        public static void GetDirectionLeftRight(int index, int[][] matrix, int numMoves)
        {
            var temp = new int[matrix[0].Length];

            for (int col = 0; col < matrix[0].Length; col++)
            {
                temp[col] = matrix[index][(col + numMoves) % matrix[0].Length];
            }
            matrix[index] = temp;
        }

        public static void GetDirectionUpDown(int index, int[][] matrix, int numMoves)
        {
            var tempMatrix = new int[matrix.Length];


            for (int row = 0; row < matrix.Length; row++)
            {

                tempMatrix[row] = matrix[(row + numMoves) % matrix.Length][index];

            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][index] = tempMatrix[row];
            }
        }

        public static int[][] FillTheRubic(int rowsSize, int colsSize)
        {
            var matrix = new int[rowsSize][];
            var count = 1;
            
            for (int row = 0; row < rowsSize; row++)
            {
                matrix[row] = new int[colsSize];

                for (int col = 0; col < colsSize; col++)
                {
                    matrix[row][col] = count;
                    count++;
                }
            }


            return matrix;
        }
    }
}
