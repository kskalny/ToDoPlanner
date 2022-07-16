using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoPlanner.Commands;
using ToDoPlannerLib.Interfaces;

namespace ToDoPlanner.ViewModels
{
    internal class TasksListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TaskViewModel> _tasks;
        private readonly IToDoService _service;


        void TaskDeleted(ITask task)
        {
            var __task_to_clear = _tasks.First((x) => x.TaskId == task.TaskId);
            if (__task_to_clear != null)
                _tasks.Remove(__task_to_clear); 
        }
        public TasksListViewModel(IToDoService service)
        {
            _service = service;
            _tasks = new ObservableCollection<TaskViewModel>();
            _service.TaskDeleted += TaskDeleted;
            foreach (var task in _service.GetTasksAsObservableCollectin())
            {
                var author = _service.GetAuthoById(task.AuthorId);
                _tasks.Add(
                    new TaskViewModel(task, author));
            }
        }

        public IEnumerable<TaskViewModel> Tasks => _tasks;

        public ICommand DeleteTask => new DeleteTask(_service);

            
    
    }
}
