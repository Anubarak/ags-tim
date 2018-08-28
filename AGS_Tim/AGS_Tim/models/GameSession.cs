using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Tim.models
{
   public class GameSession
    {

        public List<int> playersCompleted;
        public DateTime startTime;
        public DateTime endTime;
        public int inputType;  

        public Player[] players = new Player[6];

        public GameSession()
        {
            Random rnd = new Random();
            List<int> usedPlayerIds = new List<int>();


       
            for (int i = 0; i  <6; i++)
            {
                int tempPlayerId;

                players[i] = new Player(); 
                players[i].GetSubject();
                players[i].GetQuestion();  


            }

        }

    }
}
