using System.Collections.ObjectModel;
using ToDoPlannerLib.Interfaces;

namespace ToDoPlannerLib.Models
{
    public class Category : ICategory
    {

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ToDoTask>
            Tasks
        { get; private set; } =
            new ObservableCollection<ToDoTask>();

    }
}
