using System;

namespace HomeTask_WindowsForms
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
        public int  AnswerValue { get; set; }
        
        public Answer(int wordId, Type answer)
        {
            this.AnswersDate = DateTime.Now;
            this.WordId = wordId;
            this.AnswerValue = (int) answer;
        }
        public Answer(int id, DateTime date, int wordId, int answerValue)
        {
            this.AnswerId = id;
            this.AnswersDate = date;
            this.WordId = wordId;
            this.AnswerValue = answerValue;
        }
    }
}
