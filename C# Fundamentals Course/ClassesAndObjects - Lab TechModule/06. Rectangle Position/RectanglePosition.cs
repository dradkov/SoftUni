namespace RectanglePosition
{
    using System;
    using System.Linq;

    class RectanglePosition
    {
        static void Main()
        {
            var firstRectangle = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondRectangle = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rectangleOne = new Rectangle
            {
                Left = firstRectangle[0],
                Top = firstRectangle[1],
                Wight = firstRectangle[2],
                Height = firstRectangle[3]
            };

            var rectangleSecond = new Rectangle
            {
                Left = secondRectangle[0],
                Top = secondRectangle[1],
                Wight = secondRectangle[2],
                Height = secondRectangle[3]
            };


            if (rectangleOne.Left >= rectangleSecond.Left &&
                rectangleOne.Top >= rectangleSecond.Top &&
                rectangleOne.Right <= rectangleSecond.Right &&
                rectangleOne.Bottom <= rectangleSecond.Bottom)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not Inside");
            }
        }
        
    }
}
