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
    [Serializable]

    public partial class Player : Form
    {
        public static string NameOfPlayer { get; set; }

        public Player()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NameOfPlayer = textBox1.Text;
            Difficulty diff = new Difficulty();
            this.Hide();
            diff.ShowDialog();
        }
    }
}
