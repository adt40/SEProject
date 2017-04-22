using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Minesweeper

{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            
            String file = "highScore";
            displayLeaderboard(file);
            InitializeComponent();
        }
        public static void displayLeaderboard(String filename)
        {

            
        }
        
       
    }
}
