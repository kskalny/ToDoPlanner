using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlannerLib.Interfaces
{
    internal interface IGenericService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();

        T GetById(int id);
        
        bool DeleteById(int id);

        public event Action<T> Created;
        public event Action<T> Deleted;
        public event Action<T> Changed;

    }
}
