using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace HomeTask_WindowsForms
{
    public class CategoryRepository
    {
        private readonly string _connectionString = Properties.Settings.Default.connectionString;
        
        public IEnumerable<Category> GetAllCategories()
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT CategoryId, CategoryName, IsUsed FROM Category";

                    var reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        var category = new Category(Convert.ToInt16(reader["CategoryId"]),
                            reader["CategoryName"].ToString().Trim(), Convert.ToBoolean(reader["IsUsed"]));

                        yield return category;
                    }
                }
            }
        }
        public void AddCategory(Category category)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Category (CategoryName, IsUsed) VALUES (@categoryName, @isUsed)";
                    command.Parameters.Add("categoryName", SqlDbType.NVarChar, 40).Value = category.CategoryName;
                    command.Parameters.Add("isUsed", SqlDbType.Bit).Value = false;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void RemoveCategory(Category category)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Category WHERE CategoryId=(@categoryId)";
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = category.CategoryId;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Category SET CategoryName=(@categoryName) WHERE categoryId=(@categoryId)";
                    command.Parameters.Add("categoryName", SqlDbType.NVarChar, 40).Value = category.CategoryName;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = category.CategoryId;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ChangeUsingCategory(Category category)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Category SET IsUsed=(@IsUsed) WHERE categoryId=(@categoryId)";
                    command.Parameters.Add("IsUsed", SqlDbType.Bit).Value = !category.IsUsed;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = category.CategoryId;
                    command.ExecuteNonQuery();
                }
            }            
        }
    }
}
