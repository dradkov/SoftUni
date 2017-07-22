namespace FirstName
{
    using System;
    using System.Linq;

    public class NameFirst
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();
            var chars = Console.ReadLine().Split();
            var order = chars.OrderBy(x => x).ToList();

            var result = string.Empty;
            foreach (var letter in order)
            {
                result = words.Where(w => w.ToLower().StartsWith(letter.ToLower())).FirstOrDefault();

                if (result != null)
                {
                    Console.WriteLine(result);
                    break;
                }

            }
            if (result == null)

            {
                Console.WriteLine("No match");
            }
        }
    }
}
