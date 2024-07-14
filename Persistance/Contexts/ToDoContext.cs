using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Configurations;
using Task = Domain.Entities.Task;

namespace Persistance.Contexts
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options) : base(options) 
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());


        }
    }
}
