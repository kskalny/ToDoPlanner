using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ToDoPlannerLib.Interfaces;

namespace ToDoPlannerLib.Models
{

    public class ToDoTask : ITask
    {
        [Key]
        public int TaskId { get; set; }

        [Required] 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; } = false;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }

    }
}
