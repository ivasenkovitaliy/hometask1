using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;


namespace HomeTask_WindowsForms
{
    public class CategoryRepository
    {
        private const string ConnectionString = @"Data Source=|DataDirectory|\programm_data.sdf";
        
        public List<Category> GetAllCategories()
        {
            List<Category> categoriesList = new List<Category>();

            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT CategoryId, CategoryName, IsUsed FROM Category";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Category tempCategory = new Category(Convert.ToInt16(reader["CategoryId"]),
                            reader["CategoryName"].ToString().Trim(), Convert.ToBoolean(reader["IsUsed"]));
                        
                        categoriesList.Add(tempCategory);
                    }
                }
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
                    command.CommandText = "INSERT INTO Category (CategoryName, IsUsed) VALUES (@category, @isUsed)";
                    command.Parameters.Add("category", SqlDbType.NVarChar, 40).Value = Category;
                    command.Parameters.Add("isUsed", SqlDbType.Bit).Value = false;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void RemoveCategory(int categoryId)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Category WHERE CategoryId=(@categoryId)";
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = categoryId;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateCategory(int categoryIdOld, string categoryNameNew)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Category SET CategoryName=(@categoryName) WHERE categoryId=(@categoryId)";
                    command.Parameters.Add("categoryName", SqlDbType.NVarChar, 50).Value = categoryNameNew;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = categoryIdOld;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ChangeUsingCategory(int categoryId, bool isUsed)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Category SET IsUsed=(@IsUsed) WHERE categoryId=(@categoryId)";
                    command.Parameters.Add("IsUsed", SqlDbType.Bit).Value = isUsed;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = categoryId;
                    command.ExecuteNonQuery();
                }
            }            
        }
    }
}
