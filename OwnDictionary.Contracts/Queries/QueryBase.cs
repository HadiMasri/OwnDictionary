using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Queries
{
    public class QueryBase<T> : IRequest<T> where T : class
    {
    }
}
