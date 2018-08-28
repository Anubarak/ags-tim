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
        public Image PlayerPicture;
        public string Name; 



        public Question GetQuestion() {
           return  Main.questions.GetNewQuestion(Subject.id);
        }

    }
}
