using TodoApp.Infra.Commands;

namespace TodoApp.Infra.CommandsRequest;

public class UpdateTodoCommandRequest : ICommand
{
  public UpdateTodoCommandRequest() { }

  public UpdateTodoCommandRequest(Guid id, string title, string description, bool done)
  {
    Id = id;
    Title = title;
    Description = description;
    Done = done;
  }

  public Guid Id { get; set; }  
  public string? Title { get; set; }
  public string? Description { get; set; }
  public bool Done { get; set; }
}