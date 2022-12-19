using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SnakeTheGame
{

    enum TypeObject : int
    {
        Empty,
        Wall,
        Snake,
        Food
    }

    public partial class Form1 : Form
    {
        private string _playerNick = "Player1"; // ник игрока
        private string _difficulty; // сложность
        private string _snakeSkin; // скин змейки
        private string _mapType; // тип карты
        private int _boost; // множитель очков
        private Bitmap _pictureWall; // спрайт стены
        private Snake _snake; // змея
        private LinkedList<SnakePart> _pictureSnake; // змейка для отрисовки
        private List<IEatable> _food; // еда 
        private readonly int mapXSize = 52; // постоянный размер карты (const)
        private readonly int mapYSize = 25;
        private int[,] _mapMatrix; // матрица карты 
        private int _moveDirection; // направление движения змейки
        private bool _pauseFlag; // паузка
        private int _points; // сумма очков
        private Point[] _border; // точки для отрисовки границ игровой области

        public Form1()
        {
            InitializeComponent();
            SetDefaultSetting();
            
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).SetValue(GamePanel, true, null);
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).SetValue(MenuPanel, true, null);
           
            
            MenuPanel.Visible = true;
            _mapMatrix = new int[mapYSize, mapXSize];

            _border = new Point[4]{ new Point(1,mapYSize*30+1),new Point(mapXSize*30,mapYSize*30+1),new Point(mapXSize*30,1),new Point(1,1)};
            _pictureWall = new Bitmap(new Bitmap("Wall.png"), 30, 30);
            _pauseFlag = true;
        }

        private void PanelsOff()
        {
            GamePanel.Visible = false;
            MenuPanel.Visible = false;
            SettingPanel.Visible = false;
            RecordsTablePanel.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void recordsButton_Click(object sender, EventArgs e)
        {
            PanelsOff();
            BuildRecordsTable(Program.GetRecordsTable());
            RecordsTablePanel.Visible = true;
        } 

        private void settingsButton_Click(object sender, EventArgs e)
        {
            PanelsOff();
            SettingPanel.Visible = true;
        }
        
        private void playButton_Click(object sender, EventArgs e)
        {
            InitializeGame();
            
            PanelsOff();
            GamePanel.Visible = true;
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            PanelsOff();
            nickInput.Text = "";
            MenuPanel.Visible = true;
        }
        
        private void pause_Click(object sender, EventArgs e)
        {
            _pauseFlag = !_pauseFlag;
            if (_pauseFlag)
                timer1.Stop();
            else
                timer1.Start();
            ActiveControl = null;
        }
        
        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            if (GamePanel.Visible)
            {
                e.Graphics.DrawPolygon(new Pen(Color.Black,2),_border);
                
                for (int i = 0; i < mapYSize; i++)
                for (int j = 0; j < mapXSize; j++)
                {
                    if (_mapMatrix[i,j] == (int)TypeObject.Wall)
                        e.Graphics.DrawImage(_pictureWall,j*30,i*30);
                }

                foreach (var part in _pictureSnake)
                    _mapMatrix[part.Y, part.X] = (int)TypeObject.Empty;
                
                _pictureSnake = _snake.ForDraw();

                if (_mapMatrix[_pictureSnake.First.Value.Y, _pictureSnake.First.Value.X] == (int)TypeObject.Food) // отслеживание ошибки спауна
                    FreeMapOfFood(_pictureSnake.First.Value.X, _pictureSnake.First.Value.Y, false);
                
                
                foreach (var part in _pictureSnake)
                {
                    e.Graphics.DrawImage(part.Img,part.X*30,part.Y*30);
                    _mapMatrix[part.Y, part.X] = (int)TypeObject.Snake;
                }
                
                foreach (var ob in _food)
                    e.Graphics.DrawImage(ob.Img,ob.X*30,ob.Y*30);;

                textPoints.Text = $"Сумма очков: {_points*_boost}";

                if (ActiveControl == textPoints)
                    ActiveControl = null;
            }
        }


        private void InitializeGame()
        {
            
            _boost = difficulty.Items.IndexOf(_difficulty)+1; // буст за карту и сложность
            
            for (int i = 0; i < mapYSize;i++) // заполнение карты пустыми клетками
                for (int j = 0; j < mapXSize;j++)
                    _mapMatrix[i, j] = (int)TypeObject.Empty;
            BuildMap();
            
            
            _snake = new Snake(mapXSize,mapYSize,_snakeSkin); // спаун змеки
            _food = new List<IEatable>(); // список с едой
            _moveDirection = (int)Program.MoveDirection.Right; // направление движения изначально
            _pauseFlag = false; // пауза
            _pictureSnake = _snake.ForDraw(); // добавление змейки на карту
            foreach (var part in _pictureSnake)
                _mapMatrix[part.Y, part.X] = (int)TypeObject.Snake;
            
            _points = 0; // очки
            SpawnFood(); // появление еды
            timer1.Interval = 50D*(difficulty.Items.Count - difficulty.Items.IndexOf(_difficulty)); // скорость игры
            timer1.Start();
        }

        private void BuildMap()
        {
            switch (_mapType)
            {
                case "Коробка" :
                {
                    for (int i = 0; i < mapYSize || i < mapXSize; i++) // расположение стен на карте
                    {
                        if (i < mapYSize)
                        { 
                            _mapMatrix[i,0] = (int)TypeObject.Wall;
                            _mapMatrix[i, mapXSize - 1] = (int)TypeObject.Wall;
                        }

                        if (i < mapXSize)
                        {
                            _mapMatrix[0, i] = (int)TypeObject.Wall;
                            _mapMatrix[mapYSize - 1, i] = (int)TypeObject.Wall;
                        }
                    }

                    _boost += 1;
                    break;
                }
                
                case "Стены слева-справа" :
                {
                    for (int i = 0; i < mapYSize; i++) // расположение стен на карте
                    {
                        _mapMatrix[i, 0] = (int)TypeObject.Wall;
                        _mapMatrix[i, mapXSize-1] = (int)TypeObject.Wall;
                    }
                    break;
                }
                
                case "Стены сверху-снизу" :
                {
                    for (int i = 0; i < mapXSize; i++) // расположение стен на карте
                    {
                        _mapMatrix[0, i] = (int)TypeObject.Wall;
                        _mapMatrix[ mapYSize-1,i] = (int)TypeObject.Wall;
                    }
                    break;
                }

                case "Без стен":
                {
                    _boost = 1;
                    break;
                }
            }
        }
        
        private void EndGame()
        {
            timer1.Stop();
            string message;
            (bool, int) result = Program.ChangeRecordsTable(_playerNick,_points*_boost);
            if (result.Item1)
                message = $"Вы заняли {result.Item2} место в таблице рекордов!";
            else
                message = "Увы, вы не занимаете место в таблице рекордов!";
            
            MessageBox.Show("Конец игры!\n" + $"Вы набрали {_points*_boost} очков.\n" + message);
            GamePanel.Visible = false;
            MenuPanel.Visible = true;
            ActiveControl = null;
        }

        private void SpawnFood()
        {
            Random rnd = new Random();
            int x, y;
            bool appleFlag = false;

            foreach (var ob in _food)
                if (ob.ObjectName() == "Apple")
                {
                    appleFlag = true;
                    break;
                }

            if (!appleFlag)
            {
                int count = 0;
                do
                {
                    x = rnd.Next(0, mapXSize-1);
                    y = rnd.Next(0, mapYSize-1);
                    count++;
                } while (_mapMatrix[y,x] != (int)TypeObject.Empty && count < 20);

                if (count < 20)
                {
                    _food.Add(new Apple(x, y));
                    _mapMatrix[y, x] = (int)TypeObject.Food;
                }
                else
                {
                    bool nan = false;
                    for (int i = 0; i < mapYSize;i++) // заполнение карты пустыми клетками
                        for (int j = 0; j < mapXSize;j++)
                            if (_mapMatrix[i, j] == (int)TypeObject.Empty)
                            {
                                x = j;
                                y = i;
                                nan = true;
                                break;
                            }

                    if (nan)
                    {
                        _food.Add(new Apple(x, y));
                        _mapMatrix[y, x] = (int)TypeObject.Food;
                    }
                    else
                        EndGame();    
                }

                int probability = rnd.Next(0, 100);
                if (probability < 60)
                {
                    count = 0;
                    do
                    {
                        x = rnd.Next(0, mapXSize - 2);
                        y = rnd.Next(0, mapYSize - 2);
                        count++;
                    } while ((_mapMatrix[y,x] != (int)TypeObject.Empty  || _mapMatrix[y+1,x] != (int)TypeObject.Empty ||
                             _mapMatrix[y,x+1] != (int)TypeObject.Empty  || _mapMatrix[y+1,x+1] != (int)TypeObject.Empty) && count < 10);

                    if (count < 10)
                    {
                        _food.Add(new Coco(x, y));
                        _mapMatrix[y, x] = (int)TypeObject.Food;
                        _mapMatrix[y+1, x] = (int)TypeObject.Food;
                        _mapMatrix[y, x+1] = (int)TypeObject.Food;
                        _mapMatrix[y+1, x+1] = (int)TypeObject.Food;
                    }
                }
                else if (probability > 70)
                {
                    count = 0;
                    bool flag;
                    do
                    {
                        flag = false;
                        x = rnd.Next(0, mapXSize - 3);
                        y = rnd.Next(0, mapYSize - 3);
                        count++;
                        
                        for (int i = y; i < y+3;i++)
                            for (int j = x; j < x+3;j++)
                            {
                                if (_mapMatrix[i, j] != (int)TypeObject.Empty)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        
                    } while (flag && count < 10);

                    if (count < 10)
                    {
                        _food.Add(new Watermelon(x, y));
                        
                        for (int i = y; i < y+3;i++)
                            for (int j = x; j < x+3;j++)
                                _mapMatrix[i, j] = (int)TypeObject.Food;
                    }
                }
            } 
        }

        private bool FreeMapOfFood(int x,int y,bool pointsAdd)
        {
            foreach (var ob in _food)
            {
                if (ob.ObjectName() == "Apple" && ob.X == x && ob.Y == y)
                {
                    if (pointsAdd) 
                        _points += ob.Points;
                    _mapMatrix[ob.Y, ob.X] = (int)TypeObject.Empty;
                    _food.Remove(ob);
                    return true;
                }
                
                if (ob.ObjectName() == "Coco" && ob.X <= x && ob.X + 1 >= x && ob.Y <= y && ob.Y + 1 >= y)
                {
                    if (pointsAdd)  
                        _points += ob.Points;
                    _mapMatrix[ob.Y, ob.X] = (int)TypeObject.Empty;
                    _mapMatrix[ob.Y+1, ob.X] = (int)TypeObject.Empty;   
                    _mapMatrix[ob.Y, ob.X+1] = (int)TypeObject.Empty;   
                    _mapMatrix[ob.Y+1, ob.X+1] = (int)TypeObject.Empty;   
                    _food.Remove(ob);
                    return true;
                }
                
                if (ob.ObjectName() == "Watermelon" && ob.X <= x && ob.X + 2 >= x && ob.Y <= y && ob.Y + 2 >= y)
                {
                    
                    

                    Watermelon melon = (Watermelon)ob;
                    int [,] p = melon.ActivePoint();

                    if (p[y - melon.Y, x - melon.X] == 1)
                    {
                        if (pointsAdd)
                            _points += ob.Points;
                        for (int i = ob.Y; i < ob.Y+3; i++)
                            for (int j = ob.X; j < ob.X+3; j++)
                                if (_mapMatrix[i, j] == (int)TypeObject.Food)
                                    _mapMatrix[i, j] = (int)TypeObject.Empty;

                        _food.Remove(ob);
                        return true;
                    }
                }
            }

            return false;
        }

        private (bool,bool) Eat_Crash()
        {
            int x = _pictureSnake.First.Value.X;
            int y = _pictureSnake.First.Value.Y;
            bool eat = false;
            bool crash = false;

            switch (_moveDirection)
            {
                case (int)Program.MoveDirection.Up:
                {
                    if (--y < 0)
                        y = mapYSize - 1;
                    break;
                }
                
                case (int)Program.MoveDirection.Down:
                {
                    y = (y + 1) % mapYSize;
                    break;
                }
                    
                case (int)Program.MoveDirection.Left:
                {
                    if (--x < 0)
                        x = mapXSize - 1;
                    break;
                }
                    
                case (int)Program.MoveDirection.Right:
                {
                    x = (x + 1) % mapXSize;
                    break;
                }
            }


            if (_mapMatrix[y, x] == (int)TypeObject.Food)
                eat = FreeMapOfFood(x,y,true);
            
            
            if (_mapMatrix[y, x] == (int)TypeObject.Wall || (_mapMatrix[y, x] == (int)TypeObject.Snake && (!(_pictureSnake.Last.Value.X == x && _pictureSnake.Last.Value.Y == y) || eat)))
                crash = true;

            return (crash, eat);

        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<int> delFoodIndex = new List<int>();

            int ind = 0;
            foreach (var ob in _food)
            {
                if (!ob.Transformation())
                {
                    delFoodIndex.Add(ind);
                }

                ind++;
            }
            delFoodIndex.Sort();
            int amendment = 0;

            foreach (var index in delFoodIndex)
            {
                int i = 0;
                foreach (var ob in _food)
                {
                    if (i == index-amendment)
                    {
                        int x = ob.X+1;
                        int y = ob.Y+1;
                        FreeMapOfFood(x, y, false);
                        break;
                    }
                    i++;
                }
                amendment++;
            }

            (bool, bool) flags = Eat_Crash();
            
            if (flags.Item1)
            {
                EndGame();
                return;
            }

            if (flags.Item2 || _food.Count == 0)
                SpawnFood();
            
            _snake.Move(_moveDirection,flags.Item2);
            GamePanel.Invalidate();
            
            //GC.Collect();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GamePanel.Visible && !_pauseFlag)
            {
                switch (e.KeyCode.ToString())
                {
                    case "W":
                    case "Up":
                    {
                        if (_snake.GetMoveDirection() != (int)Program.MoveDirection.Down) 
                            _moveDirection = (int)Program.MoveDirection.Up;
                        break;
                    }
                    
                    case "D":
                    case "Right":
                    {
                        if (_snake.GetMoveDirection()!= (int)Program.MoveDirection.Left)     
                            _moveDirection = (int)Program.MoveDirection.Right;
                        break;
                    }
                    
                    case "S":
                    case "Down":
                    {
                        if (_snake.GetMoveDirection() != (int)Program.MoveDirection.Up)  
                            _moveDirection = (int)Program.MoveDirection.Down;
                        break;
                    }
                    
                    case "A":
                    case "Left":
                    {
                        if (_snake.GetMoveDirection() != (int)Program.MoveDirection.Right) 
                            _moveDirection = (int)Program.MoveDirection.Left;
                        break;
                    }
                        
                }
            }
        }

        private void defaultSettingsButton_Click(object sender, EventArgs e)
        {
            SetDefaultSetting();
        }

        private void SetDefaultSetting()
        {
            difficulty.SelectedItem = difficulty.Items[1];
            _difficulty = difficulty.SelectedItem.ToString();
            
            snakeSkin.SelectedItem = snakeSkin.Items[0];
            _snakeSkin = "Green";
            
            mapType.SelectedItem = mapType.Items[0];
            _mapType = mapType.SelectedItem.ToString();
            
            _playerNick = "Player1";
            textBox5.Text = "Никнейм: " + _playerNick;
            nickInput.Text = "";
            
            ActiveControl = null;
        }

        private void difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            _difficulty = difficulty.SelectedItem.ToString();
        }

        private void snakeSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (snakeSkin.SelectedItem.ToString())
            {
                case "Зелёная":
                {
                    _snakeSkin = "Green";
                    break;
                }
                
                case "Красная":
                {
                    _snakeSkin = "Red";
                    break;
                }
                
                case "Синяя":
                {
                    _snakeSkin = "Blue";
                    break;
                }
            }
        }

        private void mapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mapType = mapType.SelectedItem.ToString();
        }

        private void BuildRecordsTable(LinkedList<RecordsTableNode> table)
        {
            dataGridView1.RowCount = 11;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 550;
            dataGridView1.Columns[2].Width = 150;
            

            dataGridView1.Rows[0].Cells[0].Value = "№";
            dataGridView1.Rows[0].Cells[1].Value = "Никнейм";
            dataGridView1.Rows[0].Cells[2].Value = "Очки";

            var node = table.First;

            for (int i = 1; i < 11; i++)
            {
                
                dataGridView1.Rows[i].Cells[0].Value = i.ToString();
                if (node != null)
                { 
                    dataGridView1.Rows[i].Cells[1].Value = node.Value.Nickname;
                    dataGridView1.Rows[i].Cells[2].Value = node.Value.Points.ToString();
                }
                else
                { 
                    dataGridView1.Rows[i].Cells[1].Value = "----";
                    dataGridView1.Rows[i].Cells[2].Value = "----";
                }

                if (node != null)
                    node = node.Next;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nickInput.Text != "")    
                _playerNick = nickInput.Text;
            textBox5.Text = "Никнейм: " + _playerNick;
            nickInput.Text = "";
        }
    }
}