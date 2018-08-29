using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AGS_Tim.models;
using AGS_Tim.services;

namespace AGS_Tim.services
{
   public class Validate
    {
        private string answer = ""; 


        /// <summary>
        /// initialte new Validate Service
        /// </summary>
        /// <param name="player"> Player which is currently played agaunst</param>
        public Validate(Player player)
        {
            answer = player.Question.correctAnswer;
            
        }

        /// <summary>
        /// Compares a String with the Correct Answer
        /// </summary>
        /// <param name="input">String to check against the correct answer</param>
        /// <returns>Response if answer is wrong, correct, complete</returns>
        public ValidateAnswerResponse CheckAnswer(string input)
        {
            string tempAnswer = answer.Substring(0, input.Length);
            if (input.Equals("") || input == null)
                return ValidateAnswerResponse.WrongAnswer;
            else if (answer.Equals(input))
                return ValidateAnswerResponse.AnswerComplete;
            else if (tempAnswer.Equals(input))
                return ValidateAnswerResponse.CorrectAnswer;
            else
                return ValidateAnswerResponse.WrongAnswer;
             

        }
        

    }
}