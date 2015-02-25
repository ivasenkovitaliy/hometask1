﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace HomeTask_WindowsForms
{
    public class AnswerRepository
    {
        private readonly string _connectionString = Properties.Settings.Default.connectionString;
        
        public IEnumerable<Answer> GetAllAnswers()
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id_PK, Date, Word_FK, AnswerValue FROM Answer";
                    
                    var reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        var answer = new Answer(Convert.ToInt16(reader["Id_PK"]),
                            Convert.ToDateTime(reader["Date"]), Convert.ToInt16(reader["Word_FK"]), Convert.ToInt16(reader["AnswerValue"]));

                        yield return answer;
                    }
                }
            }
        }
        public void AddAnswer(Answer answer)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Answer (Date, Word_FK, AnswerValue) VALUES (@date, @word_FK, @answerValue)";
                    command.Parameters.Add("date", SqlDbType.DateTime).Value = answer.AnswersDate;
                    command.Parameters.Add("word_FK", SqlDbType.Int).Value = answer.WordId;
                    command.Parameters.Add("answerValue", SqlDbType.Int).Value = answer.AnswerValue;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
