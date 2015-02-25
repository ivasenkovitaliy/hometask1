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
        public string AnswerWordName { get; set; }
        public int  AnswerValue { get; set; }
        
        public Answer(string wordName, Type answer)
        {
            this.AnswersDate = DateTime.Now;
            this.AnswerWordName = wordName;
            this.AnswerValue = (int) answer;
        }
        public Answer(int id, DateTime date, string wordName, int answerValue)
        {
            this.AnswerId = id;
            this.AnswersDate = date;
            this.AnswerWordName = wordName;
            this.AnswerValue = answerValue;
        }
    }
}
