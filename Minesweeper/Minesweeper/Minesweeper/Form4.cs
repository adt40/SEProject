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
    public partial class Form4 : Form
    {
        private Button buttonSender;

        public Form4(Button sender)
        {
            buttonSender = sender;

            


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (buttonSender.Name == "NewGameButton")
            {
                Form1 game = new Form1(xScrollBar.Value, yScrollBar.Value, bombsScrollBar.Value);
                game.Show();//Pass settings to this
                this.Hide();
            } else if (buttonSender.Name == "CustomMapEditorButton")
            {
                Form3 editor = new Form3(xScrollBar.Value, yScrollBar.Value);
                editor.Show();//Pass settings to this
                this.Hide();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //Create the correct settings based on what button was pressed to open settings
            if (buttonSender.Name == "NewGameButton")
            {
                
            }
            else if (buttonSender.Name == "CustomMapEditorButton")
            {

            }
        }

        private void xScrollBar_Scroll_1(object sender, ScrollEventArgs e)
        {
            xText.Text = xScrollBar.Value.ToString();
            bombsScrollBar.Maximum = xScrollBar.Value * yScrollBar.Value;
        }

        private void yScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            yText.Text = yScrollBar.Value.ToString();
            bombsScrollBar.Maximum = xScrollBar.Value * yScrollBar.Value;
        }

        private void bombsScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            bombsText.Text = bombsScrollBar.Value.ToString();
        }

        private void xText_TextChanged(object sender, EventArgs e)
        {
            if (IsDigitsOnly(xText.Text))
            {
                int xVal = int.Parse(xText.Text);
                if (xVal < xScrollBar.Maximum && xVal > xScrollBar.Minimum)
                {
                    xScrollBar.Value = xVal;
                }
            }
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void yText_TextChanged_1(object sender, EventArgs e)
        {
            if (IsDigitsOnly(yText.Text))
            {
                int yVal = int.Parse(yText.Text);
                if (yVal < yScrollBar.Maximum && yVal > yScrollBar.Minimum)
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
                if (bombsVal < bombsScrollBar.Maximum && bombsVal > bombsScrollBar.Minimum)
                {
                    bombsScrollBar.Value = bombsVal;
                }
            }
        }
    }
}
