using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanner.ViewModels;
using ToDoPlannerLib.Interfaces;

namespace ToDoPlanner.Commands
{
    internal class DeleteTask : CommandBase
    {
        private readonly IToDoService _service;
        public DeleteTask(IToDoService service)
        {
            _service = service;
        }
        public override void Execute(object parameter)
        {
            if (parameter is null) return;
            if (parameter.GetType() is TaskViewModel) return;
            var taskViewModel = (TaskViewModel)parameter;

            _service.DeleteTaskById(taskViewModel.TaskId);
        }
    }
}
