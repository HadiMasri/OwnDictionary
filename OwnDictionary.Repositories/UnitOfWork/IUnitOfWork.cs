using OwnDictionary.Models.Entities;
using OwnDictionary.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Term> TermRepository { get; }


        void Commit();
        void Rollback();
    }
}
