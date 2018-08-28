
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
        public Database()
        {
            var databasePath = Path.Combine(Environment.CurrentDirectory, "TIM.db");
            var db = new SQLiteConnection(databasePath);

            //Test

          //  Highscore Test2 = new Highscore()
          //  {
          //      name = "Higscore1",
          //      dateCreated = DateTime.Now,
          //      points = 100,
          //      timer = 100,
          //      level = 1

          //  };

          ////  var s = db.Insert(Test2);

          //  var TestName = db.Table<Highscore>();

          //  foreach (var name in TestName) {
          //      Debug.WriteLine(name.name + "     " + name.dateCreated);
                
}
        }
    }

}




