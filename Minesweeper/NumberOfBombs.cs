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
        public static int BombsPercent;

        public NumberOfBombs()
        {
            InitializeComponent();
        }

        // 10% percent bombs
        private void button1_Click(object sender, EventArgs e)
        {
            BombsPercent = 10;
            StartTheGame();
        }
        // 20% percent bombs
        private void button2_Click(object sender, EventArgs e)
        {
            BombsPercent = 20;
            StartTheGame();
        }
        // 30% percent bombs
        private void button3_Click(object sender, EventArgs e)
        {
            BombsPercent = 30;
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
