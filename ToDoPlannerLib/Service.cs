using Microsoft.EntityFrameworkCore;

using ToDoPlannerLib.Models;

namespace ToDoPlannerLib
{
     public class Service
    {
        private string DatabaseName { get; init;}
        private readonly ToDoRepository _repo;

        public Service(string databaseName)
        {
            DatabaseName = databaseName;
            _repo = new ToDoRepository(DatabaseName, true);

        }
    }
    
}