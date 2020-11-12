using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    public class Snake
    {

        private List<int> _x = new List<int>();
        private List<int> _y = new List<int>();
        private ConsoleColor _color;
        private char _character;
        private int _life;
        private int dx = 0, dy = 1;
        private int _speed;
        private int _speedController;
      
        
        public Snake (char character, ConsoleColor color, int speed)
        {
            _character = character;
            _color = color;
            _x.Add(2);
            _x.Add(3);
            _x.Add(4);
            _y.Add(4);
            _y.Add(4);
            _y.Add(4);
            _speed= speed;
        }

        public void Move(int width, int height)
        {  
            

            ConsoleKeyInfo consoleKey;

            if (Console.KeyAvailable)
            {
                consoleKey = Console.ReadKey(true);
                switch (consoleKey.Key)
                {
                    case ConsoleKey.UpArrow: //UP
                        dx = 0;
                        dy = -1;
                        break;
                    case ConsoleKey.DownArrow: // DOWN
                        dx = 0;
                        dy = 1;
                        break;
                    case ConsoleKey.LeftArrow: //LEFT
                        dx = -1;
                        dy = 0;
                        break;
                    case ConsoleKey.RightArrow: //RIGHT
                        dx = 1;
                        dy = 0;
                        break;
                }
            }


            if(_speedController == 0)
            {
                Console.SetCursorPosition(_x[_x.Count - 1], _y[_x.Count - 1]);
                Console.Write(' ');

                if (_x.Count > 1)
                {
                    for (int i = _x.Count - 1; i > 0; i--)
                    {
                        _x[i] = _x[i - 1];  
                        _y[i] = _y[i - 1];  
                    }
                }
                _x[0] += dx; 
                _y[0] += dy;
                _speedController = _speed;
            }
            else
                _speedController--;
            
            if (_x[0] > width - 1)
                _x[0] = 1;
            if (_x[0] < 1)
                _x[0] = width - 1;

            if (_y[0] > height - 1)
                _y[0] = 3; // 2 due to top spaces used for directions
            if (_y[0] < 3)
                _y[0] = height - 1;
        }

        public bool Grow(int x, int y)
        {
            if(_speedController == 0)
            {
                if (x == _x[0] && y == _y[0])
                {
                    _x.Insert(0, x);
                    _y.Insert(0, y);
                    return true;
                }
                else
                    return false;
            }
             else
                    return false;
        }



        public void Draw()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_x[0], _y[0]);
            Console.Write(_character);
        }
            
           

        public int Score
        {
            get {return _x.Count - 1;}
        }
        
        public void GodeMode()
        {

        }


        public List<int> PositionX
        {
            get {return _x;}
        }
        public List<int> PositionY
        {
            get {return _y;}
        }

        public int Life
        {
            get {return _life;}
        }
        
        public void LifeIncrement()
        {
            _life++;
        }
        public void LifeDecrement()
        {
            _life--;
        }


    }


}