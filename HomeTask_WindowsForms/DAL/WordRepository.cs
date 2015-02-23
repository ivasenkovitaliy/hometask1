using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;


namespace HomeTask_WindowsForms
{
    public class WordRepository

    {
        private const string ConnectionString = @"Data Source=|DataDirectory|\programm_data.sdf";
        
        public List<Word> GetAllWords()
        {
            List<Word> wordsList = new List<Word>();

            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT id, original, translate, categoryname FROM Word JOIN Category ON word.category=category.categoryid";
                    
                    var reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Word tempWord = new Word(Convert.ToInt16(reader["Id"]), reader["Original"].ToString().Trim(),
                            reader["Translate"].ToString().Trim(), reader["CategoryName"].ToString().Trim());
                        wordsList.Add(tempWord);
                    }
                }

                return wordsList;
            }
        }
        public void AddWord(string original, string translate, int categoryId)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO word (original, translate, category) VALUES (@original, @translate, @categoryId)";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 40).Value = original;
                    command.Parameters.Add("translate", SqlDbType.NVarChar, 130).Value = translate;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = categoryId;
                    command.ExecuteNonQuery();
                }
            }
            
        }
        public void RemoveWord(int wordId)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM word WHERE Id=(@Id)";
                    command.Parameters.Add("Id", SqlDbType.Int).Value = wordId;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateWord(int oldWordId, string wordNameNew, string wordTranslate, int wordCategoryId)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE word SET original=(@original), translate=(@translate), category=(@category) WHERE id=(@oldWordId)";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 40).Value = wordNameNew;
                    command.Parameters.Add("translate", SqlDbType.NVarChar, 130).Value = wordTranslate;
                    command.Parameters.Add("category", SqlDbType.Int).Value = wordCategoryId;
                    command.Parameters.Add("oldWordId", SqlDbType.Int).Value = oldWordId;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateWordsCategory(int oldWordCategory, int newWordCategory)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE word SET category=(@newWordCategory) WHERE category=(@oldWordCategory)";
                    command.Parameters.Add("oldWordCategory", SqlDbType.Int).Value = oldWordCategory;
                    command.Parameters.Add("newWordCategory", SqlDbType.Int).Value = newWordCategory;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
