using System.Collections.Generic;
using System.Drawing;


namespace SnakeTheGame
{

    enum TypeOfSprite : int
    {
        Body,
        Head,
        Angle,
        Tail
    }
    public class Snake
    {
        private Bitmap[] _bodyLength = new Bitmap[2];
        private Bitmap[] _head = new Bitmap[4];
        private Bitmap[] _bodyAngle = new Bitmap[4];
        private Bitmap[] _tail = new Bitmap[4];
        private int _mapXSize;
        private int _mapYSize;
        private int _moveDirection;

        private LinkedList<SnakePart> _snake = new LinkedList<SnakePart>();
        

        public Snake(int x, int y,string snakeColor)
        {
            
            _bodyLength[0] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\Body1.png"),30,30);
            _bodyLength[1] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\Body2.png"),30,30);
            
            _head[(int)Program.MoveDirection.Up] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\headUp.png"),30,30);
            _head[(int)Program.MoveDirection.Right] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\headRight.png"),30,30);
            _head[(int)Program.MoveDirection.Down] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\headDown.png"),30,30);
            _head[(int)Program.MoveDirection.Left] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\headLeft.png"),30,30);
            
            _bodyAngle[0] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\Angle1.png"),30,30);
            _bodyAngle[1] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\Angle2.png"),30,30);
            _bodyAngle[2] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\Angle3.png"),30,30);
            _bodyAngle[3] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\Angle4.png"),30,30);
            
            _tail[(int)Program.MoveDirection.Up] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\TailUp.png"),30,30);
            _tail[(int)Program.MoveDirection.Right] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\TailRight.png"),30,30);
            _tail[(int)Program.MoveDirection.Down] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\TailDown.png"),30,30);
            _tail[(int)Program.MoveDirection.Left] = new Bitmap(new Bitmap("PNG_Snake"+ snakeColor +"\\TailLeft.png"),30,30);
            
            _snake.AddLast(new SnakePart(_head[(int)Program.MoveDirection.Right],6,1,(int)Program.MoveDirection.Right));
            _snake.AddLast(new SnakePart(_bodyLength[1],5,1,(int)Program.MoveDirection.Right));
            _snake.AddLast(new SnakePart(_tail[(int)Program.MoveDirection.Right],4,1,(int)Program.MoveDirection.Right));

            _moveDirection = (int)Program.MoveDirection.Right;

            _mapXSize = x;
            _mapYSize = y;
        }
        
        public LinkedList<SnakePart> ForDraw()
        {
            return new LinkedList<SnakePart>(_snake);
        }

        private void SelectSprite(int type)
        {
            SnakePart newPart;

            switch (type)
            {
                case (int)TypeOfSprite.Head:
                {
                    newPart = new SnakePart(_snake.First.Value);
                    newPart.Img = _head[newPart.DirMove];
                    _snake.First.Value = newPart;
                    break;
                }

                case (int)TypeOfSprite.Tail:
                {
                    newPart = new SnakePart(_snake.Last.Value);
                    newPart.Img = _tail[newPart.DirMove];
                    _snake.Last.Value = newPart;
                    break;
                }

                case (int)TypeOfSprite.Body:
                {
                    newPart = new SnakePart(_snake.First.Next.Value);

                    if (newPart.DirMove == (int)Program.MoveDirection.Up || newPart.DirMove == (int)Program.MoveDirection.Down)
                        newPart.Img = _bodyLength[0];
                    else
                        newPart.Img = _bodyLength[1];
                    
                    _snake.First.Next.Value = newPart;
                    break;
                }

                case (int)TypeOfSprite.Angle:
                {
                    newPart = new SnakePart(_snake.First.Next.Value);

                    switch (newPart.DirMove)
                    {
                        case (int)Program.MoveDirection.Up:
                        {
                            if (_snake.First.Next.Next.Value.DirMove == (int)Program.MoveDirection.Left)
                                newPart.Img = _bodyAngle[0];
                            else
                                newPart.Img = _bodyAngle[1];
                            _snake.First.Next.Value = newPart;
                            break;
                        }

                        case (int)Program.MoveDirection.Down:
                        {
                            if (_snake.First.Next.Next.Value.DirMove == (int)Program.MoveDirection.Left)
                                newPart.Img = _bodyAngle[3];
                            else
                                newPart.Img = _bodyAngle[2];
                            _snake.First.Next.Value = newPart;
                            break;
                        }

                        case (int)Program.MoveDirection.Left:
                        {
                            if (_snake.First.Next.Next.Value.DirMove == (int)Program.MoveDirection.Up)
                                newPart.Img = _bodyAngle[2];
                            else
                                newPart.Img = _bodyAngle[1];
                            _snake.First.Next.Value = newPart;
                            break;
                        }

                        case (int)Program.MoveDirection.Right:
                        {
                            if (_snake.First.Next.Next.Value.DirMove == (int)Program.MoveDirection.Up)
                                newPart.Img = _bodyAngle[3];
                            else
                                newPart.Img = _bodyAngle[0];
                            _snake.First.Next.Value = newPart;
                            break;
                        }
                    }

                    break;
                }
            }
        }


        

        public void Move(int direction, bool lengthChange)
        {
            SnakePart specPart = new SnakePart(_snake.First.Value);

            switch (direction)
            {
                case (int)Program.MoveDirection.Up:
                {
                    if (_moveDirection != (int)Program.MoveDirection.Down)
                        specPart.DirMove = direction;
                    break;
                }
                
                case (int)Program.MoveDirection.Down:
                {
                    if (_moveDirection != (int)Program.MoveDirection.Up)
                        specPart.DirMove = direction;
                    break;
                }
                
                case (int)Program.MoveDirection.Left:
                {
                    if (_moveDirection != (int)Program.MoveDirection.Right)
                        specPart.DirMove = direction;
                    break;
                }
                
                case (int)Program.MoveDirection.Right:
                {
                    if (_moveDirection != (int)Program.MoveDirection.Left)
                        specPart.DirMove = direction;
                    break;
                }
            }

            if (specPart.DirMove == (int)Program.MoveDirection.Up)
            {
                if (--specPart.Y < 0)
                    specPart.Y = _mapYSize - 1;
            }
            else if (specPart.DirMove == (int)Program.MoveDirection.Right)
                specPart.X = (specPart.X + 1) % _mapXSize;
            
            else if (specPart.DirMove == (int)Program.MoveDirection.Down)
                specPart.Y = (specPart.Y+1) % _mapYSize;
                
            else if (specPart.DirMove == (int)Program.MoveDirection.Left)
            {
                if (--specPart.X < 0)
                    specPart.X = _mapXSize - 1;
            }
             

            _snake.AddFirst(new SnakePart(specPart));
            SelectSprite((int)TypeOfSprite.Head);

            if (!lengthChange)
            {
                _snake.RemoveLast();
                SelectSprite((int)TypeOfSprite.Tail);
            }
            
            if (_moveDirection != _snake.First.Value.DirMove)
            {
                specPart = new SnakePart(_snake.First.Next.Value);
                specPart.DirMove = _snake.First.Value.DirMove;
                _snake.First.Next.Value =  new SnakePart(specPart);
                SelectSprite((int)TypeOfSprite.Angle);
                _moveDirection = _snake.First.Value.DirMove;
            }
            else
            {
                SelectSprite((int)TypeOfSprite.Body);
            }
            
        }
        
        public int GetMoveDirection()
        {
            return _moveDirection;
        }
    }
}