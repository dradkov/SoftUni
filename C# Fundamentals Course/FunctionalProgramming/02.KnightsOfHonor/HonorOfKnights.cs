namespace KnightsOfHonor
{
    using System;
    using System.Linq;

    public class HonorOfKnights
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string> print = title => Console.WriteLine(title);

            foreach (var name in names)
            {
                print("Sir" + " " + name);
            }

        }


    }
}
