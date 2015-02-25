﻿using System.Data;
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
                        query.CommandText = @"CREATE TABLE Category (
                            Category_Id_PK INT IDENTITY(1,1) PRIMARY KEY, 
                            Name NVARCHAR(40) NOT NULL,
                            IsUsed BIT NOT NULL
                            );";
                        query.ExecuteNonQuery();
                    }

                    using (var query = connection.CreateCommand())
                    {
                        query.CommandText = @"CREATE TABLE Word (
                            Id_PK INT IDENTITY(1,1) PRIMARY KEY,
                            Original NVARCHAR(40) NOT NULL,
                            Translate NVARCHAR(40) NOT NULL,
                            TranslateSecond NVARCHAR(40),
                            TranslateThird NVARCHAR(40),
                            Category_FK INT NOT NULL,
                            FOREIGN KEY (Category_FK) REFERENCES Category (Category_Id_PK)
                            );";

                        query.ExecuteNonQuery();
                    }
               
                    using (var query = connection.CreateCommand())
                    {
                        query.CommandText = @"CREATE TABLE Answer (
                            Id_PK INT IDENTITY(1,1) PRIMARY KEY,
                            Date DATETIME NOT NULL,
                            Word_FK INT NOT NULL,
                            AnswerValue INT NOT NULL,
                            FOREIGN KEY (Word_FK) REFERENCES Word (Id_PK)
                            );";
                        query.ExecuteNonQuery();
                    }

                    // adding one category
                    var categoryRepository = new CategoryRepository();
                    categoryRepository.AddCategory(new Category("no category"));

                    // adding five words
                    var wordRepository = new WordRepository();
                    wordRepository.AddWord(new Word("river", "река", null, null), 1);
                    wordRepository.AddWord(new Word("job", "работа", null, null), 1);
                    wordRepository.AddWord(new Word("class", "класс", null, null), 1);
                    wordRepository.AddWord(new Word("set", "набор", null, null), 1);
                    wordRepository.AddWord(new Word("moon", "луна", null, null), 1);
                }
            }
        }
    }
}