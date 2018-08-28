﻿using AGS_Tim.services;
using AGS_Tim.windows;
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
        public static MainWindow mainWindow;

       public  static void init()
        {
            db = new Database();
            highscores = new Highscores();
            questions = new Questions();
            mainWindow = new MainWindow();
        }
    }
}
