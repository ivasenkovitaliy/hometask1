using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace HomeTask_WindowsForms
{
    public class AnswerRepository
    {
        private const string ConnectionString = @"Data Source=|DataDirectory|\programm_data.sdf";
        
        public List<Answer> GetAllAnswers()
        {
            List<Answer> answersList = new List<Answer>();
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, AnswerDate, Word, AnswerValue FROM Answer";
                    var reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        var tempAnswer = new Answer(Convert.ToInt16(reader["Id"]),
                            Convert.ToDateTime(reader["AnswerDate"]), reader["Word"].ToString(), Convert.ToInt16(reader["AnswerValue"]));
                        
                        answersList.Add(tempAnswer);
                    }
                }
            }
            return answersList;
            
        }
        public void AddAnswer(Answer answer)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Answer (AnswerDate, Word, AnswerValue) VALUES (@date, @word, @answerValue)";
                    command.Parameters.Add("date", SqlDbType.DateTime).Value = answer.AnswersDate;
                    command.Parameters.Add("word", SqlDbType.NVarChar, 40).Value = answer.AnswerWordName;
                    command.Parameters.Add("answerValue", SqlDbType.Int).Value = answer.AnswerValue;
                    command.ExecuteNonQuery();
                }
            }
        }
        
    }
}
