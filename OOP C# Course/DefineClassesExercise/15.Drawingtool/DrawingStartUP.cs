namespace Drawingtool.Models
{
    using System;

    public class DrawingStartUP
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();

            if (figure == "Square")
            {
                var size = int.Parse(Console.ReadLine());
                var cor = new CorDrawn(new Square(size));
                cor.square.Draw();
            }
            else if (figure == "Rectangle")
            {
                var width = int.Parse(Console.ReadLine());
                var heigth = int.Parse(Console.ReadLine());
                var cor = new CorDrawn(new Rectangle(width, heigth));
                cor.rectangle.Draw();
            }
        }
    }
}
