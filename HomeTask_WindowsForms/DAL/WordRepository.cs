using HomeTask_WindowsForms.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;


namespace HomeTask_WindowsForms
{
    public class WordRepository : RepositoryBase

    {
        public IEnumerable<Word> GetAllWords()
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT word.Id, original, translate, translateSecond, translateThird, category.Id, name FROM Word JOIN Category " +
                        "ON word.category_Id = category.id";

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var word = new Word(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6));

                        yield return word;
                    }
                }
            }
        }

        public int AddWord(Word word)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO word (original, translate, translateSecond, translateThird, category_Id)" +
                                          " VALUES (@original, @translate, @translateSecond, @translateThird, @categoryId)";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 40).Value = word.Original;
                    command.Parameters.Add("translate", SqlDbType.NVarChar, 40).Value = word.Translate;
                    command.Parameters.Add("translateSecond", SqlDbType.NVarChar, 40).Value = word.TranslateSecond;
                    command.Parameters.Add("translateThird", SqlDbType.NVarChar, 40).Value = word.TranslateThird;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = word.CategoryId;
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "SELECT @@IDENTITY";

                    var newId = Convert.ToInt32(command.ExecuteScalar());

                    return newId;
                }
            }
        }

        public void RemoveWord(Word word)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM word WHERE Id = @Id";
                    command.Parameters.Add("Id", SqlDbType.Int).Value = word.Id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWord(Word newWord)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE word " +
                                          "SET original = @original, translate = @translate, translateSecond = @translateSecond," +
                                          " translateThird= @translateThird, category_Id = @category_id WHERE id = @oldWordId";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 40).Value = newWord.Original;
                    command.Parameters.Add("translate", SqlDbType.NVarChar, 40).Value = newWord.Translate;
                    command.Parameters.Add("translateSecond", SqlDbType.NVarChar, 40).Value = newWord.TranslateSecond;
                    command.Parameters.Add("translateThird", SqlDbType.NVarChar, 40).Value = newWord.TranslateThird;
                    command.Parameters.Add("category_id", SqlDbType.Int).Value = newWord.CategoryId;
                    command.Parameters.Add("oldWordId", SqlDbType.Int).Value = newWord.Id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWordsCategory(Category deletedCategory)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE word SET category_Id = @newWordCategory WHERE category_Id = @oldWordCategory";
                    command.Parameters.Add("oldWordCategory", SqlDbType.Int).Value = deletedCategory.CategoryId;
                    command.Parameters.Add("newWordCategory", SqlDbType.Int).Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
