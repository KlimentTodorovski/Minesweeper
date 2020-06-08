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
            this.MoreAboutTheGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.InfoText;
            this.StartButton.Location = new System.Drawing.Point(206, 93);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(201, 29);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // HowToPlayIt
            // 
            this.HowToPlayIt.BackColor = System.Drawing.Color.DodgerBlue;
            this.HowToPlayIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HowToPlayIt.Location = new System.Drawing.Point(206, 154);
            this.HowToPlayIt.Name = "HowToPlayIt";
            this.HowToPlayIt.Size = new System.Drawing.Size(201, 29);
            this.HowToPlayIt.TabIndex = 1;
            this.HowToPlayIt.Text = "How to play the game ?";
            this.HowToPlayIt.UseVisualStyleBackColor = false;
            this.HowToPlayIt.Click += new System.EventHandler(this.HowToPlayIt_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.DodgerBlue;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.Location = new System.Drawing.Point(206, 211);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(201, 29);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MoreAboutTheGame
            // 
            this.MoreAboutTheGame.BackColor = System.Drawing.Color.DodgerBlue;
            this.MoreAboutTheGame.Location = new System.Drawing.Point(32, 295);
            this.MoreAboutTheGame.Name = "MoreAboutTheGame";
            this.MoreAboutTheGame.Size = new System.Drawing.Size(143, 23);
            this.MoreAboutTheGame.TabIndex = 3;
            this.MoreAboutTheGame.Text = "More About The Game";
            this.MoreAboutTheGame.UseVisualStyleBackColor = false;
            this.MoreAboutTheGame.Click += new System.EventHandler(this.MoreAboutTheGame_Click);
            // 
            // StartingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minesweeper.Properties.Resources.ms;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.MoreAboutTheGame);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.HowToPlayIt);
            this.Controls.Add(this.StartButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartingMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button HowToPlayIt;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button MoreAboutTheGame;
    }
}