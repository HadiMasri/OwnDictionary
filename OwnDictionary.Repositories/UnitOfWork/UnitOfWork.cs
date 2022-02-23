using OwnDictionary.Data;
using OwnDictionary.Models.Entities;
using OwnDictionary.Repositories.IRepositories;
using OwnDictionary.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OwnDictionaryDbContext _dbContext;
        private IRepository<Term> _termRepository;

        public UnitOfWork(OwnDictionaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IRepository<Term> TermRepository
        {
            get
            {
                return _termRepository = _termRepository ?? new Repository<Term>(_dbContext);
            }
        }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string exf = ex.Message;
                throw;
            }
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }
    }
}
