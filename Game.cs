using System;
using System.Linq;

namespace SnakeGame
{
    public class Game
    {
        private int _height;
        private int _width;
        bool _gameLive;
        
        public Game (int height, int width)
        {
            _height = height;
            _width = width;
            _gameLive = true;
        }

        public void DrawMap(ConsoleColor backgroundColor, ConsoleColor borderColor)
        {
            Console.Clear();
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = borderColor;
            for (int i = 0; i < _width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('-');
                Console.SetCursorPosition(i, 2);
                Console.Write('-');
                Console.SetCursorPosition(i, _height);
                Console.Write('-');
            }
            for (int i = 0; i < _height; i++){
                Console.SetCursorPosition(0, i);
                Console.Write('|');
                Console.SetCursorPosition(_width, i);
                Console.Write('|');
            }
        }

        public void DrawText( ConsoleColor fontColor,  int score)
        {
            Console.ForegroundColor = fontColor;
            Console.SetCursorPosition(2, 1);
            Console.Write("Arrows move up/down/right/left. Press 'esc' quit.");
            Console.Write("\tScore: {0}", score);
        }
        

        public void WelcomeScreen()
        {
            System.Console.WriteLine();


        }

        public void MainMenu()
        {
            System.Console.WriteLine();

        }

        public void Help()
        {
            System.Console.WriteLine();
        }


        public bool GameLive
        {
            get {return _gameLive;}
        }

        public void GameEnd()
        {
            if (Console.KeyAvailable)
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    _gameLive = false;
                    break;
            }
        }

        public int Height
        {
            get {return _height;}
        }

        public int Width
        {
            get {return _width;}
        }

    }
}