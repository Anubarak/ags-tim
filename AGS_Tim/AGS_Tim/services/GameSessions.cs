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

   

        public GameSessions()

        {

            gs = new GameSession();
           gs.playerPictures = new List<Image>();
           gs.players = new Player[6];

            Random rnd = new Random();
            List<int> usedPlayerIds = new List<int>();

            AddPlayerPictures();

            for (int i = 0; i < 6; i++)
            {
                gs.players[i] = new Player();
               gs. players[i].GetSubject();
                gs.players[i].level = 1; // zum Testen hier muss das Level aus den Einstellungen übernommen werden
              gs.  players[i].GetQuestion();
               gs. players[i].PlayerPicture = gs.playerPictures[0];

               gs. playerPictures.RemoveAt(0);
            }

        }


        void AddPlayerPictures()
        {

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
