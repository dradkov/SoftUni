namespace RectangleIntersection
{
    public class Rectangle
    {

        private string id;
        private double width;
        private double height;
        private double x;
        private double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.ID = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public string Intersects(Rectangle rectangle)
        {
            if ((rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) ||
                (rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x >= this.x && rectangle.x <= this.x + this.width) ||
                (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) ||
                (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x >= this.x && rectangle.x <= this.x + this.width))
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}

