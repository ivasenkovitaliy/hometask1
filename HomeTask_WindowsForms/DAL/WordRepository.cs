using System;
using System.Collections.Generic;
using System.Data;
using EnglishAssistant.Entities;

namespace EnglishAssistant.DAL
{
    public class WordRepository : RepositoryBase
    {
        public IEnumerable<Word> GetAllWords()
        {
            using (var connection = GetOpenConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT word.Id, original, translate, translateSecond, translateThird, category.Id, name, isLearnedEnglishByCheck, isLearnedRussianByCheck, isLearnedEnglishByTranslation, isLearnedRussianByTranslation FROM Word JOIN Category " +
                        "ON word.category_Id = category.id";

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var word = new Word(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), 
                            reader.GetString(6), reader.GetBoolean(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetBoolean(10));

                        yield return word;
                    }
                }
            }
        }

        public void ResetAllEnglishLearnedWordsByChecking()
        {
            ExecuteQuery("UPDATE Word SET IsLearnedEnglishByCheck = 0");
        }

        public void ResetAllLearnedWords()
        {
            ResetAllEnglishLearnedWordsByChecking();
            ResetAllEnglishLearnedWordsByTranslation();
            ResetAllRussianLearnedWordsByChecking();
            ResetAllRussianLearnedWordsByTranslation();
        }

        public void ResetAllRussianLearnedWordsByChecking()
        {
            ExecuteQuery("UPDATE Word SET IsLearnedRussianByCheck = 0");
        }

        public void ResetAllEnglishLearnedWordsByTranslation()
        {
            ExecuteQuery("UPDATE Word SET IsLearnedEnglishByTranslation = 0");
        }

        public void ResetAllRussianLearnedWordsByTranslation()
        {
            ExecuteQuery("UPDATE Word SET IsLearnedRussianByTranslation = 0");
        }

        public void AddWord(Word word)
        {
            using (var connection = GetOpenConnection())
            {
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

                    word.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void RemoveWord(Word word)
        {
            using (var connection = GetOpenConnection())
            {
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
            using (var connection = GetOpenConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE word " +
                                          "SET original = @original, translate = @translate, translateSecond = @translateSecond, " +
                                          "translateThird= @translateThird, category_Id = @category_id, isLearnedEnglishByCheck = @isLearnedEnglishByCheck, isLearnedRussianByCheck = @isLearnedRussianByCheck, " +
                                          "isLearnedEnglishByTranslation = @isLearnedEnglishByTranslation, isLearnedRussianByTranslation = @isLearnedRussianByTranslation " +
                                          "WHERE id = @oldWordId";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 40).Value = newWord.Original;
                    command.Parameters.Add("translate", SqlDbType.NVarChar, 40).Value = newWord.Translate;
                    command.Parameters.Add("translateSecond", SqlDbType.NVarChar, 40).Value = newWord.TranslateSecond;
                    command.Parameters.Add("translateThird", SqlDbType.NVarChar, 40).Value = newWord.TranslateThird;
                    command.Parameters.Add("category_id", SqlDbType.Int).Value = newWord.CategoryId;
                    command.Parameters.Add("isLearnedEnglishByCheck", SqlDbType.Bit).Value = newWord.IsLearnedEnglishByCheck;
                    command.Parameters.Add("isLearnedRussianByCheck", SqlDbType.Bit).Value = newWord.IsLearnedRussianByCheck;
                    command.Parameters.Add("isLearnedEnglishByTranslation", SqlDbType.Bit).Value = newWord.IsLearnedEnglishByTranslation;
                    command.Parameters.Add("isLearnedRussianByTranslation", SqlDbType.Bit).Value = newWord.IsLearnedRussianByTranslation;
                    command.Parameters.Add("oldWordId", SqlDbType.Int).Value = newWord.Id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWordsCategory(Category deletedCategory)
        {
            using (var connection = GetOpenConnection())
            {
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
