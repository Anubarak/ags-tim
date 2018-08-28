using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AGS_Tim.models
{
  public   class Question
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int questionTypeID { get; set; }
        public int level { get; set; }
        public string text { get; set; }
        public string correctAnswer { get; set; }
        public string[] possibleAnswer { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateUpdated { get; set; }

    }
}
