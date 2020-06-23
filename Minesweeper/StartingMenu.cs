using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class StartingMenu : Form
    {
        public static string[] bestFive { get; set; }
        public static int LastPlayerTimeInSeconds { get; set; }

        public StartingMenu()
        {
            InitializeComponent();
            BestFive();
        }

        public static void WriteInFile()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "best_5.txt");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                if (!File.Exists(fileName))
                    File.Create(fileName);

                foreach (var Player in bestFive)
                {
                    file.WriteLine(Player);
                }
            }
        }

        private void BestFive()
        {
            bestFive = Minesweeper.Properties.Resources.best_5.Split('\n');
            for (int i = 0; i < 5; i++)
            {
                listBox1.Items.Add(bestFive[i]);
            }
            GetLastPlayerTime();
        }

        private void GetLastPlayerTime()
        {
            string [] LastPlayer = bestFive[4].Split(' ');
            string [] Time = LastPlayer[1].Split(':');
            LastPlayerTimeInSeconds = Int32.Parse(Time[0]) * 60 + Int32.Parse(Time[1]);
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
