using System;
using System.Collections.Generic;

namespace HomeTask_WindowsForms
{
    public class Answers
    {
        private static Answers _instance = null;
        public static DateTime AnswersDate { get; set; }
        public static int RightAnswers { get; set; }
        public static int WrongAnswers { get; set; }
        
        protected Answers()
        {
        }

        public static Answers GetInstance()
        {
            if(_instance == null) 
            {
                _instance = new Answers();
                AnswersDate = DateTime.Today;
            }
            return _instance;
        }

        public static void AddAnswer(bool rightAnswer)
        {
            if (rightAnswer)
                RightAnswers++;
            else
                WrongAnswers++;
        }
    }
}
