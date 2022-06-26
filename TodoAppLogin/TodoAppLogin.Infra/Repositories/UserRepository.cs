using TodoAppLogin.Domain.Entities;
using TodoAppLogin.Infra.Context;

namespace TodoAppLogin.Infra.Repositories;

public class UserRepository
{
  private readonly UserDbContext _context;

  public UserRepository(UserDbContext _context)
  {
    this._context = _context;
  }

  public User GetById(Guid id)
  {
    return _context.User.Find(id);
  }

  public User GetByEmail(string email)
  {
    var user =_context.User.Where(u => u.Email == email).FirstOrDefault();
    return user;
  }
  public User Add(User user)
  {
    _context.Add(user);
    _context.SaveChanges();
    return user;
  }
}