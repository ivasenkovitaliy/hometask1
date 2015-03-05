namespace HomeTask_WindowsForms.DAL
{
    public abstract class RepositoryBase
    {
        protected string ConnectionString = Properties.Settings.Default.connectionString;
    }
}
