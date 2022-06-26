
using TodoAppLogin.Infra.Commands;

namespace TodoApp.Infra.CommandsRequest;

public class CreateUserCommandRequest : ICommand
{
  public CreateUserCommandRequest() { }

  public CreateUserCommandRequest(string email, string password)
  {
    Email = email;
    Password = password;
  }
  public CreateUserCommandRequest(string email, string password, string name)
  {
    Email = email;
    Password = password;
    Name = name;
  }

  public string? Email { get; set; }
  public string? Password { get; set; }
  public string? Name { get; set; }
  
  
  
  
  
  
}