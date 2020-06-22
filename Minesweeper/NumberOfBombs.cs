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
    public partial class NumberOfBombs : Form
    {
        public static int Bombs;

        public NumberOfBombs()
        {
            InitializeComponent();
        }

        // 10% percent bombs
        private void button1_Click(object sender, EventArgs e)
        {
            if (Difficulty.MapWidth == 8)
            {
                Bombs = 7;
            }
            else if (Difficulty.MapWidth == 10)
            {
                Bombs = 10;
            }
            else
            {
                Bombs = 17;
            }
            StartTheGame();
        }
        // 20% percent bombs
        private void button2_Click(object sender, EventArgs e)
        {
            if (Difficulty.MapWidth == 8)
            {
                Bombs = 14;
            }
            else if (Difficulty.MapWidth == 10)
            {
                Bombs = 20;
            }
            else
            {
                Bombs = 34;
            }
            StartTheGame();
        }
        // 30% percent bombs
        private void button3_Click(object sender, EventArgs e)
        {
            if (Difficulty.MapWidth == 8)
            {
                Bombs = 21;
            }
            else if (Difficulty.MapWidth == 10)
            {
                Bombs = 30;
            }
            else
            {
                Bombs = 51;
            }
            StartTheGame();
        }

        private void StartTheGame()
        {
            GameMain gm = new GameMain();
            this.Hide();
            gm.ShowDialog();
        }

    }
}

