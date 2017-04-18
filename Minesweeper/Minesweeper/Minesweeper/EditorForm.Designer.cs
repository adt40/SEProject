using System.Diagnostics.CodeAnalysis;

namespace Minesweeper
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveOutcomeLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(645, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetMapToolStripMenuItem,
            this.mainMenuToolStripMenuItem,
            this.saveMapToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // resetMapToolStripMenuItem
            // 
            this.resetMapToolStripMenuItem.Name = "resetMapToolStripMenuItem";
            this.resetMapToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.resetMapToolStripMenuItem.Text = "Reset Map";
            this.resetMapToolStripMenuItem.Click += new System.EventHandler(this.resetMapToolStripMenuItem_Click);
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // SaveOutcomeLabel
            // 
            this.SaveOutcomeLabel.AutoSize = true;
            this.SaveOutcomeLabel.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveOutcomeLabel.Location = new System.Drawing.Point(-5, 578);
            this.SaveOutcomeLabel.Name = "SaveOutcomeLabel";
            this.SaveOutcomeLabel.Size = new System.Drawing.Size(0, 27);
            this.SaveOutcomeLabel.TabIndex = 1;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 604);
            this.Controls.Add(this.SaveOutcomeLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EditorForm";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.Label SaveOutcomeLabel;
    }
}