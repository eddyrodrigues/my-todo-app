using FluentValidation;
using TodoApp.Infra.Commands;

namespace TodoApp.Infra.CommandsRequest;

public class CreateTodoItemCommandRequest : ICommand
{
  public CreateTodoItemCommandRequest() { }
  public CreateTodoItemCommandRequest(string title, string description)
  {
    Title = title;
    Description = description;
    Done = false;
  }
  public CreateTodoItemCommandRequest(string title, string description, bool done)
  {
    Title = title;
    Description = description;
    Done = done;
  }

  public string? Title { get; set; }
  public string? Description { get; set; }
  public bool Done { get; set; }
}