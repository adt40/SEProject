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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void NewGameButton_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm((Button)sender);
            settings.Show();
            this.Hide();
        }

        private void CustomMapEditorButton_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm((Button)sender);
            settings.Show();
            this.Hide();
        }
    }
}
