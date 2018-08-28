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
    class Questions
    {

        List<int> questionIds = new List<int>();

        /// <summary>
        /// Returns a random question according to subject
        /// </summary>
        /// <param name="Subject"> Subject ID</param>
        /// <returns>Random Question</returns>
        public Question GetNewQuestion(int Subject)
        {
            Question newQuestion;
            Random rnd = new Random();
            int randomQuestionId;
            int questionCounter = 0;

            //table with all Questions of the subject
            var tempQuestions =  Main.db.dbConnection.Table<Question>().Where(v => v.subjectId.Equals(Subject));

         if (questionIds.Count <= 0)
            {
                foreach (var question in tempQuestions)
                {
                    questionIds.Add(question.id);
                }
                questionIds.Shuffle();
            }

         
            if(questionIds.Count <= 0 )
            {
                return null; 
            }

            int temp = questionIds[0];
            questionIds.RemoveAt(0);

            return tempQuestions.First( v => v.id.Equals(temp));   
        }
    }
    
}
