namespace TodoAppLogin.Domain.Entities;

public class User: Entity
{
  public User(string? name, string? email, string? password)
  {
    Name = name;
    Email = email;
    Password = password;
  }

  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; }
  public List<Roles> Roles { get; set; } = new List<Roles>();
}