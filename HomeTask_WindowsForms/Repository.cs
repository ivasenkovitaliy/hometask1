using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTask_WindowsForms
{
    public class Repository
    {
        private const string ConnectionString = @"Data Source=|DataDirectory|\test_db.sdf";

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

        
}

}
