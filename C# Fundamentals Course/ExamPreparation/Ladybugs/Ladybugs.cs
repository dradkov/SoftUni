namespace Ladybugs
{
    using System;
    using System.Linq;

    class Ladybugs
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] ladyBugsIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(a => a >= 0 && a < fieldSize)
                .ToArray();

            var ladyBugs = new int[fieldSize];

            for (int i = 0; i < ladyBugsIndexes.Length; i++)
            {
                var currentIndex = ladyBugsIndexes[i];
                ladyBugs[currentIndex] = 1;
            }

            string command = Console.ReadLine();

            while (!command.Equals("end"))
            {
                var commandInfo = command.Split();

                var ladyBugIndex = int.Parse(commandInfo[0]);
                var direction = commandInfo[1];
                var flyLength = int.Parse(commandInfo[2]);


                if (ladyBugIndex<0 || ladyBugIndex>= ladyBugs.Length)
                {
                    command = Console.ReadLine();
                    continue;
                }
                if (ladyBugs[ladyBugIndex]==0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                MovingLadyBugs(ladyBugs, ladyBugIndex, direction, flyLength);

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",ladyBugs));
        }

        private static void MovingLadyBugs(int[] ladyBugs, int ladyBugIndex, string direction, int flyLength)
        {
            ladyBugs[ladyBugIndex] = 0;

            var FoundBugs = false;

            while (!FoundBugs)
            {
                switch (direction)
                {
                    case "left":
                        ladyBugIndex -= flyLength;
                        break;
                    case "right":
                        ladyBugIndex += flyLength;
                        break;
                   
                }
                if (ladyBugIndex < 0 || ladyBugIndex >= ladyBugs.Length)
                {
                    FoundBugs = true;
                    continue;
                }
                if (ladyBugs[ladyBugIndex] == 1)
                {
                    continue;
                }
                if (ladyBugs[ladyBugIndex] == 0)
                {
                    ladyBugs[ladyBugIndex] = 1;
                    FoundBugs = true;
                    continue;
                }
            }
        }
    }
}
