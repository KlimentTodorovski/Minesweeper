using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    [Serializable]

    public partial class StartingMenu : Form
    {
        List<Players> players = new List<Players>();
        public StartingMenu()
        {
            InitializeComponent();
            players = GameMain.getPlayers();
            for (int i = 0; i < players.Count; i++)
            {
                listBox1.Items.Add(players.ElementAt(i).ToString());
            }
        }

        //Start button for the game on starting  page 
        private void StartButton_Click(object sender, EventArgs e)
        {
            Player player = new Player(); 
            this.Hide();
            player.ShowDialog();
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
