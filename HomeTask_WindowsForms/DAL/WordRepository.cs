using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;


namespace HomeTask_WindowsForms
{
    public class WordRepository

    {
        private readonly string _connectionString = Properties.Settings.Default.connectionString;

        public IEnumerable<Word> GetAllWords()
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id_PK, original, translate, translateSecond, translateThird, name FROM Word JOIN Category " +
                        "ON word.category_FK = category.Category_id_PK";

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var word = new Word(Convert.ToInt16(reader["Id_PK"]), reader["Original"].ToString().Trim(),
                            reader["Translate"].ToString().Trim(), reader["TranslateSecond"].ToString().Trim(), 
                              reader["TranslateThird"].ToString().Trim(), reader["Name"].ToString().Trim());
                        
                        yield return word;
                    }
                }
            }
        }

        public void AddWord(Word word, int categoryId)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO word (original, translate, translateSecond, translateThird, category_FK)" +
                                          " VALUES (@original, @translate, @translateSecond, @translateThird, @categoryId)";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 40).Value = word.Original;
                    command.Parameters.Add("translate", SqlDbType.NVarChar, 40).Value = word.Translate;
                    command.Parameters.Add("translateSecond", SqlDbType.NVarChar, 40).Value = word.TranslateSecond;
                    command.Parameters.Add("translateThird", SqlDbType.NVarChar, 40).Value = word.TranslateThird;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = categoryId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveWord(Word word)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM word WHERE Id_PK = @Id";
                    command.Parameters.Add("Id", SqlDbType.Int).Value = word.Id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWord(int oldWordId, Word newWord, int newWordCategoryId)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE word " +
                                          "SET original = @original, translate = @translate, translateSecond = @translateSecond," +
                                          " translateThird= @translateThird, category_FK = @category WHERE id_PK = @oldWordId";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 40).Value = newWord.Original;
                    command.Parameters.Add("translate", SqlDbType.NVarChar, 40).Value = newWord.Translate;
                    command.Parameters.Add("translateSecond", SqlDbType.NVarChar, 40).Value = newWord.TranslateSecond;
                    command.Parameters.Add("translateThird", SqlDbType.NVarChar, 40).Value = newWord.TranslateThird;
                    command.Parameters.Add("category", SqlDbType.Int).Value = newWordCategoryId;
                    command.Parameters.Add("oldWordId", SqlDbType.Int).Value = oldWordId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWordsCategory(Category deletedCategory)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE word SET category_FK = @newWordCategory WHERE category_FK = @oldWordCategory";
                    command.Parameters.Add("oldWordCategory", SqlDbType.Int).Value = deletedCategory.CategoryId;
                    command.Parameters.Add("newWordCategory", SqlDbType.Int).Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
