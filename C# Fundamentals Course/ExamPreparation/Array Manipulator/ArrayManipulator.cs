namespace ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();

            var command = Console.ReadLine();



            while (!command.Equals("end"))
            {
                var commandInfo = command.Split().ToList();


                switch (commandInfo[0])
                {
                    case "exchange":
                        input = ExchancheInput(input, commandInfo);
                        break;

                    case "max":
                        GetMaxIndex(input, commandInfo);
                        break;

                    case "min":
                        GetMinIndex(input, commandInfo);
                        break;

                    case "first":
                        GetFirstEvenOdd(input, commandInfo);

                        break;

                    case "last":
                        GetLastEvenOdd(input, commandInfo);
                        break;


                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", input)}]");
        }

        private static void GetLastEvenOdd(List<int> input, List<string> commandInfo)
        {
            var count = int.Parse(commandInfo[1]);
            var evenOdd = commandInfo[2];


            if (evenOdd == "even")
            {
                if (count > 0 && count <= input.Count)
                {
                    var temp = input.Where(x => x % 2 == 0).Reverse().Take(count).Reverse().ToList();

                    if (temp.Any())
                    {
                        Console.WriteLine($"[{string.Join(", ", temp)}]");
                    }
                    else
                    {
                        Console.WriteLine("[]");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid count");
                }
            }
            else if (evenOdd == "odd")
            {
                if (count > 0 && count <= input.Count)
                {
                    var temp = input.Where(x => x % 2 == 1).Reverse().Take(count).Reverse().ToList();

                    if (temp.Any())
                    {
                        Console.WriteLine($"[{string.Join(", ", temp)}]");
                    }
                    else
                    {
                        Console.WriteLine("[]");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid count");
                }
            }
        }

        private static void GetFirstEvenOdd(List<int> input, List<string> commandInfo)
        {
            var count = int.Parse(commandInfo[1]);
            var evenOdd = commandInfo[2];

            if (evenOdd == "even")
            {
                if (count > 0 && count <= input.Count)
                {
                    var temp = input.Where(x => x % 2 == 0).ToList();

                    var output = temp.Take(count).ToList();
                    if (output.Any())
                    {
                        Console.WriteLine($"[{string.Join(", ", output)}]");
                    }
                    else
                    {
                        Console.WriteLine("[]");
                    }


                }
                else
                {
                    Console.WriteLine("Invalid count");
                }

            }
            else if (evenOdd == "odd")
            {
                if (count > 0 && count <= input.Count)
                {
                    var temp = input.Where(x => x % 2 == 1).ToList();

                    var output = temp.Take(count).ToList();
                    if (output.Any())
                    {
                        Console.WriteLine($"[{string.Join(", ", output)}]");
                    }
                    else
                    {
                        Console.WriteLine("[]");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid count");
                }
            }

        }

        private static void GetMinIndex(List<int> input, List<string> commandInfo)
        {
            var evenOdd = commandInfo[1];

            if (evenOdd == "even")
            {
                var tempNums = input.Where(x => Math.Abs(x) % 2 == 0);

                if (tempNums.Count() > 0)
                {
                    var minEven = tempNums.Min();
                    var index = input.LastIndexOf(minEven);

                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            else if (evenOdd == "odd")
            {
                var tempNums = input.Where(x => Math.Abs(x) % 2 == 1);

                if (tempNums.Count() > 0)
                {
                    var minEven = tempNums.Min();
                    var index = input.LastIndexOf(minEven);

                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }

        }

        private static void GetMaxIndex(List<int> input, List<string> commandInfo)
        {
            var evenOdd = commandInfo[1];

            if (evenOdd == "even")
            {
                var tempNums = input.Where(x => Math.Abs(x) % 2 == 0);
                if (tempNums.Count() > 0)
                {
                    var maxEven = tempNums.Max();
                    var index = input.LastIndexOf(maxEven);

                    Console.WriteLine(index);

                }
                else
                {
                    Console.WriteLine("No matches");
                }

            }
            else if (evenOdd == "odd")
            {
                var tempNums = input.Where(x => Math.Abs(x) % 2 == 1);

                if (tempNums.Count() > 0)
                {
                    var maxOdd = tempNums.Max();
                    var index = input.LastIndexOf(maxOdd);

                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }

            }

        }

        private static List<int> ExchancheInput(List<int> input, List<string> commandInfo)
        {

            var index = int.Parse(commandInfo[1]);


            if (index < 0 || index >= input.Count)
            {
                Console.WriteLine("Invalid index");
                return input;
            }

            var temp = input.Skip(index + 1).ToList();
            temp.AddRange(input.Take(index + 1));

            return temp;

        }
    }
}
