using System.Collections.ObjectModel;
using ToDoPlannerLib.Interfaces;

namespace ToDoPlannerLib.Models
{
    public class Comment : IComment
    {

        public int CommentId { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
