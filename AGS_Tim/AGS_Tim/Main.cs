using AGS_Tim.services;
using AGS_Tim.windows;
using AGS_Tim.models;
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
        public static Subjects subjects; 
        public static MainWindow mainWindow;
        public static GameSession gameSession;
        public static Hardware hardware;

       public  static void init()
        {
            db = new Database();
            highscores = new Highscores();
            questions = new Questions();
            subjects = new Subjects(); 
            mainWindow = new MainWindow();
            hardware = new Hardware(mainWindow);

            //Zum Testen
            gameSession = new GameSession();

        }
    }
}
