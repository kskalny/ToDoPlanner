using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanner.ViewModels;
using ToDoPlannerLib.Interfaces;

using ToDoPlannerLib.Interfaces;

namespace ToDoPlanner.Commands
{
    internal class CreateTask : CommandBase
    {
        private readonly IToDoService _service;
        private readonly ITask _task;
        public CreateTask(IToDoService service, ITask task)
        {
            _service = service;
            _task = task;
        }
        public override void Execute(object parameter)
        {
            _service.AddTask(_task);
        }
    }
}
