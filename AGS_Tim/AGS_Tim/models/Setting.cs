using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite; 

namespace AGS_Tim.models
{
   public  class Setting
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int level { get; set; }
    }
}
