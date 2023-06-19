using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        IQueryable<T> GetByExpression(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        T? GetFirstByExpression(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        IQueryable<T> GetQuery(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        T? GetRandomElement(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        void Save();
        Task SaveAsync();
        void Update(T entity);
    }
}