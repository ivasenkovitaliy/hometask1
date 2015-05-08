using System;
using System.Linq;
using EnglishAssistant.DAL;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;

namespace EnglishAssistant.Services
{
    public class StatisticService
    {
        private readonly AnswerRepository _answerRepository = new AnswerRepository();

        public Tuple<int, int, int> GetAnswersCount(DateTime fromDate, DateTime toDate)
        {
            int rightAnswers = 0;
            int wrongAnswers = 0;
            int cancelledAnswers = 0;

            var selectedAnswers =
                from answer in LocalAppData.Instance.Answers
                where answer.AnswersDate.Date >= fromDate &&
                      answer.AnswersDate.Date <= toDate
                select answer;

            foreach (var answer in selectedAnswers)
            {
                if (answer.AnswerValue == Answer.Type.Wrong)
                    wrongAnswers++;
                if (answer.AnswerValue == Answer.Type.Right)
                    rightAnswers++;
                if (answer.AnswerValue == Answer.Type.Cancelled)
                    cancelledAnswers++;
            }

            return new Tuple<int, int, int>(rightAnswers, wrongAnswers, cancelledAnswers);
        }

        public void ClearStatistic()
        {
            _answerRepository.ClearStatistic();
        }
    }
}
