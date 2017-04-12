namespace Minesweeper
{
    partial class MapBrowserForm
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
            this.YourMapsList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OnlineMapsList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // YourMapsList
            // 
            this.YourMapsList.FormattingEnabled = true;
            this.YourMapsList.ItemHeight = 16;
            this.YourMapsList.Location = new System.Drawing.Point(12, 87);
            this.YourMapsList.Name = "YourMapsList";
            this.YourMapsList.Size = new System.Drawing.Size(230, 404);
            this.YourMapsList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Maps:";
            // 
            // OnlineMapsList
            // 
            this.OnlineMapsList.FormattingEnabled = true;
            this.OnlineMapsList.ItemHeight = 16;
            this.OnlineMapsList.Location = new System.Drawing.Point(318, 87);
            this.OnlineMapsList.Name = "OnlineMapsList";
            this.OnlineMapsList.Size = new System.Drawing.Size(230, 404);
            this.OnlineMapsList.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(314, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Online Maps:";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(252, 249);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(56, 34);
            this.DownloadButton.TabIndex = 4;
            this.DownloadButton.Text = "<--";
            this.DownloadButton.UseVisualStyleBackColor = true;
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(252, 289);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(56, 34);
            this.UploadButton.TabIndex = 5;
            this.UploadButton.Text = "-->";
            this.UploadButton.UseVisualStyleBackColor = true;
            // 
            // MapBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 637);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OnlineMapsList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YourMapsList);
            this.Name = "MapBrowserForm";
            this.Text = "MapBrowserForm";
            this.Load += new System.EventHandler(this.MapBrowserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox YourMapsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox OnlineMapsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button UploadButton;
    }
}