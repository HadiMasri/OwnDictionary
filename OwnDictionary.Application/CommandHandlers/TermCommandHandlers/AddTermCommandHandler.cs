using MediatR;
using Microsoft.Extensions.Caching.Memory;
using OwnDictionary.Application.Dxos;
using OwnDictionary.Contracts.Commands;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Models.Entities;
using OwnDictionary.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.CommandHandlers
{
    public class AddTermCommandHandler : IRequestHandler<AddTermCommand, TermDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITermDxos _dxos;
        private readonly IMemoryCache _memoryCache;
        public AddTermCommandHandler(IUnitOfWork unitOfWork, ITermDxos dxos, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
            _memoryCache = memoryCache;
        }

        public async Task<TermDto> Handle(AddTermCommand request, CancellationToken cancellationToken)
        {
            Term t = new Term();
            t.Word = request.Word;
            t.Description = request.Description;
            t.LanguageId = request.LanguageId;
            t.Synonyms = request.Synonym;
            t.Examples = request.Examples;
            _unitOfWork.TermRepository.Add(t);
            _unitOfWork.Commit();

            return _dxos.MapTermDto(t); ;
        }
    }
}
