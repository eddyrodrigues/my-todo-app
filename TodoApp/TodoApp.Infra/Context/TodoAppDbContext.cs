using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Infra.Map;

namespace TodoApp.Infra.Context;

public class TodoAppDbContext : DbContext
{
  public DbSet<TodoItem> TodoItems { get; set; }
  public DbSet<User> User { get; set; }

  public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options) {}
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new TodoItemMap());
    modelBuilder.ApplyConfiguration(new UserMap());
  }
}