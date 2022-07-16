﻿using System;
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

        bool AddTask(ITask task);
        bool DeleteTask(ITask task);
        bool DeleteTaskById(int taskId);

    }
}
