using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using AGS_Tim.Properties;
using AGS_Tim.helpers;
using AGS_Tim.models;

namespace AGS_Tim.services
{
    class GameSessions
    {
        public GameSession gs; 

        /// <summary>
        /// Initiates a new GameSession
        /// </summary>
        public GameSessions()
        {
            gs = new GameSession();
            gs.players = new Player[6];

            Random rnd = new Random();
            List<int> usedPlayerIds = new List<int>();

            AddPlayerPictures();

            for (int i = 0; i < 6; i++)
            {
                gs.players[i] = new Player();
                gs.players[i].GetSubject();
                gs.players[i].level = Main.settings.level; 
                gs.players[i].GetQuestion();
                gs.players[i].PlayerPicture = gs.playerPictures[0];

                gs. playerPictures.RemoveAt(0);
            }

        }


        /// <summary>
        /// Adds the Player Avatars to the Playerpicture List in the gamesession
        /// </summary>
        void AddPlayerPictures()
        {
            gs.playerPictures = new List<Image>();
            gs.playerPictures.Add(Resources.a_Constanze);
            gs.playerPictures.Add(Resources.a_Fußballspieler);
            gs.playerPictures.Add(Resources.a_Goth);
            gs.playerPictures.Add(Resources.a_Hipster);
            gs.playerPictures.Add(Resources.a_Punk);
            gs.playerPictures.Add(Resources.a_Schwarzer);

            gs.playerPictures.Shuffle();
        }
    }

}
