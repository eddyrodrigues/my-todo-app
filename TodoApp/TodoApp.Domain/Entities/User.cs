namespace TodoApp.Domain.Entities;

public class User: Entity
{
  public int Id { get; set; }
  public string Name { get; set; }
  public IList<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}