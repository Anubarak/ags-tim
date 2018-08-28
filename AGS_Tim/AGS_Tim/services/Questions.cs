using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGS_Tim.models;
using SQLite; 


namespace AGS_Tim.services
{
    class Questions
    {
        /// <summary>
        /// Returns a random question according to subject, if all questions have been asked it returns the First Question in the database
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

            //search for Question that hasn't been asked yet
            do
            {
                randomQuestionId = rnd.Next(1, tempQuestions.Count());
                questionCounter++;  
            } while (Main.gameSession.answeredQuestions.Contains(randomQuestionId) && questionCounter < tempQuestions.Count());


            // returns the Question
            foreach (var question in tempQuestions)
            {
               if((question.id == randomQuestionId)) {
                   return  newQuestion = question; 
                }
            }
            
            return tempQuestions.First( v => v.id.Equals(1));   
        }
    }
    
}
