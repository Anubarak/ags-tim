
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;



namespace AGS_Tim.services
{
    public class Database
    {
       public  Database()
        {
            var databasePath = Path.Combine(Environment.CurrentDirectory, "TIM.db");
            var db = new SQLiteConnection(databasePath);

            var s = db.Insert(new QuestionType()
            {
                name = "Test"
            });

        }
    }



    public class QuestionType
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
    }
}

