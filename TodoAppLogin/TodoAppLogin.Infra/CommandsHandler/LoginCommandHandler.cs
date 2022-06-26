using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using TodoApp.Infra.CommandsRequest;
using TodoApp.Infra.CommandsResponse;
using TodoAppLogin.Domain.Entities;
using TodoAppLogin.Infra.Commands;
using TodoAppLogin.Infra.CommandsValidator;
using TodoAppLogin.Infra.Repositories;
using TodoAppLogin.Web.Services;

namespace TodoApp.Infra.CommandsHandler;

public class LoginCommandHandler : ICommandHandler<CreateTokenCommandRequest>
{
  private readonly UserRepository _userRepository;

  public LoginCommandHandler(UserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public ICommandResult handle(CreateTokenCommandRequest command)
  {
    var validator = new CreateTokenCommandRequestValidator().Validate(command);
    if (validator.IsValid)
    {
      var user = _userRepository.GetByEmail(command.Email);
      if (user != null)
      {
        if (PasswordHasher.Verify(user.Password ?? "", command.Password))
          return new GenericCommandResult(true, "Token gerado com sucesso", TokenService.GenerateToken(user));
        return new GenericCommandResult(false, "Usuário ou senhas incorretos", null);
      } else {
        return new GenericCommandResult(false, "Usuário ou senhas incorretos", null);
      }
    }
    else
    {
      return new GenericCommandResult(false, "Usuário ou senhas incorretos", null);
    }
  }
  public ICommandResult handle(CreateUserCommandRequest command)
  {
    var validator = new CreateUserCommandRequestValidator().Validate(command);
    if (validator.IsValid)
    {
      var user = new User(
        command.Name,
        command.Email,
        PasswordHasher.Hash(command.Password)
      );
      try{
        _userRepository.Add(user);
      }catch
      {
        return new GenericCommandResult(false, "Não foi possível criar o usuário, favor verificar os dados e tentar novamente", null);
      }
      if (user.Id > 0)
      {
        return new GenericCommandResult(true, "Usuário criado com sucesso!", new User(
          user.Name,
          user.Email,
          ""
        ));
      } else {
        return new GenericCommandResult(false, "Não foi possível criar o usuário, favor verificar os dados e tentar novamente", null);
      }
    }
    else
    {
      return new GenericCommandResult(false, "Não foi possível criar o usuário, favor verificar os dados e tentar novamente", null);
    }
  }
}