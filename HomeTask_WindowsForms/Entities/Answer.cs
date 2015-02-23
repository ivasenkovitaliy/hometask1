using System;

namespace HomeTask_WindowsForms
{
    public class Answer
    {
        public enum Answers
        {
            Wrong = 0,
            Right,
            Cancelled
        }

        public int AnswerId { get; private set; }
        public DateTime AnswersDate { get; private set; }
        public string AnswerWordName { get; set; }
        public int  AnswerValue { get; set; }
        
        
        public Answer(string wordName, string answer)
        {
            this.AnswersDate = DateTime.Now;
            this.AnswerWordName = wordName;
            switch (answer)
            {
                case "Wrong":
                    this.AnswerValue = (int)Answers.Wrong;
                    break;
                case "Right":
                    this.AnswerValue = (int)Answers.Right;
                    break;
                case "Cancelled":
                    this.AnswerValue = (int)Answers.Cancelled;
                    break;
            }
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
