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

        public bool AddTask(ITask task)
        {
            var _task = _repo.AddTask(task);
            if (_task == null) { return false; };

            OnTaskCreation(_task);
            return true;
        }


        public bool DeleteTaskById(int id)
        {
            var _task = _repo.DeleteTaskById(id);
            if (_task == null) { return false; };

            OnTaskDeletion(_task);
            return true;
        
        }

        public IAuthor GetAuthoById(int id)
        {
            return _repo.GetAuthoById(id);
        }

        public Task<IEnumerable<ITask>> GetTasks()
        {
            return _repo.GetTasks();
        }

        public ObservableCollection<ITask> GetTasksAsObservableCollectin()
        {
            return _repo.GetTasksAsObservableCollectin();
        }

        public event Action<ITask> TaskCreated;
        public event Action<ITask> TaskDeleted;
        public event Action<ITask> TaskChanged;

        private void OnTaskDeletion(ITask task)
        {
            TaskDeleted?.Invoke(task);
        }
        private void OnTaskCreation(ITask task)
        {
            TaskCreated?.Invoke(task);
        }
    }   
    
    
}