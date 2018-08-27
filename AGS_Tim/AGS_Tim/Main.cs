using AGS_Tim.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Tim
{
    static class Main
    {

        public static Database db;
        public static Highscores highscores;
        public static Questions questions;

        static void init()
        {
            db = new Database();
            highscores = new Highscores();
            questions = new Questions();
        }
    }
}
