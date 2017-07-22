namespace RectanglePosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Rectangle
    {
        public int Top { get; set; }
        public int Left{ get; set; }
        public int Wight { get; set; }
        public int Height { get; set; }

        public int Bottom => Top + Height;

        public int Right => Left + Wight;

        public int Area()
        {
            return Wight * Height; 
        }  
    }
}
