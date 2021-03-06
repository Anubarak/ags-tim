﻿using System;
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

        public Validate(Player player)
        {
            answer = player.Question.correctAnswer.ToLower();
            
        }

        /// <summary>
        /// Checks if Answer is answered, coreerct, wrong
        /// </summary>
        /// <param name="input">Complete Input String</param>
        /// <returns></returns>
        public ValidateAnswerResponse CheckAnswer(string input)
        {
            string tempAnswer = answer.Substring(0, input.Length).ToLower();
            string inputerLowerCase = input.ToLower();

            if (inputerLowerCase.Equals("") || input == null)
                return ValidateAnswerResponse.WrongAnswer;
            else if (answer.Equals(inputerLowerCase))
                return ValidateAnswerResponse.AnswerComplete;
            else if (tempAnswer.Equals(inputerLowerCase))
                return ValidateAnswerResponse.CorrectAnswer;
            else
                return ValidateAnswerResponse.WrongAnswer;
             

        }
        

    }
}