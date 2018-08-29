using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AGS_Tim.services
{
    public class InputConverter
    {
        private System.Windows.Threading.DispatcherTimer Timer;
        public Action<char> Callback;
        public int Current;
        private int LastCurrent = 0;
        private int Counter = 0;
        private char Character;
        private char[,] CharacterSet;

        public char[,] LettersNumbers = new char[9, 5]{
            {'0', '1', '*', ' ', ' '},
            {'2', 'A', 'B', 'C', ' '},
            {'3', 'D', 'E', 'F', ' '},
            {'4', 'G', 'H', 'I', ' '},
            {'5', 'J', 'K', 'L', ' '},
            {'6', 'M', 'N', 'O', ' '},
            {'7', 'P', 'Q', 'R', 'S'},
            {'8', 'T', 'U', 'V', ' '},
            {'9', 'W', 'X', 'Y', 'Z'}
            };

        public char[,] Letters = new char[9, 5]{
            {' ', ' ', ' ', ' ', ' '},
            {'A', 'B', 'C', ' ', ' '},
            {'D', 'E', 'F', 'G', ' '},
            {'G', 'H', 'I', ' ', ' '},
            {'J', 'K', 'L', ' ', ' '},
            {'M', 'N', 'O', ' ', ' '},
            {'P', 'Q', 'R', 'S', ' '},
            {'T', 'U', 'V', ' ', ' '},
            {'W', 'X', 'Y', 'Z', ' '}
            };

        public void StartTimer(bool WithNumbers = true)
        {

            if (WithNumbers)
            {
                CharacterSet = LettersNumbers;
            }
            else
            {
                CharacterSet = Letters;
            }
            

            if (Timer == null)
            {
                this.Timer = new System.Windows.Threading.DispatcherTimer();
                this.Timer.Tick += new EventHandler(this.TimerCallback);
            }
            this.Timer.Interval = new TimeSpan(0, 0, 1);

            this.Timer.IsEnabled = true;
            this.Timer.Start();

            if (this.LastCurrent == Current)
            {
                Counter++;

                if (this.Counter > this.CharacterSet.GetLength(1))
                {   
                    this.Counter = 1;
                }
                else if (this.CharacterSet[this.Current - 1, this.Counter - 1] == ' ')
                {
                    this.Counter = 1;
                }
            }
            else
            {
                if (this.Counter != 0)
                {
                    this.Counter = 1;
                    this.Callback(Character);
                }
                else
                {
                    this.LastCurrent = Current;
                    Counter++;
                }
            }
            

            this.Character = this.CharacterSet[this.Current - 1, this.Counter - 1];
            this.Timer.IsEnabled = true;
            this.Timer.Start();
            this.LastCurrent = Current;
        }
           
        public void TimerCallback(object sender, EventArgs e)
        {
            this.Counter = 0;
            this.Timer.Stop();
            this.Timer.IsEnabled = false;

            this.Callback(Character);
        }

    }
}
