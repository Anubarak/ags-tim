using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AGS_Tim.Properties;
using AGS_Tim.helpers;



namespace AGS_Tim.models
{
   public class GameSession
    {

        public List<int> playersCompleted;
        public DateTime startTime;
        public DateTime endTime;
        public int inputType;
        List<Image> playerPictures = new List<Image>();


        public Player[] players = new Player[6];

        public GameSession()
        {
            Random rnd = new Random();
            List<int> usedPlayerIds = new List<int>();

            AddPlayerPictures();

            for (int i = 0; i < 6; i++)
            {
                players[i] = new Player();
                players[i].GetSubject();
                players[i].GetQuestion();
                players[i].PlayerPicture = playerPictures[0];

                playerPictures.RemoveAt(0);
            }

          




        }


        void AddPlayerPictures()
        {

            playerPictures.Add(Resources.a_Constanze);
            playerPictures.Add(Resources.a_Fußballspieler);
            playerPictures.Add(Resources.a_Goth);
            playerPictures.Add(Resources.a_Hipster);
            playerPictures.Add(Resources.a_Lehrer);
            playerPictures.Add(Resources.a_Punk);
            playerPictures.Add(Resources.a_Schwarzer);

            playerPictures.Shuffle();
        }
    }
}
