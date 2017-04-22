namespace Minesweeper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NewGameButton = new System.Windows.Forms.Button();
            this.CustomMapEditorButton = new System.Windows.Forms.Button();
            this.browserButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.SystemColors.InfoText;
            this.NewGameButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NewGameButton.BackgroundImage")));
            this.NewGameButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGameButton.Image = ((System.Drawing.Image)(resources.GetObject("NewGameButton.Image")));
            this.NewGameButton.Location = new System.Drawing.Point(38, 263);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(140, 51);
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.Text = "new game";
            this.NewGameButton.UseVisualStyleBackColor = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // CustomMapEditorButton
            // 
            this.CustomMapEditorButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomMapEditorButton.Image = ((System.Drawing.Image)(resources.GetObject("CustomMapEditorButton.Image")));
            this.CustomMapEditorButton.Location = new System.Drawing.Point(291, 261);
            this.CustomMapEditorButton.Name = "CustomMapEditorButton";
            this.CustomMapEditorButton.Size = new System.Drawing.Size(140, 53);
            this.CustomMapEditorButton.TabIndex = 2;
            this.CustomMapEditorButton.Text = "custom map editor";
            this.CustomMapEditorButton.UseVisualStyleBackColor = true;
            this.CustomMapEditorButton.Click += new System.EventHandler(this.CustomMapEditorButton_Click);
            // 
            // browserButton
            // 
            this.browserButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browserButton.Image = ((System.Drawing.Image)(resources.GetObject("browserButton.Image")));
            this.browserButton.Location = new System.Drawing.Point(38, 320);
            this.browserButton.Name = "browserButton";
            this.browserButton.Size = new System.Drawing.Size(140, 51);
            this.browserButton.TabIndex = 3;
            this.browserButton.Text = "map browser";
            this.browserButton.UseVisualStyleBackColor = true;
            this.browserButton.Click += new System.EventHandler(this.browserButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Image = ((System.Drawing.Image)(resources.GetObject("QuitButton.Image")));
            this.QuitButton.Location = new System.Drawing.Point(291, 320);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(140, 51);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(458, 402);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.browserButton);
            this.Controls.Add(this.CustomMapEditorButton);
            this.Controls.Add(this.NewGameButton);
            this.Name = "MainForm";
            this.Text = "Minesweeper PRO";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button CustomMapEditorButton;
        private System.Windows.Forms.Button browserButton;
        private System.Windows.Forms.Button QuitButton;
    }
}