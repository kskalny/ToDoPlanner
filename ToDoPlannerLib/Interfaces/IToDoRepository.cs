using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlannerLib.Interfaces
{
    public interface IToDoRepository
    {
        bool AddTask(ITask task);
        bool DeleteTask(ITask task);
        bool DeleteTaskById(int taskId);

    }
}
