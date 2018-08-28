using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGS_Tim.models;
using SQLite;
using AGS_Tim.helpers;

namespace AGS_Tim.services
{
   public class Subjects
    {
        List<int> subjectIds = new List<int>();

        /// <summary>
        /// Returns Random Subject
        /// </summary>
        /// <returns></returns>
        public Subject GetNewSubject()
        {
            Subject newSubject;
            Random rnd = new Random();
            int subjectCount = 0;
            var tempSubject = Main.db.dbConnection.Table<Subject>();

            if (subjectIds.Count <= 0)
            {
                subjectCount = tempSubject.Count();

                foreach (var subject in tempSubject)
                {
                    subjectIds.Add(subject.id);
                }

                subjectIds.Shuffle();
            }

            int temp = subjectIds[0];
            subjectIds.RemoveAt(0);
       
            return tempSubject.First(v => v.id.Equals(temp));
        }



    }
}
