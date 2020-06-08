﻿namespace Minesweeper
{
    partial class Difficulty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Difficulty));
            this.Easy = new System.Windows.Forms.Button();
            this.Intermediate = new System.Windows.Forms.Button();
            this.Hard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Easy
            // 
            this.Easy.BackColor = System.Drawing.Color.DodgerBlue;
            this.Easy.Location = new System.Drawing.Point(236, 95);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(138, 23);
            this.Easy.TabIndex = 0;
            this.Easy.Text = "Easy ( 8 x 8 )";
            this.Easy.UseVisualStyleBackColor = false;
            // 
            // Intermediate
            // 
            this.Intermediate.BackColor = System.Drawing.Color.DodgerBlue;
            this.Intermediate.Location = new System.Drawing.Point(236, 153);
            this.Intermediate.Name = "Intermediate";
            this.Intermediate.Size = new System.Drawing.Size(138, 23);
            this.Intermediate.TabIndex = 1;
            this.Intermediate.Text = "Intermediate ( 10 x 10 )";
            this.Intermediate.UseVisualStyleBackColor = false;
            // 
            // Hard
            // 
            this.Hard.BackColor = System.Drawing.Color.DodgerBlue;
            this.Hard.Location = new System.Drawing.Point(236, 211);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(138, 23);
            this.Hard.TabIndex = 2;
            this.Hard.Text = "Hard ( 13 x 13 )";
            this.Hard.UseVisualStyleBackColor = false;
            // 
            // Difficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minesweeper.Properties.Resources.ms;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Hard);
            this.Controls.Add(this.Intermediate);
            this.Controls.Add(this.Easy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Difficulty";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Easy;
        private System.Windows.Forms.Button Intermediate;
        private System.Windows.Forms.Button Hard;
    }
}