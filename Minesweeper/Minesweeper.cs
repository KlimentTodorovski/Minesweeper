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
    
    public partial class GameMain : Form
    {
        // Matrix of buttons for the gameplay ????????????
        Button[,] buttons = new Button[41, 41];
        // Matrix of int using them as help for the calculations ????????
        int[,] ButtonProperties = new int[41, 41];

        // FirstClick can't be on bomb 
        bool FirstPlay = true;
        // GameOver bool for finishing the game with fail 
        bool GameOver = false;

        // Start coordinants for buttons marked as x,y
        int Start_x, Start_y;
        // Width an Height of the map ??????????????
        int Height = Difficulty.MapHeight;
        int Width = Difficulty.MapWidth;

        // The size of the button
        int ButtonSize = 30;
        // Distance between every button in all directions 
        int DistanceBetween = 30;


        // Number of mines ?????????
        //int Mines = ((Difficulty.MapHeight * Difficulty.MapWidth) / 100) * NumberOfBombs.BombsPercent;
        int Mines = 5;
        // Development value for flag 
        int flag_value = 9;
        // Number of flags 
        // number of flags must be always mines=flags
        int Flags = 3;

        // ClickCordinatiton for x and y values of our mouse when we click smth 
        Point ClickCordination;


        // Simple helpful array for checking all the neighbours of button
        //using x
        int[] PointsAroundX = { 1, 0, -1, 0, 1, -1, -1, 1 };
        // usiing y
        int[] PointsAroundY = { 0, 1, 0, -1, 1, -1, 1, -1 };


        //After we gather all the needed information about the start of the game 
        //we neeed to generate the map which is a matrix of buttons 
        // and set the bombs and number of it in the background
        // in another matrix which we use as help to create game 

        //Sarting all needed method and functions for the fame on the load of the form
        private void GameMain_Load(object sender, EventArgs e)
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
            // Creating the map od buttons 
            CreateButtons(Height, Width);
            // Generating the bombs on map 
            GenerateMap(Height, Width, Mines);
            // Using background map as development help 
            SetMapNumbers(Height, Width);
        }

        void CreateButtons(int x, int y)
        {
            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].SetBounds(j * ButtonSize + Start_x, i * ButtonSize + Start_y, DistanceBetween, DistanceBetween);
                    // adding the event for discovering buttons and putting flags on them
                    buttons[i, j].Click += new EventHandler(OneClick);
                    buttons[i, j].MouseUp += new MouseEventHandler(RightClick);
                    //Debug help
                    buttons[i, j].Text = "0";
                    ButtonProperties[i, j] = 0;
                    //saved_btn_prop[i, j] = 0;
                    buttons[i, j].TabStop = false;
                    Controls.Add(buttons[i, j]);
                }
        }

        // Generates the map and its bombs 
        void GenerateMap(int x, int y, int mines)
        {
            Random random = new Random();
            while (mines > 0)
            {
                int randomIntegerX = (int)(random.NextDouble() * x) + 1;
                int randomIntegerY = (int)(random.NextDouble() * y) + 1;
                if (ButtonProperties[randomIntegerX, randomIntegerY] == -1)
                    continue;
                else
                {
                    ButtonProperties[randomIntegerX, randomIntegerY] = -1;
                    buttons[randomIntegerX, randomIntegerY].Text = "0";
                    mines--;
                }
                buttons[randomIntegerX, randomIntegerY].Text = "-1";
            }
        }

        // Calculates the numbers on the map showing how many mines are there
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

        // Counts the mines around the button and writes them in array 
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


        //Check if the point is on the map
        private int isPointOnMap(int aroundPointX, int aroundPointY)
        {
            if (aroundPointX < 1 || aroundPointX > Height || aroundPointY < 1 || aroundPointY > Width)
                return 0;
            return 1;
        }

        
        //Defines action on right click on button
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


        // Winning conditions 
        void Check_FlagWin()
        {
            bool win = true;

            for (int i = 1; i <= Height; i++)
                for (int j = 1; j <= Width; j++)
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
            int Height = (ClickCordination.Y - Start_y) / ButtonSize;
            int Width = (ClickCordination.X - Start_x) / ButtonSize;
            if (ButtonProperties[Width, Height] != flag_value)
            {

                ((Button)sender).Enabled = false;
                //((Button)sender).Text = "";

                ((Button)sender).BackgroundImageLayout = ImageLayout.Stretch;

                if (ButtonProperties[Height, Width] != -1 && !GameOver)
                {
                    //gameProgress.Value++;
                    //score.Text = "Score: " + gameProgress.Value.ToString();
                    Check_ClickWin();
                }

                set_ButtonImage(Height, Width);
            }
        }

        void Check_ClickWin()
        {
            bool win = true;
            for (int i = 1; i <= Height; i++)
                for (int j = 1; j <= Width; j++)
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
            for (int i = 1; i <= Height; i++)
                for (int j = 1; j <= Width; j++)
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

        // Menu option for exiting the game 
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        public GameMain()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
