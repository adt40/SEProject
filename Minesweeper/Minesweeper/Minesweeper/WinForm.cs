using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Minesweeper
{
    public partial class WinForm : Form
    {
        
        public GameForm game;
        public String filename;

        public WinForm(GameForm game) {
            this.game = game;
            InitializeComponent();
        }

        [ExcludeFromCodeCoverage]
        public WinForm()
        {
            
            InitializeComponent();
            //for unit testing
        }
        private void WinForm_Load(object sender, EventArgs e)
        {
            filename = game.map.MyName;
            if (filename == null)
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                HighScoresList.Visible = false;
                textBox1.Visible = false;
                button2.Visible = false;
                button1.Left = 100;
                Height = 200;
            } else
            {

                int counter = 0;
                List<Tuple<int, String>> OrderedScores = new List<Tuple<int, String>>();
                foreach (String name in game.map.scores.Keys)
                {
                    OrderedScores.Add(Tuple.Create(game.map.scores[name], name));
                }

                OrderedScores.Sort();

                foreach (Tuple<int, String> tuple in OrderedScores)
                {
                    HighScoresList.Items.Add(tuple.Item1 + "   " + tuple.Item2);

                    counter += 1;
                    if (counter >= 10)
                    {
                        break;
                    }
                }
                
                
            }

        }

        [ExcludeFromCodeCoverage]
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            game.Hide();
            this.Hide();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            TransferUtility utility = new TransferUtility(RegionEndpoint.USEast2);
            
            if (game.map.scores.Keys.Contains(textBox1.Text))
            {
                game.map.scores[textBox1.Text] = game.Time;
            } else
            {
                game.map.scores.Add(textBox1.Text, game.Time);
            }
            

            game.map.CreateMapFile(filename);

            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
            request.BucketName = "eecs393minesweeper";
            
            request.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + filename;
            utility.Upload(request);

            MainForm main = new MainForm();
            main.Show();
            game.Hide();
            this.Hide();

        }
    }
}
