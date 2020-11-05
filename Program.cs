using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            Game game = new Game(25,80); 
            Snake snake = new Snake('*', ConsoleColor.DarkGreen, 2);
            Food food = new Food('o', ConsoleColor.Blue, game.Height, game.Width, 300);
            Food life = new Food('^', ConsoleColor.Red, game.Height, game.Width, 2500);
            Food godMode = new Food('g', ConsoleColor.Yellow, game.Height, game.Width, 1700);
            Score score = new Score();

            int refreshRate = 16; //60fps
            game.DrawMap(ConsoleColor.Black, ConsoleColor.DarkYellow);

            do
            {
                game.DrawText(ConsoleColor.White, snake.Score);
                
                snake.Move(game.Width, game.Height);
                snake.Draw();
                
                food.SetPosition(snake.PositionX, snake.PositionY);
                food.Draw();
                life.SetPosition(snake.PositionX, snake.PositionY);
                life.Draw();
                godMode.SetPosition(snake.PositionX, snake.PositionY);
                godMode.Draw();
                
                if (snake.Grow(food.X, food.Y) == true)
                    food.RemoveFood();
                
                
                    
                
                game.GameEnd();
                Console.SetCursorPosition(0, 0);
                System.Threading.Thread.Sleep(refreshRate);
               
            } while (game.GameLive);

            if(!game.GameLive){
                score.RecordScore(snake);
                Console.Clear();
                Console.ResetColor();
            }
        }
    }
}