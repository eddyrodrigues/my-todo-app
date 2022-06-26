namespace TodoApp.Domain.Entities;

public class TodoItem : Entity
{
  public TodoItem(string title, string description, int userId)
  {
    Title = title;
    Description = description;
    UserId = userId;
  }
  public TodoItem(string title, string description, int userId, bool done)
  {
    Title = title;
    Description = description;
    UserId = userId;
    Done = done;
  }

  public string Title { get; private set; }
  public string Description { get; private set; }
  public int UserId { get; private set; }
  public bool Done { get; private set; }
  public User User { get; private set; }

  public void UpdateDescription(string description) => Description = description;
  public void UpdateTitle(string title) => Title = title;
  public void UpdateDone(bool situ) => Done = situ;
}