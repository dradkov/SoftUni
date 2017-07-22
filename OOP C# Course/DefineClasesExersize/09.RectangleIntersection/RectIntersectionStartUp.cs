namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RectIntersectionStartUp
    {
        static void Main()
        {
            var commandsInfo = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            var listRect = new List<Rectangle>();

            for (int i = 0; i < int.Parse(commandsInfo[0]); i++)
            {
                var command = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                var id = command[0];
                var width = double.Parse(command[1]);
                var heigth = double.Parse(command[2]);
                var x = double.Parse(command[3]);
                var y = double.Parse(command[4]);

                listRect.Add(new Rectangle(id, width, heigth, x, y));

            }

            for (int i = 0; i < int.Parse(commandsInfo[1]); i++)
            {
                var arg = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var first = listRect.Where(r => r.ID == arg[0]).First();
                var second = listRect.Where(r => r.ID == arg[1]).First();

                Console.WriteLine(first.Intersects(second));
            }
        }
    }
}

