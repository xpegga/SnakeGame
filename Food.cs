using System;
using System.Linq;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Food 
    {
        private char _character;
        private int _resetTime;
        private int _x;
        private int _y;
        private ConsoleColor _color;
        private int _foodTimer;
        private int _timerRefresh;
        private int _height;
        private int _width;
        
        
        public Food (char character, ConsoleColor color, int height, int width, int foodTimer)
        {
            _character = character;
            _color = color;
            _foodTimer= foodTimer;
            _height = height;
            _width = width;
        }

        public void SetPosition (List<int> x, List<int> y) 
        {
            if(_timerRefresh != 0)
                 _timerRefresh--;
               
            else 
            {
                //and
                _timerRefresh = _foodTimer;
                var rand = new Random();
                
                bool conflict = false;

                Console.SetCursorPosition(_x, _y);
                Console.Write(' ');
               
                if (_x == 0 || _y == 0) {
                    _x = rand.Next(1, _width - 1);
                    _y = rand.Next(3, _height - 1);
                }
                else
                {
                    int tempX;
                    int tempY;
                    do
                    {
                        conflict = false;
                        tempX = rand.Next(1, _width - 1);
                        tempY = rand.Next(3, _height - 1);

                        if (_x == tempX  && _y == tempY)
                            conflict = true;

                        for(int i = 0; i < x.Count; i++)
                        {
                            if(tempX == x[i] && tempY == y[i])
                                conflict = true;
                        }                       

                    }while (conflict == true);
                    _x = tempX;
                    _y = tempY;
                }
            }
        }

        public void RemoveFood()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(' '); 
            _timerRefresh = 0;
        }

        public void Draw()
        { 
            Console.ForegroundColor = _color;
           
            Console.SetCursorPosition(_x, _y);
            Console.Write(_character);
            
        }

        public int X
        {
            get {return _x;}
        }

         public int Y
        {
            get {return _y;}
        }

    }
}