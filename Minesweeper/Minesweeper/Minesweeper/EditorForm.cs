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
using System.Diagnostics.CodeAnalysis;

namespace Minesweeper
{
    public partial class EditorForm : Form
    {
        public int mapX, mapY;
        public Map map { get; set; }
        public Button[,] buttons;
        public Coordinate check;
        public EditorForm(int x, int y)
        {
            //Test values, grab real values some other way
            mapX = x;
            mapY = y;

            InitializeComponent();
        }

        public void Form3_Load(object sender, EventArgs e)
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

        public void MapClicked(object sender, EventArgs e)
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
                        check = c;
                        map.squares[c].isBomb = !map.squares[c].isBomb;                        
                        updateAdj();
                        

                        keepLooping = false;
                    }
                }
            }
        }

        public void ColorText(int numAdj, Button button)
        {
            switch (numAdj)
            {
                case 1:
                    button.ForeColor = Color.Blue;
                    break;
                case 2:
                    button.ForeColor = Color.ForestGreen;
                    break;
                case 3:
                    button.ForeColor = Color.DarkRed;
                    break;
                case 4:
                    button.ForeColor = Color.Purple;
                    break;
                case 5:
                    button.ForeColor = Color.Orange;
                    break;
                case 6:
                    button.ForeColor = Color.DarkBlue;
                    break;
                case 7:
                    button.ForeColor = Color.Goldenrod;
                    break;
                case 8:
                    button.ForeColor = Color.Brown;
                    break;
                default:
                    button.ForeColor = Color.Black;
                    break;
            }
        }


        [ExcludeFromCodeCoverage]
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm menu = new MainForm();
            menu.Show();
            this.Hide();
        }
        [ExcludeFromCodeCoverage]
        private void resetMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorForm editor = new EditorForm(mapX, mapY);
            editor.Show();
            this.Hide();

        }
        [ExcludeFromCodeCoverage]
        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String filename = Microsoft.VisualBasic.Interaction.InputBox("Save Map", "Enter name", "", 0, 0);
            if (filename.Length > 0)
            {
                
                map.CreateMapFile(filename + ".map");
                SaveOutcomeLabel.Text = "Map successfully saved!";

            } else
            {
                SaveOutcomeLabel.Text = "Map could not be saved. Enter a valid filename.";
            }
            

        }

        public void updateAdj()
        {
            map.SetAdjBombVals();
            for (int x = 0; x < buttons.GetLength(0); x++)
            {
                for (int y = 0; y < buttons.GetLength(1); y++)
                {
                    Coordinate c = new Coordinate(x, y);
                    Square square = map.squares[c];
                    if (!square.isBomb)
                    {
                        buttons[x, y].BackgroundImage = null;
                        int adj = square.numAdjBombs;
                        if (adj != 0)
                        {
                            buttons[x, y].Text = square.numAdjBombs.ToString();
                            ColorText(square.numAdjBombs, buttons[x, y]);
                        }
                        else
                        {
                            buttons[x, y].Text = "";
                        }
                    }
                    else
                    {
                        buttons[x, y].BackgroundImage = Properties.Resources.bomb;
                        buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }
    }
}
