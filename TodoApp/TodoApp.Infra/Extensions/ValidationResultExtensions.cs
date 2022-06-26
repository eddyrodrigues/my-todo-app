using FluentValidation.Results;
using Flunt.Notifications;

namespace TodoApp.Infra.Extensions;

public static class ValidationResultExtensions
{
  public static IList<Notification> ToFluntNotifications(this ValidationResult validationResult)
  {
    return validationResult.Errors.Select(a => new Notification(a.PropertyName, a.ErrorMessage)).ToList();
  }
  public static IList<string> ToMessages(this ValidationResult validationResult)
  {
    return validationResult.Errors.Select(a => $"{a.PropertyName} - {a.ErrorMessage}").ToList();
  }
}