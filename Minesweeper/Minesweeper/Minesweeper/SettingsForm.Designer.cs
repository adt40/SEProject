﻿using System.Diagnostics.CodeAnalysis;
namespace Minesweeper
{
    [ExcludeFromCodeCoverage]
    partial class SettingsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.xScrollBar = new System.Windows.Forms.HScrollBar();
            this.yScrollBar = new System.Windows.Forms.HScrollBar();
            this.bombsScrollBar = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bombLabel = new System.Windows.Forms.Label();
            this.xText = new System.Windows.Forms.TextBox();
            this.yText = new System.Windows.Forms.TextBox();
            this.bombsText = new System.Windows.Forms.TextBox();
            this.customText = new System.Windows.Forms.TextBox();
            this.customLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(125, 272);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // xScrollBar
            // 
            this.xScrollBar.LargeChange = 1;
            this.xScrollBar.Location = new System.Drawing.Point(57, 38);
            this.xScrollBar.Maximum = 20;
            this.xScrollBar.Minimum = 5;
            this.xScrollBar.Name = "xScrollBar";
            this.xScrollBar.Size = new System.Drawing.Size(225, 15);
            this.xScrollBar.TabIndex = 1;
            this.xScrollBar.Value = 5;
            this.xScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.xScrollBar_Scroll_1);
            // 
            // yScrollBar
            // 
            this.yScrollBar.LargeChange = 1;
            this.yScrollBar.Location = new System.Drawing.Point(57, 70);
            this.yScrollBar.Maximum = 20;
            this.yScrollBar.Minimum = 5;
            this.yScrollBar.Name = "yScrollBar";
            this.yScrollBar.Size = new System.Drawing.Size(225, 15);
            this.yScrollBar.TabIndex = 2;
            this.yScrollBar.Value = 5;
            this.yScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.yScrollBar_Scroll);
            // 
            // bombsScrollBar
            // 
            this.bombsScrollBar.LargeChange = 1;
            this.bombsScrollBar.Location = new System.Drawing.Point(57, 101);
            this.bombsScrollBar.Maximum = 10;
            this.bombsScrollBar.Minimum = 1;
            this.bombsScrollBar.Name = "bombsScrollBar";
            this.bombsScrollBar.Size = new System.Drawing.Size(225, 15);
            this.bombsScrollBar.TabIndex = 3;
            this.bombsScrollBar.Value = 1;
            this.bombsScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.bombsScrollBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // bombLabel
            // 
            this.bombLabel.AutoSize = true;
            this.bombLabel.Location = new System.Drawing.Point(1, 101);
            this.bombLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bombLabel.Name = "bombLabel";
            this.bombLabel.Size = new System.Drawing.Size(51, 17);
            this.bombLabel.TabIndex = 6;
            this.bombLabel.Text = "Bombs";
            // 
            // xText
            // 
            this.xText.Location = new System.Drawing.Point(295, 38);
            this.xText.Margin = new System.Windows.Forms.Padding(4);
            this.xText.Name = "xText";
            this.xText.Size = new System.Drawing.Size(47, 22);
            this.xText.TabIndex = 10;
            this.xText.TextChanged += new System.EventHandler(this.xText_TextChanged);
            // 
            // yText
            // 
            this.yText.Location = new System.Drawing.Point(295, 70);
            this.yText.Margin = new System.Windows.Forms.Padding(4);
            this.yText.Name = "yText";
            this.yText.Size = new System.Drawing.Size(47, 22);
            this.yText.TabIndex = 11;
            this.yText.TextChanged += new System.EventHandler(this.yText_TextChanged_1);
            // 
            // bombsText
            // 
            this.bombsText.Location = new System.Drawing.Point(295, 102);
            this.bombsText.Margin = new System.Windows.Forms.Padding(4);
            this.bombsText.Name = "bombsText";
            this.bombsText.Size = new System.Drawing.Size(47, 22);
            this.bombsText.TabIndex = 12;
            this.bombsText.TextChanged += new System.EventHandler(this.bombsText_TextChanged_1);
            // 
            // customText
            // 
            this.customText.Location = new System.Drawing.Point(17, 222);
            this.customText.Margin = new System.Windows.Forms.Padding(4);
            this.customText.Name = "customText";
            this.customText.Size = new System.Drawing.Size(199, 22);
            this.customText.TabIndex = 13;
            this.customText.TextChanged += new System.EventHandler(this.customText_TextChanged);
            // 
            // customLabel
            // 
            this.customLabel.AutoSize = true;
            this.customLabel.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabel.Location = new System.Drawing.Point(13, 163);
            this.customLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customLabel.Name = "customLabel";
            this.customLabel.Size = new System.Drawing.Size(163, 19);
            this.customLabel.TabIndex = 14;
            this.customLabel.Text = "Load custom map:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(17, 186);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 15;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.customLabel);
            this.Controls.Add(this.customText);
            this.Controls.Add(this.bombsText);
            this.Controls.Add(this.yText);
            this.Controls.Add(this.xText);
            this.Controls.Add(this.bombLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bombsScrollBar);
            this.Controls.Add(this.yScrollBar);
            this.Controls.Add(this.xScrollBar);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HScrollBar xScrollBar;
        private System.Windows.Forms.HScrollBar yScrollBar;
        private System.Windows.Forms.HScrollBar bombsScrollBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label bombLabel;
        private System.Windows.Forms.TextBox xText;
        private System.Windows.Forms.TextBox yText;
        private System.Windows.Forms.TextBox bombsText;
        private System.Windows.Forms.TextBox customText;
        private System.Windows.Forms.Label customLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
    }
}