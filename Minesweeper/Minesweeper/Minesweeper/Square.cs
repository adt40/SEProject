﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Square
    {
        public Coordinate pos { get; set; }
        public int isBomb { get; set; }
        public bool hasFlag { get; set; }
        public bool hasClicked { get; set; }
        public int numAdjBombs { get; set; }

        public Square(Coordinate pos, int isBomb)
        {
            this.pos = pos;
            this.isBomb = isBomb;
            hasFlag = false;
            hasClicked = false;
            numAdjBombs = 0; //init value, will change with Map calculation
        }
        
    }
}
