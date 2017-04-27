using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

namespace Minesweeper
{
    [ExcludeFromCodeCoverage]
    public partial class LoseForm : Form
    {
        GameForm game;

        public LoseForm(GameForm game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            game.Hide();
            this.Hide();
        }
    }
}
