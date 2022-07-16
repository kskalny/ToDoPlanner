using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlannerLib.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ITask>> GetTasks();
        ObservableCollection<ITask> GetTasksAsObservableCollectin();

        IAuthor GetAuthoById(int id);
        bool DeleteTaskById(int id);

        public event Action<ITask> TaskCreated;
        public event Action<ITask> TaskDeleted;
        public event Action<ITask> TaskChanged;


    }
}
