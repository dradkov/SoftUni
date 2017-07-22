namespace IndexLetters
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var alfa = Console.ReadLine().ToCharArray();


            for (int i = 0; i < alfa.Length; i++)
            {
                Console.WriteLine("{0} -> {1}", alfa[i], alfa[i] - 'a');
            }
        }
    }
}

