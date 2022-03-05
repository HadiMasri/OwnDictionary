using OwnDictionary.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Queries
{
    public class GetTermQuery : QueryBase<TermDto>
    {
        public Guid Id { get; set; }
    }
}
