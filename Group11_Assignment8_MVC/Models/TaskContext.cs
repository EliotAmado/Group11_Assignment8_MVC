using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group11_Assignment8_MVC.Models
{
    public class TaskContext : DbContext
    {
        //Constructor
        public TaskContext (DbContextOptions<TaskContext> options) : base (options)
        {
            //Leave blank
        }

        public DbSet<AddTaskResponce> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Home"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Church"
                }
                );

            mb.Entity<AddTaskResponce>().HasData(
                new AddTaskResponce
                {
                    TaskId = 1,
                    Task = "Mission 8",
                    Due_Date = DateTime.ParseExact("24/02/2023", "dd/MM/yyyy", null),
                    Quadrant = 1,
                    Completed = false,
                    CategoryId = 2
                },
                new AddTaskResponce
                {
                    TaskId = 2,
                    Task = "Clean the kitchen",
                    Due_Date = DateTime.ParseExact("25/02/2023", "dd/MM/yyyy", null),
                    Quadrant = 2,
                    Completed = false,
                    CategoryId = 1
                },
                new AddTaskResponce
                {
                    TaskId = 3,
                    Task = "Ministering",
                    Due_Date = DateTime.ParseExact("21/02/2023", "dd/MM/yyyy", null),
                    Quadrant = 3,
                    Completed = false,
                    CategoryId = 4
                },
                new AddTaskResponce
                {
                    TaskId = 4,
                    Task = "Go to work",
                    Due_Date = DateTime.ParseExact("22/02/2023", "dd/MM/yyyy", null),
                    Quadrant = 4,
                    Completed = false,
                    CategoryId = 3
                }
                );
        }
    }
}
