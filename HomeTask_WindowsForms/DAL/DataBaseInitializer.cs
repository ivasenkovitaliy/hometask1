using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;
using EnglishAssistant.Entities;

namespace EnglishAssistant.DAL
{
    public class DataBaseInitializer : RepositoryBase
    {
        public void CreateDb()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var dbFileName = Path.Combine(directoryName, "programm_data.sdf");

            if (!File.Exists(dbFileName))
            {
                var engine = new SqlCeEngine(ConnectionString);
                engine.CreateDatabase();

                using (var connection = GetOpenConnection())
                {
                    using (var query = connection.CreateCommand())
                    {
                        query.CommandText = @"CREATE TABLE Category (
                            Id INT IDENTITY(1,1) PRIMARY KEY, 
                            Name NVARCHAR(40) NOT NULL,
                            IsUsed BIT NOT NULL
                            );";
                        query.ExecuteNonQuery();
                    }

                    using (var query = connection.CreateCommand())
                    {
                        query.CommandText = @"CREATE TABLE Word (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Original NVARCHAR(40) NOT NULL,
                            Translate NVARCHAR(40) NOT NULL,
                            TranslateSecond NVARCHAR(40),
                            TranslateThird NVARCHAR(40),
                            Category_Id INT NOT NULL,
                            IsLearnedEnglishByCheck bit NOT NULL DEFAULT(0),
                            IsLearnedRussianByCheck bit NOT NULL DEFAULT(0),
                            IsLearnedEnglishByTranslation bit NOT NULL DEFAULT(0),
                            IsLearnedRussianByTranslation bit NOT NULL DEFAULT(0),
                            FOREIGN KEY (Category_Id) REFERENCES Category (Id)
                            );";

                        query.ExecuteNonQuery();
                    }
               
                    using (var query = connection.CreateCommand())
                    {
                        query.CommandText = @"CREATE TABLE Answer (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Date DATETIME NOT NULL,
                            Word_Id INT NOT NULL,
                            AnswerValue INT NOT NULL,
                            FOREIGN KEY (Word_Id) REFERENCES Word (Id)
                            );";
                        query.ExecuteNonQuery();
                    }

                    var categoryRepository = new CategoryRepository();
                    var wordRepository = new WordRepository();

                    // making one category
                    var firstCategory = new Category("no category", true);

                    categoryRepository.AddCategory(firstCategory);

                    // adding five words
                    wordRepository.AddWord(new Word("river", "река", string.Empty, string.Empty, firstCategory.CategoryId));
                    wordRepository.AddWord(new Word("job", "работа", string.Empty, string.Empty, firstCategory.CategoryId));
                    wordRepository.AddWord(new Word("class", "класс", string.Empty, string.Empty, firstCategory.CategoryId));
                    wordRepository.AddWord(new Word("set", "набор", string.Empty, string.Empty, firstCategory.CategoryId));
                    wordRepository.AddWord(new Word("moon", "луна", string.Empty, string.Empty, firstCategory.CategoryId));
                }
            }
        }
    }
}
