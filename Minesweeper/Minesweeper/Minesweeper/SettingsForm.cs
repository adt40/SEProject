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
    public partial class SettingsForm : Form
    {
        private Button buttonSender;

        public SettingsForm(Button sender)
        {
            buttonSender = sender;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (buttonSender.Name == "NewGameButton")
            {
                if (customText.Text == "")
                {
                    GameForm game = new GameForm(xScrollBar.Value, yScrollBar.Value, bombsScrollBar.Value);
                    game.Show();
                } else
                {
                    GameForm game = new GameForm(customText.Text);
                    game.Show();
                }
                this.Hide();
            } else if (buttonSender.Name == "CustomMapEditorButton")
            {
                EditorForm editor = new EditorForm(xScrollBar.Value, yScrollBar.Value);
                editor.Show();
                this.Hide();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //Create the correct settings based on what button was pressed to open settings
            if (buttonSender.Name == "NewGameButton")
            {
                xText.Text = xScrollBar.Value.ToString();
                yText.Text = yScrollBar.Value.ToString();
                bombsText.Text = bombsScrollBar.Value.ToString();
                UpdateBombScroll();

                bombLabel.Visible = true;
                bombsScrollBar.Visible = true;
                bombsText.Visible = true;

                customLabel.Visible = true;
                customText.Visible = true;
            }
            else if (buttonSender.Name == "CustomMapEditorButton")
            {
                xText.Text = xScrollBar.Value.ToString();
                yText.Text = yScrollBar.Value.ToString();

                bombLabel.Visible = false;
                bombsScrollBar.Visible = false;
                bombsText.Visible = false;

                customLabel.Visible = false;
                customText.Visible = false;
            }
        }

        private void xScrollBar_Scroll_1(object sender, ScrollEventArgs e)
        {
            xText.Text = xScrollBar.Value.ToString();
            UpdateBombScroll();
        }

        private void yScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            yText.Text = yScrollBar.Value.ToString();
            UpdateBombScroll();
        }

        private void bombsScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            bombsText.Text = bombsScrollBar.Value.ToString();
        }

        private void UpdateBombScroll()
        {
            bombsScrollBar.Maximum = 4 * (int)Math.Sqrt(xScrollBar.Value * yScrollBar.Value);
        }

        private bool IsDigitsOnly(string str)
        {
            if (str.Length == 0)
            {
                return false;
            }
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void xText_TextChanged(object sender, EventArgs e)
        {
            if (IsDigitsOnly(xText.Text))
            {
                int xVal = int.Parse(xText.Text);
                if (xVal > xScrollBar.Maximum)
                {
                    xScrollBar.Value = xScrollBar.Maximum;
                    UpdateBombScroll();
                }
                else if (xVal < xScrollBar.Minimum)
                {
                    xScrollBar.Value = xScrollBar.Minimum;
                    UpdateBombScroll();
                }
                else
                {
                    xScrollBar.Value = xVal;
                }
            }
        }

        private void yText_TextChanged_1(object sender, EventArgs e)
        {
            if (IsDigitsOnly(yText.Text))
            {
                int yVal = int.Parse(yText.Text);
                if (yVal > yScrollBar.Maximum)
                {
                    yScrollBar.Value = yScrollBar.Maximum;
                    UpdateBombScroll();
                }
                else if (yVal < yScrollBar.Minimum)
                {
                    yScrollBar.Value = yScrollBar.Minimum;
                    UpdateBombScroll();
                }
                else
                {
                    yScrollBar.Value = yVal;
                }
            }
        }

        private void bombsText_TextChanged_1(object sender, EventArgs e)
        {
            if (IsDigitsOnly(bombsText.Text))
            {
                int bombsVal = int.Parse(bombsText.Text);
                if (bombsVal > bombsScrollBar.Maximum)
                {
                    bombsScrollBar.Value = bombsScrollBar.Maximum;
                }
                else if (bombsVal < bombsScrollBar.Minimum)
                {
                    bombsScrollBar.Value = bombsScrollBar.Minimum;
                }
                else
                {
                    bombsScrollBar.Value = bombsVal;
                }
            }
        }
    }
}
