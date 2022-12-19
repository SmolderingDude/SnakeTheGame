using System.Drawing;

namespace SnakeTheGame
{
    public class Apple : IEatable
    {
        public int Points { get; }
        public Bitmap Img { get; }
        public int X { get; }
        public int Y { get; }
        
        public string ObjectName()
        {
            return "Apple";
        }

        public bool Transformation()
        {
            return true;
        }

        public Apple(int x, int y)
        {
            X = x;
            Y = y;
            Img = new Bitmap(new Bitmap("PNG_Food\\Apple.png"),30,30);
            Points = 10;
        }
    }
}