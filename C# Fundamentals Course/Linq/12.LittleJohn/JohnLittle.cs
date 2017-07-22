namespace LittleJohn
{
    using System;
    using System.Text.RegularExpressions;

    public class JohnLittle
    {
        static void Main(string[] args)
        {

            var decimalNum = GetArrows();
            var binNum = Convert.ToString(decimalNum, 2);
            var reverse = binNum.ToCharArray();
            Array.Reverse(reverse);
            binNum = binNum + string.Join("", reverse);
            var result = Convert.ToInt64(binNum, 2);

            Console.WriteLine(result);


        }

        private static int GetArrows()
        {
            var countS = 0;
            var countM = 0;
            var countL = 0;
            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();
                string pattern = @">-{5}>|>{2}-{5}>|>{3}-{5}>{2}";
                var regex = new Regex(pattern);
                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    switch (match.Length)
                    {
                        case 7:
                            countS++;
                            break;
                        case 8:
                            countM++;
                            break;
                        case 10:
                            countL++;
                            break;
                        default:
                            break;
                    }
                }
            }
            return countS * 100 + countM * 10 + countL;
        }
    }
}
