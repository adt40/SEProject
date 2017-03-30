﻿using System;
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
                    buttons[x, y].MouseDown += new MouseEventHandler(MapRightClicked);

                    this.Controls.Add(buttons[x, y]);
                }
            }
            map.SetAdjBombVals();
        }

        private void MapRightClicked(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return; //If it's not a right click, we don't care
            Coordinate buttonCoordinates = findButtonCoordinates(sender as Button);
            Button button = buttons[buttonCoordinates.x, buttonCoordinates.y];
            Square square = map.squares[buttonCoordinates];
            if (!square.hasFlag)
            {
                square.hasFlag = true;
                button.Text = "F";
            }
            else
            {
                square.hasFlag = false;
                button.Text = "";
            }
        }

        private void MapClicked(object sender, EventArgs e)
        {
            Coordinate buttonCoordinates = findButtonCoordinates(sender as Button);
            Button button = buttons[buttonCoordinates.x, buttonCoordinates.y];
            Square square = map.squares[buttonCoordinates];
            if (square.hasClicked || square.hasFlag) return;

            square.hasClicked = true;
            if (square.isBomb)
            {
                loseAt(button);
            }
            else
            {
                int numAdj = square.numAdjBombs;
                if (numAdj == 0)
                {
                    button.BackColor = SystemColors.ScrollBar;
                    square.hasClicked = true;
                    revealZeros(buttonCoordinates.x, buttonCoordinates.y);

                }
                else
                {
                    button.Text = numAdj.ToString();
                    button.BackColor = SystemColors.ScrollBar;
                    square.hasClicked = true;

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
                        }
                        else if (map.squares[c].numAdjBombs > 0)
                        {
                            buttons[x + i, y + j].Text = map.squares[c].numAdjBombs.ToString();
                            buttons[x + i, y + j].BackColor = SystemColors.ScrollBar;
                            map.squares[c].hasClicked = true;
                        }
                    }

                }
            }
        }

        private Coordinate findButtonCoordinates(Button sender)
        {
            for (int x = 0; x < buttons.GetLength(0); x++)
            {
                for (int y = 0; y < buttons.GetLength(1); y++)
                {
                    if (buttons[x, y].Equals(sender)) return new Coordinate(x, y);
                }
            }
            return null;
        }

        private void loseAt(Button button)
        {
            //If you lose like a heckin dummy
            button.Text = "B";
            button.BackColor = SystemColors.ScrollBar;
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
        }
    }
}
