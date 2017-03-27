using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Minesweeper
{
    public partial class GameForm : Form
    {
        private int mapX, mapY, numBombs;
        private Map map { get; set; }
        private Button[,] buttons;

        public GameForm(int x, int y, int bombs)
        {
            //Test values, grab real values some other way
            mapX = x;
            mapY = y;
            numBombs = bombs;

            map = new Map(mapX, mapY, numBombs);

            InitializeComponent();
        }

        public GameForm(String filename)
        {
            map = new Map(filename);
            mapX = map.width;
            mapY = map.height;
            numBombs = map.numBombs;

            InitializeComponent();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameForm game = new GameForm(mapX, mapY, numBombs);
            game.Show();
            this.Hide();
        }

        private void menu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm menu = new MainForm();
            menu.Show();
            this.Hide();
        }

        private void changeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Simulating opening from main menu, but this could be its own thing if need be
            Button temp = new Button();
            temp.Name = "NewGameButton";
            SettingsForm settings = new SettingsForm(temp);
            settings.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[mapX, mapY];

            int gridSizeInPixels = 400; //Change this at some point
            int offset = 50;
            int buttonSize = Math.Min(gridSizeInPixels / mapX, gridSizeInPixels / mapY);

            for (int x = 0; x < buttons.GetLength(0); x++)
            {
                for (int y = 0; y < buttons.GetLength(1); y++)
                {
                    buttons[x, y] = new Button();
                    buttons[x, y].Top = offset + x * buttonSize;
                    buttons[x, y].Left = offset + y * buttonSize;
                    buttons[x, y].Width = buttonSize;
                    buttons[x, y].Height = buttonSize;
                    buttons[x, y].Click += new EventHandler(MapClicked);

                    this.Controls.Add(buttons[x, y]);
                }
            }

        }

        private void MapClicked(object sender, EventArgs e)
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
                            buttons[x, y].BackColor = SystemColors.ScrollBar;
                            square.hasClicked = true;
                        } else
                        {
                            int numAdj = square.numAdjBombs;
                            if (numAdj == 0)
                            {
                                buttons[x, y].BackColor = SystemColors.ScrollBar;
                                square.hasClicked = true;
                                revealZeros(x, y);
                                
                            } else
                            {
                                buttons[x, y].Text = numAdj.ToString();
                                buttons[x, y].BackColor = SystemColors.ScrollBar;
                                square.hasClicked = true;
                                
                            }
                            

                        }

                        keepLooping = false;
                    }
                }
            }
        }

        private void revealZeros(int x, int y)
        {
            //Directly Adjacent
            if (x != mapX - 1)
            {
                Square squareRight = map.squares[new Coordinate(x + 1, y)];
                if (squareRight.numAdjBombs == 0 && squareRight.hasClicked == false)
                {
                    buttons[x + 1, y].BackColor = SystemColors.ScrollBar;
                    squareRight.hasClicked = true;
                    revealZeros(x + 1, y);
                }
                else if (squareRight.numAdjBombs > 0)
                {
                    buttons[x + 1, y].Text = squareRight.numAdjBombs.ToString();
                    buttons[x + 1, y].BackColor = SystemColors.ScrollBar;
                    squareRight.hasClicked = true;
                }
            }

            if (x != 0)
            {
                Square squareLeft = map.squares[new Coordinate(x - 1, y)];
                if (squareLeft.numAdjBombs == 0 && squareLeft.hasClicked == false)
                {
                    buttons[x - 1, y].BackColor = SystemColors.ScrollBar;
                    squareLeft.hasClicked = true;
                    revealZeros(x - 1, y);
                }
                else if (squareLeft.numAdjBombs > 0)
                {
                    buttons[x - 1, y].Text = squareLeft.numAdjBombs.ToString();
                    buttons[x - 1, y].BackColor = SystemColors.ScrollBar;
                    squareLeft.hasClicked = true;
                }
            }

            if (y != mapY - 1)
            {
                Square squareDown = map.squares[new Coordinate(x, y + 1)];
                if (squareDown.numAdjBombs == 0 && squareDown.hasClicked == false)
                {
                    buttons[x, y + 1].BackColor = SystemColors.ScrollBar;
                    squareDown.hasClicked = true;
                    revealZeros(x, y + 1);
                }
                else if (squareDown.numAdjBombs > 0)
                {
                    buttons[x, y + 1].Text = squareDown.numAdjBombs.ToString();
                    buttons[x, y + 1].BackColor = SystemColors.ScrollBar;
                    squareDown.hasClicked = true;
                }
            }

            if (y != 0)
            {
                Square squareUp = map.squares[new Coordinate(x, y - 1)];
                if (squareUp.numAdjBombs == 0 && squareUp.hasClicked == false)
                {
                    buttons[x, y - 1].BackColor = SystemColors.ScrollBar;
                    squareUp.hasClicked = true;
                    revealZeros(x, y - 1);
                }
                else if (squareUp.numAdjBombs > 0)
                {
                    buttons[x, y - 1].Text = squareUp.numAdjBombs.ToString();
                    buttons[x, y - 1].BackColor = SystemColors.ScrollBar;
                    squareUp.hasClicked = true;
                }
            }


            //Diagonal
            if (x != mapX - 1 && y != mapY - 1)
            {
                Square squareDownRight = map.squares[new Coordinate(x + 1, y + 1)];
                if (squareDownRight.numAdjBombs == 0 && squareDownRight.hasClicked == false)
                {
                    buttons[x + 1, y + 1].BackColor = SystemColors.ScrollBar;
                    squareDownRight.hasClicked = true;
                    revealZeros(x + 1, y + 1);
                }
                else if (squareDownRight.numAdjBombs > 0)
                {
                    buttons[x + 1, y + 1].Text = squareDownRight.numAdjBombs.ToString();
                    buttons[x + 1, y + 1].BackColor = SystemColors.ScrollBar;
                    squareDownRight.hasClicked = true;
                }
            }

            if (x != mapX - 1 && y != 0)
            {
                Square squareUpRight = map.squares[new Coordinate(x + 1, y - 1)];
                if (squareUpRight.numAdjBombs == 0 && squareUpRight.hasClicked == false)
                {
                    buttons[x + 1, y - 1].BackColor = SystemColors.ScrollBar;
                    squareUpRight.hasClicked = true;
                    revealZeros(x + 1, y - 1);
                }
                else if (squareUpRight.numAdjBombs > 0)
                {
                    buttons[x + 1, y - 1].Text = squareUpRight.numAdjBombs.ToString();
                    buttons[x + 1, y - 1].BackColor = SystemColors.ScrollBar;
                    squareUpRight.hasClicked = true;
                }
            }

            if (x != 0 && y != mapY - 1)
            {
                Square squareDownLeft = map.squares[new Coordinate(x - 1, y + 1)];
                if (squareDownLeft.numAdjBombs == 0 && squareDownLeft.hasClicked == false)
                {
                    buttons[x - 1, y + 1].BackColor = SystemColors.ScrollBar;
                    squareDownLeft.hasClicked = true;
                    revealZeros(x - 1, y + 1);
                }
                else if (squareDownLeft.numAdjBombs > 0)
                {
                    buttons[x - 1, y + 1].Text = squareDownLeft.numAdjBombs.ToString();
                    buttons[x - 1, y + 1].BackColor = SystemColors.ScrollBar;
                    squareDownLeft.hasClicked = true;
                }
            }

            if (x != 0 && y != 0)
            {
                Square squareUpLeft = map.squares[new Coordinate(x - 1, y - 1)];
                if (squareUpLeft.numAdjBombs == 0 && squareUpLeft.hasClicked == false)
                {
                    buttons[x - 1, y - 1].BackColor = SystemColors.ScrollBar;
                    squareUpLeft.hasClicked = true;
                    revealZeros(x - 1, y - 1);
                }
                else if (squareUpLeft.numAdjBombs > 0)
                {
                    buttons[x - 1, y - 1].Text = squareUpLeft.numAdjBombs.ToString();
                    buttons[x - 1, y - 1].BackColor = SystemColors.ScrollBar;
                    squareUpLeft.hasClicked = true;
                }
            }
        }


    }
}
