using System.Drawing;

namespace SnakeTheGame
{
    public interface IEatable
    {
        int Points { get; }
        Bitmap Img { get; }
        int X { get; }
        int Y { get; }

        bool Transformation();
        string ObjectName(); 
    }
}