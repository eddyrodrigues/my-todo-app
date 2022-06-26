
using TodoAppLogin.Infra.Commands;

namespace TodoApp.Infra.CommandsRequest;

public class CreateTokenCommandRequest : ICommand
{
  public CreateTokenCommandRequest() { }

  public CreateTokenCommandRequest(string email, string password)
  {
    Email = email;
    Password = password;
  }

  public string? Email { get; set; }
  public string? Password { get; set; }
  
  
  
  
}