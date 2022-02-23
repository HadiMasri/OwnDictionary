using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Repositories.IRepositories
{
    public interface ITermRepository
    {
        void Add(Term newTerm);
        Task<Term> GetBookAsync(Expression<Func<Term, bool>> predicate);
        Task<IEnumerable<Term>> GetListOfBooksAsync();

        Task<IEnumerable<Term>> GetListOfBooksAsync(Expression<Func<Term, bool>> predicate = null);
        void Delete(Guid id);
        void SaveChangesAsync();
        void Update(Term theTerm);
    }
}
