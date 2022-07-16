using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoPlannerLib.Interfaces;
namespace ToDoPlanner.ViewModels
{
    internal class TaskViewModel:ViewModelBase
    {
        private readonly ITask _task;

        public TaskViewModel(ITask task)
        {
            _task = task;
        }

        public string TaskId => _task.TaskId.ToString();
        public string AuthorId => _task.AuthorId.ToString();
        public string Description => _task.Description;
        public string Title => _task.Title;

        public DateTime DueDate => _task.DueDate;
           
    }
}
