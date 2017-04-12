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
            this.label1 = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.CustomMapEditorButton = new System.Windows.Forms.Button();
            this.browserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(553, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minesweeper PRO";
            // 
            // NewGameButton
            // 
            this.NewGameButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGameButton.Location = new System.Drawing.Point(63, 155);
            this.NewGameButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(187, 63);
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.Text = "new game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // CustomMapEditorButton
            // 
            this.CustomMapEditorButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomMapEditorButton.Location = new System.Drawing.Point(343, 155);
            this.CustomMapEditorButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CustomMapEditorButton.Name = "CustomMapEditorButton";
            this.CustomMapEditorButton.Size = new System.Drawing.Size(187, 65);
            this.CustomMapEditorButton.TabIndex = 2;
            this.CustomMapEditorButton.Text = "custom map editor";
            this.CustomMapEditorButton.UseVisualStyleBackColor = true;
            this.CustomMapEditorButton.Click += new System.EventHandler(this.CustomMapEditorButton_Click);
            // 
            // browserButton
            // 
            this.browserButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browserButton.Location = new System.Drawing.Point(63, 270);
            this.browserButton.Margin = new System.Windows.Forms.Padding(4);
            this.browserButton.Name = "browserButton";
            this.browserButton.Size = new System.Drawing.Size(187, 63);
            this.browserButton.TabIndex = 3;
            this.browserButton.Text = "map browser";
            this.browserButton.UseVisualStyleBackColor = true;
            this.browserButton.Click += new System.EventHandler(this.browserButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 495);
            this.Controls.Add(this.browserButton);
            this.Controls.Add(this.CustomMapEditorButton);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Minesweeper PRO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button CustomMapEditorButton;
        private System.Windows.Forms.Button browserButton;
    }
}