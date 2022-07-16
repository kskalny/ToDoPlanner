using Microsoft.EntityFrameworkCore;

using ToDoPlannerLib.Interfaces;
using ToDoPlannerLib.Models;

namespace ToDoPlannerLib
{
     public class Service
    {
        private readonly IToDoRepository _repo;

        public Service(IToDoRepository repository)
        {
            _repo = repository;
        }

        public ITask CreateTask(string title)
        {
            return new ToDoTask()
            {
                Title = title

            };
        }
    }
    
}