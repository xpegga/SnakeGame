using System;

namespace SnakeGame
{
    public class Score
    {
        public Score()
        {




        }

        public void ScoreBoard(int score)
        {
            do{
                Console.SetCursorPosition(39, 12);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(39, 13);
                Console.WriteLine($"{score}");
                Console.SetCursorPosition(39, 14);
                Console.WriteLine("Press Enter to Continue");
            } while(Console.ReadKey().Key != ConsoleKey.Enter);

        }

    }



}