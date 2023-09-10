using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private readonly  char foodSymbol;
        private readonly  Random random;
        private readonly Wall wall;
        protected Food(Wall wall,char foodSymbol,int points) 
            : base(0, 0)
        {
            random = new Random();
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
        }
        public int FoodPoints { get;private  set; }
        public bool isFoodPoint(Point snakeHead)
       => TopY ==snakeHead.TopY  && LeftX == snakeHead.LeftX;
        public void SetRandomPosition(Queue <Point> snake)
        {
            LeftX = random.Next(2, wall .LeftX -2);
            TopY = random.Next(2, wall .TopY -2);
            bool isPartOfSnake = snake.Any(x => x.TopY == TopY && x.LeftX == LeftX);
            while (isPartOfSnake)
            {

                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);
               isPartOfSnake = snake.Any(x => x.TopY == TopY && x.LeftX == LeftX);

            }
            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
