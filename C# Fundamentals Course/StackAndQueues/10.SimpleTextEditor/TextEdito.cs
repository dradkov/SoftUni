namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class TextEditor
        {
            public static void Main()
            {
                int numberOfOperations = int.Parse(Console.ReadLine());

                StringBuilder sb = new StringBuilder();
                var sbHistory = new Stack<string>();

                while (numberOfOperations-- > 0)
                {
                    var inputParams = Console.ReadLine().Split();
                    var cmd = inputParams[0];
                    var value = inputParams.Length > 1 ? inputParams[1] : null;

                    switch (cmd)
                    {
                        // appends value to the end of the text
                        case "1":
                            sbHistory.Push(sb.ToString());
                            sb.Append(value);
                            break;

                        // erases the last number(value) of elements from the text
                        case "2":
                            sbHistory.Push(sb.ToString());
                            sb.Length -= int.Parse(value);
                            break;

                        // returns the element at position index(value) from the text
                        case "3":
                            Console.WriteLine(sb[int.Parse(value) - 1]);
                            break;

                        // undoes the last not undone command of type 1 / 2 
                        // and returns the text to the state before that operation
                        case "4":
                            sb = new StringBuilder(sbHistory.Pop());
                            break;
                    }
                }
            }
        }
    
}