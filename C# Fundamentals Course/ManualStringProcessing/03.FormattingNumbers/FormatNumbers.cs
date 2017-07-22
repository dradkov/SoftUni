namespace FormattingNumbers
{
    using System;

    public class FormatNumbers
    {
        static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n','\r' }, StringSplitOptions.RemoveEmptyEntries);


            var a = int.Parse(inputNumbers[0]);
            var b = double.Parse(inputNumbers[1]);
            var c = double.Parse(inputNumbers[2]);

            var hexadecimal = a.ToString("X");
            var bin = Convert.ToString(a, 2);

            if (bin.Length > 10)
            {
                bin = bin.Substring(0, 10);
            }

            Console.WriteLine
                (string.Format($"|{hexadecimal.PadRight(10, ' ')}|{bin.PadLeft(10, '0')}|{b,10:f2}|{c,-10:F3}|"));

        }
    }
}
