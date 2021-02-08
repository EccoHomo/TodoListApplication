using Microsoft.EntityFrameworkCore;
using TodoListApplication.Core.Entities;

namespace TodoListApplication.DataAccess
{
    public class TodoAppContext : DbContext
    {
        public TodoAppContext(DbContextOptions<TodoAppContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoCategory> TodoCategories { get; set; }
    }
}
