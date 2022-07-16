using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoPlannerLib.Models
{
    class ToDoRepository : DbContext
    {
        private string dbName;
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
                Description= "Test",
                DueDate = DateTime.Now,
                Category=cat1,
                Author = author
            };
            Categories.Add(cat1);
            Categories.Add(cat2);
            Categories.Add(cat3);
            Authors.Add(author);
            Tasks.Add(task);
            SaveChanges();
        }

        public ToDoRepository(string dbName, bool test=false)
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
}
