using HomeTask_WindowsForms.DAL;
using HomeTask_WindowsForms.Entities;

namespace HomeTask_WindowsForms.Infrastructure
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
