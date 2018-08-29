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

        public List<Image> playerPictures;

        public List<int> playersCompleted;
        public DateTime startTime;
        public DateTime endTime;
        public int inputType;
        public string userName;
        public int points;
        public int level;

        public Player[] players;

    }
}
