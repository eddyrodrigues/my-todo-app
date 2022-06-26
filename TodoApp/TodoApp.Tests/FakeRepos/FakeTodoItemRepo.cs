using System.Collections.Generic;
using System.Linq;
using TodoApp.Domain.Entities;
using TodoApp.Infra.Queries;
using TodoApp.Tests.FakeContext;

namespace TodoApp.Tests.FakeRepos;

public class FakeTodoItemRepo {
  public IList<TodoItem> GetAll(int userId)
  {
    return new FakeDbContext().TodoItems.Where(TodoQueries.GetAll2(userId)).ToList();
  }
  public IList<TodoItem> GetAllDone(int userId)
  {
    return new FakeDbContext().TodoItems.Where(TodoQueries.GetAllDone2(userId)).ToList();
  }
  public IList<TodoItem> GetAllUnDone(int userId)
  {
    return new FakeDbContext().TodoItems.Where(TodoQueries.GetAllUndone2(userId)).ToList();
  }
}