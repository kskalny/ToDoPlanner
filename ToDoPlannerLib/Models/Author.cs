using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoPlannerLib.Interfaces;

namespace ToDoPlannerLib.Models
{
    public class Author : IAuthor
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Comment> Comments { get; private set; } = new ObservableCollection<Comment>();
        public virtual ICollection<ToDoTask> Tasks { get; private set; } = new ObservableCollection<ToDoTask>();

    }
}
