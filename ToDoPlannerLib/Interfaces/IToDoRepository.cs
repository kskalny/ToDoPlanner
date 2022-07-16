using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlannerLib.Interfaces
{
    public interface IToDoRepository
    {
        ObservableCollection<ITask> GetTasksAsObservableCollectin();
        Task<IEnumerable<ITask>> GetTasks();

        ITask AddTask(ITask task);
        ITask DeleteTask(ITask task);
        ITask DeleteTaskById(int taskId);

        IAuthor GetAuthoById(int id);
    }
}
