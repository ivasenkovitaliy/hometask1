using HomeTask_WindowsForms.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace HomeTask_WindowsForms.DAL
{
    public class CategoryRepository : RepositoryBase
    {
        public IEnumerable<Category> GetAllCategories()
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, Name, IsUsed FROM Category";

                    var reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        var category = new Category(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2));
                        
                        yield return category;
                    }
                }
            }
        }
        
        public void AddCategory(Category category)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Category (Name, IsUsed) VALUES (@categoryName, @isUsed)";
                    command.Parameters.Add("categoryName", SqlDbType.NVarChar, 40).Value = category.CategoryName;
                    command.Parameters.Add("isUsed", SqlDbType.Bit).Value = category.IsUsed;
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "SELECT @@IDENTITY";

                    category.CategoryId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void RemoveCategory(Category category)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Category WHERE Id = @categoryId";
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = category.CategoryId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Category SET Name = @categoryName WHERE Id = @categoryId";
                    command.Parameters.Add("categoryName", SqlDbType.NVarChar, 40).Value = category.CategoryName;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = category.CategoryId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ChangeUsingCategory(Category category)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Category SET IsUsed = @isUsed WHERE Id = @categoryId";
                    command.Parameters.Add("isUsed", SqlDbType.Bit).Value = !category.IsUsed;
                    command.Parameters.Add("categoryId", SqlDbType.Int).Value = category.CategoryId;
                    command.ExecuteNonQuery();
                }
            }            
        }
    }
}
