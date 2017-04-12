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

namespace Minesweeper
{
    public partial class MapBrowserForm : Form
    {
        public List<String> LocalFiles { get; }
        public List<String> OnlineFiles { get; }


        public MapBrowserForm()
        {
            LocalFiles = new List<String>();
            OnlineFiles = new List<String>();
            InitializeComponent();
        }

        private void MapBrowserForm_Load(object sender, EventArgs e)
        {
            ReadLocalFiles();
            PopulateLocalList();
            ReadOnlineFiles();
            PopulateOnlineList();


        }

        private void ReadOnlineFiles()
        {
            //use server, and use ReadLocalList as an example of sort of whats going on here
        }

        private void PopulateOnlineList()
        {
            OnlineMapsList.Items.Clear();
            foreach (String file in OnlineFiles)
            {
                OnlineMapsList.Items.Add(RemoveExcessFilename(file));
            }
        }

        private void PopulateLocalList()
        {
            YourMapsList.Items.Clear();
            foreach (String file in LocalFiles)
            {
                YourMapsList.Items.Add(RemoveExcessFilename(file));
            }
        }

        private void ReadLocalFiles()
        {
            String[] rawfiles = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\bin\\debug");
            foreach (String s in rawfiles)
            {
                if (s.Contains(".map"))
                {
                    LocalFiles.Add(s);
                }
            }
        }

        private String RemoveExcessFilename(String filename)
        {
            return filename.Substring(filename.LastIndexOf("\\") + 1); 
        }
    }
}
