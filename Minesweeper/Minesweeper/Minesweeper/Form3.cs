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
    public partial class Form3 : Form
    {
        private int mapX, mapY;
        private Map map { get; set; }
        private Button[,] buttons;

        public Form3(int x, int y)
        {
            //Test values, grab real values some other way
            mapX = x;
            mapY = y;

            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            buttons = new Button[mapX, mapY];
            map = new Map(mapX, mapY, 0);

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
                        square.isBomb = 1;

                        updateAdj();


                        keepLooping = false;
                    }
                }
            }
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 menu = new Form2();
            menu.Show();
            this.Hide();
        }

        private void resetMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 editor = new Form3(mapX, mapY);
            editor.Show();
            this.Hide();

        }

        private void updateAdj()
        {
            for (int x = 0; x < buttons.GetLength(0); x++)
            {
                for (int y = 0; y < buttons.GetLength(1); y++)
                {
                    Coordinate c = new Coordinate(x, y);
                    Square square = map.squares[c];
                    if (square.isBomb == 0)
                    {
                        int adj = square.numAdjBombs;
                        if (adj != 0)
                        {
                            buttons[x, y].Text = square.numAdjBombs.ToString();
                        }
                    } else
                    {
                        buttons[x, y].Text = "B";
                    }
                }
            }
        }
    }
}
