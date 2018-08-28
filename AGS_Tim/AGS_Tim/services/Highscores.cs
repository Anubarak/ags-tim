using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGS_Tim.models;


namespace AGS_Tim.services
{
    class Highscores
    {
        public bool WriteHighscore()
        {
            Highscore hs = new Highscore();

            hs.dateCreated = DateTime.Now;
            hs.level = Main.gameSession.level;
            hs.name = Main.gameSession.userName;
            hs.points = Main.gameSession.points;
            hs.timer = Main.gameSession.endTime - Main.gameSession.startTime; 
           
            return true;
        }
    }
}
