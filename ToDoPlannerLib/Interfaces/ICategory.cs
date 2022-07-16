using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlannerLib.Interfaces
{
    public interface ICategory
    {
        public int CategoryId { get; init; }
        public string Name { get; set; }
    }
}
