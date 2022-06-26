namespace TodoApp.Infra.Repositories.Contracts;

public interface IBaseRepository<T>
{

    public T Add(T entity);

    public T Update(T entity);

    public T GetById(int id);
}