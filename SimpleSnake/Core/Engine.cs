using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
   
    public class Engine
    {
        private readonly Point[] pointsOfDirectins;
        private Direction direction;
        private readonly Wall wall;
        private readonly Snake snake;
        private float sleepTime;
        public Engine(Wall wall, Snake snake)
        {
            pointsOfDirectins = new Point[4];
            pointsOfDirectins[0] = new Point(1, 0);
            pointsOfDirectins[1] = new Point(-1, 0);
            pointsOfDirectins[2] = new Point(0, 1);
            pointsOfDirectins[3] = new Point(0, -1);
            sleepTime = 100;
            this.wall = wall;
            this.snake = snake;
        }
        public void Run()
        {
            while (true)
            {
                if(Console.KeyAvailable)
                {
                    GetNextDiraction();
                }
                bool isMoving = snake.isMoving(pointsOfDirectins[(int)direction]);
                if(!isMoving)
                {
                    AskUserForRestart();
                }
                sleepTime -= 0.01F;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            Console.SetCursorPosition(3, 3);
            Console.Write("Would you  like to continue? y/n");
            string input = Console.ReadLine();
            if(input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Console.Write("GameOver");
            }
        }

        private void GetNextDiraction()
        {
            ConsoleKeyInfo key = Console.ReadKey(); 
            if(key.Key == ConsoleKey.LeftArrow)
            {
                if(direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if(key.Key == ConsoleKey.RightArrow)
            {
                if(direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            Console.CursorVisible = false;
        }
    }
}
