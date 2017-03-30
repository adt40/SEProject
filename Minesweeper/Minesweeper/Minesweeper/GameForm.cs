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
        private bool winCondition = true;
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
            map.SetAdjBombVals();
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
                        if (square.isBomb)
                        {
                            //If you lose like a heckin dummy
                            buttons[x, y].Text = "B";
                            buttons[x, y].BackColor = SystemColors.ScrollBar;
                            square.hasClicked = true;
                            // Loop through grid to find each bomb and uncover them
                            for (int xgrid = 0; xgrid < buttons.GetLength(0); xgrid++)
                            {
                                for (int ygrid = 0; ygrid < buttons.GetLength(1); ygrid++)
                                {
                                    Coordinate cgrid = new Coordinate(xgrid, ygrid);
                                    Square testsquare = map.squares[cgrid];
                                    if (testsquare.isBomb)
                                    {
                                        buttons[xgrid, ygrid].Text = "B";
                                        buttons[xgrid, ygrid].BackColor = SystemColors.ScrollBar;
                                    }
                                }
                            }
                            winCondition = false;
                            LoseForm youLose = new LoseForm();
                            youLose.ShowDialog();
                            
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
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    Coordinate c = new Coordinate(x + i, y + j);
                    if (map.squares.ContainsKey(c))
                    {
                        if (map.squares[c].numAdjBombs == 0 && !map.squares[c].hasClicked)
                        {
                            buttons[x + i, y + j].BackColor = SystemColors.ScrollBar;
                            map.squares[c].hasClicked = true;
                            revealZeros(x + i, y + j);
                        } else if (map.squares[c].numAdjBombs > 0)
                        {
                            buttons[x + i, y + j].Text = map.squares[c].numAdjBombs.ToString();
                            buttons[x + i, y + j].BackColor = SystemColors.ScrollBar;
                            map.squares[c].hasClicked = true;
                        }
                    }

                }
            }
        }
    }
}
