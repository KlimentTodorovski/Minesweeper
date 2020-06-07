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
    public partial class Minesweeper : Form
    {
        Button[,] buttons = new Button[41, 41];
        int[,] ButtonProperties = new int[41, 41];

        bool FirstPlay = true;
        bool GameOver = false;

        int Start_x, Start_y;
        int Height = 5, Width = 5;

        int ButtonSize = 30;
        int DistanceBetween = 30;

        int Mines = 5;
        int flag_value = 9;
        int Flags = 10;

        Point ClickCordination;

        int[] PointsAroundX = { 1, 0, -1, 0, 1, -1, -1, 1 };
        int[] PointsAroundY = { 0, 1, 0, -1, 1, -1, 1, -1 };

        private void Start_Click(object sender, EventArgs e)
        {
            TableMargins();

            if (FirstPlay)
            {
                StartGame();
                FirstPlay = false;
            }
        }

        private void StartGame()
        {
            CreateButtons(Width, Height);
            GenerateMap(Width, Height, Mines);
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    label1.Text += ButtonProperties[i, j];
                }
                label1.Text += "\n";
            }
            SetMapNumbers(Width, Height);
        }

        private void SetMapNumbers(int width, int height)
        {
            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    if (ButtonProperties[i, j] != -1)
                    {
                        ButtonProperties[i, j] = MinesAround(i, j);
                        //Debugging
                        //btn[i, j].Text = btn_prop[i, j].ToString();
                        //saved_btn_prop[i, j] = MinesAround(i, j);
                    }
                }
            }
        }

        private int MinesAround(int x, int y)
        {
            int Score = 0;
            for (int i = 0; i < 8; i++)
            {
                int AroundPointX = x + PointsAroundX[i];
                int AroundPointY = y + PointsAroundY[i];

                if (isPointOnMap(AroundPointX, AroundPointY) == 1 && ButtonProperties[AroundPointX, AroundPointY] == -1)
                    Score++;
            }
            return Score;
        }

        private int isPointOnMap(int aroundPointX, int aroundPointY)
        {
            if (aroundPointX < 1 || aroundPointX > Width || aroundPointY < 1 || aroundPointY > Height)
                return 0;
            return 1;
        }

        void GenerateMap(int x, int y, int mines)
        {
            Random rand = new Random();
            List<int> coordx = new List<int>();
            List<int> coordy = new List<int>();

            while (mines > 0)
            {
                coordx.Clear();
                coordy.Clear();

                for (int i = 1; i <= x; i++)
                    for (int j = 1; j <= y; j++)
                        if (ButtonProperties[i, j] != -1)
                        {
                            coordx.Add(i);
                            coordy.Add(j);
                        }

                int randNum = rand.Next(0, coordx.Count);
                label2.Text = randNum.ToString();
                ButtonProperties[coordx[randNum], coordy[randNum]] = -1;
                MessageBox.Show(coordx[randNum].ToString() + coordy[randNum].ToString());
                buttons[coordx[randNum], coordy[randNum]].Text = "-1";
                //saved_btn_prop[coordx[randNum], coordy[randNum]] = -1;
                mines--;
            }
        }

        void CreateButtons(int x, int y)
        {
            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].SetBounds(i * ButtonSize + Start_x, j * ButtonSize + Start_y, DistanceBetween, DistanceBetween);
                    buttons[i, j].Click += new EventHandler(OneClick);
                    buttons[i, j].MouseUp += new MouseEventHandler(RightClick);
                    buttons[i, j].Text = "0";
                    ButtonProperties[i, j] = 0;
                    //saved_btn_prop[i, j] = 0;
                    buttons[i, j].TabStop = false;
                    Controls.Add(buttons[i, j]);
                }
        }

        private void RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                ClickCordination = ((Button)sender).Location;
                int x = (ClickCordination.X - Start_x) / ButtonSize;
                int y = (ClickCordination.Y - Start_y) / ButtonSize;

                if (ButtonProperties[x, y] != flag_value && Flags > 0)
                {
                    buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[x, y].Text = "Z";
                    ButtonProperties[x, y] = flag_value;
                    Flags--;
                    Check_FlagWin();
                }
                else
                if (ButtonProperties[x, y] == flag_value)
                {
                    //ButtonProperties[x, y] = saved_btn_prop[x, y];
                    buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[x, y].BackgroundImage = null;
                    Flags++;
                }

                //remainingFlags.Text = "Flags: " + flags;
            }
        }

        void Check_FlagWin()
        {
            bool win = true;

            for (int i = 1; i <= Width; i++)
                for (int j = 1; j <= Height; j++)
                    if (ButtonProperties[i, j] == -1)
                        win = false;

            if (win)
            {
                WinGame();
            }
        }

        private void OneClick(object sender, EventArgs e)
        {
            Point ClickCordination = ((Button)sender).Location;
            int x = (ClickCordination.X - Start_x) / ButtonSize;
            int y = (ClickCordination.Y - Start_y) / ButtonSize;

            if (ButtonProperties[x, y] != flag_value)
            {

                ((Button)sender).Enabled = false;
                //((Button)sender).Text = "";

                ((Button)sender).BackgroundImageLayout = ImageLayout.Stretch;

                if (ButtonProperties[x, y] != -1 && !GameOver)
                {
                    //gameProgress.Value++;
                    //score.Text = "Score: " + gameProgress.Value.ToString();
                    Check_ClickWin();
                }

                set_ButtonImage(x, y);
            }
        }

        void Check_ClickWin()
        {
            bool win = true;
            for (int i = 1; i <= Width; i++)
                for (int j = 1; j <= Height; j++)
                    if (buttons[i, j].Enabled == true && ButtonProperties[i, j] != -1)
                        win = false;
            //ButtonProperties ставено место saved

            if (win)
            {
                WinGame();
            }
        }

        void WinGame()
        {
            GameOver = true;
            Discover_Map();
            //gameProgress.Value = 0;
            MessageBox.Show("Win !");
        }

        void Discover_Map()
        {
            for (int i = 1; i <= Width; i++)
                for (int j = 1; j <= Height; j++)
                    if (buttons[i, j].Enabled == true)
                    {
                        set_ButtonImage(i, j);
                    }
        }

        void set_ButtonImage(int x, int y)
        {
            buttons[x, y].Enabled = false;
            buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;

            if (GameOver && ButtonProperties[x, y] == flag_value)
                //ButtonProperties[x, y] = saved_btn_prop[x, y];

            if (GameOver)
                //timer.Stop();

            switch (ButtonProperties[x, y])
            {
                case 0:
                    //buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.blank;
                    buttons[x, y].Text = "0";
                    EmptySpace(x, y);
                    break;

                case 1:
                    //buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources._1;
                    buttons[x, y].Text = "1";
                    break;

                case 2:
                     //   buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources._2;
                            buttons[x, y].Text = "2";

                            break;

                case 3:
                     //   buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources._3;
                            buttons[x, y].Text = "3";

                            break;

                case 4:
                       // buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources._4;
                            buttons[x, y].Text = "4";

                            break;

                case 5:
//                      buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources._5;
                            buttons[x, y].Text = "5";

                            break;

                case 6:
                       // buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources._6;
                            buttons[x, y].Text = "6";

                            break;

                case 7:
                      //  buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources._7;
                            buttons[x, y].Text = "7";

                            break;

                case 8:
                       // buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources._8;
                            buttons[x, y].Text = "8";

                            break;

                case -1:
                        //buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.bmb;
                            buttons[x, y].Text = "9";

                            if (!GameOver)
                        GameOver_();
                    break;
            }

        }

        void EmptySpace(int x, int y)
        {
            if (ButtonProperties[x, y] == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    int cx = x + PointsAroundX[i];
                    int cy = y + PointsAroundY[i];

                    if (isPointOnMap(cx, cy) == 1)
                        if (buttons[cx, cy].Enabled == true && ButtonProperties[cx, cy] != -1 && !GameOver)
                        {
                            //gameProgress.Value++;
                            //score.Text = "Score: " + gameProgress.Value.ToString();
                            set_ButtonImage(cx, cy);
                        }
                }
            }
        }

        void GameOver_()
        {
            GameOver = true;
            Discover_Map();
            MessageBox.Show("Game Over !");
        }

        private void TableMargins()
        {
            Start_x = (this.Size.Width - (Width + 2) * DistanceBetween) / 2;
            Start_y = (this.Size.Height - (Height + 2) * DistanceBetween) / 2;
        }

        public Minesweeper()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
