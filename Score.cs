using System;
using System.IO;

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

        public void RecordScore(Snake snake){
            int currentScore = snake.Score;
            int nextScore;
            string[] allScore = File.ReadAllLines(@".\Score.txt");
            for(int findScoreLoop = 0; findScoreLoop < 10; findScoreLoop++){
                if(currentScore > Convert.ToInt32(allScore[findScoreLoop])){
                    nextScore = Convert.ToInt32(allScore[findScoreLoop]);
                    allScore[findScoreLoop] = currentScore.ToString();
                    currentScore = nextScore;
                }
            }
            File.WriteAllLines(@".\Score.txt", allScore);
        }

    }



}