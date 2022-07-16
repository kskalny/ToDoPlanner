using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoPlannerLib.Interfaces;
namespace ToDoPlanner.ViewModels
{
    internal class TaskViewModel : ViewModelBase
    {
        private readonly ITask _task;
        private readonly IAuthor _author;

        public TaskViewModel(ITask task, IAuthor author)
        {
            _task = task;
            _author = author;
        }

        public int TaskId => _task.TaskId;
        public string Author => _author.Name;
        public string Description => _task.Description;
        public string Title => _task.Title;
        public bool Completed { get => _task.IsDone; set { _task.IsDone = value; } }

        public DateTime DueDate => _task.DueDate;
           
    }
}
