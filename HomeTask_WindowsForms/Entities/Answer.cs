using System;

namespace EnglishAssistant.Entities
{
    public class Answer
    {
        public enum Type
        {
            Wrong = 0,
            Right,
            Cancelled
        }

        public int AnswerId { get; private set; }
        public DateTime AnswersDate { get; private set; }
        public int WordId { get; set; }
        public Type AnswerValue { get; set; }
        
        public Answer(int wordId, Type answer)
        {
            AnswersDate = DateTime.Now;
            WordId = wordId;
            AnswerValue = answer;
        }

        public Answer(int id, DateTime date, int wordId, int answerValue)
        {
            AnswerId = id;
            AnswersDate = date;
            WordId = wordId;
            AnswerValue = (Type) answerValue;
        }
    }
}
