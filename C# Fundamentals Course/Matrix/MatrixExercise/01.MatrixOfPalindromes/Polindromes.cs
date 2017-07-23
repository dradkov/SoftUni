namespace MatrixOfPalindromes
{
    using System;
    using System.Linq;
 
    public class Polindromes
    {
        static void Main()
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rowsSize = matrixSize[0];
            var colsSize = matrixSize[1];

            var sideLetter = 'a';

            for (int row = 0; row < rowsSize; row++)
            {
                var middLetter = sideLetter;
                for (int col = 0; col < colsSize; col++)
                {
                    Console.Write("" + sideLetter + middLetter + sideLetter+" ");
                    middLetter++;
                }
                Console.WriteLine();
                sideLetter++;
            }
        }
    }
}
