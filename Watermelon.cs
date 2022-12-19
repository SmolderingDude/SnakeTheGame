using System.Collections.Generic;
using System.Drawing;

namespace SnakeTheGame
{
    public class Watermelon : IEatable
    {
        private Bitmap[] _img = new Bitmap[11];

        private int _stage;
        private int _timer;
        private int _points;
        public int Points
        {
            get
            {
                if (10-_stage == 0)
                    return _points;
                return _points * (10 - _stage);

            }
        } 
        public Bitmap Img { get => _img[_stage]; }
        public int X { get; }
        public int Y { get; }
        
        public string ObjectName()
        {
            return "Watermelon";
        }

        public int[,] ActivePoint()
        {

            int[,] mas = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    mas[i, j] = 1;
            
            if (_stage < 5)
                return mas;
            
            if(_stage < 8)
            {
                mas[0, 0] = 0;
                mas[0, 2] = 0;
                mas[2, 0] = 0;
                mas[2, 2] = 0;
                return mas;
            }
            
            for (int i = 0; i < 3;i++)
                for (int j = 0; j < 3; j++)
                    mas[i, j] = 0;

            mas[1, 1] = 1;
            return mas;

        }
        public bool Transformation()
        {
            if (_timer++ == 15)
            {
                _stage++;
                _timer = 0;
            }

            if (_stage > 10)
                return false;

            return true;
        }

        public Watermelon(int x, int y)
        {
            X = x;
            Y = y;
            for (int i = 1;i < 12;i++)
                _img[i-1] = new Bitmap(new Bitmap($"PNG_Food\\Watermelon\\Watermelon{i}.png"),90,90); 
            _points = 10;
            _stage = 0;
            _timer = 0;
        }
    }
}