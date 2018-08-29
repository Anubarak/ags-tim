using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AGS_Tim;


namespace AGS_Tim.models
{
   public  class Player
    {
        public Question Question;
        public Subject Subject;
        public string PlayerPicture;
        public int level; 
        public string Name;
        public int ID;


        /// <summary>
        /// Sets a new random Question according to the set subject
        /// </summary>
       public void GetQuestion() {
          Question =  Main.questions.GetNewQuestion(Subject.id, level);
            if (Question == null)
            {
                GetSubject();
                Main.questions.GetNewQuestion(Subject.id, level );
            }
        }

        /// <summary>
        /// Sets new random question according to subject
        /// </summary>
        public void GetSubject()
        {
            Subject = Main.subjects.GetNewSubject(); 
        }


       
    }
}
