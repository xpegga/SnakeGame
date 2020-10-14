using System;
using System.Collections.Generic;

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
            char ch2 = '|';
            bool gameLive = true;
            ConsoleKeyInfo consoleKey; // holds whatever key is pressed

            // location info & display
            int x = 0, y = 2; // y is 2 to allow the top row for directions & space
            int dx = 1, dy = 0;
            int consoleWidthLimit = 79;
            int consoleHeightLimit = 24;

            // clear to color
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            // delay to slow down the character movement so you can see it
            int delayInMillisecs = 50;
            // whether to keep trails
            bool trail = false;

            //Food Block
            var rand = new Random();
            bool food = false;
            int foodx = 0, foody = 2;
            bool foodPosition = false;
            int foodResetTime = 0;

            int score = 0;

            List<int> positionX = new List<int>();
            List<int> positionY = new List<int>();

            do // until escape
            {
                // print directions at top, then restore position
                // save then restore current color
                ConsoleColor cc = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Arrows move up/down/right/left. Press 'esc' quit.");
                Console.WriteLine(positionX.Count);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = cc;

                // Food Start
                if(food == false){
                    do{
                    foodx = rand.Next(0, 79);
                    foody = rand.Next(2, 24);
                    if(foodx != x && foody !=y){
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

                // see if a key has been pressed
                if (Console.KeyAvailable)
                {
                    // get key and use it to set options
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

                // find the current position in the console grid & erase the character there if don't want to see the trail
                Console.SetCursorPosition(x, y);
                if (trail == false)
                    Console.Write(' ');
                
                if (score > 0)
                {
                    Console.SetCursorPosition(positionX[positionX.Count-1], positionY[positionY.Count-1]);
                    Console.Write(' ');
                }

                // calculate the new position
                // note x set to 0 because we use the whole width, but y set to 1 because we use top row for instructions
                x += dx;
                if (x > consoleWidthLimit)
                    x = 0;
                if (x < 0)
                    x = consoleWidthLimit;

                y += dy;
                if (y > consoleHeightLimit)
                    y = 2; // 2 due to top spaces used for directions
                if (y < 2)
                    y = consoleHeightLimit;

                // write the character in the new position
                Console.SetCursorPosition(x, y);
                Console.Write(ch);
               
                if (x == foodx && y == foody) 
                    score++;  

               
                
                    positionX.Insert(0, x);
                    positionY.Insert(0, y);

                    if (positionX.Count > score)
                    {
                        positionX.RemoveAt(score);
                        positionY.RemoveAt(score);
                    }
                
               

                for (int i = 0; i < score; i++){
                    Console.SetCursorPosition(positionX[i], positionY[i]);
                    Console.Write(ch);
                }


               
               

                // pause to allow eyeballs to keep up
                System.Threading.Thread.Sleep(delayInMillisecs);

            } while (gameLive);

            if(!gameLive){
                Console.Clear();
                do{
                    Console.SetCursorPosition(39, 12);
                    Console.WriteLine("Game Over");
                } while(Console.ReadKey().Key != ConsoleKey.Enter);
            }
        }
    }
    
}