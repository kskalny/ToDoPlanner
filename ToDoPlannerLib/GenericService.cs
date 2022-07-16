using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoPlannerLib.Interfaces;

namespace ToDoPlannerLib
{
    internal class GenericService<T> : IGenericService<T>
    {
        public event Action<T> Created;
        public event Action<T> Deleted;
        public event Action<T> Changed;

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return new List<T>();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
