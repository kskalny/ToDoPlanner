using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlannerLib.Interfaces
{
    public interface IComment
    {
        public int CommentId { get; init; }
        public string Content { get; set; }
        public int AuthorId { get; init; }

    }
}
