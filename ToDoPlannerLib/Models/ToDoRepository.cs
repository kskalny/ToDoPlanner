using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoPlannerLib.Interfaces;

namespace ToDoPlannerLib.Models
{
    internal class ToDoDBConnector : DbContext
    {
        private readonly string dbName;
        private void InitDummyData()
        {
            var cat1 = new Category()
            {
                Name = "Test2"
            };
            var cat2 = new Category()
            {
                Name = "Test"
            };
            var cat3 = new Category()
            {
                Name = "Test3;"
            };

            var author = new Author()
            {
                Name = "Kamil Skalny"
            };

            var task = new ToDoTask()
            {
                Title = "Stop delaying important things.",
                Description = "Test",
                DueDate = DateTime.Now,
                Category = cat1,
                Author = author
            };
            var task1 = new ToDoTask()
            {
                Title = "Complete the application.",
                Description = "Test",
                DueDate = DateTime.Now,
                Category = cat1,
                Author = author
            };
            var task2 = new ToDoTask()
            {
                Title = "Have a great vacation in work.",
                Description = "Test",
                DueDate = DateTime.Now,
                Category = cat1,
                Author = author
            };
            
            Categories.Add(cat1);
            Categories.Add(cat2);
            Categories.Add(cat3);
            Authors.Add(author);
            Tasks.Add(task);
            Tasks.Add(task1);
            Tasks.Add(task2);

            SaveChanges();
        }

        public ToDoDBConnector(string dbName, bool test = false)
        {
            this.dbName = dbName;
            if (test) Database.EnsureDeleted();
            if (Database.EnsureCreated())
            {
                // If db has to be created do:...
                InitDummyData();
            }

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                $"Data Source={this.dbName}");
        }
    }
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDBConnector connector;

        public ToDoRepository(string DatabaseName)
        {
            connector = new ToDoDBConnector(DatabaseName, true);
        }

        public ITask? AddTask(ITask task)
        {
            connector.Tasks.Add(
                new ToDoTask()
                {
                    TaskId = task.TaskId,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    AuthorId = task.AuthorId,
                    CategoryId = task.CategoryId
                }
            );
            return (connector.SaveChanges() == 1) ? task:null ;
        }

        public ITask? DeleteTask(ITask task)
        {
            var taskToDelete = connector.Tasks.Find(task);
            if (taskToDelete is null)
            {
                return null;
            }
            connector.Tasks.Remove(taskToDelete);
            return (connector.SaveChanges() == 1) ? task : null;

        }

        public ITask? DeleteTaskById(int taskId)
        {
            var result = connector.Tasks.Find(taskId);
            if (result is null) { return null; }
            connector.Tasks.Remove(result);

            return (connector.SaveChanges() == 1) ? result : null;
        }

        public IAuthor GetAuthoById(int id)
        {
            var result =  connector.Authors.Find(id);
            if (result is null) { throw new Exception(); }
            return result;
        }


        public Task<IEnumerable<ITask>> GetTasks()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<ITask>> GetTasks()
        //{
        //    return  await connector.Tasks.ToListAsync();
        //}
        public ObservableCollection<ITask> GetTasksAsObservableCollectin()
        {
            return new ObservableCollection<ITask>(connector.Tasks);
        }
    }
}
