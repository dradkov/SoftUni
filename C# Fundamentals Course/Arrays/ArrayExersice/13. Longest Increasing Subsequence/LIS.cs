namespace LIS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LargestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            

            string inputStr = Console.ReadLine();
            List<int> inputL = inputStr.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int countSeq = 0;
            int len = inputL.Count;
            int maxL = inputL.Max();
            int nextN = 1;
            int tempPos = 1;
            int pos;
            List<int> tempL = new List<int>();
            List<int> posIncSubseqL = new List<int>();

           
            if (len == 1)
            {
                tempL.Add(inputL[0]);
                tempPos = 0;
                countSeq = 1;
            }
            else
            {
                for (int i = 0; i < len - 1; i++)
                {
                    tempL.Add(inputL[i]);
                    tempPos = i + 1;
                    do
                    {
                        for (int j = tempPos; j < len; j++)
                        {
                            if (inputL[j] == inputL[i] + nextN)
                            {
                                tempL.Add(inputL[j]);
                              
                                tempPos = j + 1;
                                break;
                            }
                            if ((inputL[i] + nextN) > maxL)
                            {
                               
                                break;
                            }
                        }
                        nextN++;
                    } while (nextN <= maxL);
                    posIncSubseqL.Add(i); 
                    posIncSubseqL.Add(tempL.Count); 
                 
                    tempL.Clear(); 
                    nextN = 1; 

                } 

                for (int i = 1; i < posIncSubseqL.Count; i += 2)
                {
                    if (posIncSubseqL[i] > countSeq)
                    {
                        countSeq = posIncSubseqL[i];
                        tempPos = posIncSubseqL[i - 1];
                    }
                }
            } 
            pos = tempPos;
            tempL.Clear();
            tempL.Add(inputL[pos]);
            tempPos = pos + 1;
            nextN = 1;

            if (countSeq > 1)
            {
                do
                {
                    for (int j = tempPos; j < len; j++)
                    {
                        if (inputL[j] == inputL[pos] + nextN)
                        {
                            tempL.Add(inputL[j]);
                            
                            tempPos = j + 1;
                            break;
                        }
                    }
                    nextN++;
                } while (nextN <= maxL);
            }

            Console.WriteLine(string.Join(" ", tempL));

        } 
    }
}