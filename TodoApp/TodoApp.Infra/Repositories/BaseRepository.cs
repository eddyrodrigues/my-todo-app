using TodoApp.Infra.Context;
using TodoApp.Infra.Repositories.Contracts;

namespace TodoApp.Infra.Repositories;

public class BaseRepository<Entity> : IBaseRepository<Entity>
where Entity : class
{
  protected readonly TodoAppDbContext _context;

  public BaseRepository(TodoAppDbContext context) => _context = context;
  public Entity Add(Entity entity)
  {
      _context.Add(entity);
      if (_context.SaveChanges() > 0)
          return entity;
      else
          throw new System.Exception("Não foi possível adicionar a entidade ao banco de dados - Favor verificar");
  }

  public Entity GetById(int id)
  {
    return _context.Set<Entity>().Find(id);
  }
  public Entity GetById(Guid id)
  {
    return _context.Set<Entity>().Find(id);
  }

  public Entity Update(Entity entity)
  {
      _context.Update(entity);
      if (_context.SaveChanges() > 0)
          return entity;
      else
          throw new System.Exception("Não foi possível atualizar a entidade ao banco de dados - Favor verificar");
  }
}