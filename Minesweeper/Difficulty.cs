﻿using System;
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
    public partial class Difficulty : Form
    {
        int MapWidth;
        int MapHeight;

        public Difficulty()
        {
            InitializeComponent();
        }

        // Creates map of 8x8
        private void Easy_Click(object sender, EventArgs e)
        {
            MapHeight = 8;
            MapWidth = 8;
            GoToNextForm();
        }

        // Creates map 10x10
        private void Intermediate_Click(object sender, EventArgs e)
        {
            MapHeight = 10;
            MapWidth = 10;
            GoToNextForm();
        }

        //Creates map 13x13
        private void Hard_Click(object sender, EventArgs e)
        {
            MapHeight = 13;
            MapWidth = 13;
            GoToNextForm();
        }

        //Going to next form
        private void GoToNextForm()
        {
            NumberOfBombs nb = new NumberOfBombs();
            this.Hide();
            nb.ShowDialog();
        }

        private int getWidth()
        {
            return MapWidth;
        }

        private int getHeight()
        {
            return MapHeight;
        }

    }
}
