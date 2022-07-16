namespace ToDoPlannerLib
{
    public class Service
    {
        private string DatabaseName { get; init;}

        public Service(string databaseName)
        {
            DatabaseName = databaseName;
        }
    }
    
}