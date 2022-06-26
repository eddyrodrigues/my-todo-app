using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Infra.Context;
using TodoApp.Infra.Queries;

namespace TodoApp.Infra.Repositories;

public class TodoItemRepository : BaseRepository<TodoItem>
{
  public TodoItemRepository(TodoAppDbContext context) : base(context) { }

  public IList<TodoItem> GetAll(int userId)
  {
    return _context.TodoItems.AsNoTracking().Where(TodoQueries.GetAll(userId)).ToList();
  }
  public IList<TodoItem> GetAllDone(int userId)
  {
    return _context.TodoItems.AsNoTracking().Where(TodoQueries.GetAllDone(userId)).ToList();
  }
  public IList<TodoItem> GetAllUnDone(int userId)
  {
    return _context.TodoItems.AsNoTracking().Where(TodoQueries.GetAllUndone(userId)).ToList();
  }

}

