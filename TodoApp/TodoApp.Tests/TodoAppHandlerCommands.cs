using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Infra.CommandsHandler;
using TodoApp.Infra.CommandsRequest;
using TodoApp.Infra.CommandsValidator;
using TodoApp.Infra.Repositories;
using TodoApp.Tests.FakeContext;
using TodoApp.Tests.FakeRepos;

namespace TodoApp.Tests;

[TestClass]
public class TodoAppHandlerCommands
{
  private readonly CreateTodoItemCommandRequest createTodoItemCommandRequest_invalid = new CreateTodoItemCommandRequest("", "", false);
  private readonly CreateTodoItemCommandRequest createTodoItemCommandRequest_valid = new CreateTodoItemCommandRequest("asdad", "asdasd");
  private readonly CreateTodoItemCommandRequest createTodoItemCommandRequest_valid2 = new CreateTodoItemCommandRequest("asdad", "asdasd", true);
  private readonly UpdateTodoCommandRequest updateTodoItemCommandRequest_valid = new UpdateTodoCommandRequest(System.Guid.Empty, "askodkaskd", "iasdijasidj", false);
  private readonly UpdateTodoCommandRequest updateTodoItemCommandRequest_invalid = new UpdateTodoCommandRequest();

  [TestMethod]
  public void create_todo_item_command_valid()
  {
    Assert.AreEqual( new CreateTodoItemCommandRequestValidator().Validate(createTodoItemCommandRequest_valid).IsValid, true);
  }
  
  [TestMethod]
  public void create_todo_item_command_valid2()
  {
    Assert.AreEqual(new CreateTodoItemCommandRequestValidator().Validate(createTodoItemCommandRequest_valid2).IsValid, true);
  }
  [TestMethod]
  public void create_todo_item_command_invalid()
  {
    Assert.AreEqual(new CreateTodoItemCommandRequestValidator().Validate(createTodoItemCommandRequest_invalid).IsValid, false);
  }
  
  [TestMethod]
  public void shows_updateTodoItemCommandRequest_valid()
  {
    Assert.AreEqual(new UpdateTodoCommandRequestValidator().Validate(updateTodoItemCommandRequest_valid).IsValid, true);
  }
  [TestMethod]
  public void shows_updateTodoItemCommandRequest_invalid()
  {
    Assert.AreEqual(new UpdateTodoCommandRequestValidator().Validate(updateTodoItemCommandRequest_invalid).IsValid, false);
  }


  
}