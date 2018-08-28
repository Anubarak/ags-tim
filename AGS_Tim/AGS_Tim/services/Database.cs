
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using System.Diagnostics;
using AGS_Tim.models;

namespace AGS_Tim.services
{
    public class Database
    {
        private string databasePath; 
        public SQLiteConnection dbConnection;

        public Database()
        {
            databasePath = Path.Combine(Environment.CurrentDirectory, "TIM.db");
            db = new SQLiteConnection(databasePath);

        }


    }

}




