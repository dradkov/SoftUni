namespace MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaxElement
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var queNums = new Stack<int>();

            var maxNumStack = new Stack<int>();      

            var maxNum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var currentNum = Console.ReadLine().Split();

                if (currentNum[0] == "1")
                {
                    var numForPush = int.Parse(currentNum[1]);
                    queNums.Push(numForPush);

                    if (numForPush >= maxNum)
                    {
                        maxNum = numForPush;
                        maxNumStack.Push(maxNum);
                    }

                }

                else if (currentNum[0] == "2")
                {
                  
                    var elemenOnTop = queNums.Pop();
                    var currMaxNum = maxNumStack.Peek();

                    if (elemenOnTop == currMaxNum)
                    {
                        maxNumStack.Pop();
                        if (maxNumStack.Count>0)
                        {
                            maxNum = maxNumStack.Peek();
                        }
                        else
                        {
                            maxNum = int.MinValue;
                        }

                    }

                }
                else
                {
                    Console.WriteLine(maxNumStack.Peek());

                }

            }          

        }
    }
}
