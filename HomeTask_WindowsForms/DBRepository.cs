using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;


namespace HomeTask_WindowsForms
{
    public class DBRepository
    {
        private const string ConnectionString = @"Data Source=|DataDirectory|\test_db.sdf";
        private int _IndexInDB;

        public List<Word> GetAllWords()
        {
            List<Word> wordsList = new List<Word>();

            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT original, translate, category FROM words JOIN categories ON words.categ=categories.category_id";
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
        public HashSet<Category> GetAllCategories()
        {
            HashSet<Category> categoriesList = new HashSet<Category>();

            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT category_id, category FROM categories";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Category tempCategory = new Category(reader["category_id"].ToString().Trim(),
                            reader["category"].ToString().Trim(), true);
                        
                        categoriesList.Add(tempCategory);
                    }
                }
                connection.Close();
                return categoriesList;
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
                        _IndexInDB = Convert.ToInt16(reader["category_id"]);
                    }
                }
                
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE categories SET category=(@category) WHERE category_id=(@category_id)";
                    command.Parameters.Add("category", SqlDbType.NVarChar, 50).Value = category_new;
                    command.Parameters.Add("category_id", SqlDbType.Int).Value = _IndexInDB;
                    command.ExecuteNonQuery();
                }

            connection.Close();
            }
        }
        public void AddWord(string original, string translate, string category)
        {
            int categoryId=1;
            foreach (var cat in LocalRepository.Categories)
            {
                if (category.Equals(cat.CategoryName))
                    categoryId = cat.CategoryId;
            }
            
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO words (original, translate, categ) VALUES (@original, @translate, @categoryId)";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 50).Value = original;
                    command.Parameters.Add("translate", SqlDbType.NVarChar, 50).Value = translate;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = categoryId;
                    command.ExecuteNonQuery();
                }
            }
            
        }
        public void RemoveWord(string word)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM words WHERE original=(@original)";
                    command.Parameters.Add("original", SqlDbType.NVarChar, 50).Value = word;
                    command.ExecuteNonQuery();
                }
            }
        }
}

}
