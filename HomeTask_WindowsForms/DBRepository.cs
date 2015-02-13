using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;


namespace HomeTask_WindowsForms
{
    public class DBRepository
    {
        private const string ConnectionString = @"Data Source=|DataDirectory|\test_db.sdf";
        private int indexInDB;
        public List<Word> GetAllWords()
        {
            List<Word> wordsList = new List<Word>();

            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT original, translate, category FROM words JOIN categories ON words.category_id=categories.category_id";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Word tempWord = new Word(reader["Original"].ToString().Trim(),
                            reader["Translate"].ToString().Trim(), reader["Category"].ToString().Trim());
                        wordsList.Add(tempWord);
                    }
                }
                connection.Close();
                return wordsList;
            }
        }

        public void AddCategory(string Category)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO categories (CATEGORY) VALUES (@category)";
                    command.Parameters.Add("category", SqlDbType.NVarChar, 50).Value = Category;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveCategory(string category)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM categories WHERE category=(@category)";
                    command.Parameters.Add("category", SqlDbType.NVarChar, 50).Value = category;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCategory(string category_old, string category_new)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT category_id FROM categories WHERE category=(@category)";
                    command.Parameters.Add("category", SqlDbType.NVarChar, 50).Value = category_old;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        indexInDB = Convert.ToInt16(reader["category_id"]);
                    }
                }
                
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE categories SET category=(@category) WHERE category_id=(@category_id)";
                    command.Parameters.Add("category", SqlDbType.NVarChar, 50).Value = category_new;
                    command.Parameters.Add("category_id", SqlDbType.Int).Value = indexInDB;
                    command.ExecuteNonQuery();
                }

            connection.Close();
            }
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT category FROM categories";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Category category = new Category(reader["category"].ToString(), false);
                        categories.Add(category);
                    }
                }
                connection.Close();
                return categories;
            }
        } 

        
}

}
