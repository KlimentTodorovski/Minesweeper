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
    public partial class Player: Form
    {
        public static string Name { get; set; }

        public Player()
        {
            InitializeComponent();
        }

        private void StartTheGame()
        {
            Difficulty DifficultyFrom = new Difficulty();
            this.Hide();
            DifficultyFrom.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            StartTheGame();
        }
    }
}
