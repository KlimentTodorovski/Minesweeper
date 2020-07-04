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

    public partial class HowToPlayTheGame : Form
    {
        public HowToPlayTheGame()
        {
            InitializeComponent();
        }

        //This will get you back to the starting page
        private void button1_Click(object sender, EventArgs e)
        {
            StartingMenu sm = new StartingMenu();
            this.Hide();
            sm.ShowDialog();
        }
    }
}
