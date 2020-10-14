using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Program
    {

        static void Main(string[] args)
        {
            // start game
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // display this char on the console during the game
            char ch = '*';
            char obstacle = '|';
            bool gameLive = true;
            ConsoleKeyInfo consoleKey; // holds whatever key is pressed

            List<int> positionX = new List<int>();
            List<int> positionY = new List<int>();

            // location info & display
            int x = 1, y = 2; 
            positionX.Add(x);
            positionY.Add(y);
            int dx = 1, dy = 0;
            int consoleWidthLimit = 79;
            int consoleHeightLimit = 24;
           

            // clear to color
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            // delay to slow down the character movement so you can see it
            int delayInMillisecs = 50;

            //Food Block
            var rand = new Random();
            bool food = false;
            int foodx = 0, foody = 0;
            bool foodPosition = false;
            int foodResetTime = 0;

             //obstacle Block
            bool obstacleCheck = false;
            bool obstaclePosition = false;
            int  obstacleResetTime = 0;
            List<int> obstacleX = new List<int>();
            List<int> obstacleY = new List<int>();



            int score = 0;

            for (int i = 0; i < consoleWidthLimit; i++){
                Console.SetCursorPosition(i, 1);
                Console.Write('-');
                Console.SetCursorPosition(i, consoleHeightLimit);
                Console.Write('-');
            }
            for (int i = 0; i < consoleHeightLimit; i++){
                Console.SetCursorPosition(0, i);
                Console.Write('|');
                Console.SetCursorPosition(consoleWidthLimit, i);
                Console.Write('|');
            }


            do // until escape
            {
                // print directions at top, then restore position
                // save then restore current color
                ConsoleColor cc = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, 0);
                Console.Write("Arrows move up/down/right/left. Press 'esc' quit.");
                Console.Write("\tScore: {0}", score);
                Console.ForegroundColor = cc;

                // Food Start
                if(food == false){
                    do{
                        foodx = rand.Next(1, 78);
                        foody = rand.Next(2, 23);

                        if (positionX.Any())
                        for (int i = 0; i < positionX.Count; i++)
                        {
                            if(foodx == x && foody == y)
                                break;
                            else
                                foodPosition = true;
                        }
                    } while (foodPosition == false);
                    
                    Console.SetCursorPosition(foodx, foody);
                    Console.Write("o");
                    foodPosition = false;
                    food = true;
                }

                if(foodx == x && foody == y){
                    food = false;
                    foodResetTime = 0;
                }

                foodResetTime += 1;

                if(foodResetTime == 100){
                    Console.SetCursorPosition(foodx, foody);
                    Console.WriteLine(' ');
                    food = false;
                    foodResetTime = 0;
                }
                // Food End
                
                //obstacle
                if(obstacleCheck == false)
                do{
                    int tempX = 0, tempY = 0;
                    
                    obstacleResetTime = 0;
                    tempX = rand.Next(1, 78);
                    tempY = rand.Next(2, 23);

                    if (positionX.Any())
                    for (int i = 0; i < positionX.Count; i++)
                    {
                        if(tempX == x && tempY == y)
                            break;
                        else
                            obstaclePosition = true;
                    }
                    if (tempX == foodx && tempY == foody)
                            obstaclePosition = false;
                    if (obstaclePosition == true)
                    {
                        obstacleX.Insert(0, tempX);
                        obstacleY.Insert(0, tempY);
                    }
                } while (obstaclePosition == false);
                
                for (int i =0; i < obstacleX.Count; i++)
                {
                    Console.SetCursorPosition(obstacleX[i], obstacleY[i]);
                    Console.Write(obstacle);
                }
                obstacleCheck = true;
                obstaclePosition = true;
                obstacleResetTime += 1;

                if(obstacleResetTime == 100){
                    if(obstacleX.Count > 2)
                    {
                        Console.SetCursorPosition(obstacleX[3], obstacleY[3]);
                        Console.WriteLine(' ');
                        obstacleX.RemoveAt(obstacleX.Count - 1);
                        obstacleY.RemoveAt(obstacleY.Count - 1);
                    }
                    
                    obstacleCheck = false;
                    obstacleResetTime = 0;
                }
               
                

                if (score > 0)
                    Console.SetCursorPosition(positionX[positionX.Count-1], positionY[positionY.Count-1]);
                else  
                    Console.SetCursorPosition(x, y);
                Console.Write(' ');


                // see if a key has been pressed
                if (Console.KeyAvailable)
                {
                    consoleKey = Console.ReadKey(true);
                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.UpArrow: //UP
                            delayInMillisecs = 100;
                            dx = 0;
                            dy = -1;
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case ConsoleKey.DownArrow: // DOWN
                            delayInMillisecs = 100;
                            dx = 0;
                            dy = 1;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case ConsoleKey.LeftArrow: //LEFT
                            delayInMillisecs = 50;
                            dx = -1;
                            dy = 0;
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case ConsoleKey.RightArrow: //RIGHT
                            delayInMillisecs = 50;
                            dx = 1;
                            dy = 0;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case ConsoleKey.Escape: //END
                            gameLive = false;
                            break;
                    }
                }

                // calculate the new position
                // note x set to 0 because we use the whole width, but y set to 1 because we use top row for instructions
                x += dx;
                y += dy;

                if (x > consoleWidthLimit - 1)
                    x = 1;
                if (x < 1)
                    x = consoleWidthLimit - 1;

                if (y > consoleHeightLimit - 1)
                    y = 2; // 2 due to top spaces used for directions
                if (y < 2)
                    y = consoleHeightLimit - 1;

                Console.SetCursorPosition(x, y);
                Console.Write(ch);
                
               
                if (x == foodx && y == foody) 
                    score++;  
                if (score == 100)
                    gameLive = false;
               
                //snake growth
                positionX.Insert(0, x);
                positionY.Insert(0, y);

                if(positionX.Count > score + 1){
                    positionX.RemoveAt(positionX.Count - 1);
                    positionY.RemoveAt(positionY.Count - 1);
                }

                for (int i = 0; i < score; i++){
                    Console.SetCursorPosition(positionX[i], positionY[i]);
                    Console.Write(ch);
                }

                for (int i = 1; i < positionX.Count; i++){
                    if (x == positionX[i] && y == positionY[i])
                        gameLive = false;
                }
                for (int i = 0; i < obstacleX.Count; i++){
                    if (x == obstacleX[i] && y == obstacleY[i])
                        gameLive = false;
                }

                // pause to allow eyeballs to keep up
                System.Threading.Thread.Sleep(delayInMillisecs);

            } while (gameLive);

            if(!gameLive){
                Console.Clear();
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
}