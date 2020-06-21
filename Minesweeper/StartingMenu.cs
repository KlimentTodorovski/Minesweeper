using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class StartingMenu : Form
    {
        public StartingMenu()
        {
            InitializeComponent();
        }

        //Start button for the game on starting  page 
        private void StartButton_Click(object sender, EventArgs e)
        {
            Difficulty DifficultyFrom = new Difficulty();
            this.Hide();
            DifficultyFrom.ShowDialog();
        }

        // Description how to play the game 
        // going to new form which has back option for going to the starting menu
        private void HowToPlayIt_Click(object sender, EventArgs e)
        {
            HowToPlayTheGame how = new HowToPlayTheGame();
            this.Hide();
            how.ShowDialog();
        }

        //Hyperlink from wikipedia site about the game 
        private void LinkWiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            LinkWiki.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Minesweeper_(video_game)");
        }

        //Exit button on the starting page on the game 
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
