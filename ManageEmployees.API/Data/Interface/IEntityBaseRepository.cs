using ManageEmployees.API.Data.Consts;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ManageEmployees.API.Data.Interface
{
    public interface IEntityBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(bool WithNoTracking = true);

        T Add(T entity);

        IQueryable<T> GetQueryable();
        T? GetById(int id);
        T? Find(Expression<Func<T, bool>> predicate);
        T? Find(Expression<Func<T, bool>> predicate, string[]? includes = null);
        T? Find(Expression<Func<T, bool>> predicate,
                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int? skip = null, int? take = null,
            Expression<Func<T, object>>? orderBy = null, string? orderByDirection = OrderBy.Ascending);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>>? orderBy = null, string? orderByDirection = OrderBy.Ascending);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T, object>>? orderBy = null, string? orderByDirection = OrderBy.Ascending);

        IEnumerable<T> AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void DeleteBulk(Expression<Func<T, bool>> predicate);
        bool IsExists(Expression<Func<T, bool>> predicate);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        int Max(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> field);
        void Commit();
    }
}
