using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake 
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly  Queue<Point> snake;
        private readonly  Food[] food;
        private readonly Wall wall;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        public Snake(Wall wall) 
           
        {
            snake = new Queue<Point>();
            food = new Food [3] ;
            this.wall = wall;
            foodIndex = GetRandomPosition;
           
            GetFood();
            GreateSnake();
            food[foodIndex].SetRandomPosition(snake);
        }
        public int GetRandomPosition => new Random().Next(0, food.Length);
        public bool isMoving(Point direction)
        {
            Point snakeHead = snake.Last();
            GetNextDirection(direction, snakeHead);
            bool isPartOfSnake = snake.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
            if (isPartOfSnake)
            {
                return false;
            }
            var newHead = new Point(nextLeftX, nextTopY);
            bool isWall = wall.IsPointOfWall (newHead);
            if (isWall)
            {
                return false;
            }
            snake .Enqueue (newHead);
            newHead.Draw(SnakeSymbol);
            if (food[foodIndex ].isFoodPoint(newHead))
            {
                Eat(direction, newHead);
            }
            Point tail = snake.Dequeue();
            tail.Draw(' ');
            return true;
        }

        private void Eat(Point direction, Point newHead)
        {
            var foodPoints = food[foodIndex].FoodPoints;
            for (int i = 0; i < foodPoints; i++)
            {
                snake.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextDirection(direction,newHead);
                foodIndex = GetRandomPosition;
                food[foodIndex].SetRandomPosition (snake);
            }
        }

        private void GetNextDirection(Point direction,Point snakeHead)
        {
            nextLeftX = direction.LeftX + snakeHead.LeftX;
            nextTopY = direction .TopY + snakeHead.TopY;
        }
        private void GetFood()
        {
            food[0] = new FoodAsterisk(wall);
            food[1] = new FoodDollar (wall );
            food[2] = new FoodHash(wall);
        }

        private void GreateSnake()
        {
            for (int leftX = 3; leftX <= 9; leftX++)
            {
                snake.Enqueue(new Point(leftX, 3));
            }
        }
    }
}
