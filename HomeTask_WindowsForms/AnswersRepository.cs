using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_WindowsForms
{
    public class AnswersRepository
    {
        private static AnswersRepository _instance = null;
        public static List<Answer> AnswersList = new List<Answer>();
        public struct Answer
        {
            public DateTime AnswerTime;
            public bool AnswerValue;
            public Answer(bool value)
            {
                AnswerTime = DateTime.Today;
                AnswerValue = value;
            }
        }
        
        protected AnswersRepository()
        {
        }

        public static AnswersRepository GetInstance()
        {
            if(_instance == null) 
            {
                _instance = new AnswersRepository();
            }
            return _instance;
        }

        public static void AddAnswer(bool value)
        {
            AnswersList.Add(new Answer(value));
        }

        public static List<Answer> GetAnswers()
        {
            return AnswersList;
        }

         
        
    }
}
