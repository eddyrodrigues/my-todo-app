using System.Collections.Generic;
using TodoApp.Domain.Entities;

namespace TodoApp.Tests.FakeContext;

public class FakeDbContext
{
  public FakeDbContext()
  {
    var todoItem1 = new TodoItem("title 1", "desc 1", 1, false);
    var todoItem2 = new TodoItem("title 2", "desc 2", 1, false);
    var todoItem3 = new TodoItem("title 3", "desc 3", 1, false);
    var todoItem4 = new TodoItem("title 4", "desc 4", 1, false);
    var todoItem5 = new TodoItem("title 5", "desc 5", 1, false);
    var todoItem6 = new TodoItem("title 6", "desc 6", 1, false);
    var todoItem7 = new TodoItem("title 7", "desc 7", 1, false);
    var todoItem9 = new TodoItem("title 9", "desc 9", 1, false);
    var todoItem99 = new TodoItem("title 99", "desc 99", 1, false);

    TodoItems = new List<TodoItem>();
    TodoItems.Add(todoItem1 );
    TodoItems.Add(todoItem2 );
    TodoItems.Add(todoItem3 );
    TodoItems.Add(todoItem4 );
    TodoItems.Add(todoItem5 );
    TodoItems.Add(todoItem6 );
    TodoItems.Add(todoItem7 );
    TodoItems.Add(todoItem9 );
    TodoItems.Add(todoItem99);
    
  }
  public List<TodoItem> TodoItems { get; set; }

}