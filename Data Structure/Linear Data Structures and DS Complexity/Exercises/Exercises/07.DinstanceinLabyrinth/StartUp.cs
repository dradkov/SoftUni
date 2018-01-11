using System;

namespace _07.DinstanceinLabyrinth
{
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {



            int matrixSixe = int.Parse(Console.ReadLine());


            string[,] inputMatrix = FillMatrix(matrixSixe);

         
          DistanceInLabyrinth.CalcDistance(inputMatrix);
        }

        private static string[,] FillMatrix(int matrixSize)
        {
            string[,] matrix = new string[matrixSize, matrixSize];


            for (int i = 0; i < matrixSize; i++)
            {
                char[] tempword = Console.ReadLine().ToCharArray();

                for (int j = 0; j < tempword.Length; j++)
                {
                    matrix[i,j] = tempword[j].ToString();
                }
               
            }

            return matrix;
        }
    }

    public class DistanceInLabyrinth
    {
        // Keeps (row, col) pair
        private class HelpNode
        {
            public HelpNode(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; set; }
            public int Col { get; set; }
        }

        private static HelpNode startNode = new HelpNode(0, 0);

        public static void CalcDistance(string[,] inputMatrix)
        {
            int size = inputMatrix.GetLength(0);
            int[,] matrix = ParseMatrix(inputMatrix);
            Queue<HelpNode> queue = new Queue<HelpNode>(new[] { startNode });

            while (queue.Count > 0)
            {
                HelpNode currNode = queue.Dequeue();
                int row = currNode.Row;
                int col = currNode.Col;

                List<HelpNode> children = new List<HelpNode>()
                {
                    new HelpNode(row + 1, col), new HelpNode(row - 1, col),
                    new HelpNode(row, col + 1), new HelpNode(row, col - 1)
                };

                foreach (var child in children)
                {
                    if (inBounds(child.Row, child.Col, size) && matrix[child.Row, child.Col] == 0)
                    {
                        matrix[child.Row, child.Col] = matrix[row, col] + 1;
                        queue.Enqueue(new HelpNode(child.Row, child.Col));
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static bool inBounds(int row, int col, int size)
        {
            if (row >= 0 && col >= 0 && row < size && col < size)
            {
                return true;
            }
            return false;
        }

        // Converts string matrix to integer matrix
        private static int[,] ParseMatrix(string[,] matrix)
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (matrix[i, j])
                    {
                        case "0":
                            result[i, j] = 0;
                            break;
                        case "x":
                            result[i, j] = -1;
                            break;
                        default:
                            startNode.Row = i; startNode.Col = j;
                            break;
                    }
                }
            }

            return result;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == startNode.Row && j == startNode.Col)
                    {
                        Console.Write("*");
                        continue;
                    }
                    switch (matrix[i, j])
                    {
                        case 0:
                            Console.Write("u");
                            break;
                        case -1:
                            Console.Write("x");
                            break;
                        default:
                            Console.Write(matrix[i, j].ToString());
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}


