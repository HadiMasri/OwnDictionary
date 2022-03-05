using OwnDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Repositories.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Delete(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include1 = null, Expression<Func<T, object>> include2 = null);
        Task<IEnumerable<T>> GetListAsync();
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include1 = null, Expression<Func<T, object>> include2 = null);
        void SaveChangesAsync();
        void Update(T entity);
    }
}
