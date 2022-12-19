using System.Drawing;

namespace SnakeTheGame
{
    public class Coco : IEatable
    {
        private Bitmap[] _img = new Bitmap[7];

        private int _stage;
        private int _timer;
        private int _points;
        public int Points { get => _points*(7-_stage); }
        public Bitmap Img { get => _img[_stage]; }
        public int X { get; }
        public int Y { get; }
        
        public string ObjectName()
        {
            return "Coco";
        }

        public bool Transformation()
        {
            if (_timer++ == 10)
            {
                _stage++;
                _timer = 0;
            }

            if (_stage > 6)
                return false;

            return true;
        }

        public Coco(int x, int y)
        {
            X = x;
            Y = y;
            _img[0] = new Bitmap(new Bitmap("PNG_Food\\Coco\\Coco1.png"),60,60);
            _img[1] = new Bitmap(new Bitmap("PNG_Food\\Coco\\Coco2.png"),60,60);
            _img[2] = new Bitmap(new Bitmap("PNG_Food\\Coco\\Coco3.png"),60,60);
            _img[3] = new Bitmap(new Bitmap("PNG_Food\\Coco\\Coco4.png"),60,60);
            _img[4] = new Bitmap(new Bitmap("PNG_Food\\Coco\\Coco5.png"),60,60);
            _img[5] = new Bitmap(new Bitmap("PNG_Food\\Coco\\Coco6.png"),60,60);
            _img[6] = new Bitmap(new Bitmap("PNG_Food\\Coco\\Coco7.png"),60,60);
            
            _points = 10;
            _stage = 0;
            _timer = 0;
        }
    }
}