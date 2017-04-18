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

        public void ReadOnlineFiles()
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

        public void PopulateLocalList()
        {
            YourMapsList.Items.Clear();
            foreach (String file in LocalFiles)
            {
                YourMapsList.Items.Add(RemoveExcessFilename(file));
            }
        }

        public void ReadLocalFiles()
        {
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
            return filename.Substring(filename.LastIndexOf("\\") + 1); 
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
    }
}
