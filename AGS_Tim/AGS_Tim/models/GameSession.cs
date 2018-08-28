using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Tim.models
{
   public class GameSession
    {
        public List<int> answeredQuestions;
        public List<int> playersCompleted;
        public DateTime startTime;
        public DateTime endTime;
        public int inputType;  

        public Player[] players = new Player[5];

        public GameSession()
        {
            for(int i = 0; i == 5; i++)
            {

            }

        }

    }
}
