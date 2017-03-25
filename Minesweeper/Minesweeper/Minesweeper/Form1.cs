using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private int mapX, mapY, numBombs;
        private Map map { get; set; }
        private Button[,] buttons;

        public Form1()
        {
            //Test values, grab real values from components on the window
            mapX = 10;
            mapY = 10;
            numBombs = 15;

            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void menu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[mapX, mapY];
            map = new Map(mapX, mapY, numBombs);

            int gridSizeInPixels = 400; //Change this at some point
            int offset = 50;
            int buttonSize = Math.Min(gridSizeInPixels / mapX, gridSizeInPixels / mapY);

            for (int x = 0; x < buttons.GetLength(0); x++)
            {
                for (int y = 0; y < buttons.GetLength(1); y++)
                {
                    buttons[x, y] = new Button();
                    buttons[x, y].Top = offset / 2 + x * buttonSize;
                    buttons[x, y].Left = offset + y * buttonSize;
                    buttons[x, y].Width = buttonSize;
                    buttons[x, y].Height = buttonSize;
                    buttons[x, y].Click += new EventHandler(MapClicked);

                    this.Controls.Add(buttons[x, y]);
                }
            }

        }

        protected void MapClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            bool keepLooping = true;
            for (int x = 0; x < buttons.GetLength(0) && keepLooping; x++)
            {
                for (int y = 0; y < buttons.GetLength(1) && keepLooping; y++)
                {
                    if (buttons[x, y].Equals(button))
                    {
                        Coordinate c = new Coordinate(x, y);
                        Square square = map.squares[c];
                        if (square.isBomb == 1)
                        {
                            buttons[x, y].Text = "B";
                        } else
                        {
                            int numAdj = square.numAdjBombs;
                            if (numAdj == 0)
                            {
                                //revealZeros(x, y)
                            } else
                            {
                                buttons[x, y].Text = numAdj.ToString();
                            }
                            

                        }

                        keepLooping = false;
                    }
                }
            }
        }
    }
}
