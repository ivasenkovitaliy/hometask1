using System.Collections.Generic;
using System.Data;
using EnglishAssistant.Entities;

namespace EnglishAssistant.DAL
{
    public class AnswerRepository : RepositoryBase
    {
        public IEnumerable<Answer> GetAllAnswers()
        {
            using (var connection = GetOpenConnection())
            {
                
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, Date, Word_id, AnswerValue FROM Answer";
                    
                    var reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        var answer = new Answer(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3));
                        
                        yield return answer;
                    }
                }
            }
        }

        public void AddAnswer(Answer answer)
        {
            using (var connection = GetOpenConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Answer (Date, Word_Id, AnswerValue) VALUES (@date, @word_Id, @answerValue)";
                    command.Parameters.Add("date", SqlDbType.DateTime).Value = answer.AnswersDate;
                    command.Parameters.Add("word_Id", SqlDbType.Int).Value = answer.WordId;
                    command.Parameters.Add("answerValue", SqlDbType.Int).Value = answer.AnswerValue;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
