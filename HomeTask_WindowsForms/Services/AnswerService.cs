using EnglishAssistant.DAL;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;

namespace EnglishAssistant.Services
{
    public class AnswerService
    {
        private readonly AnswerRepository _answerRepository = new AnswerRepository();
        
        public void AddAnswer(Answer answer)
        {
            _answerRepository.AddAnswer(answer);
            LocalAppData.Instance.Answers.Add(answer);
        }
    }
}
