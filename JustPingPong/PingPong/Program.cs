using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong
{
    class Program
    {

       static int ballPositionX = 0;
       static int ballPositionY = 0;      
       static bool ballDirectionUp = true; // determing if ball direction is up
        static bool ballDirectionRight = false;
       static int firstPlayerPosition = 8;
       static int secondPlayerPosition = 8;
       static int firstPlayerpadSize = 6;
       static int secondPlayerpadSize = 6;
       static int firstPlayerResult = 0;
       static int secondPlayerResult = 0;
       static Random randomGenerator = new Random();


        public static object SetInitialPositions { get; private set; }

        static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerpadSize; y++)
            {
                PrintAtPosition(0, y, '|');
                PrintAtPosition(1, y, '|');
            }
        }

        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerpadSize; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, '|');
                PrintAtPosition(Console.WindowWidth - 2, y, '|');
            }
        }

        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }


        static void SetIntitialPositions()
        {
            firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerpadSize /2 ;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerpadSize / 2;
            SetBallAtTheMiddleOfTheGameField();
        }

        static void SetBallAtTheMiddleOfTheGameField()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }


        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@');
        }

        static void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.WriteLine("{0}-{1}",firstPlayerResult,secondPlayerResult);
        }

        static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < Console.WindowHeight - firstPlayerpadSize)
            {

                firstPlayerPosition++;
            }
        }

        static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                // TODO: move first player up
                firstPlayerPosition--;
            }
        }

        static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < Console.WindowHeight - secondPlayerPosition)
            {

                secondPlayerPosition++;
            }
        }

        static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                // TODO: move first player up
                secondPlayerPosition--;
            }
        }

        static void SecondPlayerAIMove()
        {
           //int randomNumber = randomGenerator.Next(0,2);

           // if (randomNumber == 0)
           // {
           //     MoveSecondPlayerUp();
           // }
           // if (randomNumber == 1)
           // {
           //     MoveSecondPlayerDown();
           // }
           if (ballDirectionUp == true)
            {

                MoveSecondPlayerUp();
            }
            else
            {
                MoveSecondPlayerDown();
            }
          

        }

         static void MoveBall()
        {
            if(ballPositionY==0)
            {
                ballDirectionUp = false;
            }

            if(ballPositionY == Console.WindowHeight -1)
            {
                ballDirectionUp = true;
            }
            if (ballPositionX == Console.WindowWidth- 1)

            {


                SetBallAtTheMiddleOfTheGameField();
                ballDirectionRight = false;
                ballDirectionUp = true;
                firstPlayerResult++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("First Player Wins");
                Console.ReadKey();
                //TODO: Second player loses


            }
            if (ballPositionX == 0)
            {
                SetBallAtTheMiddleOfTheGameField();
                ballDirectionRight = true;
                ballDirectionUp = true;
                secondPlayerResult++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Second Player Wins");
                Console.ReadKey();
                //TODO: first player loses
            }
          if (ballPositionX < 3)
            {
                if(ballPositionY >= firstPlayerPosition && ballPositionY < firstPlayerPosition + firstPlayerpadSize)
                {
                    ballDirectionRight = true;         
                }

            }
          if(ballPositionX >= Console.WindowWidth - 3 - 1)
            {
                if (ballPositionY >= secondPlayerPosition && ballPositionY < secondPlayerPosition + secondPlayerpadSize)
                {
                    ballDirectionRight = false;
                }
            }
        


            if (ballDirectionUp)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;
            }
            if (ballDirectionRight)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        

        }

        static void Main(string[] args)
        {


            RemoveScrollBars();
            SetIntitialPositions();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveFirstPlayerDown();

                    }
                }

                
                SecondPlayerAIMove();
                MoveBall();
                
                Console.Clear();
                DrawFirstPlayer();
                DrawSecondPlayer();
                DrawBall();
                PrintResult();

                Thread.Sleep(60);
            }


        }

     
    }
}
