using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    [Serializable]

    public partial class GameMain : Form
    {
        // Matrix of buttons for the gameplay 
        Button[,] buttons = new Button[41, 41];
        // Matrix of int using them as help for the calculations 
        int[,] ButtonProperties = new int[41, 41];
        // Matrix for saved values when we need back the orginal value
        int[,] SavedButtonProperties = new int[41, 41];

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


        // Number of mines 
        //int Mines = ((Difficulty.MapHeight * Difficulty.MapWidth) / 100) * NumberOfBombs.BombsPercent;
        int Mines = NumberOfBombs.Bombs;
        // Development value for flag 
        int flag_value = 9;
        // Number of flags 
        // number of flags must be always mines=flags
        int Flags = NumberOfBombs.Bombs;

        // ClickCordinatiton for x and y values of our mouse when we click smth 
        Point ClickCordination;

        //Time
        int Seconds = 0;
        int Minutes = 0;


        // Simple helpful array for checking all the neighbours of button
        //using x
        int[] PointsAroundX = { 1, 0, -1, 0, 1, -1, -1, 1 };
        // usiing y
        int[] PointsAroundY = { 0, 1, 0, -1, 1, -1, 1, -1 };

        string FileName = null;

        public static List<Players> gamePlayers = new List<Players>();

        //After we gather all the needed information about the start of the game 
        //we neeed to generate the map which is a matrix of buttons 
        // and set the bombs and number of it in the background
        // in another matrix which we use as help to create game 

        //Sarting all needed method and functions for the fame on the load of the form
        public GameMain()
        {
            InitializeComponent();
        }

        private void GameMain_Load(object sender, EventArgs e)
        {
            //When page loads start the process for creating the grid for gameplay 
            Play();
        }

        public static List<Players> getPlayers()
        {
            return gamePlayers;
        }

        private void Play()
        {
            //Defines table margins 
            TableMargins();
            //Starting the drawing of the map 
            StartGame();
        }

        private void TableMargins()
        {
            Start_x = (this.Size.Width - (Width + 2) * DistanceBetween) / 2;
            Start_y = (this.Size.Height - (Height + 2) * DistanceBetween) / 2;
        }

        private void StartGame()
        {
            timer1.Start();

            // Creating the map od buttons
            CreateButtons(Height, Width);
            // Generating the bombs on map 
            GenerateMap(Height, Width, Mines);
            // Using background map as development help 
            SetMapNumbers(Height, Width);

            numFlags.Text = "Number of flags: " + Flags.ToString();
            smileMan.BackgroundImageLayout = ImageLayout.Stretch;
            smileMan.BackgroundImage = Minesweeper.Properties.Resources.normalSmile;

        }

        // Creating the buttons for game 
        void CreateButtons(int x, int y)
        {
            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= y; j++)
                {
                    // Setting the buttons and its locations on map 
                    buttons[i, j] = new Button();
                    buttons[i, j].SetBounds(j * ButtonSize + Start_x, i * ButtonSize + Start_y, DistanceBetween, DistanceBetween);
                    buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[i, j].BackgroundImage = Minesweeper.Properties.Resources.blank;

                    // adding the event for discovering buttons and putting flags on them
                    buttons[i, j].Click += new EventHandler(OneClick);
                    buttons[i, j].MouseUp += new MouseEventHandler(RightClick);

                    // We need the calculation for saved matrix 
                    // for now we put all values equal to 0
                    SavedButtonProperties[i, j] = 0;
                    buttons[i, j].TabStop = false;
                    Controls.Add(buttons[i, j]);
                }
            }
        }

        // Generates the map and its bombs 
        // on random locations 
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
                    mines--;
                }
            }
        }

        // Calculates the numbers on the map showing how many mines are there
        private void SetMapNumbers(int x, int y)
        {
            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= y; j++)
                {
                    if (ButtonProperties[i, j] != -1)
                    {
                        ButtonProperties[i, j] = MinesAround(i, j);
                        SavedButtonProperties[i, j] = MinesAround(i, j);
                    }
                    else
                    {
                        SavedButtonProperties[i, j] = -1;
                    }
                    //buttons[i, j].Text = ButtonProperties[i, j].ToString();
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

                if (!(AroundPointX < 1 || AroundPointX > Height ||
                      AroundPointY < 1 || AroundPointY > Width))
                {
                    if (ButtonProperties[AroundPointX, AroundPointY] == -1)
                    {
                        Score++;
                    }
                }
            }
            return Score;
        }

        // Actions for left click on button 
        private void OneClick(object sender, EventArgs e)
        {
            smileMan.BackgroundImageLayout = ImageLayout.Stretch;
            smileMan.BackgroundImage = Minesweeper.Properties.Resources.shockedSmile;
            var t = Task.Delay(100);
            t.Wait();
            Point ClickCordination = ((Button)sender).Location;
            int Height = (ClickCordination.Y - Start_y) / ButtonSize;
            int Width = (ClickCordination.X - Start_x) / ButtonSize;
            if (FirstPlay && ButtonProperties[Height, Width] == -1)
            {
                GenerateMap(Difficulty.MapHeight, Difficulty.MapWidth, 1);
                ButtonProperties[Height, Width] = 0;
                SavedButtonProperties[Height, Width] = 0;
                SetMapNumbers(Difficulty.MapHeight, Difficulty.MapWidth);
            }
            FirstPlay = false;
            if (ButtonProperties[Height, Width] != flag_value)
            {
                ((Button)sender).Enabled = false;

                ((Button)sender).BackgroundImageLayout = ImageLayout.Stretch;

                if (ButtonProperties[Height, Width] != -1 && !GameOver)
                {
                    CheckWin();
                }

                set_ButtonImage(Height, Width);
            }
            else
            {
                buttons[Height, Width].Enabled = true;
            }
        }

        //Defines action on right click on button
        private void RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                ClickCordination = ((Button)sender).Location;
                int Height = (ClickCordination.Y - Start_y) / ButtonSize;
                int Width = (ClickCordination.X - Start_x) / ButtonSize;

                if (ButtonProperties[Height, Width] != flag_value && Flags > 0)
                {
                    buttons[Height, Width].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[Height, Width].BackgroundImage = Minesweeper.Properties.Resources.flagImage;
                    ButtonProperties[Height, Width] = flag_value;
                    numFlags.Text = SavedButtonProperties[Height, Width].ToString();
                    Flags--;
                    CheckWin();
                }
                else if (ButtonProperties[Height, Width] == flag_value)
                {
                    buttons[Height, Width].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[Height, Width].BackgroundImage = Minesweeper.Properties.Resources.blank;
                    ButtonProperties[Height, Width] = SavedButtonProperties[Height, Width];
                    Flags++;
                }
                numFlags.Text = "Number of flags: " + Flags.ToString();
            }
            
        }

        void set_ButtonImage(int x, int y)
        {
            buttons[x, y].Enabled = false;
            buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;

            if (GameOver)
            {
                timer1.Stop();
            }

            if (ButtonProperties[x, y] == 0)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.tileImage;
                EmptySpace(x, y);
            }
            else if (ButtonProperties[x, y] == 1)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.number1;
            }
            else if (ButtonProperties[x, y] == 2)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.number2;
            }
            else if (ButtonProperties[x, y] == 3)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.number3;
            }
            else if (ButtonProperties[x, y] == 4)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.number4;
            }
            else if (ButtonProperties[x, y] == 5)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.number5;
            }
            else if (ButtonProperties[x, y] == 6)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.number6;
            }
            else if (ButtonProperties[x, y] == 7)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.number7;
            }
            else if (ButtonProperties[x, y] == 8)
            {
                buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.number8;
            }
            else if (ButtonProperties[x, y] == -1)
            {
                if (!GameOver)
                    GameOver_(x, y);
            }
            smileMan.BackgroundImageLayout = ImageLayout.Stretch;
            smileMan.BackgroundImage = Minesweeper.Properties.Resources.normalSmile;
        }

        void EmptySpace(int x, int y)
        {
            if (ButtonProperties[x, y] == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    int cx = x + PointsAroundX[i];
                    int cy = y + PointsAroundY[i];

                    if (!(cx < 1 || cx > Height || cy < 1 || cy > Width))
                    {
                        if (buttons[cx, cy].Enabled == true && ButtonProperties[cx, cy] != -1 && !GameOver)
                        {
                            //gameProgress.Value++;
                            //score.Text = "Score: " + gameProgress.Value.ToString();
                            set_ButtonImage(cx, cy);
                        }
                    }
                }
            }
        }

        // Conditions for game to be won
        void CheckWin()
        {
            int bombsPlusFlags = 0;
            int enabledButtons = 0;

            for (int i = 1; i <= Height; i++)
            {
                for (int j = 1; j <= Width; j++)
                {
                    if (buttons[i, j].Enabled == true)
                    {
                        enabledButtons++;
                    }
                    if (ButtonProperties[i, j] == -1 || ButtonProperties[i, j] == 9)
                    {
                        bombsPlusFlags++;
                    }
                }
            }

            if (bombsPlusFlags == enabledButtons)
            {
                WinGame();
            }
        }


        // After game is won
        void WinGame()
        {
            GameOver = true;
            Discover_Map_Win();
            smileMan.BackgroundImageLayout = ImageLayout.Stretch;
            smileMan.BackgroundImage = Minesweeper.Properties.Resources.gameWon;
            //gameProgress.Value = 0;
            CheckPlayerInBestFive();
            MessageBox.Show("Win !!!");
            StartingMenu sm = new StartingMenu();
            this.Hide();
            sm.ShowDialog();
        }

        private void CheckPlayerInBestFive()
        {
            int PlayerTimeInSeconds = Minutes * 60 + Seconds;
            string time = Minutes + ":" + Seconds;
            Players player = new Players(Player.NameOfPlayer, time, Difficulty.MapHeight + "x" + Difficulty.MapWidth, NumberOfBombs.Bombs);
            gamePlayers.Insert(0, player);
            gamePlayers.Sort((a, b) => {
                return a.GetTimeInSeconds().CompareTo(b.GetTimeInSeconds());
            });
            if(gamePlayers.Count == 6)
            {
                gamePlayers.RemoveAt(gamePlayers.Count - 1);
            }
        }

        public int LastPlayerTimeInSeconds()
        {
            if(gamePlayers.Count == 0)
            {
                return Int32.MaxValue;
            }
            return gamePlayers.ElementAt(gamePlayers.Count - 1).GetTimeInSeconds();
        }

        // After game over
        void GameOver_(int x, int y)
        {
            GameOver = true;
            Discover_Map_Lose();
            buttons[x, y].BackgroundImageLayout = ImageLayout.Stretch;
            buttons[x, y].BackgroundImage = Minesweeper.Properties.Resources.bombExplode;
            smileMan.BackgroundImageLayout = ImageLayout.Stretch;
            smileMan.BackgroundImage = Minesweeper.Properties.Resources.lostGameSmile;
            MessageBox.Show("Game Over !!!");
            StartingMenu sm = new StartingMenu();
            this.Hide();
            sm.ShowDialog();
        }

        void Discover_Map_Win()
        {
            for (int i = 1; i <= Height; i++)
                for (int j = 1; j <= Width; j++)
                {
                    if (ButtonProperties[i, j] == 9 || ButtonProperties[i, j] == -1)
                    {
                        buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        buttons[i, j].BackgroundImage = Minesweeper.Properties.Resources.brokenBombWin;
                    }
                    else
                    {
                        set_ButtonImage(i, j);
                    }
                }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Seconds++;

            if(Seconds == 60)
            {
                Minutes++;
                Seconds = 0;
            }

            if(Seconds < 10)
            {
                time.Text = Minutes + ":0" + Seconds;
            }
            else
            {
                time.Text = Minutes + ":" + Seconds;
            }
        }

        void Discover_Map_Lose()
        {
            for (int i = 1; i <= Height; i++)
                for (int j = 1; j <= Width; j++)
                {
                    if (ButtonProperties[i, j] == 9 || ButtonProperties[i, j] == -1)
                    {
                        buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        buttons[i, j].BackgroundImage = Minesweeper.Properties.Resources.brokenBomb;
                    }
                    else
                    {
                        set_ButtonImage(i, j);
                    }

                }
        }
    }
}
