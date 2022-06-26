using FluentValidation;
using TodoApp.Infra.CommandsRequest;

namespace TodoApp.Infra.CommandsValidator;

public class UpdateTodoCommandRequestValidator : AbstractValidator<UpdateTodoCommandRequest>
{
  public UpdateTodoCommandRequestValidator()
  {
    RuleFor(o => o.Id).NotNull().WithMessage("Id should have between 1 and 36 chars");
    RuleFor(o => o.Description).NotNull().Length(1, 400).WithMessage("Description should have between 1 and 400 chars");
    RuleFor(o => o.Title).NotNull().Length(1, 200).WithMessage("Description should hava between 1 and 200 chars");
    RuleFor(o => o.Done).NotNull().WithMessage("Done options should be true or false");
  }
}