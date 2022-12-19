using System;
using System.Drawing;

namespace SnakeTheGame
{
    public struct SnakePart
    {
        private Bitmap _img;
        private int _x;
        private int _y;
        private int _direction;
        
        
        public Bitmap Img { get => _img; set => _img = value; }
        
        public int X
        {
            get => _x;

            set
            {
                if (value < -1)
                    throw new Exception("Ошибка координаты X!");
                else
                    _x = value;
            }
        }

        public int Y
        {
            get => _y;

            set
            {
                if (value < -1)
                    throw new Exception("Ошибка координаты Y!");
                else
                    _y = value;
            }
        }

        public int DirMove
        {
            get => _direction;

            set
            {
                _direction = value;
            }
        }
        

        public SnakePart(Bitmap img,int x, int y,int dM)
        {
            this._img = img;
            this._x = x;
            this._y = y;
            this._direction = dM;
            
        }
        
        public SnakePart(SnakePart ob)
        {
            this._img = ob.Img;
            this._x = ob.X;
            this._y = ob.Y;
            this._direction = ob.DirMove;
        }
    }
}