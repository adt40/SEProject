﻿using System;
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
    public partial class NetworkForm : Form
    {
        public NetworkForm()
        {
            InitializeComponent();
        }

        private void NetworkForm_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "MAP Files|*.map";
            openFileDialog2.Title = "Select a Map";
            MessageBox.Show("Servers are not up.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
