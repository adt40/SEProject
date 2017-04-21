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
using System.IO;

namespace Minesweeper
{
    public partial class WinForm : Form
    {
        TransferUtility utility;
        GameForm game;
        public WinForm(GameForm game) {
            this.game = game;
            InitializeComponent();
        }
        public WinForm()
        {
            InitializeComponent();
            //for unit testing
        }
        private void WinForm_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            game.Hide();
            this.Hide();
        }
        private void downloader(String filename)
        {
            //download file
            
            TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest();
            request.BucketName = "eecs393highscore";
            
            request.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + filename + ".score";
            request.Key = filename + ".score";
            utility.Download(request);
        }
        private void uploader(String filename)
        {
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
            request.BucketName = "eecs393highscore";
            request.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + filename + ".score";
            utility.Upload(request);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //putting a highScore file online
            //download latest file
            String filename = "highScore";
            downloader(filename);
            String USR = textBox1.Text+" ";
            Debug.Print(Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper").ToString());
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper");
            }
            StreamWriter file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + filename + ".score");
            File.AppendAllText(filename + ".score", USR);

            //uploading file
            uploader(filename);

            
        }
    }
}
