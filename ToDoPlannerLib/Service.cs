using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using ToDoPlannerLib.Interfaces;
using ToDoPlannerLib.Models;

namespace ToDoPlannerLib
{
    public class Service:IToDoService
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

        public Task<IEnumerable<ITask>> GetTasks()
        {
            return _repo.GetTasks();
        }

        public ObservableCollection<ITask> GetTasksAsObservableCollectin()
        {
            return _repo.GetTasksAsObservableCollectin();
        }
    }   
    
}