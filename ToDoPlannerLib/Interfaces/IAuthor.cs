using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlannerLib.Interfaces
{
    public interface IAuthor
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

    }
}
