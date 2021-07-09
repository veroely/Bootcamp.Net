using Microsoft.EntityFrameworkCore;
using Models;

namespace ToDo.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public ToDoContext() : base() { }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(@"Server=.;Database=BootcampToDo;Trusted_Connection=True;");
        }
    }
}
