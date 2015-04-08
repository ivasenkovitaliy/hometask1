using System.Data.SqlServerCe;
using EnglishAssistant.Infrastructure;

namespace EnglishAssistant.DAL
{
    public abstract class RepositoryBase
    {
        protected readonly string ConnectionString = Settings.ConnectionString;

        protected SqlCeConnection GetOpenConnection()
        {
            var connection = new SqlCeConnection(ConnectionString);
            connection.Open();
            return connection;
        }


        protected void ExecuteQuery(string query)
        {
            using (var connection = GetOpenConnection())
            {
                var command = new SqlCeCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
