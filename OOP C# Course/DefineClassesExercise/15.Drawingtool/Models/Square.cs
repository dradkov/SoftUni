namespace Drawingtool.Models
{
    using System;

    public class Square
    {
        public int size;

        public Square(int size)
        {
            this.size = size;
        }

        public void Draw()
        {
            for (int i = 0; i < this.size; i++)
            {
                if (i == 0 || i == this.size - 1)
                {
                    Console.WriteLine("|" + new string('-', this.size) + "|");
                }
                else
                {
                    Console.WriteLine("|" + new string(' ', this.size) + "|");
                }
            }
        }
    }
}

