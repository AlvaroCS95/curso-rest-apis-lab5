using Microsoft.EntityFrameworkCore;

namespace DotNetWebApi.Entities
{
    // Code-first
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected ToDoDbContext()
        {
        }

        // Tables
        public virtual DbSet<ToDoItem> ToDos { get; set; }
    }
}