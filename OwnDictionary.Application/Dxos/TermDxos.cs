using AutoMapper;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.Dxos
{
    public class TermDxos : ITermDxos
    {
        private readonly IMapper _mapper;

        public TermDxos()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Term, TermDto>();
            });
            _mapper = config.CreateMapper();
        }
        public TermDto MapTermDto(Term term)
        {
            return _mapper.Map<Term, TermDto>(term);
        }
        public List<TermDto> MapTermDtos(IEnumerable<Term> term)
        {
            return _mapper.Map<List<TermDto>>(term);
        }
    }
}
