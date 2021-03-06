﻿using System;
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
        public void WriteHighscore()
        {
            Highscore hs = new Highscore
            {
                dateCreated = DateTime.Now,
                level = Main.gameSession.gs.level,
                name = Main.gameSession.gs.userName,
                points = GetPoints(),
                timer = (Main.gameSession.gs.endTime - Main.gameSession.gs.startTime).ToString("mm':'ss")
            };

            Main.db.dbConnection.Insert(hs);

        }

        /// <summary>
        /// Returns a List with all Highscores
        /// </summary>
        /// <returns> List with Highscores</returns>
        public List<Highscore> ReadHighscores()
        {
            List<Highscore> hs = new List<Highscore>();
           
            var tempHighscore =  Main.db.dbConnection.Table<Highscore>();

            foreach(var score in tempHighscore)
            {
                hs.Add(score);
            }
            List<Highscore> SortedList = hs.OrderBy(o => o.timer).ToList();

            return SortedList ; 
        }


        /// <summary>
        /// Calculates Points from time and Wrong answers
        /// </summary>
        /// <returns>Number of Points</returns>
        public int GetPoints()
        {
            GameSession gs = Main.gameSession.gs;


            return gs.wrongAnswerCounter;

        }

    }


  
}
