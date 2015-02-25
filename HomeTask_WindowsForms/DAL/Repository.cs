using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;

namespace HomeTask_WindowsForms.DAL
{
    public static class Repository
    {
        private static readonly string ConnectionString = Properties.Settings.Default.connectionString;
        
        public static void CreateDb()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var dbFileName = Path.Combine(directoryName, "programm_data.sdf");

            if (!File.Exists(dbFileName))
            {
                SqlCeEngine engine = new SqlCeEngine(ConnectionString);
                engine.CreateDatabase();

                using (var connection = new SqlCeConnection(ConnectionString))
                {
                    connection.Open();

                    using (var query = connection.CreateCommand())
                    {
                        query.CommandText = @"CREATE TABLE Word (Id INT IDENTITY(1,1) PRIMARY KEY, Original NVARCHAR(40) NOT NULL, Translate NVARCHAR(40) NOT NULL, TranslateSecond NVARCHAR(40), TranslateThird NVARCHAR(40), Category INT NOT NULL);";
                        query.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                        command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "snow";
                        command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "снег";
                        command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                        command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "river";
                        command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "река";
                        command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                        command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "job";
                        command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "работа";
                        command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                        command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "class";
                        command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "класс";
                        command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                        command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "set";
                        command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "набор";
                        command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                        command.ExecuteNonQuery();
                    }
                }

                using (var connection = new SqlCeConnection(ConnectionString))
                {
                    connection.Open();

                    using (var query = connection.CreateCommand())
                    {
                        query.CommandText = @"CREATE TABLE Category (CategoryId INT IDENTITY(1,1) PRIMARY KEY, CategoryName NVARCHAR(40) NOT NULL, IsUsed BIT NOT NULL);";
                        query.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Category (CategoryName, IsUsed) VALUES (@CategoryName, @IsUsed)";

                        command.Parameters.Add("CategoryName", SqlDbType.NVarChar, 40).Value = "no category";
                        command.Parameters.Add("IsUsed", SqlDbType.Bit).Value = true;

                        command.ExecuteNonQuery();
                    }
                }

                using (var connection = new SqlCeConnection(ConnectionString))
                {
                    connection.Open();

                    using (var query = connection.CreateCommand())
                    {
                        query.CommandText = @"CREATE TABLE Answer (Id INT IDENTITY(1,1) PRIMARY KEY, AnswerDate DATETIME NOT NULL, Word NVARCHAR(40) NOT NULL, AnswerValue INT NOT NULL);";
                        query.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
