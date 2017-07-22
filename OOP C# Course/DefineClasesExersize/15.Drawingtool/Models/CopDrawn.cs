namespace Drawingtool.Models
{
    public class CorDrawn
    {
        public Rectangle rectangle;
        public Square square;

        public CorDrawn(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public CorDrawn(Square square)
        {
            this.square = square;
        }
    }
}