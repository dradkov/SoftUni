namespace CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            var inputAsString = Console.ReadLine().Split().Select(str => str.Trim()).ToList();
            var command = Console.ReadLine();

            var start = 0;
            var count = 0;

            var listArray = new List<string>();


            while (!command.Equals("end"))
            {
                var commandInfo = command.Split().Select(c => c.Trim()).ToList();

                var instructs = commandInfo[0];

                switch (instructs)
                {
                    case "reverse":

                        start = int.Parse(commandInfo[2]);
                        count = int.Parse(commandInfo[4]);

                        if (start<0 || start>= inputAsString.Count || start+count> inputAsString.Count || count<0 )
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                       

                        listArray = inputAsString.Skip(start).Take(count).Reverse().ToList();

                        inputAsString.RemoveRange(start, count);
                        inputAsString.InsertRange(start, listArray);

                        break;                         
                    case "sort":

                        start = int.Parse(commandInfo[2]);
                        count = int.Parse(commandInfo[4]);

                        if (start < 0 || start >= inputAsString.Count || start + count > inputAsString.Count || count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        listArray = inputAsString.Skip(start).Take(count).OrderBy(s => s).ToList();

                        inputAsString.RemoveRange(start, count);
                        inputAsString.InsertRange(start, listArray);

                        break;
                    case "rollLeft":

                        count = int.Parse(commandInfo[1]);

                        if (count<0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        for (int i = 0; i < count % inputAsString.Count; i++)
                        {
                            string element = inputAsString[0];

                            inputAsString.RemoveAt(0);
                            inputAsString.Add(element);

                        }

                        break;
                    case "rollRight":

                        count = int.Parse(commandInfo[1]);

                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        for (int i = 0; i < count % inputAsString.Count; i++)
                        {
                            string element = inputAsString[inputAsString.Count - 1];

                            inputAsString.RemoveAt(inputAsString.Count-1);
                            inputAsString.Insert(0,element);

                        }
                        break;
               
                }

                command = Console.ReadLine();
            }


            var output = string.Join(", ", inputAsString);

            Console.WriteLine($"[{output}]");
        }
    }
}
