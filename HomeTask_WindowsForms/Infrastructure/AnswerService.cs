namespace HomeTask_WindowsForms.Infrastructure
{
    public class AnswerService
    {
        private readonly AnswerRepository _answerRepository = new AnswerRepository();
        
        public void AddAnswer(Answer answer)
        {
            _answerRepository.AddAnswer(answer);
            LocalAppData.Answers.Add(answer);
        }
    }
}
