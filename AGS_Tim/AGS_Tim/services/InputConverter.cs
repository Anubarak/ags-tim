using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Tim.services
{
    public class InputConverter
    {
        private System.Windows.Threading.DispatcherTimer Timer;
        public Action<char> Callback;
        public int Current;

        public void StartTimer()
        {
            this.Timer = new System.Windows.Threading.DispatcherTimer();
            this.Timer.Tick += new EventHandler(this.TimerCallback);
            this.Timer.Interval = new TimeSpan(0, 0, 1);

            this.Timer.IsEnabled = true;
            this.Timer.Start();
        }

        public void TimerCallback(object sender, EventArgs e)
        {
            this.Timer.Stop();
            this.Timer.IsEnabled = false;

            this.Callback('a');
        }

    }
}
