using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly PhotoEvaluatorContext _context;

        public RepositoryBase(PhotoEvaluatorContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetQuery(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (filter is not null)
                query = query.Where(filter);
            if (includes is not null)
                query = includes(query);

            return query;
        }
        public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            return GetQuery(includes: includes);
        }
        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            return GetQuery(filter: filter, includes: includes);
        }
        public T? GetFirstByExpression(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            return GetQuery(filter: filter, includes: includes).FirstOrDefault();
        }
        public T? GetRandomElement(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            return GetQuery(filter: filter, includes: includes).OrderBy(r => Guid.NewGuid()).FirstOrDefault();
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
