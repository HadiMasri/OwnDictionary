using Microsoft.EntityFrameworkCore;
using OwnDictionary.Data;
using OwnDictionary.Models.Entities;
using OwnDictionary.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Repositories.Repositories
{
    public class TermRepository : ITermRepository
    {

        private readonly OwnDictionaryDbContext _dbContext;
        private readonly DbSet<Term> _modelDbSets;

        public TermRepository(OwnDictionaryDbContext dbContext)
        {
            _dbContext = dbContext;
            _modelDbSets = _dbContext.Set<Term>();
        }


        public async Task<Term> GetBookAsync(Expression<Func<Term, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Term>> GetListOfBooksAsync()
        {
            return await _modelDbSets.ToListAsync();

        }
        public async Task<IEnumerable<Term>> GetListOfBooksAsync(Expression<Func<Term, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).ToListAsync();

        }

        public void Add(Term newTerm)
        {
            _modelDbSets.Add(newTerm);
        }

        public void Delete(Guid id)
        {
            var term = _modelDbSets.Find(id);
            _dbContext.Remove(term);
        }
        public void Update(Term theTerm)
        {
            _modelDbSets.Attach(theTerm);
            _dbContext.Entry(theTerm).State = EntityState.Modified;
        }

        public void SaveChangesAsync()
        {
             _dbContext.SaveChangesAsync();
            
        }
    }
}
