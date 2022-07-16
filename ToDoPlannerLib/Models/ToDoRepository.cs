using System;
using System.Collections.Generic;
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
                Title = "Test",
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
            connector = new ToDoDBConnector(DatabaseName);
        }

        public bool AddTask(ITask task)
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
            return connector.SaveChanges() == 1;
        }

        public bool DeleteTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTaskById(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
