namespace Minesweeper
{
    partial class StartingMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingMenu));
            this.StartButton = new System.Windows.Forms.Button();
            this.HowToPlayIt = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.LinkWiki = new System.Windows.Forms.LinkLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.InfoText;
            this.StartButton.Location = new System.Drawing.Point(337, 127);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(268, 36);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // HowToPlayIt
            // 
            this.HowToPlayIt.BackColor = System.Drawing.Color.DodgerBlue;
            this.HowToPlayIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HowToPlayIt.Location = new System.Drawing.Point(337, 222);
            this.HowToPlayIt.Margin = new System.Windows.Forms.Padding(4);
            this.HowToPlayIt.Name = "HowToPlayIt";
            this.HowToPlayIt.Size = new System.Drawing.Size(268, 36);
            this.HowToPlayIt.TabIndex = 1;
            this.HowToPlayIt.Text = "How to play the game ?";
            this.HowToPlayIt.UseVisualStyleBackColor = false;
            this.HowToPlayIt.Click += new System.EventHandler(this.HowToPlayIt_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.DodgerBlue;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.Location = new System.Drawing.Point(337, 319);
            this.Exit.Margin = new System.Windows.Forms.Padding(4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(268, 36);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // LinkWiki
            // 
            this.LinkWiki.AutoSize = true;
            this.LinkWiki.BackColor = System.Drawing.Color.DodgerBlue;
            this.LinkWiki.LinkColor = System.Drawing.Color.Black;
            this.LinkWiki.Location = new System.Drawing.Point(35, 469);
            this.LinkWiki.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LinkWiki.Name = "LinkWiki";
            this.LinkWiki.Size = new System.Drawing.Size(147, 17);
            this.LinkWiki.TabIndex = 4;
            this.LinkWiki.TabStop = true;
            this.LinkWiki.Text = "More about the game ";
            this.LinkWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkWiki_LinkClicked);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 100);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(277, 276);
            this.listBox1.TabIndex = 5;
            // 
            // StartingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(912, 512);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.LinkWiki);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.HowToPlayIt);
            this.Controls.Add(this.StartButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartingMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button HowToPlayIt;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.LinkLabel LinkWiki;
        private System.Windows.Forms.ListBox listBox1;
    }
}