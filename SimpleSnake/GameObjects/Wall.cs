using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char Symbol = '■';
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeBorder();
        }
        public bool IsPointOfWall(Point snakeHead)
        => snakeHead.TopY == 0 
            || snakeHead.LeftX == 0 
            || snakeHead.LeftX == LeftX
            || snakeHead.TopY == TopY;
        private void InitializeBorder()
        {
            SetHorizontalBorder(0);

            SetVerticalBorder(0);
            SetVerticalBorder(LeftX - 1);

            SetHorizontalBorder(TopY);

           
           
        }

        private void SetHorizontalBorder(int y)
        {
            Console.SetCursorPosition(0, y);
            for (int i = 0; i < LeftX; i++)
            {
              
                Console.Write(Symbol);
            }
        }

        private void SetVerticalBorder(int x)
        {
            for (int i = 1; i < TopY; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(Symbol);
            }
        }
    }
}
