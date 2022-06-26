using TodoApp.Domain.Entities;
using TodoApp.Infra.Commands;
using TodoApp.Infra.CommandsRequest;
using TodoApp.Infra.CommandsResponse;
using TodoApp.Infra.CommandsValidator;
using TodoApp.Infra.Extensions;
using TodoApp.Infra.Repositories;

namespace TodoApp.Infra.CommandsHandler;

public class TodoItemCommandHandler : ICommandHandler<CreateTodoItemCommandRequest> 
{
  private readonly TodoItemRepository _todoItemRepository;

  public TodoItemCommandHandler(TodoItemRepository todoItemRepository)
  {
    _todoItemRepository = todoItemRepository;
  }
  public ICommandResult handle(CreateTodoItemCommandRequest command)
  {

    var validator = new CreateTodoItemCommandRequestValidator().Validate(command);
    if (validator.IsValid)
    {
      var newTodoItem = new TodoItem(command?.Title, command?.Description, 1, command.Done);
      _todoItemRepository.Add(newTodoItem);

      return new GenericCommandResult(true, "TodoItem Adicionado Com Sucesso", newTodoItem);
    } else {
      return new GenericCommandResult( false, validator.ToMessages(), command);
    }
  }
  public ICommandResult handle(UpdateTodoCommandRequest command)
  {

    var validator = new UpdateTodoCommandRequestValidator().Validate(command);
    if (validator.IsValid)
    {
      var todoItem = _todoItemRepository.GetById(command.Id);
      if (todoItem != null){
        todoItem.UpdateDescription(command.Description);
        todoItem.UpdateDone(command.Done);
        todoItem.UpdateTitle(command.Title);
      } else {
        return new GenericCommandResult( false, "Todo item nao encontrado", command);
      }
      _todoItemRepository.Update(todoItem);
      return new GenericCommandResult(true, "TodoItem Atualizado Com Sucesso", todoItem);
    } else {
      return new GenericCommandResult( false, validator.ToMessages(), command);
    }
  }
}