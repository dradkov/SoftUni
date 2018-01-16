namespace LinkedStack
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            LinkedStack<int> stack= new LinkedStack<int>();


            stack.Push(3);
            stack.Push(7);
            stack.Push(4);
            stack.Push(6);

            Console.WriteLine(string.Join(" ",stack.ToArray()));
        }
    }
}
