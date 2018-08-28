
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using System.Diagnostics;

namespace AGS_Tim.services
{
    public class Database
    {
       public  Database()
        {
            var databasePath = Path.Combine(Environment.CurrentDirectory, "TIM.db");
            var db = new SQLiteConnection(databasePath);

            //Test

            //QuestionType Test2 = new QuestionType(){
            //    name = "Test2"
            //};
            
            //var s = db.Insert(Test2);

            //var TestName = db.Table<QuestionType>();

            //foreach (var name in TestName)
            //    Debug.WriteLine(name.name);

        }
    }




    public class QuestionType
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
    }
}

