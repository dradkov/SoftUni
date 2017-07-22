using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        var arr1 = Console.ReadLine().Split().ToArray();
        var arr2 = Console.ReadLine().Split().ToArray();

        var count = 0;



        for (int a = 0; a < arr1.Length; a++)
        {
            for (int b = 0; b < arr2.Length; b++)
            {
                if (arr2[a] == arr1[b])
                {
                    count++;
                }
            }
        }



    }

}

