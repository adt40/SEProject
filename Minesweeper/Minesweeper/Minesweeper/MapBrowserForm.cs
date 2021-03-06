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
using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using System.Diagnostics.CodeAnalysis;

namespace Minesweeper
{
    public partial class MapBrowserForm : Form
    {
        public List<String> LocalFiles { get; }
        public List<S3Object> OnlineFiles { get; }
        public AmazonS3Client client;
        public TransferUtility utility;

        public MapBrowserForm()
        {
            LocalFiles = new List<String>();
            OnlineFiles = new List<S3Object>();
            client = new AmazonS3Client(RegionEndpoint.USEast2);
            utility = new TransferUtility(RegionEndpoint.USEast2);
            InitializeComponent();
        }

        private void MapBrowserForm_Load(object sender, EventArgs e)
        {
            ReadLocalFiles();
            PopulateLocalList();
            ReadOnlineFiles();
            PopulateOnlineList();

        }

        public void ReadOnlineFiles()
        {
            OnlineFiles.Clear();
            ListObjectsRequest request = new ListObjectsRequest();
            request.BucketName = "eecs393minesweeper";
            ListObjectsResponse response = client.ListObjects(request);
            foreach(S3Object o in response.S3Objects)
            {
                OnlineFiles.Add(o);
            }
        }

        private void PopulateOnlineList()
        {
            OnlineMapsList.Items.Clear();
            foreach (S3Object file in OnlineFiles)
            {
                OnlineMapsList.Items.Add(RemoveExcessFilename(file.Key));
            }
        }

        public void PopulateLocalList()
        {
            YourMapsList.Items.Clear();
            foreach (String file in LocalFiles)
            {
                YourMapsList.Items.Add(RemoveExcessFilename(file));
            }
        }

        //These blocks have been excluded from code coverage, because to fully test all blocks requires a test computer to not have a minesweeper documents folder
        [ExcludeFromCodeCoverage]
        public void ReadLocalFiles()
        {
            LocalFiles.Clear();
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper");
            }
            String[] rawfiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper");
            foreach (String s in rawfiles)
            {
                if (s.Contains(".map"))
                {
                    LocalFiles.Add(s);
                }
            }
        }

        public String RemoveExcessFilename(String filename)
        {

            String justFile = filename.Substring(filename.LastIndexOf("\\") + 1);
            return justFile.Substring(0, justFile.IndexOf("."));            
        }


        //For testing
        public ListBox getYourMapsList()
        {
            return YourMapsList;
        }
        public ListBox getOnlineMapsList()
        {
            return OnlineMapsList;
        }
        [ExcludeFromCodeCoverage] //Test method below
        public void UploadButton_Click(object sender, EventArgs e)
        {
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
            request.BucketName = "eecs393minesweeper";
            String filename = YourMapsList.SelectedItem.ToString();
            request.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + filename + ".map";
            utility.Upload(request);
            ReadOnlineFiles();
            PopulateOnlineList();
        }

        public bool UploadTest()
        {
            
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
            request.BucketName = "eecs393minesweeper";
            String filename = "testmap";
            request.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + filename + ".map";
            utility.Upload(request);
            ReadOnlineFiles();
            PopulateOnlineList();
            GetObjectMetadataRequest req = new GetObjectMetadataRequest();
            req.BucketName = "eecs393minesweeper";
            String key = "test.map";
            req.Key = key;
            try
            {
                GetObjectMetadataResponse response = client.GetObjectMetadata(req.BucketName, req.Key);
            }
            catch(AmazonS3Exception e)
            {
                if (e.Message == "The specified key does not exist")
                    return false;

                throw;
            }
            return true;
            
        }
        [ExcludeFromCodeCoverage] //test method below
        public void DownloadButton_Click(object sender, EventArgs e)
        {
            TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest();
            request.BucketName = "eecs393minesweeper";
            String key = OnlineMapsList.SelectedItem.ToString() + ".map";
            request.Key = key;
            request.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + key;
            utility.Download(request);
            ReadLocalFiles();
            PopulateLocalList();
        }
        public bool testDownload()
        {
            TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest();
            request.BucketName = "eecs393minesweeper";
            String key = "test.map";
            request.Key = key;
            request.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + key;
            utility.Download(request);
            ReadLocalFiles();
            PopulateLocalList();
            return File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Minesweeper\\" + key);

        }
        [ExcludeFromCodeCoverage]
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }
    }
}
