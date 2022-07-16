using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlannerLib.Interfaces;

namespace ToDoPlanner.ViewModels
{
    internal class TasksListViewModel:ViewModelBase
    {
        private readonly ObservableCollection<TaskViewModel> _tasks;
        private readonly IToDoService _service;

        public TasksListViewModel(IToDoService service)
        {
            _service = service;
            _tasks = new ObservableCollection<TaskViewModel>();
            foreach (var task in _service.GetTasksAsObservableCollectin())
            {
                _tasks.Add(
                    new TaskViewModel(task));
            }
        }
       
 

        public IEnumerable<TaskViewModel> Tasks => _tasks;
        
        
    }
}
