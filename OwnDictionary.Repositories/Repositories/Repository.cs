using Microsoft.EntityFrameworkCore;
using OwnDictionary.Data;
using OwnDictionary.Models;
using OwnDictionary.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Repositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly OwnDictionaryDbContext _dbContext;
        private readonly DbSet<T> _modelDbSets;
        public Repository(OwnDictionaryDbContext dbContext)
        {
            _dbContext = dbContext;
            _modelDbSets = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _modelDbSets.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _modelDbSets.Find(id);
            _dbContext.Remove(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _modelDbSets.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).ToListAsync();
        }

        public  void SaveChangesAsync()
        {
             _dbContext.SaveChangesAsync();
           
        }

        public void Update(T entity)
        {
            try
            {
                _modelDbSets.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
