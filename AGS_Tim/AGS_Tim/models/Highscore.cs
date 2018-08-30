using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AGS_Tim.models
{
    public class Highscore
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dateCreated { get; set; }
        public int points { get; set; }
        public String timer { get; set; }
        public int level { get; set; }
        public int position { get; set; }
}
}
