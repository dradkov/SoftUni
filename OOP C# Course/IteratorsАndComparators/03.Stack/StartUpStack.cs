namespace _03.Stack
{
    using _03.Stack.Models;
    using System;
    using System.Linq;


    public class StartUpStack
    {
        public static void Main(string[] args)
        {

            CustomStack<string> stack = new CustomStack<string>();

            string inputCommand;

            while ((inputCommand = Console.ReadLine()) != "END")
            {
                var command = inputCommand.Split(new[] { ',', ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (command[0])
                    {
                        case "Push":

                            var elements = command.Skip(1).ToList();

                            foreach (var element in elements)
                            {
                                stack.Push(element);
                            }
                         
                            break;
                        case "Pop":
                            stack.Pop();
                            break;

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No elements");
                   
                }
             
            }
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

        }
    }
}
