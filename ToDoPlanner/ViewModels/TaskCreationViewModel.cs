using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoPlanner.Commands;
using ToDoPlanner.Stores;
using ToDoPlannerLib.Interfaces;

namespace ToDoPlanner.ViewModels
{
    internal class TaskCreationViewModel : ViewModelBase, ITask
    {
        private readonly IToDoService _service;
        private readonly NavigationStore _navigation;

        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
        public bool IsDone { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }


        public TaskCreationViewModel(IToDoService service , NavigationStore navigation)
        {
            _service = service;
            _navigation = navigation;

        }
        public ICommand CreateTask => new CreateTask(_service, this);
        public ICommand ListRoute => new Route(_navigation, "list");



    }
}
