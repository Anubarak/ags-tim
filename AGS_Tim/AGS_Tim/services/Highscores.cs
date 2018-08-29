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
        /// <summary>
        /// Writes Highscore to Database
        /// </summary>
        /// <returns></returns>
        public bool WriteHighscore()
        {
            Highscore hs = new Highscore();
            hs.dateCreated = DateTime.Now;
            hs.level = Main.gameSession.gs.level;
            hs.name = Main.gameSession.gs.userName;
            hs.points = Main.gameSession.gs.points;
            hs.timer = Main.gameSession.gs.endTime - Main.gameSession.gs.startTime; 
           
            return true;
        }
    }
}
