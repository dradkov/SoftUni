namespace PascalTriangle
{
    using System;

    public class TrianglePascal
    {
        static void Main()
        {
            var inputRows = int.Parse(Console.ReadLine());


            var pascal = new long[inputRows][];


            for (int row = 0; row < inputRows; row++)
            {
                pascal[row] = new long[row+1];
                pascal[row][0] = 1;
                pascal[row][pascal[row].Length - 1] = 1;


                for (int col = 1; col < pascal[row].Length-1; col++)
                {
                    pascal[row][col] = pascal[row - 1][col - 1] + pascal[row-1][col];
                }
                

            }
           
        }
    }
}
