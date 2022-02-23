using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.Dxos
{
    public interface ITermDxos
    {
        TermDto MapTermDto(Term term);
        List<TermDto> MapTermDtos(IEnumerable<Term> terms);
    }
}
