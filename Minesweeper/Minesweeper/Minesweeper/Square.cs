using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Square
    {
        public Coordinate pos { get; set; }
        public bool isBomb { get; set; }
        public bool hasFlag { get; set; }
        public bool hasClicked { get; set; }
        public int numAdjBombs { get; set; }
        private Map map { get; }

        public Square(Coordinate pos, bool isBomb, Map map)
        {
            this.pos = pos;
            this.isBomb = isBomb;
            this.map = map;
            hasFlag = false;
            hasClicked = false;
            numAdjBombs = 0; //init value, will change with Map calculation
        }

        public void isClicked()
        {
            if (hasClicked)
                return; //Can't click a thing already clicked
            if (isBomb)
                return; //TODO: Display game over
            int bombAdjNum = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (j == 0 && i == 0) continue; //Don't need to check this square
                    Square checkSquare = map.getSquare(new Coordinate(pos.x + i, pos.y + j));
                    if (checkSquare == null) continue;
                    if (checkSquare.isBomb)
                        bombAdjNum++;
                }
            }
            numAdjBombs = bombAdjNum;
            return; //TODO: Add numAdjBombs to square display
        }
        
    }
}
