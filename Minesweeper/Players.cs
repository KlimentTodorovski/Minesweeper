using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Players
    {
        public string Name { get; set; }
        public string Time { get; set; }
        public string Difficulty { get; set; }
        public int Bombs  { get; set; }
        public Players(string Name, string Time, string Difficulty, int Bombs)
        {
            this.Name = Name;
            this.Time = Time;
            this.Difficulty = Difficulty;
            this.Bombs = Bombs;
        }
        public int GetTimeInSeconds()
        {
            string[] time = Time.Split(':');
            return Int32.Parse(time[0]) * 60 + Int32.Parse(time[1]);
        }
        public string ToString()
        {
            return Name + " " + Time + " " + Difficulty + " " + Bombs.ToString();
        }
    }
}