using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Entities;
using TodoApp.Infra.CommandsHandler;
using TodoApp.Infra.CommandsRequest;
using TodoApp.Infra.CommandsResponse;
using TodoApp.Infra.Repositories;

namespace TodoApp.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TodoItemController : ControllerBase
{
  private readonly TodoItemCommandHandler _todoItemCommandHandler;

  public TodoItemController(TodoItemCommandHandler todoItemCommandHandler)
  {
    _todoItemCommandHandler = todoItemCommandHandler;
  }

  [HttpPost(Name = "v1/TodoItem")]
  public IActionResult Post([FromBody] CreateTodoItemCommandRequest createTodoItemCommandRequest)
  {
    return Ok(_todoItemCommandHandler.handle(createTodoItemCommandRequest));
  }
  [HttpGet]
  [Route("v1/TodoItem")]
  public IActionResult GetAll(
    [FromServices] TodoItemRepository _todoRepository
  )
  {
    return Ok(_todoRepository.GetAll(1));
  }
  [HttpGet]
  [Route("v1/TodoItem/GetAllDone")]
  public IActionResult GetAllDone1(
    [FromServices] TodoItemRepository _todoRepository
  )
  {
    return Ok(_todoRepository.GetAllDone(1));
  }
  [HttpGet]
  [Route("v1/TodoItem/GetAllUndone")]
  public IActionResult GetAllUndone(
    [FromServices] TodoItemRepository _todoRepository
  )
  {
    return Ok(_todoRepository.GetAllUnDone(1));
  }

  [HttpPut(Name = "v1/TodoItem/Atualizar")]
  public IActionResult Put(UpdateTodoCommandRequest updateTodoCommandRequest)
  {
    return Ok(_todoItemCommandHandler.handle(updateTodoCommandRequest));
  }
  

}
