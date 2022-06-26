using System.Linq.Expressions;
using TodoApp.Domain.Entities;

namespace TodoApp.Infra.Queries;
public static class TodoQueries
{
    public static Expression<Func<TodoItem, bool>> GetAll(int userId)
    {
        return x => x.UserId == userId;
    }
    public static Func<TodoItem, bool> GetAll2(int userId)
    {
        return x => x.UserId == userId;
    }

    public static Expression<Func<TodoItem, bool>> GetAllDone(int userId)
    {
        return x => x.UserId == userId && x.Done == true;
    }
    public static Func<TodoItem, bool> GetAllDone2(int userId)
    {
        return x => x.UserId == userId && x.Done == true;
    }

    public static Expression<Func<TodoItem, bool>> GetAllUndone(int userId)
    {
        return x => x.UserId == userId && x.Done == false;
    }
    public static Func<TodoItem, bool> GetAllUndone2(int userId)
    {
        return x => x.UserId == userId && x.Done == false;
    }

}
