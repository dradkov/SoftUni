namespace TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PracticeTarget
    {
        static void Main()
        {

            var matrixSize = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int
               .Parse)
               .ToArray();

            var rowsSize = matrixSize[0];
            var colsSize = matrixSize[1];

            var matrix = new char[rowsSize][];

            var snake = Console.ReadLine();

            FillMatrix(rowsSize, colsSize, matrix, snake);

            var shotInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var impactRow = shotInfo[0];
            var impactCol = shotInfo[1];
            var radius = shotInfo[2];

            FireShot(matrix, impactRow, impactCol, radius);

            for (int col = 0; col < matrix[1].Length; col++)
            {
                RunGravity(matrix, col);
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }

        }

        static void RunGravity(char[][] matrix, int col)
        {
            while (true)
            {
                bool hasFallen = false;
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    char topChar = matrix[row - 1][col];
                    char currentChar = matrix[row][col];
                    if (currentChar == ' ' && topChar != ' ')
                    {
                        matrix[row][col] = topChar;
                        matrix[row - 1][col] = ' ';
                        hasFallen = true;
                    }
                }
                if (!hasFallen)
                {
                    break;
                }
            }
        }

       public static void FireShot(char[][] matrix, int impactRow, int impactCol, int radius)
        {
            //(x - center_x)^2 + (y - center_y)^2 <= radius^2

            for (int row = 0; row < matrix[0].Length; row++)
            {
                for (int col = 0; col < matrix[1].Length; col++)
                {
                    if ((col - impactCol) * (col - impactCol) + (row - impactRow) * (row - impactRow) <= radius * radius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

        }

        public static void FillMatrix(int rowsSize, int colsSize, char[][] matrix, string snake)
        {
            bool isMovingLeft = true;
            var currentIndex = 0;

            for (int row = rowsSize - 1; row >= 0; row--)
            {
                matrix[row] = new char[colsSize];
                if (isMovingLeft)
                {
                    for (int col = colsSize - 1; col >= 0; col--)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }
                        matrix[row][col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < colsSize; col++)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }
                        matrix[row][col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
                isMovingLeft = !isMovingLeft;
            }
        }
    }
}
