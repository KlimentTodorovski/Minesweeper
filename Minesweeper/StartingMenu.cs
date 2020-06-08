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

        //Exit button on the starting page on the game 
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Start button for the game on starting page 
        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        // Description how to play the game 
        // going to new form which has back option for going to the starting menu
        private void HowToPlayIt_Click(object sender, EventArgs e)
        {

        }

        private void MoreAboutTheGame_Click(object sender, EventArgs e)
        {

        }
    }
}
