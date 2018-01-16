namespace MatchingBrackets
{

    using System;
    using System.Collections.Generic;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string exprecion = "1+(2-(2+3)*4/(3+1))*5";

            for (int i = 0; i < exprecion.Length; i++)
            {
                if (exprecion[i] == '(')
                {
                    stack.Push(i);
                }
                else if (exprecion[i] == ')')
                {
                    var startindex = stack.Pop();
                    int endIndex = i;

                    Console.WriteLine(exprecion.Substring(startindex, endIndex - startindex + 1));
                }
            }
        }
    }
}
