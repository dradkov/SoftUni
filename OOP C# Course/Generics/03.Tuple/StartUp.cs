namespace Tuple
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputInfo = Console.ReadLine().Split();

            var tupleOne = new Threeuple<string, string, string>((inputInfo[0] + " " + inputInfo[1]), inputInfo[2], inputInfo[3]);

            inputInfo = Console.ReadLine().Split();


            var tupleTwo = new Threeuple<string, int, bool>(inputInfo[0], int.Parse(inputInfo[1]), inputInfo[2] == "drunk" ? true : false);

            inputInfo = Console.ReadLine().Split();

            var tupleThree = new Threeuple<string, double, string>(inputInfo[0], double.Parse(inputInfo[1]), inputInfo[2]);


            Console.WriteLine(tupleOne);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}

